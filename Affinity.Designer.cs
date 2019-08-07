namespace Revamped_BnS_Buddy
{
    partial class Affinity
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Affinity));
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.Processor_name = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.Processor_Comp = new MetroFramework.Controls.MetroLabel();
            this.Processor_Speed = new MetroFramework.Controls.MetroLabel();
            this.Processor_Lcore = new MetroFramework.Controls.MetroLabel();
            this.Processor_cores = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButton2
            // 
            this.metroButton2.AutoSize = true;
            this.metroButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(567, 14);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(24, 23);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "X";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Processor_name
            // 
            this.Processor_name.AutoSize = true;
            this.Processor_name.Location = new System.Drawing.Point(6, 16);
            this.Processor_name.Name = "Processor_name";
            this.Processor_name.Size = new System.Drawing.Size(147, 19);
            this.Processor_name.TabIndex = 7;
            this.Processor_name.Text = "Processor Architecture: ";
            this.Processor_name.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.Processor_Comp);
            this.groupBox1.Controls.Add(this.Processor_Speed);
            this.groupBox1.Controls.Add(this.Processor_Lcore);
            this.groupBox1.Controls.Add(this.Processor_cores);
            this.groupBox1.Controls.Add(this.Processor_name);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 140);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processor Information";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(6, 111);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(110, 19);
            this.metroLabel3.TabIndex = 12;
            this.metroLabel3.Text = "Processor name: ";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Processor_Comp
            // 
            this.Processor_Comp.AutoSize = true;
            this.Processor_Comp.Location = new System.Drawing.Point(6, 92);
            this.Processor_Comp.Name = "Processor_Comp";
            this.Processor_Comp.Size = new System.Drawing.Size(73, 19);
            this.Processor_Comp.TabIndex = 11;
            this.Processor_Comp.Text = "Company: ";
            this.Processor_Comp.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Processor_Speed
            // 
            this.Processor_Speed.AutoSize = true;
            this.Processor_Speed.Location = new System.Drawing.Point(6, 73);
            this.Processor_Speed.Name = "Processor_Speed";
            this.Processor_Speed.Size = new System.Drawing.Size(76, 19);
            this.Processor_Speed.TabIndex = 10;
            this.Processor_Speed.Text = "Frequency: ";
            this.Processor_Speed.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Processor_Lcore
            // 
            this.Processor_Lcore.AutoSize = true;
            this.Processor_Lcore.Location = new System.Drawing.Point(6, 54);
            this.Processor_Lcore.Name = "Processor_Lcore";
            this.Processor_Lcore.Size = new System.Drawing.Size(95, 19);
            this.Processor_Lcore.TabIndex = 9;
            this.Processor_Lcore.Text = "Logical Cores: ";
            this.Processor_Lcore.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Processor_cores
            // 
            this.Processor_cores.AutoSize = true;
            this.Processor_cores.Location = new System.Drawing.Point(6, 35);
            this.Processor_cores.Name = "Processor_cores";
            this.Processor_cores.Size = new System.Drawing.Size(50, 19);
            this.Processor_cores.TabIndex = 8;
            this.Processor_cores.Text = "Cores: ";
            this.Processor_cores.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(20, 212);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(243, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "How many cores to assign to the game?";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Items.AddRange(new object[] {
            "All",
            "First Half",
            "Second Half",
            "Odd",
            "Even"});
            this.metroComboBox1.Location = new System.Drawing.Point(459, 206);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(121, 29);
            this.metroComboBox1.TabIndex = 14;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroComboBox1.UseSelectable = true;
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.MetroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(327, 212);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(126, 19);
            this.metroLabel2.TabIndex = 15;
            this.metroLabel2.Text = "Pre-defined settings";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton1
            // 
            this.metroButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(514, 14);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(47, 23);
            this.metroButton1.TabIndex = 17;
            this.metroButton1.Text = "Save";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.MetroLabel1_Click);
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.FontSize = MetroFramework.MetroProgressBarSize.Small;
            this.metroProgressBar1.Location = new System.Drawing.Point(20, 60);
            this.metroProgressBar1.MarqueeAnimationSpeed = 200;
            this.metroProgressBar1.Maximum = 6;
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.Size = new System.Drawing.Size(560, 175);
            this.metroProgressBar1.Step = 1;
            this.metroProgressBar1.TabIndex = 18;
            this.metroProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Affinity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.metroButton2;
            this.ClientSize = new System.Drawing.Size(600, 258);
            this.ControlBox = false;
            this.Controls.Add(this.metroProgressBar1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.metroButton2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Affinity";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowInTaskbar = false;
            this.Text = "Process Affinity Manager";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Affinity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MetroFramework.Controls.MetroButton metroButton2;

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel Processor_Comp;
        private MetroFramework.Controls.MetroLabel Processor_Speed;
        private MetroFramework.Controls.MetroLabel Processor_Lcore;
        private MetroFramework.Controls.MetroLabel Processor_cores;
        private MetroFramework.Controls.MetroLabel Processor_name;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
    }
}