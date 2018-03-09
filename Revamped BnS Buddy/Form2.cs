using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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

            if (File.Exists(AppPath + "\\Settings.ini"))
            {
                // Check Quick Settings.ini
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("admincheck = false"))
                {
                    AdminCheck = false;
                }
                // Check if admin
                if (AdminCheck == true)
                {
                    CheckIsAdministrator();
                }
            }
        }
        public static bool IsAdministrator()
        {
            // Direct admin check
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void CheckIsAdministrator()
        {
            // Check admin shortcut
            if (IsAdministrator() == false)
            {
                MessageBox.Show("Please run as Admin", "Error: Not admin", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                KillApp();
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
