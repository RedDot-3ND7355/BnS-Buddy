using MetroFramework.Forms;
using Revamped_BnS_Buddy.Functions;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class PreviewMod : MetroForm
    {

        public PreviewMod()
        {
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
            metroStyleManager1.Style = Prompt.ColorSet;
            base.Style = metroStyleManager1.Style;
            Refresh();
        }

    }
}
