using BlackSharp.Core.Extensions;
using LibreHardwareMonitor.Hardware;

namespace Temp_Watcher.Core
{
    public class HardwareMonitor
    {
        private readonly Computer computer;
        private readonly List<IHardware> monitoredHardware;

        private readonly List<ISensor> cpuTemperatureSensors = [];
        private readonly List<ISensor> gpuTemperatureSensors = [];

        public ISensor? CpuTemperatureSensor { get; private set; }
        public ISensor? GpuTemperatureSensor { get; private set; }

        public IReadOnlyList<SensorInfo> CpuTemperatureSensors { get; private set; } = [];
        public IReadOnlyList<SensorInfo> GpuTemperatureSensors { get; private set; } = [];




        public HardwareMonitor()
        {
            computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true
            };

            monitoredHardware = new List<IHardware>();

            Initialize();
        }

        private void Initialize()
        {
            computer.Open();

            foreach (IHardware hardware in computer.Hardware)
            {
                AddHardware(hardware);
            }

            CpuTemperatureSensors = cpuTemperatureSensors
                .Select(ToSensorInfo)
                .ToList();

            GpuTemperatureSensors = gpuTemperatureSensors
                .Select(ToSensorInfo)
                .ToList();
        }

        private void AddHardware(IHardware hardware)
        {
            switch (hardware.HardwareType)
            {
                case HardwareType.Cpu:
                    monitoredHardware.Add(hardware);
                    cpuTemperatureSensors.AddRange(GetTemperatureSensors(hardware));
                    break;

                case HardwareType.GpuNvidia:
                case HardwareType.GpuAmd:
                case HardwareType.GpuIntel:
                    monitoredHardware.Add(hardware);
                    gpuTemperatureSensors.AddRange(GetTemperatureSensors(hardware));
                    break;
            }
        }

        public PCStats GetStats()
        {
            UpdateHardware();

            PCStats stats = new PCStats
            {
                CPUTemperature = CpuTemperatureSensor?.Value ?? -1,
                GPUTemperature = GpuTemperatureSensor?.Value ?? -1
            };

            return stats;
        }

        private static List<ISensor> GetTemperatureSensors(IHardware hardware)
        {
            return hardware.Sensors
                .Where(sensor => sensor.SensorType == SensorType.Temperature)
                .ToList();
        }

        private static SensorInfo ToSensorInfo(ISensor sensor)
        {
            return new SensorInfo(
                sensor.Identifier.ToString(),
                sensor.Name);
        }

        public bool SelectCpuSensor(string sensorId)
        {
            ISensor? sensor = cpuTemperatureSensors
                .FirstOrDefault(sensor => sensor.Identifier.ToString() == sensorId);

            if (sensor == null)
                return false;

            CpuTemperatureSensor = sensor;
            return true;
        }

        public bool SelectGpuSensor(string sensorId)
        {
            ISensor? sensor = gpuTemperatureSensors
                .FirstOrDefault(sensor => sensor.Identifier.ToString() == sensorId);

            if (sensor == null)
                return false;

            GpuTemperatureSensor = sensor;
            return true;
        }

        private void UpdateHardware()
        {
            foreach (IHardware hardware in monitoredHardware)
                hardware.Update();
        }
    }
}