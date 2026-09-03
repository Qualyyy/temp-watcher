using LibreHardwareMonitor.Hardware;

namespace Temp_Watcher.Core
{
    public class SensorSelectionService
    {
        private readonly HardwareMonitor monitor;
        private readonly SensorSettingsStore settingsStore;

        public SensorSelectionService(
            HardwareMonitor monitor,
            SensorSettingsStore settingsStore)
        {
            this.monitor = monitor;
            this.settingsStore = settingsStore;
        }

        public void ApplyAndSave(ISensor? cpuSensor, ISensor? gpuSensor)
        {
            if (cpuSensor != null)
                monitor.SelectCpuSensor(cpuSensor.Identifier.ToString());

            if (gpuSensor != null)
                monitor.SelectGpuSensor(gpuSensor.Identifier.ToString());

            settingsStore.Save(new SensorSettings
            {
                CpuSensorId = cpuSensor?.Identifier.ToString(),
                GpuSensorId = gpuSensor?.Identifier.ToString()
            });
        }
    }
}