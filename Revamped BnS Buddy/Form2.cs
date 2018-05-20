using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
        public bool AdminCheck = true;
        public Form2()
        {
            // Load Splash
            InitializeComponent();
            Application.DoEvents();
            // Get Color
            GetColor();
            // Continue
        }

        private void GetColor()
        {
            string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(43).Take(1).First().Replace("buddycolor = ", "");
            if (line == "Black")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Black;
            }
            else if (line == "Red")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Red;
            }
            else if (line == "Purple")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Purple;
            }
            else if (line == "Pink")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Pink;
            }
            else if (line == "Orange")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Orange;
            }
            else if (line == "Magenta")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Magenta;
            }
            else if (line == "Lime")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Lime;
            }
            else if (line == "Green")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Green;
            }
            else if (line == "Default")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Default;
            }
            else if (line == "Brown")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Brown;
            }
            else if (line == "Blue")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Blue;
            }
            else if (line == "Silver")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Silver;
            }
            else if (line == "Teal")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Teal;
            }
            else if (line == "White")
            {
                Themer.Style = MetroFramework.MetroColorStyle.White;
            }
            else if (line == "Yellow")
            {
                Themer.Style = MetroFramework.MetroColorStyle.Yellow;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            KillApp();
        }

        public void KillApp()
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }
    }
}
