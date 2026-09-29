using LibreHardwareMonitor.Hardware;
using Temp_Watcher.Core;

namespace Temp_Watcher.App
{
    public partial class SensorSelectionForm : Form
    {

        public SensorInfo? SelectedCpuSensor { get; private set; }
        public SensorInfo? SelectedGpuSensor { get; private set; }


        public SensorSelectionForm(HardwareMonitor monitor)
        {
            InitializeComponent();

            cmbCpuSensor.DataSource = monitor.CpuTemperatureSensors;
            cmbCpuSensor.DisplayMember = nameof(ISensor.Name);

            if (monitor.CpuTemperatureSensors.Count == 0)
            {
                cmbCpuSensor.Enabled = false;
                lblCpu.Text = "CPU temperature sensor (unavailable)";
            }

            cmbGpuSensor.DataSource = monitor.GpuTemperatureSensors;
            cmbGpuSensor.DisplayMember = nameof(ISensor.Name);

            if (monitor.GpuTemperatureSensors.Count == 0)
            {
                cmbGpuSensor.Enabled = false;
                lblGpu.Text = "GPU temperature sensor (unavailable)";
            }

            cmbCpuSensor.SelectedItem =
                monitor.CpuTemperatureSensors
                    .FirstOrDefault(sensor => sensor.Id == monitor.CpuTemperatureSensor?.Identifier.ToString())
                ?? monitor.CpuTemperatureSensors.FirstOrDefault();
            cmbGpuSensor.SelectedItem =
                monitor.GpuTemperatureSensors
                    .FirstOrDefault(sensor => sensor.Id == monitor.GpuTemperatureSensor?.Identifier.ToString())
                ?? monitor.GpuTemperatureSensors.FirstOrDefault();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedCpuSensor = cmbCpuSensor.SelectedItem as SensorInfo;
            SelectedGpuSensor = cmbGpuSensor.SelectedItem as SensorInfo;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
