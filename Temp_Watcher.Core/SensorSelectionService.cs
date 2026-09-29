using LibreHardwareMonitor.Hardware;
using static System.Collections.Specialized.BitVector32;

namespace Temp_Watcher.Core
{
    public class SensorSelectionService
    {
        private readonly HardwareMonitor monitor;
        private readonly SensorSettingsStore settingsStore;

        public SensorSelection Selection { get; private set; }

        public SensorSelectionService(
            HardwareMonitor monitor,
            SensorSettingsStore settingsStore)
        {
            this.monitor = monitor;
            this.settingsStore = settingsStore;

            Selection = new SensorSelection(null, null);
        }

        public void ApplyAndSave(SensorSelection selection)
        {
            Selection = selection;

            settingsStore.Save(new SensorSettings
            {
                CpuSensorId = selection.CpuSensorId,
                GpuSensorId = selection.GpuSensorId
            });
        }

        public void Load()
        {
            SensorSettings? settings = settingsStore.Load();

            if (settings == null)
                return;

            Selection = new SensorSelection(
                settings.CpuSensorId,
                settings.GpuSensorId);

            if (Selection.CpuSensorId != null)
                monitor.SelectCpuSensor(Selection.CpuSensorId);

            if (Selection.GpuSensorId != null)
                monitor.SelectGpuSensor(Selection.GpuSensorId);
        }
    }
}