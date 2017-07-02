using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public unsafe partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public static Form3 CurrentForm;
        public Form3()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        public static class Prompt
        {
            public static void Popup(string Message)
            {
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Dock = DockStyle.Fill, AutoSize = true, Left = 5, Top = 0, Text = Message + Environment.NewLine + Environment.NewLine, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Dock = DockStyle.Bottom, Text = "Ok", Left = 5, Width = 100, Top = (prompt.Height - 20), DialogResult = DialogResult.OK, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                prompt.ShowDialog();
            }
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            Prompt.Popup("You can add as many Search and Replace in the patch." + Environment.NewLine + Environment.NewLine + "Don't include .patch in patch name." + Environment.NewLine + Environment.NewLine + "Manually get your search pattern through dat editor.");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = Form1.CurrentForm.FullAddonPath.ToString();
                openFileDialog1.Filter = "patch files (*.patch)|*.patch|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.Title = "Select Patch to Edit";
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string tmp = Path.GetFileName(openFileDialog1.FileName);
                        tmp = tmp.Replace(".patch", "");
                        fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                        metroTextBox7.Text = tmp;
                    }
                    catch (Exception x)
                    {
                        Prompt.Popup("Error: " + x.ToString());
                    }
                }
            } catch(Exception x) { Prompt.Popup("Error: " + x.ToString()); }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = metroTextBox7.Text + ".patch";
                savefile.InitialDirectory = Form1.CurrentForm.FullAddonPath.ToString();
                savefile.RestoreDirectory = true;
                savefile.Title = "Select Where to Save Patch";
                savefile.Filter = "patch files (*.patch)|*.patch|All files (*.*)|*.*";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(savefile.FileName, fastColoredTextBox1.Text);
                }
            } catch(Exception x) { Prompt.Popup("Error: " + x.ToString()); }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Form1.CurrentForm.FullAddonPath.ToString() + metroTextBox7.Text + ".patch", fastColoredTextBox1.Text);
            } catch(Exception x) { Prompt.Popup("Error: " + x.ToString()); }
        }
    }
}
