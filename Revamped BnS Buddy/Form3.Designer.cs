namespace Revamped_BnS_Buddy
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox7 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel55 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Themer = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Themer)).BeginInit();
            this.SuspendLayout();
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(467, 56);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.fastColoredTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fastColoredTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fastColoredTextBox1.CaretColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.CharHeight = 14;
            this.fastColoredTextBox1.CharWidth = 8;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastColoredTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(20, 60);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(570, 309);
            this.fastColoredTextBox1.TabIndex = 3;
            this.fastColoredTextBox1.Text = "FileName = example[bit].dat.files\\\\example.example2.xml\r\nSearch = <option name=\"e" +
    "xample\" value=\"true\" />\r\nReplace = <option name=\"example\" value=\"false\" />\r\nDesc" +
    "ription = Disable example";
            this.fastColoredTextBox1.TextAreaBorderColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.Zoom = 100;
            // 
            // metroButton2
            // 
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(560, 24);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(30, 30);
            this.metroButton2.TabIndex = 10;
            this.metroButton2.Text = "X";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel3.Location = new System.Drawing.Point(515, 24);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(39, 30);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Tips";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseStyleColors = true;
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroTextBox7
            // 
            this.metroTextBox7.Location = new System.Drawing.Point(293, 28);
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.Size = new System.Drawing.Size(216, 23);
            this.metroTextBox7.TabIndex = 12;
            this.metroTextBox7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox7.UseStyleColors = true;
            // 
            // metroLabel55
            // 
            this.metroLabel55.AutoSize = true;
            this.metroLabel55.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel55.Location = new System.Drawing.Point(186, 25);
            this.metroLabel55.Name = "metroLabel55";
            this.metroLabel55.Size = new System.Drawing.Size(105, 25);
            this.metroLabel55.TabIndex = 13;
            this.metroLabel55.Text = "Patch name:";
            this.metroLabel55.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel55.UseStyleColors = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(515, 370);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 19);
            this.metroButton1.TabIndex = 14;
            this.metroButton1.Text = "Save";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(443, 370);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(75, 19);
            this.metroButton3.TabIndex = 15;
            this.metroButton3.Text = "Save As";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(20, 370);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(136, 19);
            this.metroButton4.TabIndex = 16;
            this.metroButton4.Text = "Edit existing addon";
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Themer
            // 
            this.Themer.Owner = this;
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(610, 389);
            this.ControlBox = false;
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel55);
            this.Controls.Add(this.metroTextBox7);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Resizable = false;
            this.Text = "Addon Creator";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Themer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox metroTextBox7;
        private MetroFramework.Controls.MetroLabel metroLabel55;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Components.MetroStyleManager Themer;
    }
}