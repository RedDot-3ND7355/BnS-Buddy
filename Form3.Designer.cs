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
		private void InitializeComponent2()
        {
            this.SuspendLayout();
            // 
            // Form3
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "Form3";
            this.ResumeLayout(false);

        }

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
            this.Themer = new MetroFramework.Components.MetroStyleManager(components);
            //this.fastColoredTextBox1.BeginInit();
            //this.Themer.BeginInit();
            base.SuspendLayout();
            this.fastColoredTextBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[10]
            {
                '(',
                ')',
                '{',
                '}',
                '[',
                ']',
                '"',
                '"',
                '\'',
                '\''
            };
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(467, 56);
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.fastColoredTextBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.fastColoredTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fastColoredTextBox1.CaretColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.CharHeight = 14;
            this.fastColoredTextBox1.CharWidth = 8;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(100, 180, 180, 180);
            this.fastColoredTextBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(20, 60);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(60, 0, 0, 255);
            //this.fastColoredTextBox1.ServiceColors = (FastColoredTextBoxNS.ServiceColors)componentResourceManager.GetObject("fastColoredTextBox1.ServiceColors");
            this.fastColoredTextBox1.Size = new System.Drawing.Size(570, 314);
            this.fastColoredTextBox1.TabIndex = 3;
            this.fastColoredTextBox1.TabStop = false;
            this.fastColoredTextBox1.Text = "FileName = example[bit].dat.files\\\\example.example2.xml\r\nSearch = <option name=\"example\" value=\"true\" />\r\nReplace = <option name=\"example\" value=\"false\" />\r\nDescription = Disable example";
            this.fastColoredTextBox1.TextAreaBorderColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.Zoom = 100;
            this.metroButton2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(560, 24);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(30, 30);
            this.metroButton2.TabIndex = 10;
            this.metroButton2.TabStop = false;
            this.metroButton2.Text = "X";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            this.metroLabel3.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
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
            this.metroTextBox7.Location = new System.Drawing.Point(293, 28);
            this.metroTextBox7.MaxLength = 32767;
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.PasswordChar = '\0';
#pragma warning disable CS0618 // Type or member is obsolete
            this.metroTextBox7.PromptText = "example";
#pragma warning restore CS0618 // Type or member is obsolete
            this.metroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox7.Text = "";
            this.metroTextBox7.Select(0, 0);
            this.metroTextBox7.Size = new System.Drawing.Size(216, 23);
            this.metroTextBox7.TabIndex = 12;
            this.metroTextBox7.TabStop = false;
            this.metroTextBox7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox7.UseStyleColors = true;
            //this.metroTextBox7.set_WaterMark("example");
            //this.metroTextBox7.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
            //this.metroTextBox7.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroLabel55.AutoSize = true;
            this.metroLabel55.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel55.Location = new System.Drawing.Point(186, 25);
            this.metroLabel55.Name = "metroLabel55";
            this.metroLabel55.Size = new System.Drawing.Size(105, 25);
            this.metroLabel55.TabIndex = 13;
            this.metroLabel55.Text = "Patch name:";
            this.metroLabel55.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel55.UseStyleColors = true;
            this.metroButton1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroButton1.Location = new System.Drawing.Point(20, 445);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(570, 30);
            this.metroButton1.TabIndex = 14;
            this.metroButton1.TabStop = false;
            this.metroButton1.Text = "Save";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            this.metroButton3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroButton3.Location = new System.Drawing.Point(20, 415);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(570, 30);
            this.metroButton3.TabIndex = 15;
            this.metroButton3.TabStop = false;
            this.metroButton3.Text = "Save As";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            this.metroButton4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroButton4.Location = new System.Drawing.Point(20, 385);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(570, 30);
            this.metroButton4.TabIndex = 16;
            this.metroButton4.TabStop = false;
            this.metroButton4.Text = "Edit existing addon";
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            this.Themer.Owner = this;
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            base.ClientSize = new System.Drawing.Size(610, 495);
            base.ControlBox = false;
            base.Controls.Add(this.metroButton4);
            base.Controls.Add(this.metroButton3);
            base.Controls.Add(this.metroButton1);
            base.Controls.Add(this.metroLabel55);
            base.Controls.Add(this.metroTextBox7);
            base.Controls.Add(this.metroLabel3);
            base.Controls.Add(this.metroButton2);
            base.Controls.Add(this.fastColoredTextBox1);
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.Name = "Form3";
            base.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Addon Creator";
            base.Theme = MetroFramework.MetroThemeStyle.Dark;
            //this.fastColoredTextBox1.EndInit();
            //this.Themer.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox metroTextBox7;
        private MetroFramework.Controls.MetroLabel metroLabel55;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Components.MetroStyleManager Themer;

        #endregion
    }
}