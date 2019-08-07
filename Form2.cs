using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class Form2 : MetroForm
    {

        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public bool AdminCheck = true;



        public Form2()
        {
            InitializeComponent();
            Application.DoEvents();
            GetColor();
        }

        private void GetColor()
        {
            string a = "Blue";
            if (File.Exists(AppPath + "\\Settings.ini"))
            {
                a = File.ReadLines(AppPath + "\\Settings.ini").Skip(43).Take(1)
                    .First()
                    .Replace("buddycolor = ", "");
            }
            if (a == "Black")
            {
                Themer.Style = MetroColorStyle.Black;
            }
            else if (a == "Red")
            {
                Themer.Style = MetroColorStyle.Red;
            }
            else if (a == "Purple")
            {
                Themer.Style = MetroColorStyle.Purple;
            }
            else if (a == "Pink")
            {
                Themer.Style = MetroColorStyle.Pink;
            }
            else if (a == "Orange")
            {
                Themer.Style = MetroColorStyle.Orange;
            }
            else if (a == "Magenta")
            {
                Themer.Style = MetroColorStyle.Magenta;
            }
            else if (a == "Lime")
            {
                Themer.Style = MetroColorStyle.Lime;
            }
            else if (a == "Green")
            {
                Themer.Style = MetroColorStyle.Green;
            }
            else if (a == "Default")
            {
                Themer.Style = MetroColorStyle.Blue;
            }
            else if (a == "Brown")
            {
                Themer.Style = MetroColorStyle.Brown;
            }
            else if (a == "Blue")
            {
                Themer.Style = MetroColorStyle.Blue;
            }
            else if (a == "Silver")
            {
                Themer.Style = MetroColorStyle.Silver;
            }
            else if (a == "Teal")
            {
                Themer.Style = MetroColorStyle.Teal;
            }
            else if (a == "White")
            {
                Themer.Style = MetroColorStyle.White;
            }
            else if (a == "Yellow")
            {
                Themer.Style = MetroColorStyle.Yellow;
            }
            base.Style = Themer.Style;
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
