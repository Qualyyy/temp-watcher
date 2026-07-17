using Temp_Watcher.Core;

var builder = WebApplication.CreateBuilder(args);
HardwareMonitor monitor = new HardwareMonitor();

var app = builder.Build();

app.MapGet("/stats", () => monitor.GetStats());

app.Run();
