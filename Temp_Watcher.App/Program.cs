using Temp_Watcher.Api;
using Temp_Watcher.App;
using Temp_Watcher.Core;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:5208");

HardwareMonitor monitor = new HardwareMonitor();

SensorSettingsStore settingsStore = new SensorSettingsStore();
ApplySavedSensorSettings(monitor, settingsStore);
SelectSensorsIfNeeded(monitor, settingsStore);

var app = builder.Build();

app.MapGet("/stats", () => monitor.GetStats());

await app.StartAsync();

Application.SetHighDpiMode(HighDpiMode.SystemAware);
Application.EnableVisualStyles();
Application.SetCompatibleTextRenderingDefault(false);

var trayContext = new TrayApplicationContext(
    () => app.StopAsync(),
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
    SensorSettingsStore settingsStore)
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
        if (form.SelectedCpuSensor != null)
            monitor.SelectCpuSensor(form.SelectedCpuSensor.Identifier.ToString());

        if (form.SelectedGpuSensor != null)
            monitor.SelectGpuSensor(form.SelectedGpuSensor.Identifier.ToString());

        settingsStore.Save(new SensorSettings
        {
            CpuSensorId = form.SelectedCpuSensor?.Identifier.ToString(),
            GpuSensorId = form.SelectedGpuSensor?.Identifier.ToString()
        });
    }
}