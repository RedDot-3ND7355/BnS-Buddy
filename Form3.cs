using MetroFramework.Forms;
using Revamped_BnS_Buddy.Functions;
using System;
using System.IO;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class Form3 : MetroForm
    {
        public static Form3 CurrentForm;

        public Form3()
        {
            InitializeComponent();
            GetColor();
        }

        private void GetColor()
        {
            Themer.Style = Prompt.ColorSet;
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
