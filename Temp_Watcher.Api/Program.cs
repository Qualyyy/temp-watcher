using Temp_Watcher.Api;
using Temp_Watcher.Core;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5208");

HardwareMonitor monitor = new HardwareMonitor();

var app = builder.Build();

app.MapGet("/stats", () => monitor.GetStats());

await app.StartAsync();

Application.SetHighDpiMode(HighDpiMode.SystemAware);
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

var trayContext = new TrayApplicationContext(
    () => app.StopAsync(),
    port: 5208);

Application.Run(trayContext);