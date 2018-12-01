namespace Revamped_BnS_Buddy
{
    partial class Form2
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
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            metroButton1 = new MetroFramework.Controls.MetroButton();
            Themer = new MetroFramework.Components.MetroStyleManager(components);
            SuspendLayout();
            metroProgressSpinner1.Cursor = System.Windows.Forms.Cursors.AppStarting;
            metroProgressSpinner1.Location = new System.Drawing.Point(23, 57);
            metroProgressSpinner1.Maximum = 100;
            metroProgressSpinner1.Name = "metroProgressSpinner1";
            metroProgressSpinner1.Size = new System.Drawing.Size(200, 200);
            metroProgressSpinner1.TabIndex = 0;
            metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroProgressSpinner1.Value = 1;
            metroButton1.Cursor = System.Windows.Forms.Cursors.Default;
            metroButton1.Location = new System.Drawing.Point(85, 147);
            metroButton1.Name = "metroButton1";
            metroButton1.Size = new System.Drawing.Size(75, 23);
            metroButton1.TabIndex = 1;
            metroButton1.TabStop = false;
            metroButton1.Text = "Cancel";
            metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            metroButton1.Click += new System.EventHandler(metroButton1_Click);
            Themer.Owner = this;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(250, 280);
            base.ControlBox = false;
            base.Controls.Add(metroButton1);
            base.Controls.Add(metroProgressSpinner1);
            Cursor = System.Windows.Forms.Cursors.AppStarting;
            base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "Form2";
            base.Resizable = false;
            base.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            Text = "Loading BnS Buddy";
            base.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            base.Theme = MetroFramework.MetroThemeStyle.Dark;
            base.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)Themer).EndInit();
            ResumeLayout(false);
        }

        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Components.MetroStyleManager Themer;
    }
}