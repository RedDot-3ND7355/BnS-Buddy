namespace Revamped_BnS_Buddy
{
    partial class DX12ModMan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DX12ModMan));
            this.metroProgressBar1 = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.Themer = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Themer)).BeginInit();
            this.SuspendLayout();
            // 
            // metroProgressBar1
            // 
            this.metroProgressBar1.FontSize = MetroFramework.MetroProgressBarSize.Tall;
            this.metroProgressBar1.HideProgressText = false;
            this.metroProgressBar1.Location = new System.Drawing.Point(23, 147);
            this.metroProgressBar1.Name = "metroProgressBar1";
            this.metroProgressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Blocks;
            this.metroProgressBar1.Size = new System.Drawing.Size(288, 28);
            this.metroProgressBar1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressBar1.TabIndex = 0;
            this.metroProgressBar1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroProgressBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(73, 25);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "Current:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(29, 101);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(67, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Online:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroToggle1
            // 
            this.metroToggle1.Enabled = false;
            this.metroToggle1.Location = new System.Drawing.Point(216, 63);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(95, 32);
            this.metroToggle1.TabIndex = 3;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToggle1.UseSelectable = true;
            this.metroToggle1.UseStyleColors = true;
            this.metroToggle1.Click += new System.EventHandler(this.metroToggle1_CheckedChanged);
            // 
            // metroButton1
            // 
            this.metroButton1.Enabled = false;
            this.metroButton1.Highlight = true;
            this.metroButton1.Location = new System.Drawing.Point(216, 113);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(95, 28);
            this.metroButton1.TabIndex = 4;
            this.metroButton1.Text = "Update";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.UseStyleColors = true;
            this.metroButton1.Click += new System.EventHandler(this.UpdateMod);
            // 
            // metroButton2
            // 
            this.metroButton2.Highlight = true;
            this.metroButton2.Location = new System.Drawing.Point(282, 24);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(28, 28);
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "X";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // Themer
            // 
            this.Themer.Owner = this;
            this.Themer.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(23, 142);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(288, 36);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Waiting.";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Enabled = false;
            this.metroCheckBox1.Location = new System.Drawing.Point(219, 97);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(90, 15);
            this.metroCheckBox1.TabIndex = 8;
            this.metroCheckBox1.Text = "Keep Cache?";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroToolTip1.SetToolTip(this.metroCheckBox1, "May/Will cause issues with future updates.\r\nI recommend keeping this option off.");
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.UseStyleColors = true;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Checked = true;
            this.metroCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox2.Location = new System.Drawing.Point(6, 9);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(174, 15);
            this.metroCheckBox2.TabIndex = 9;
            this.metroCheckBox2.Text = "Update available notification";
            this.metroCheckBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox2.UseSelectable = true;
            this.metroCheckBox2.UseStyleColors = true;
            this.metroCheckBox2.Click += new System.EventHandler(this.metroCheckBox2_CheckedChanged);
            // 
            // DX12ModMan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 198);
            this.ControlBox = false;
            this.Controls.Add(this.metroCheckBox2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroToggle1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroProgressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DX12ModMan";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "D912PXY Manager";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.Themer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar metroProgressBar1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Components.MetroStyleManager Themer;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.Timer timer1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
    }
}