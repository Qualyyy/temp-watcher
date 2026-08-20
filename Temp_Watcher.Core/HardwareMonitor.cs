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

        private static readonly string[] CpuTemperatureSensors =
        {
            "Core Max",
            "CCDs Max (Tdie)",
            "CPU (Tctl/Tdie)",
            "Core (Tctl/Tdie)",
            "Core (Tdie)",
            "Core (Tctl)",
            "CPU Package",
            "Core Average"
        };

        private static readonly string[] GpuTemperatureSensors =
        {
            "GPU Hot Spot",
            "GPU Core",
            "GPU Temperature"
        };

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
                        CpuTemperatureSensor = GetTemperatureSensor(hardware, CpuTemperatureSensors);
                        break;

                    case HardwareType.GpuNvidia:
                    case HardwareType.GpuAmd:
                    case HardwareType.GpuIntel:
                        monitoredHardware.Add(hardware);
                        GpuTemperatureSensor ??= GetTemperatureSensor(hardware, GpuTemperatureSensors);
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

        private ISensor? GetTemperatureSensor(IHardware hardware, string[] nameContains)
        {
            foreach (string s in nameContains)
            {
                foreach (ISensor sensor in hardware.Sensors)
                {
                    if (sensor.SensorType == SensorType.Temperature
                        && sensor.Name.Contains(s, StringComparison.OrdinalIgnoreCase))

                        return sensor;
                }
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