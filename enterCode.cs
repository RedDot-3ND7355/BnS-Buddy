using MetroFramework;
using MetroFramework.Forms;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class enterCode : MetroForm
    {
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
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
            base.Style = Themer.Style;
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
