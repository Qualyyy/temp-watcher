using Temp_Watcher.App;
using Temp_Watcher.Core;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5208");

Application.SetHighDpiMode(HighDpiMode.SystemAware);
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

HardwareMonitor monitor = new HardwareMonitor();

SensorSettingsStore settingsStore = new SensorSettingsStore();
SensorSelectionService selectionService =
    new SensorSelectionService(monitor, settingsStore);

ApplySavedSensorSettings(monitor, settingsStore);
SelectSensorsIfNeeded(monitor, selectionService);

var app = builder.Build();

app.MapGet("/stats", () => monitor.GetStats());

await app.StartAsync();

var trayContext = new TrayApplicationContext(
    monitor: monitor,
    settingsStore: settingsStore,
    onExit: () => app.StopAsync(),
    port: 5208
);

Application.Run(trayContext);


static void ApplySavedSensorSettings(
    HardwareMonitor monitor,
    SensorSettingsStore settingsStore)
{
    SensorSettings? settings = settingsStore.Load();

    if (settings != null)
    {
        if (settings.CpuSensorId != null)
            monitor.SelectCpuSensor(settings.CpuSensorId);

        if (settings.GpuSensorId != null)
            monitor.SelectGpuSensor(settings.GpuSensorId);
    }
}

static void SelectSensorsIfNeeded(
    HardwareMonitor monitor,
    SensorSelectionService selectionService)
{
    bool cpuNeedsSelection =
        monitor.CpuTemperatureSensors.Count > 0 &&
        monitor.CpuTemperatureSensor == null;

    bool gpuNeedsSelection =
        monitor.GpuTemperatureSensors.Count > 0 &&
        monitor.GpuTemperatureSensor == null;

    if (!cpuNeedsSelection && !gpuNeedsSelection)
        return;

    using SensorSelectionForm form = new SensorSelectionForm(monitor);

    if (form.ShowDialog() == DialogResult.OK)
    {
        selectionService.ApplyAndSave(
            form.SelectedCpuSensor,
            form.SelectedGpuSensor);
    }
}