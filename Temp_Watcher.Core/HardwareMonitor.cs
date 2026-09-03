using BlackSharp.Core.Extensions;
using LibreHardwareMonitor.Hardware;

namespace Temp_Watcher.Core
{
    public class HardwareMonitor
    {
        private readonly Computer computer;
        private readonly List<IHardware> monitoredHardware;

        public ISensor? CpuTemperatureSensor { get; private set; }
        public ISensor? GpuTemperatureSensor { get; private set; }

        public List<ISensor> CpuTemperatureSensors { get; } = [];
        public List<ISensor> GpuTemperatureSensors { get; } = [];


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
                switch (hardware.HardwareType)
                {
                    case HardwareType.Cpu:
                        monitoredHardware.Add(hardware);
                        CpuTemperatureSensors.AddRange(GetTemperatureSensors(hardware));
                        break;

                    case HardwareType.GpuNvidia:
                    case HardwareType.GpuAmd:
                    case HardwareType.GpuIntel:
                        monitoredHardware.Add(hardware);
                        GpuTemperatureSensors.AddRange(GetTemperatureSensors(hardware));
                        break;
                }
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

        private void UpdateHardware()
        {
            foreach (IHardware hardware in monitoredHardware)
                hardware.Update();
        }
    }
}