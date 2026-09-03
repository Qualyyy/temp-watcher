namespace Temp_Watcher.App
{
    partial class SensorSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCpu = new Label();
            cmbCpuSensor = new ComboBox();
            cmbGpuSensor = new ComboBox();
            lblGpu = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblCpu
            // 
            lblCpu.AutoSize = true;
            lblCpu.Location = new Point(221, 22);
            lblCpu.Name = "lblCpu";
            lblCpu.Size = new Size(82, 20);
            lblCpu.TabIndex = 0;
            lblCpu.Text = "CPU sensor";
            // 
            // cmbCpuSensor
            // 
            cmbCpuSensor.FormattingEnabled = true;
            cmbCpuSensor.Location = new Point(221, 89);
            cmbCpuSensor.Name = "cmbCpuSensor";
            cmbCpuSensor.Size = new Size(151, 28);
            cmbCpuSensor.TabIndex = 1;
            // 
            // cmbGpuSensor
            // 
            cmbGpuSensor.FormattingEnabled = true;
            cmbGpuSensor.Location = new Point(221, 231);
            cmbGpuSensor.Name = "cmbGpuSensor";
            cmbGpuSensor.Size = new Size(151, 28);
            cmbGpuSensor.TabIndex = 3;
            // 
            // lblGpu
            // 
            lblGpu.AutoSize = true;
            lblGpu.Location = new Point(221, 175);
            lblGpu.Name = "lblGpu";
            lblGpu.Size = new Size(83, 20);
            lblGpu.TabIndex = 2;
            lblGpu.Text = "GPU sensor";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(508, 344);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(299, 344);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SensorSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbGpuSensor);
            Controls.Add(lblGpu);
            Controls.Add(cmbCpuSensor);
            Controls.Add(lblCpu);
            Name = "SensorSelectionForm";
            Text = "SensorSelectionForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCpu;
        private ComboBox cmbCpuSensor;
        private ComboBox cmbGpuSensor;
        private Label lblGpu;
        private Button btnSave;
        private Button btnCancel;
    }
}