using System.Text.Json;
using Temp_Watcher.Core;


HardwareMonitor monitor = new HardwareMonitor();

while (true)
{
    PCStats stats = monitor.GetStats();

    Console.WriteLine(JsonSerializer.Serialize(stats));

    Thread.Sleep(1000);
}