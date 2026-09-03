using LibreHardwareMonitor.Hardware;
using Temp_Watcher.Core;

namespace Temp_Watcher.App
{
    public partial class SensorSelectionForm : Form
    {

        public ISensor? SelectedCpuSensor { get; private set; }
        public ISensor? SelectedGpuSensor { get; private set; }


        public SensorSelectionForm(HardwareMonitor monitor)
        {
            InitializeComponent();

            cmbCpuSensor.DataSource = monitor.CpuTemperatureSensors;
            cmbCpuSensor.DisplayMember = nameof(ISensor.Name);

            if (monitor.CpuTemperatureSensors.Count == 0)
            {
                cmbCpuSensor.Enabled = false;
                lblCpu.Text = "CPU sensor (unavailable)";
            }

            cmbGpuSensor.DataSource = monitor.GpuTemperatureSensors;
            cmbGpuSensor.DisplayMember = nameof(ISensor.Name);

            if (monitor.GpuTemperatureSensors.Count == 0)
            {
                cmbGpuSensor.Enabled = false;
                lblGpu.Text = "GPU sensor (unavailable)";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SelectedCpuSensor = cmbCpuSensor.SelectedItem as ISensor;
            SelectedGpuSensor = cmbGpuSensor.SelectedItem as ISensor;

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
