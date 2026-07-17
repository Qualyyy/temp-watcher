using LibreHardwareMonitor.Hardware;
using Temp_Watcher;


HardwareMonitor monitor = new HardwareMonitor();

while (true)
{
    PCStats stats = monitor.GetStats();

    Console.WriteLine(stats.ToJson());

    Thread.Sleep(500);
}