using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMI_ProcessorInformation;

namespace Revamped_BnS_Buddy
{
    public partial class Affinity : MetroForm
    {
        public static Affinity CurrentForm;
        public string value = "All";

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

        public Affinity()
        {
            CurrentForm = this;
            Prompt.AppPath = AppPath;
            InitializeComponent();
            Form1.CurrentForm.metroLabel85.Text = "Loading...";
            LoadingState(true);
            SetFormColor();
            metroButton2.DialogResult = DialogResult.Cancel;
            metroButton1.DialogResult = DialogResult.OK;
            Task.Delay(1000).ContinueWith(delegate
            {
                SetProcessor_Info();
            });
            
            
        }

        private void SetProcessor_Info()
        {
            metroLabel3.Text += WMI_Processor_Information.GetCpuName();
            LoadingState(true, (int)1);
            Processor_cores.Text += WMI_Processor_Information.GetCpuCores();
            LoadingState(true, (int)1);
            Processor_Comp.Text += WMI_Processor_Information.GetCpuManufacturer();
            LoadingState(true, (int)1);
            Processor_Speed.Text += WMI_Processor_Information.GetCpuClockSpeed() + " Mhz";
            LoadingState(true, (int)1);
            Processor_name.Text += WMI_Processor_Information.GetCpuCaption();
            LoadingState(true, (int)1);
            Processor_Lcore.Text += WMI_Processor_Information.GetCpuNumberOfLogicalProcessors();
            LoadingState(true, (int)1);
            LoadingState(false);
            Form1.CurrentForm.metroLabel85.Text = "Loaded. Waiting...";
        }

        private void LoadingState(bool v, int value = 0)
        {
            metroProgressBar1.Visible = v;
            metroProgressBar1.Value += value;
            metroProgressBar1.HideProgressText = !v;
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

        private void Affinity_Load(object sender, System.EventArgs e)
        {
            if (File.Exists(AppPath + "\\Settings.ini"))
            {
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("affinityproc = "))
                {
                    string text8 = File.ReadLines(AppPath + "\\Settings.ini").Skip(46).Take(1)
                        .First()
                        .Replace("affinityproc = ", "");
                    if (text8.Length == 0)
                    {
                        metroComboBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindString(text8);
                    }
                }
            }
        }

        private void metroButton2_Click(object sender, System.EventArgs e)
        {
            if (metroComboBox1.SelectedItem.ToString() == null)
            {
                metroComboBox1.SelectedIndex = 0;
            }
            this.Close();
        }

        private void MetroLabel1_Click(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedItem.ToString() == null)
            {
                metroComboBox1.SelectedIndex = 0;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lineChanger(string newText, string fileName, int line_to_edit)
        {
            if (File.Exists(fileName))
            {
                string[] array = File.ReadAllLines(fileName);
                array[line_to_edit - 1] = newText;
                File.WriteAllLines(fileName, array);
            }
        }

        private void MetroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                value = "Affinity: " + metroComboBox1.SelectedItem.ToString();
                lineChanger("affinityproc = " + metroComboBox1.SelectedItem.ToString(), AppPath + "\\Settings.ini", 47);
            }
            catch
            {
                Prompt.Popup("Could not save option!");
            }
        }
    }
}
