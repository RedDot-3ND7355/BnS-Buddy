using MetroFramework.Forms;
using Revamped_BnS_Buddy.Functions;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
            Application.DoEvents();
            GetColor();
        }

        private void GetColor()
        {
            base.Style = Prompt.ColorSet;
            Themer.Style = Prompt.ColorSet;
            Refresh();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            KillApp();
        }

        public void KillApp()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
