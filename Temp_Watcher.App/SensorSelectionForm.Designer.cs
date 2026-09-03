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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblCpu
            // 
            lblCpu.AutoSize = true;
            lblCpu.Dock = DockStyle.Fill;
            lblCpu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCpu.Location = new Point(12, 12);
            lblCpu.Margin = new Padding(0, 0, 0, 4);
            lblCpu.Name = "lblCpu";
            lblCpu.Size = new Size(358, 20);
            lblCpu.TabIndex = 0;
            lblCpu.Text = "CPU temperature sensor";
            lblCpu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbCpuSensor
            // 
            cmbCpuSensor.Dock = DockStyle.Fill;
            cmbCpuSensor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCpuSensor.FormattingEnabled = true;
            cmbCpuSensor.Location = new Point(12, 36);
            cmbCpuSensor.Margin = new Padding(0, 0, 0, 12);
            cmbCpuSensor.Name = "cmbCpuSensor";
            cmbCpuSensor.Size = new Size(358, 28);
            cmbCpuSensor.TabIndex = 0;
            // 
            // cmbGpuSensor
            // 
            cmbGpuSensor.Dock = DockStyle.Fill;
            cmbGpuSensor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGpuSensor.FormattingEnabled = true;
            cmbGpuSensor.Location = new Point(12, 100);
            cmbGpuSensor.Margin = new Padding(0, 0, 0, 12);
            cmbGpuSensor.Name = "cmbGpuSensor";
            cmbGpuSensor.Size = new Size(358, 28);
            cmbGpuSensor.TabIndex = 1;
            // 
            // lblGpu
            // 
            lblGpu.AutoSize = true;
            lblGpu.Dock = DockStyle.Fill;
            lblGpu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblGpu.Location = new Point(12, 76);
            lblGpu.Margin = new Padding(0, 0, 0, 4);
            lblGpu.Name = "lblGpu";
            lblGpu.Size = new Size(358, 20);
            lblGpu.TabIndex = 2;
            lblGpu.Text = "GPU temperature sensor";
            lblGpu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSave.Location = new Point(284, 0);
            btnSave.Margin = new Padding(8, 0, 0, 0);
            btnSave.Name = "btnSave";
            btnSave.Padding = new Padding(12, 0, 12, 0);
            btnSave.Size = new Size(74, 30);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCancel.Location = new Point(189, 0);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(12, 0, 12, 0);
            btnCancel.Size = new Size(87, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblCpu, 0, 0);
            tableLayoutPanel1.Controls.Add(cmbCpuSensor, 0, 1);
            tableLayoutPanel1.Controls.Add(cmbGpuSensor, 0, 3);
            tableLayoutPanel1.Controls.Add(lblGpu, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 4);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(12);
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(382, 198);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(12, 156);
            flowLayoutPanel1.Margin = new Padding(0, 16, 0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(358, 30);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.WrapContents = false;
            // 
            // SensorSelectionForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = btnCancel;
            ClientSize = new Size(382, 278);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SensorSelectionForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select temperature sensors";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}