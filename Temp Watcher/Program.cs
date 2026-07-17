using Temp_Watcher.Core;


HardwareMonitor monitor = new HardwareMonitor();

while (true)
{
    PCStats stats = monitor.GetStats();

    Console.WriteLine(stats.ToJson());

    Thread.Sleep(1000);
}