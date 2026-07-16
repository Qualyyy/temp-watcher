using LibreHardwareMonitor.Hardware;
using Temp_Watcher;

Computer computer = new Computer
{
    IsCpuEnabled = true,
    IsGpuEnabled = true
};

computer.Open();

PCStats stats = new PCStats();

foreach (IHardware hardware in computer.Hardware)
{
    hardware.Update();

    switch (hardware.HardwareType)
    {
        case HardwareType.Cpu:
            float CPUTemp = GetCPUTemp(hardware);
            Console.WriteLine($"CPU: {CPUTemp}°C");
            stats.CPUTemperature = CPUTemp;
            break;

        case HardwareType.GpuNvidia:
            float GPUTemp = GetGPUTemp(hardware);
            Console.WriteLine($"GPU: {GPUTemp}°C");
            stats.GPUTemperature = GPUTemp;
            break;
    }

    Console.WriteLine();
}

float GetCPUTemp(IHardware hardware)
{
    foreach (ISensor sensor in hardware.Sensors)
    {
        if (sensor.Value != null
            && sensor.SensorType == SensorType.Temperature
            && sensor.Name.Contains("Average"))
        {
            return (float)sensor.Value;
        }
    }

    throw new Exception("CPU temp not found");
}

float GetGPUTemp(IHardware hardware)
{
    foreach (ISensor sensor in hardware.Sensors)
    {
        if (sensor.Value != null
            && sensor.SensorType == SensorType.Temperature
            && sensor.Name.Contains("Core"))
        {
            return (float)sensor.Value;
        }
    }

    throw new Exception("GPU temp not found");
}