using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class Form3 : MetroForm
    {
        public static Form3 CurrentForm;

        public static class Prompt
        {
            public static string AppPath
            {
                get;
                internal set;
            }

            public static MetroColorStyle ColorSet
            {
                get;
                internal set;
            }

            public static void Popup(string Message)
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
                MetroForm metroForm = new MetroForm();
                metroForm.ShadowType = MetroFormShadowType.AeroShadow;
                metroForm.Width = 280;
                metroForm.Height = 135;
                metroForm.FormBorderStyle = FormBorderStyle.None;
                metroForm.Resizable = false;
                metroForm.AutoSize = true;
                metroForm.AutoSizeMode = AutoSizeMode.GrowOnly;
                metroForm.Icon = (Icon)componentResourceManager.GetObject("notifyIcon1.Icon");
                metroForm.ControlBox = false;
                metroForm.Theme = MetroThemeStyle.Dark;
                metroForm.DisplayHeader = false;
                metroForm.TopMost = true;
                metroForm.Text = "";
                metroForm.StartPosition = FormStartPosition.CenterScreen;
                MetroForm metroForm2 = metroForm;
                MetroLabel metroLabel = new MetroLabel();
                metroLabel.Dock = DockStyle.Fill;
                metroLabel.AutoSize = true;
                metroLabel.Left = 5;
                metroLabel.Top = 0;
                metroLabel.Text = Message + Environment.NewLine + Environment.NewLine;
                metroLabel.Width = 270;
                metroLabel.Height = 40;
                metroLabel.TextAlign = ContentAlignment.MiddleCenter;
                metroLabel.Theme = MetroThemeStyle.Dark;
                MetroLabel value = metroLabel;
                MetroButton metroButton = new MetroButton();
                metroButton.Dock = DockStyle.Bottom;
                metroButton.Text = "Ok";
                metroButton.Left = 5;
                metroButton.Width = 100;
                metroButton.Top = metroForm2.Height - 20;
                metroButton.DialogResult = DialogResult.OK;
                metroButton.Theme = MetroThemeStyle.Dark;
                MetroButton metroButton2 = metroButton;
                metroButton2.TabStop = false;
                metroForm2.Controls.Add(metroButton2);
                metroForm2.Controls.Add(value);
                metroForm2.AcceptButton = metroButton2;
                metroForm2.Style = ColorSet;
                metroForm2.ShowDialog();
            }
        }
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public Form3()
        {
            InitializeComponent();
            GetColor();
        }

        private void GetColor()
        {
            Prompt.AppPath = AppPath;
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
            Prompt.ColorSet = Themer.Style;
            base.Style = Themer.Style;
            Refresh();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            Prompt.Popup("You can add as many Search and Replace in the patch." + Environment.NewLine + Environment.NewLine + "Don't include .patch in patch name." + Environment.NewLine + Environment.NewLine + "Manually get your search pattern through dat editor.");
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Form1.CurrentForm.FullAddonPath.ToString();
                openFileDialog.Filter = "patch files (*.patch)|*.patch|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.Title = "Select Patch to Edit";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = Path.GetFileName(openFileDialog.FileName);
                        fileName = fileName.Replace(".patch", "");
                        ((Control)fastColoredTextBox1).Text = File.ReadAllText(openFileDialog.FileName);
                        metroTextBox7.Text = fileName;
                        metroTextBox7.ReadOnly = true;
                    }
                    catch (Exception ex)
                    {
                        Prompt.Popup("Error: " + ex.ToString());
                    }
                }
            }
            catch (Exception ex2)
            {
                Prompt.Popup("Error: " + ex2.ToString());
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = metroTextBox7.Text + ".patch";
                saveFileDialog.InitialDirectory = Form1.CurrentForm.FullAddonPath.ToString();
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.Title = "Select Where to Save Patch";
                saveFileDialog.Filter = "patch files (*.patch)|*.patch|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, ((Control)fastColoredTextBox1).Text);
                    metroTextBox7.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                Prompt.Popup("Error: " + ex.ToString());
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Form1.CurrentForm.FullAddonPath.ToString() + metroTextBox7.Text + ".patch", ((Control)fastColoredTextBox1).Text);
                metroTextBox7.ReadOnly = false;
            }
            catch (Exception ex)
            {
                Prompt.Popup("Error: " + ex.ToString());
            }
        }
    }
}
