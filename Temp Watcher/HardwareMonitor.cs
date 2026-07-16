using LibreHardwareMonitor.Hardware;

namespace Temp_Watcher
{
    internal class HardwareMonitor
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

        public PCStats getStats()
        {
            PCStats stats = new PCStats();

            UpdateHardware();
            stats.CPUTemperature = (float)CpuTemperatureSensor.Value;
            stats.GPUTemperature = (float)GpuTemperatureSensor.Value;

            return stats;
        }

        private ISensor GetSensor(IHardware hardware, string selector)
        {
            foreach (ISensor sensor in hardware.Sensors)
            {
                if (sensor.SensorType == SensorType.Temperature
                    && sensor.Name.Contains(selector)
                    )
                    return sensor;
            }
            return null;
        }

        private void UpdateHardware()
        {
            foreach (IHardware hardware in monitoredHardware)
                hardware.Update();
        }
    }
}
