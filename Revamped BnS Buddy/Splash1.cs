using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class Splash1 : MetroFramework.Forms.MetroForm
    {

        Form f = Application.OpenForms["Form1"];
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
        public bool failed = false;
        public bool login = false;

        public Splash1()
        {
            // Initialize Form
            InitializeComponent();
        }
        
        
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Document completed handler
                metroButton1.Visible = true;
                metroButton1.Enabled = true;
                metroTextBox1.Enabled = true;
                metroTextBox2.Enabled = true;
                metroProgressBar1.Visible = false; 
                metroProgressSpinner1.EnsureVisible = false;
            if (webBrowser1.Url.ToString() == "https://account.ncsoft.com/settings/index")
            {
                login = true;
                this.Hide();
                ShowDialog();
                Show(ActiveForm); // Shows the program on taskbar
                WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
            }
            else
            {
                metroButton1.Visible = true;
            }
            if (failed == true)
            {
                webBrowser1.Document.GetElementById("id").SetAttribute("value", metroTextBox1.Text);
                webBrowser1.Document.GetElementById("password").SetAttribute("value", metroTextBox2.Text);
                webBrowser1.Document.InvokeScript("doLogin");
                failed = false;
            }
        }
        

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (webBrowser1.Url.ToString() != "https://login.ncsoft.com/login")
            {
                // Disable Textboxs
                if (metroTextBox1.Enabled == true)
                {
                    metroTextBox1.Enabled = false;
                    metroTextBox2.Enabled = false;
                    metroButton1.Visible = false;
                }
                // Show Progress
                if (metroProgressBar1.Visible == false)
                {
                    metroProgressBar1.Visible = true;
                }
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e) 
        {
            // Change Values
            metroProgressBar1.Maximum = ((100 / 5) / 4);
            metroProgressBar1.Value = (int)Math.Floor((e.CurrentProgress / (double)e.MaximumProgress) * 100);
            metroProgressBar1.Refresh();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Login
            if ((metroTextBox1.Text != "") && (metroTextBox2.Text != ""))
            {
                metroButton1.Visible = false;
                try
                {
                    webBrowser1.Document.GetElementById("id").SetAttribute("value", metroTextBox1.Text);
                    webBrowser1.Document.GetElementById("password").SetAttribute("value", metroTextBox2.Text);
                    webBrowser1.Document.InvokeScript("doLogin");
                } 
                catch
                {
                    failed = true;
                    webBrowser1.Url = new Uri("https://login.ncsoft.com/login");
                }
            }
            else if ((metroTextBox1.Text == "") || (metroTextBox2.Text == ""))
            {
                if ((metroTextBox1.Text == "") && (metroTextBox2.Text == ""))
                {
                    MessageBox.Show("Fields are empty!");
                    metroButton1.Visible = true;
                }
                else
                {
                    MessageBox.Show("One of the fields are empty!");
                    metroButton1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Error!");
                metroButton1.Visible = true;
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // Close login window
            KillApp();
        }

        public void KillApp()
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }
    }
}
