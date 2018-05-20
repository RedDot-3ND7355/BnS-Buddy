namespace Revamped_BnS_Buddy
{
    partial class Splash1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash1));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.Themer = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Themer)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(158, 70);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(41, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Email";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(147, 118);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(63, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Password";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroTextBox1
            // 
            this.metroTextBox1.Location = new System.Drawing.Point(23, 92);
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.Size = new System.Drawing.Size(311, 23);
            this.metroTextBox1.TabIndex = 3;
            this.metroTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseStyleColors = true;
            this.metroTextBox1.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
            this.metroTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metroTextBox1_KeyDown);
            // 
            // metroTextBox2
            // 
            this.metroTextBox2.Location = new System.Drawing.Point(23, 140);
            this.metroTextBox2.MaxLength = 16;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '●';
            this.metroTextBox2.Size = new System.Drawing.Size(312, 23);
            this.metroTextBox2.TabIndex = 4;
            this.metroTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox2.UseStyleColors = true;
            this.metroTextBox2.UseSystemPasswordChar = true;
            this.metroTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.metroTextBox2_KeyDown);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(259, 169);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(76, 29);
            this.metroButton1.TabIndex = 8;
            this.metroButton1.Text = "Sign in";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(305, 20);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(30, 30);
            this.metroButton2.TabIndex = 9;
            this.metroButton2.Text = "X";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel3.Location = new System.Drawing.Point(23, 27);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(38, 23);
            this.metroLabel3.TabIndex = 10;
            this.metroLabel3.Text = "Help";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroLabel3, resources.GetString("metroLabel3.ToolTip"));
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.AutoPopDelay = 99999999;
            this.metroToolTip1.InitialDelay = 500;
            this.metroToolTip1.ReshowDelay = 100;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.Enabled = false;
            this.metroComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(23, 169);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(230, 29);
            this.metroComboBox1.TabIndex = 13;
            this.metroComboBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroComboBox1, "Select other accounts");
            this.metroComboBox1.SelectedIndexChanged += new System.EventHandler(this.metroComboBox1_SelectedIndexChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.CustomForeColor = true;
            this.metroLabel4.ForeColor = System.Drawing.Color.Tomato;
            this.metroLabel4.Location = new System.Drawing.Point(23, 66);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(129, 23);
            this.metroLabel4.TabIndex = 11;
            this.metroLabel4.Text = "Caps lock is on!";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.Visible = false;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Location = new System.Drawing.Point(234, 71);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(101, 15);
            this.metroCheckBox1.TabIndex = 12;
            this.metroCheckBox1.Text = "Remember me";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseVisualStyleBackColor = true;
            this.metroCheckBox1.Click += new System.EventHandler(this.metroCheckBox1_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(314, 93);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(19, 20);
            this.metroButton3.TabIndex = 14;
            this.metroButton3.Text = "X";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.Visible = false;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // Themer
            // 
            this.Themer.Owner = this;
            // 
            // Splash1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(358, 213);
            this.ControlBox = false;
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroComboBox1);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Splash1";
            this.Resizable = false;
            this.Text = "Login to NCSoft";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.Splash1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Splash1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Themer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public MetroFramework.Controls.MetroTextBox metroTextBox1;
        public MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Components.MetroStyleManager Themer;
    }
}