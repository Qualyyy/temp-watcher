using Temp_Watcher.Api;
using Temp_Watcher.Core;

var builder = WebApplication.CreateBuilder(args);
HardwareMonitor monitor = new HardwareMonitor();

var app = builder.Build();

app.MapGet("/stats", () => monitor.GetStats());

await app.StartAsync(); // non-blocking so WinForms can take over the message loop

Application.SetHighDpiMode(HighDpiMode.SystemAware);
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

var trayContext = new TrayApplicationContext(() => app.StopAsync(), port: 5208);
Application.Run(trayContext);