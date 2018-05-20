using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public unsafe partial class Form3 : MetroFramework.Forms.MetroForm
    {
        public static Form3 CurrentForm;
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public Form3()
        {
            InitializeComponent();
            // Set Color
            GetColor();
        }

        private void GetColor()
        {
            Prompt.AppPath = AppPath;
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
            // Set global
            Prompt.ColorSet = Themer.Style;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        public static class Prompt
        {
            public static string AppPath { get; internal set; }

            public static MetroFramework.MetroColorStyle ColorSet { get; internal set; }

            public static void Popup(string Message)
            {
                // Continue
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
                // Set style
                prompt.Style = ColorSet;
                // Prompt
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
                        metroTextBox7.ReadOnly = true;
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
                    metroTextBox7.ReadOnly = false;
                }
            } catch(Exception x) { Prompt.Popup("Error: " + x.ToString()); }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Form1.CurrentForm.FullAddonPath.ToString() + metroTextBox7.Text + ".patch", fastColoredTextBox1.Text);
                metroTextBox7.ReadOnly = false;
            } catch(Exception x) { Prompt.Popup("Error: " + x.ToString()); }
        }
    }
}
