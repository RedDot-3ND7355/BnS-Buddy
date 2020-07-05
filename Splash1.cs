using MetroFramework;
using MetroFramework.Forms;
using Microsoft.Win32;
using Revamped_BnS_Buddy.Functions;
using Security;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class Splash1 : MetroForm
    {
        public Splash1()
        {
            InitializeComponent();
            GetColor();
            try
            {
                SALT = FingerPrint.Value();
                SALT = StringToHex(SALT);
                RegistryKey localMachine = Registry.LocalMachine;
                if (localMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\") == null)
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\BnS Buddy");
                }
                if (File.ReadAllText(Prompt.AppPath + "\\Settings.ini").Contains("rememberme = true"))
                {
                    metroComboBox1.Enabled = true;
                    localMachine = Registry.LocalMachine;
                    localMachine = localMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\", writable: true);
                    ReOrderTree(localMachine);
                    if (metroComboBox1.Items.Count >= 1)
                    {
                        metroComboBox1.SelectedIndex = 0;
                        if (localMachine != null && localMachine.GetValue("lastused") != null)
                        {
                            string empty = string.Empty;
                            empty = localMachine.GetValue("lastused").ToString();
                            if (empty != null && empty.Length > 1)
                            {
                                metroComboBox1.SelectedIndex = metroComboBox1.FindString(empty);
                                metroButton3.Visible = true;
                            }
                        }
                        string empty2 = string.Empty;
                        string empty3 = string.Empty;
                        if (localMachine != null)
                        {
                            string name = metroComboBox1.SelectedItem.ToString();
                            empty2 = localMachine.OpenSubKey(name).GetValue("username").ToString();
                            empty3 = localMachine.OpenSubKey(name).GetValue("password").ToString();
                            empty2 = Dec(empty2);
                            empty3 = Dec(empty3);
                            if (empty2.Length > 0 && empty3.Length > 0)
                            {
                                metroTextBox1.Text = empty2;
                                metroTextBox2.Text = empty3;
                                metroCheckBox1.CheckState = CheckState.Checked;
                                metroButton3.Visible = true;
                                autologinapproved = true;
                            }
                            else
                            {
                                metroCheckBox1.CheckState = CheckState.Unchecked;
                                metroButton3.Visible = false;
                            }
                        }
                    }
                }
                CheckLock();
            }
            catch
            {
                Prompt.Popup("Resetted Registry. Reasons below." + Environment.NewLine + "Possible causes include the following:" + Environment.NewLine + "- The protected data was tampered with and/or contained invalid characters.");
                Form1.CurrentForm.metroToggle28.CheckState = CheckState.Unchecked;
                Form1.CurrentForm.metroToggle28.Checked = false;
                ClearRegistry();
            }
        }

        public static Splash1 CurrentForm;

        public string username = "";

        public string password = "";

        public string Protect;

        public string result;

        public string SALT = "";

        public bool remembered;

        public bool INTRUDER;

        public bool autologinapproved;

        private string DataPath = Form1.CurrentForm.DataPath;

        private void ReOrderTree(RegistryKey regKey)
        {
            bool flag = false;
            if (regKey != null)
            {
                string[] subKeyNames = regKey.GetSubKeyNames();
                foreach (string text in subKeyNames)
                {
                    if (text != null)
                    {
                        text.ToString();
                        string s = regKey.OpenSubKey(text.ToString()).GetValue("username").ToString();
                        s = Dec(s);
                        if (s.Length > 0)
                        {
                            string str = s.Substring(s.IndexOf("@") + 1);
                            s = s.Substring(0, s.IndexOf("@"));
                            if (text.ToString() == s + " (" + str + ") ")
                            {
                                if (!metroComboBox1.Items.Contains(s + " (" + str + ") "))
                                {
                                    metroComboBox1.Items.Add(s + " (" + str + ") ");
                                }
                            }
                            else
                            {
                                regKey.OpenSubKey(text);
                                RenameSubKey(regKey, text.ToString(), s + " (" + str + ") ");
                                flag = true;
                            }
                        }
                    }
                }
            }
            if (flag)
            {
                ReOrderTree(regKey);
            }
        }

        public bool RenameSubKey(RegistryKey parentKey, string subKeyName, string newSubKeyName)
        {
            CopyKey(parentKey, subKeyName, newSubKeyName);
            if (subKeyName != null)
            {
                parentKey.DeleteSubKeyTree(subKeyName);
            }
            return true;
        }

        public bool CopyKey(RegistryKey parentKey, string keyNameToCopy, string newKeyName)
        {
            RegistryKey destinationKey = parentKey.CreateSubKey(newKeyName);
            RegistryKey sourceKey = parentKey.OpenSubKey(keyNameToCopy);
            RecurseCopyKey(sourceKey, destinationKey);
            return true;
        }

        private void RecurseCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
        {
            string[] valueNames = sourceKey.GetValueNames();
            foreach (string name in valueNames)
            {
                object value = sourceKey.GetValue(name);
                RegistryValueKind valueKind = sourceKey.GetValueKind(name);
                destinationKey.SetValue(name, value, valueKind);
            }
            valueNames = sourceKey.GetSubKeyNames();
            foreach (string text in valueNames)
            {
                RegistryKey sourceKey2 = sourceKey.OpenSubKey(text);
                RegistryKey destinationKey2 = destinationKey.CreateSubKey(text);
                RecurseCopyKey(sourceKey2, destinationKey2);
            }
        }

        private void GetColor()
        {
            Themer.Style = Prompt.ColorSet;
            base.Style = Themer.Style;

            metroComboBox1.Theme = MetroThemeStyle.Dark;
            metroComboBox1.Style = Themer.Style;

            if (Themer.Style == MetroColorStyle.White)
            {
                metroComboBox1.Theme = MetroThemeStyle.Light;
                metroComboBox1.Style = MetroColorStyle.Silver;
            }

            Refresh();
        }

        private string StringToHex(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char value in s)
            {
                stringBuilder.Append(Convert.ToInt32(value).ToString("x"));
            }
            return stringBuilder.ToString();
        }

        private string Enc(string s)
        {
            s += SALT;
            s = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(s), "Basic Enc"));
            return s;
        }

        private string Dec(string s)
        {
            s = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(s), "Basic Enc"));
            if (s.Contains(SALT))
            {
                s = s.Replace(SALT, "");
            }
            else
            {
                s = "";
                if (!INTRUDER)
                {
                    Prompt.Popup("Did you changed hardware? Because I don't recognize you.");
                    metroComboBox1.Enabled = false;
                    ClearRegistry();
                    INTRUDER = true;
                }
            }
            return s;
        }

        public void ClearRegistry()
        {
            RegistryKey localMachine = Registry.LocalMachine;
            localMachine = localMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\", writable: true);
            string[] subKeyNames = localMachine.GetSubKeyNames();
            foreach (string text in subKeyNames)
            {
                Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).DeleteSubKeyTree(text.ToString());
            }
            if (localMachine.GetValue("lastused") != null)
            {
                localMachine.DeleteValue("lastused");
            }
        }

        public bool CheckIfAny()
        {
            bool flag = false;
            int num = 0;
            string[] subKeyNames = Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\", writable: true).GetSubKeyNames();
            for (int i = 0; i < subKeyNames.Length; i++)
            {
                string text = subKeyNames[i];
                num++;
            }
            if (num > 0)
            {
                flag = true;
            }
            return flag;
        }

        public void Perform()
        {
            if (metroTextBox1.Text != "" && metroTextBox2.Text != "")
            {
                metroButton1.Visible = false;
                try
                {
                    username = metroTextBox1.Text.ToLower().Replace(" ", "");
                    password = metroTextBox2.Text;
                    if (metroCheckBox1.CheckState != CheckState.Checked)
                    {
                        try
                        {
                            string text = metroComboBox1.SelectedItem.ToString();
                            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\" + text + "\\");
                            string empty = string.Empty;
                            string empty2 = string.Empty;
                            if (registryKey != null)
                            {
                                Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).DeleteSubKeyTree(text);
                                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).GetValue("lastused") != null)
                                {
                                    Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).DeleteValue("lastused");
                                }
                                if (!CheckIfAny() && File.ReadAllText(Prompt.AppPath + "\\Settings.ini").Contains("rememberme = true"))
                                {
                                    string text2 = File.ReadAllText(Prompt.AppPath + "\\Settings.ini");
                                    text2 = text2.Replace("rememberme = true", "rememberme = false");
                                    File.WriteAllText(Prompt.AppPath + "\\Settings.ini", text2);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        try
                        {
                            Regex regex = new Regex(@"^[\w\.\-]+@[\w\-]+(?:\.\w{2,5})+$");
                            Match match = regex.Match(@metroTextBox1.Text);
                            if (match.Success)
                            {
                                string text3 = metroTextBox1.Text;
                                string text4 = text3.Substring(text3.IndexOf("@") + 1);
                                text3 = text3.Substring(0, text3.IndexOf("@"));
                                Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).SetValue("lastused", text3 + " (" + text4 + ") ", RegistryValueKind.String);
                                Registry.LocalMachine.CreateSubKey("SOFTWARE\\BnS Buddy\\" + text3 + " (" + text4 + ") ");
                                Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\" + text3 + " (" + text4 + ") ", writable: true).SetValue("username", Enc(metroTextBox1.Text), RegistryValueKind.String);
                                Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\" + text3 + " (" + text4 + ") ", writable: true).SetValue("password", Enc(metroTextBox2.Text), RegistryValueKind.String);
                                if (File.ReadAllText(Prompt.AppPath + "\\Settings.ini").Contains("rememberme = false"))
                                {
                                    string text5 = File.ReadAllText(Prompt.AppPath + "\\Settings.ini");
                                    text5 = text5.Replace("rememberme = false", "rememberme = true");
                                    File.WriteAllText(Prompt.AppPath + "\\Settings.ini", text5);
                                }
                            }
                            else { Prompt.Popup("Invalid character detected, please try again."); }
                        }
                        catch (Exception ex)
                        {
                            Prompt.Popup(ex.ToString());
                        }
                    }
                    Hide();
                    Close();
                }
                catch
                {
                    metroButton1.Visible = true;
                }
            }
            else if (metroTextBox1.Text == "" || metroTextBox2.Text == "")
            {
                if (metroTextBox1.Text == "" && metroTextBox2.Text == "")
                {
                    Prompt.Popup("Fields are empty!");
                    metroButton1.Visible = true;
                }
                else
                {
                    Prompt.Popup("One of the fields are empty!");
                    metroButton1.Visible = true;
                }
            }
            else
            {
                Prompt.Popup("Error!");
                metroButton1.Visible = true;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Perform();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Hide();
            Close();
        }
        public void KillApp()
        {
            Process.GetCurrentProcess().Kill();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            Prompt.Popup("Getting 'Wrong Password...' error?" + Environment.NewLine + "Password has to be the following." + Environment.NewLine + "Must be 8 - 16 characters long." + Environment.NewLine + "Must not be similar to your email address or date of birth." + Environment.NewLine + "Must contain at least one number." + Environment.NewLine + "Must contain at least one alphabetic character(A - Z)." + Environment.NewLine + "No more than 4 of the continuous number or letter in a row." + Environment.NewLine + "No more than 4 of the same number or letter in a row." + Environment.NewLine + Environment.NewLine + "If your password does not respect the following," + Environment.NewLine + "please change it.");
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            CheckLock();
            if (e.KeyCode == Keys.Return)
            {
                Perform();
            }
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckLock();
            if (e.KeyCode == Keys.Return)
            {
                Perform();
            }
        }

        private void CheckLock()
        {
            if (Control.IsKeyLocked(Keys.Capital))
            {
                metroLabel4.Visible = true;
            }
            else
            {
                metroLabel4.Visible = false;
            }
        }

        private void Splash1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckLock();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string name = metroComboBox1.SelectedItem.ToString();
                RegistryKey localMachine = Registry.LocalMachine;
                localMachine = localMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\");
                string empty = string.Empty;
                string empty2 = string.Empty;
                if (localMachine != null)
                {
                    empty = localMachine.OpenSubKey(name).GetValue("username").ToString();
                    empty2 = localMachine.OpenSubKey(name).GetValue("password").ToString();
                    empty = Dec(empty);
                    empty2 = Dec(empty2);
                    if (empty.Length > 0 && empty2.Length > 0)
                    {
                        metroTextBox1.Text = empty;
                        metroTextBox2.Text = empty2;
                        metroButton3.Visible = true;
                    }
                    else
                    {
                        metroButton3.Visible = false;
                    }
                }
            }
            catch
            {
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string text = metroComboBox1.SelectedItem.ToString();
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\" + text + "\\");
                string empty = string.Empty;
                string empty2 = string.Empty;
                if (registryKey != null)
                {
                    Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).DeleteSubKeyTree(text);
                    if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).GetValue("lastused") != null)
                    {
                        Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", writable: true).DeleteValue("lastused");
                    }
                    metroButton3.Visible = false;
                    metroTextBox1.Text = "";
                    metroTextBox2.Text = "";
                }
                metroComboBox1.Items.Remove(text);
            }
            catch
            {
                Prompt.Popup("Error: Could not Forget user!");
            }
        }

        private void Splash1_Shown(object sender, EventArgs e)
        {
            if (File.ReadAllText(Prompt.AppPath + "\\Settings.ini").Contains("autologin = true") && Form1.CurrentForm.metroLabel81.Text != "Active" && Form1.CurrentForm.metroLabel82.Text != "Active" && autologinapproved)
            {
                Perform();
            }
        }

        private static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] array = File.ReadAllLines(fileName);
            array[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, array);
        }

        private void metroCheckBox1_Click(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                lineChanger("rememberme = true", Prompt.AppPath + "\\Settings.ini", 31);
                Form1.CurrentForm.metroToggle28.Checked = true;
            }
            else
            {
                lineChanger("rememberme = false", Prompt.AppPath + "\\Settings.ini", 31);
                Form1.CurrentForm.metroToggle28.Checked = false;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length >= 40)
            {
                metroTextBox1.FontWeight = MetroTextBoxWeight.Light;
            }
            else if (metroTextBox1.Text.Length <= 39)
            {
                metroTextBox1.FontWeight = MetroTextBoxWeight.Regular;
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Splash1_Load(object sender, EventArgs e)
        {

        }
    }
}
