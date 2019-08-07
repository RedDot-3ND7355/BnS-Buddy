using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class PreviewMod : MetroForm
    {
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
                metroForm.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
                metroForm.ControlBox = false;
                metroForm.Theme = MetroThemeStyle.Dark;
                metroForm.DisplayHeader = false;
                metroForm.TopMost = true;
                metroForm.Text = "";
                metroForm.StartPosition = FormStartPosition.CenterScreen;
                MetroLabel metroLabel = new MetroLabel();
                metroLabel.Dock = DockStyle.Fill;
                metroLabel.AutoSize = true;
                metroLabel.Left = 5;
                metroLabel.Top = 0;
                metroLabel.Text = Message + System.Environment.NewLine + System.Environment.NewLine;
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
                metroButton.Top = metroForm.Height - 20;
                metroButton.DialogResult = DialogResult.OK;
                metroButton.Theme = MetroThemeStyle.Dark;
                MetroButton metroButton2 = metroButton;
                metroButton2.TabStop = false;
                metroForm.Controls.Add(metroButton2);
                metroForm.Controls.Add(value);
                metroForm.AcceptButton = metroButton2;
                metroForm.Style = ColorSet;
                metroForm.ShowDialog();
            }
        }

        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public PreviewMod()
        {
            Prompt.AppPath = AppPath;
            InitializeComponent();
            SetFormColor();
            metroButton2.DialogResult = DialogResult.Cancel;
            try
            {
                pictureBox1.Image = Form1.CurrentForm.previewImage;
                this.Text = "Previewing " + Form1.CurrentForm.treeView2.SelectedNode.Text.Replace("&", "&&");
                metroLabel1.Text = Form1.CurrentForm.metroLabel40.Text;
                metroLabel1.UseMnemonic = false;
            }
            catch { Prompt.Popup("Preview image is corrupted!"); }
        }

        private void SetFormColor()
        {
            if (File.Exists(AppPath + "\\Settings.ini"))
            {
                string a = File.ReadLines(AppPath + "\\Settings.ini").Skip(43).Take(1)
                    .First()
                    .Replace("buddycolor = ", "");
                if (a == "Black")
                {
                    metroStyleManager1.Style = MetroColorStyle.Black;
                }
                else if (a == "Red")
                {
                    metroStyleManager1.Style = MetroColorStyle.Red;
                }
                else if (a == "Purple")
                {
                    metroStyleManager1.Style = MetroColorStyle.Purple;
                }
                else if (a == "Pink")
                {
                    metroStyleManager1.Style = MetroColorStyle.Pink;
                }
                else if (a == "Orange")
                {
                    metroStyleManager1.Style = MetroColorStyle.Orange;
                }
                else if (a == "Magenta")
                {
                    metroStyleManager1.Style = MetroColorStyle.Magenta;
                }
                else if (a == "Lime")
                {
                    metroStyleManager1.Style = MetroColorStyle.Lime;
                }
                else if (a == "Green")
                {
                    metroStyleManager1.Style = MetroColorStyle.Green;
                }
                else if (a == "Default")
                {
                    metroStyleManager1.Style = MetroColorStyle.Default;
                }
                else if (a == "Brown")
                {
                    metroStyleManager1.Style = MetroColorStyle.Brown;
                }
                else if (a == "Blue")
                {
                    metroStyleManager1.Style = MetroColorStyle.Blue;
                }
                else if (a == "Silver")
                {
                    metroStyleManager1.Style = MetroColorStyle.Silver;
                }
                else if (a == "Teal")
                {
                    metroStyleManager1.Style = MetroColorStyle.Teal;
                }
                else if (a == "White")
                {
                    metroStyleManager1.Style = MetroColorStyle.White;
                }
                else if (a == "Yellow")
                {
                    metroStyleManager1.Style = MetroColorStyle.Yellow;
                }
                base.Style = metroStyleManager1.Style;
                Refresh();
                Prompt.ColorSet = metroStyleManager1.Style;
            }
        }

    }
}
