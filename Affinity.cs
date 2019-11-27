using MetroFramework.Forms;
using Revamped_BnS_Buddy.Functions;
using System;
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

        public Affinity()
        {
            CurrentForm = this;
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
            SetTree(WMI_Processor_Information.GetCpuNumberOfLogicalProcessors());
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
            startup = false;
        }

        private void SetTree(int v)
        {
            for (int i = 0; i < v; i++)
            {
                treeView1.Nodes.Add(new TreeNode("Core # " + i.ToString()));
            }
            treeView1.Refresh();
        }

        private void LoadingState(bool v, int value = 0)
        {
            metroProgressBar1.Visible = v;
            metroProgressBar1.Value += value;
            metroProgressBar1.HideProgressText = !v;
        }

        private void SetFormColor()
        {
            metroStyleManager1.Style = Prompt.ColorSet;
            base.Style = metroStyleManager1.Style;
            Refresh();
        }

        private void Affinity_Load(object sender, System.EventArgs e)
        {
            if (File.Exists(Prompt.AppPath + "\\Settings.ini"))
            {
                if (File.ReadAllText(Prompt.AppPath + "\\Settings.ini").Contains("affinityproc = "))
                {
                    string text8 = File.ReadLines(Prompt.AppPath + "\\Settings.ini").Skip(46).Take(1)
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
                    if (text8 == "Custom")
                    {
                        string text9 = File.ReadLines(Prompt.AppPath + "\\Settings.ini").Skip(49).Take(1)
                        .First()
                        .Replace("customaffinity = ", "");
                        cores_selected = int.Parse(text9);
                        for (var i = 0; i < treeView1.Nodes.Count; i++)
                        {
                            treeView1.Nodes[i].Checked = (cores_selected & (1 << i)) > 0;
                        }
                        startup = false;
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
                if (metroComboBox1.SelectedItem.ToString() != "Custom")
                {
                    treeView1.Enabled = false;
                    value = "Affinity: " + metroComboBox1.SelectedItem.ToString();
                    lineChanger("affinityproc = " + metroComboBox1.SelectedItem.ToString(), Prompt.AppPath + "\\Settings.ini", 47);
                }
                else
                {
                    value = "Affinity: " + metroComboBox1.SelectedItem.ToString();
                    treeView1.Enabled = true;
                }
            }
            catch
            {
                Prompt.Popup("Could not save option!");
            }
        }

        bool startup = true;
        int cores_selected = 0;
        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!startup)
            {
                try
                {
                    cores_selected = 0;
                    for (int i = 0; i < treeView1.Nodes.Count; i++)
                    {
                        if (treeView1.Nodes[i].Checked)
                        {
                            cores_selected += 1 << i;
                        }
                    }
                    Form1.CurrentForm.customValue = cores_selected;
                    value = "Affinity: " + metroComboBox1.SelectedItem.ToString();
                    lineChanger("affinityproc = " + "Custom", Prompt.AppPath + "\\Settings.ini", 47);
                    lineChanger("customaffinity = " + cores_selected.ToString(), Prompt.AppPath + "\\Settings.ini", 50);
                }
                catch (Exception a) { Prompt.Popup("Error:" + a.Message); }
            }
        }
    }
}
