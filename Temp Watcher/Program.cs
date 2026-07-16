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
            stats.CPUTemperature = GetCPUTemp(hardware);
            break;

        case HardwareType.GpuNvidia:
            stats.GPUTemperature = GetGPUTemp(hardware);
            break;
    }
}

Console.Write(stats.ToJson());

float GetCPUTemp(IHardware hardware)
{
    foreach (ISensor sensor in hardware.Sensors)
    {
        if (sensor.Value != null
            && sensor.SensorType == SensorType.Temperature
            && sensor.Name.Contains("Max"))
        {
            return (float)sensor.Value;
        }
    }

    return -1;
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

    return -1;
}