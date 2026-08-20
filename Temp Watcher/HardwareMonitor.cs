using LibreHardwareMonitor.Hardware;

namespace Temp_Watcher.Core
{
    public class HardwareMonitor
    {
        private Computer computer;
        private List<IHardware> monitoredHardware;
        public ISensor CpuTemperatureSensor { get; private set; }
        public ISensor GpuTemperatureSensor { get; private set; }

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
                        CpuTemperatureSensor = GetSensor(hardware, "Max");
                        break;

                    case HardwareType.GpuNvidia:
                        monitoredHardware.Add(hardware);
                        GpuTemperatureSensor = GetSensor(hardware, "Core");
                        break;
                }
            }
        }

        public PCStats GetStats()
        {
            PCStats stats = new PCStats();

            UpdateHardware();
            stats.CPUTemperature = CpuTemperatureSensor.Value ?? -1;
            stats.GPUTemperature = GpuTemperatureSensor.Value ?? -1;

            return stats;
        }

        private ISensor GetSensor(IHardware hardware, string nameContains)
        {
            foreach (ISensor sensor in hardware.Sensors)
            {
                if (sensor.SensorType == SensorType.Temperature
                    && sensor.Name.Contains(nameContains)
                    )
                    return sensor;
            }
            throw new Exception($"Sensor for {hardware.Name} not found.");
        }

        private void UpdateHardware()
        {
            foreach (IHardware hardware in monitoredHardware)
                hardware.Update();
        }
    }
}
