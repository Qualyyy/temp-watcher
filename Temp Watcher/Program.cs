using LibreHardwareMonitor.Hardware;

Computer computer = new Computer
{
    IsCpuEnabled = true,
    IsGpuEnabled = true
};

computer.Open();

foreach (IHardware hardware in computer.Hardware)
{
    Console.WriteLine($"Hardware: {hardware.Name}");

    hardware.Update();

    foreach (ISensor sensor in hardware.Sensors)
    {
        if (sensor.SensorType == SensorType.Temperature)
        {
            Console.WriteLine($"{sensor.Name}: {sensor.Value}°C");
        }
    }

    Console.WriteLine();
}