using MetroFramework.Forms;
using Revamped_BnS_Buddy.Functions;
using System;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class enterCode : MetroForm
    {
        Form1 f1;

        public enterCode()
        {
            InitializeComponent();
            GetColor();
        }

        public enterCode(Form1 f)
        {
            InitializeComponent();
            GetColor();
            f1 = f;
        }

        private void GetColor()
        {
            base.Style = Prompt.ColorSet;
            Themer.Style = Prompt.ColorSet;
            Refresh();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            f1.termConnection();
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            f1.submitCode();
        }

        private void metroTextBox1_KeyPress(object sender, KeyEventArgs e)
        {
            if (metroTextBox1.Text.Length == 6)
            {
                if (e.KeyValue == (char)Keys.Return)
                {
                    f1.submitCode();
                }
            }

            if ((e.KeyValue >= '0' && e.KeyValue <= '9') || e.KeyValue == (Char)Keys.Delete || e.KeyValue == (Char)Keys.Back || e.Control && e.KeyValue == (Char)Keys.V || e.KeyValue >= 96 && e.KeyValue <= 105 || e.KeyValue == 37 || e.KeyValue == 39 || (e.Control && e.KeyValue == (Char)Keys.A)) //The  character represents a backspace
            {
                e.SuppressKeyPress = false; //Do not reject the input
            }
            else
            {
                e.SuppressKeyPress = true; //Reject the input
            }
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length == 6)
                metroButton1.Enabled = true;
            else
                metroButton1.Enabled = false;
        }
    }
}
