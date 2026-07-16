using LibreHardwareMonitor.Hardware;
using Temp_Watcher;

Computer computer = new Computer
{
    IsCpuEnabled = true,
    IsGpuEnabled = true
};

computer.Open();

while (true)
{

    HardwareMonitor monitor = new HardwareMonitor();

    PCStats stats = monitor.getStats();

    Console.WriteLine(stats.ToJson());

    Thread.Sleep(1000);
}