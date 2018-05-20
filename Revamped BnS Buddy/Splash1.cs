using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Web.Security;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public unsafe partial class Splash1 : MetroFramework.Forms.MetroForm
    {
        public static Splash1 CurrentForm;

        //Form f = Application.OpenForms["Form1"];
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public unsafe string username = @"";
        public unsafe string password = @"";
        public unsafe string Protect;
        public unsafe string result;
        public unsafe string SALT = "";
        public bool remembered = false;
        public bool INTRUDER = false;
        public bool autologinapproved = false;

        public Splash1()
        {
            // Initialize Form
            InitializeComponent();
            // Get Color
            GetColor();
            // Proceed
            try
            {
                // Get Unique SALT
                SALT = Security.FingerPrint.Value();
                SALT = StringToHex(SALT);
                // Create unexistant registry key
                RegistryKey regKey = Registry.LocalMachine;
                if (regKey.OpenSubKey(@"SOFTWARE\BnS Buddy\") == null)
                {
                    Registry.LocalMachine.CreateSubKey("SOFTWARE\\BnS Buddy");
                }
                // Check if not already remembered
                if (File.ReadAllText(@AppPath + "\\Settings.ini").Contains("rememberme = true"))
                {
                    metroComboBox1.Enabled = true;
                    regKey = Registry.LocalMachine;
                    regKey = regKey.OpenSubKey(@"SOFTWARE\BnS Buddy\", true);

                    // Add | Delete | Sort -> Users
                    ReOrderTree(regKey);
                    // Continue

                    if (metroComboBox1.Items.Count >= 1)
                    {
                        // Select first found
                        metroComboBox1.SelectedIndex = 0;

                        // Select last used
                        if (regKey != null)
                        {
                            if (regKey.GetValue("lastused") != null)
                            {
                                string tmp_last = string.Empty;
                                tmp_last = regKey.GetValue("lastused").ToString();
                                if (tmp_last != null)
                                {
                                    if (tmp_last.Length > 1)
                                    {
                                        metroComboBox1.SelectedIndex = metroComboBox1.FindString(tmp_last);
                                        metroButton3.Visible = true;
                                    }
                                }
                            }
                        }

                        string tmp_user = string.Empty;
                        string tmp_pass = string.Empty;
                        if (regKey != null)
                        {
                            string tmp_select = metroComboBox1.SelectedItem.ToString();
                            tmp_user = regKey.OpenSubKey(tmp_select).GetValue("username").ToString();
                            tmp_pass = regKey.OpenSubKey(tmp_select).GetValue("password").ToString();
                            tmp_user = Dec(tmp_user);
                            tmp_pass = Dec(tmp_pass);
                            if (tmp_user.Length > 0 && tmp_pass.Length > 0)
                            {
                                metroTextBox1.Text = tmp_user;
                                metroTextBox2.Text = tmp_pass;
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

                // Check caps lock
                CheckLock();
            }
            catch { Prompt.Popup("Resetted Registry. Reasons below." + Environment.NewLine + "Possible causes include the following:" + Environment.NewLine + "- The protected data was tampered with and/or contained invalid characters."); ClearRegistry(); }
        }

        private void ReOrderTree(RegistryKey regKey)
        {
            bool DidItWork = false;
            // foreach account login saved, add to dropbox
            if (regKey != null)
            {
                foreach (string InReg in regKey.GetSubKeyNames())
                {
                    if (InReg != null)
                    {
                        // Original Reg Key
                        RegistryKey Original = regKey;
                        // String 1
                        string initial = InReg.ToString();
                        // String 2
                        string tmp_adder = regKey.OpenSubKey(InReg.ToString()).GetValue("username").ToString();
                        tmp_adder = Dec(tmp_adder);
                        if (tmp_adder.Length > 0)
                        {
                            string tmp_origin = tmp_adder.Substring(tmp_adder.IndexOf("@") + 1);
                            tmp_adder = tmp_adder.Substring(0, tmp_adder.IndexOf("@"));
                            // Compare
                            if (InReg.ToString() == (tmp_adder + " (" + tmp_origin + ") "))
                            {
                                if (!metroComboBox1.Items.Contains(tmp_adder + " (" + tmp_origin + ") "))
                                {
                                    metroComboBox1.Items.Add(tmp_adder + " (" + tmp_origin + ") ");
                                }
                            }
                            else // Convert if old then add
                            {
                                // Conversion
                                RegistryKey tmpkey = regKey;
                                tmpkey = tmpkey.OpenSubKey(InReg);
                                RenameSubKey(regKey, InReg.ToString(), tmp_adder + " (" + tmp_origin + ") ");
                                // Add
                                DidItWork = true;
                            }
                        }
                    }
                }
            }
            // Restart to Add
            if (DidItWork)
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

        public bool CopyKey(RegistryKey parentKey,
            string keyNameToCopy, string newKeyName)
        {
            //Create new key
            RegistryKey destinationKey = parentKey.CreateSubKey(newKeyName);

            //Open the sourceKey we are copying from
            RegistryKey sourceKey = parentKey.OpenSubKey(keyNameToCopy);

            RecurseCopyKey(sourceKey, destinationKey);

            return true;
        }

        private void RecurseCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
        {
            //copy all the values
            foreach (string valueName in sourceKey.GetValueNames())
            {
                object objValue = sourceKey.GetValue(valueName);
                RegistryValueKind valKind = sourceKey.GetValueKind(valueName);
                destinationKey.SetValue(valueName, objValue, valKind);
            }

            //For Each subKey
            //Create a new subKey in destinationKey
            //Call myself
            foreach (string sourceSubKeyName in sourceKey.GetSubKeyNames())
            {
                RegistryKey sourceSubKey = sourceKey.OpenSubKey(sourceSubKeyName);
                RegistryKey destSubKey = destinationKey.CreateSubKey(sourceSubKeyName);
                RecurseCopyKey(sourceSubKey, destSubKey);
            }
        }

        private void GetColor()
        {
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

        private string StringToHex(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char t in s)
            {
                sb.Append(Convert.ToInt32(t).ToString("x"));
            }
            return sb.ToString();
        }

        private string Enc(string s)
        {
            s = String.Concat(s, SALT);
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
                if (INTRUDER == false)
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
            RegistryKey regKey = Registry.LocalMachine;
            regKey = regKey.OpenSubKey(@"SOFTWARE\BnS Buddy\", true);
            foreach (string InReg in regKey.GetSubKeyNames())
            {
                Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).DeleteSubKeyTree(InReg.ToString());
            }
            if (regKey.GetValue("lastused") != null)
            {
                regKey.DeleteValue("lastused");
            }
        }

        public bool CheckIfAny()
        {
            // ini
            bool bool_data = false;
            int IfAny = 0;
            // reg
            RegistryKey regKey = Registry.LocalMachine;
            regKey = regKey.OpenSubKey(@"SOFTWARE\BnS Buddy\", true);
            // count
            foreach (string InReg in regKey.GetSubKeyNames())
            {
                IfAny++;
            }
            // check
            if (IfAny > 0)
            {
                bool_data = true;
            }
            // return
            return bool_data;
        }

        public void Perform()
        {
            // Login
            if ((metroTextBox1.Text != "") && (metroTextBox2.Text != ""))
            {
                metroButton1.Visible = false;
                try
                {
                    username = @metroTextBox1.Text.ToString();
                    password = @metroTextBox2.Text.ToString();

                    if (metroCheckBox1.CheckState == CheckState.Checked)
                    {
                        try
                        {
                            string input = metroTextBox1.Text;
                            string tmp_origin = input.Substring(input.IndexOf("@") + 1);
                            input = input.Substring(0, input.IndexOf("@"));

                            // Create lastused
                            Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).SetValue("lastused", input + " (" + tmp_origin + ") ", Microsoft.Win32.RegistryValueKind.String);
                            // Create entries
                            Registry.LocalMachine.CreateSubKey("SOFTWARE\\BnS Buddy\\" + input + " (" + tmp_origin + ") ");
                            Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\" + input + " (" + tmp_origin + ") ", true).SetValue("username", Enc(@metroTextBox1.Text), Microsoft.Win32.RegistryValueKind.String);
                            Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy\\" + input + " (" + tmp_origin + ") ", true).SetValue("password", Enc(@metroTextBox2.Text), Microsoft.Win32.RegistryValueKind.String);
                            if (File.ReadAllText(@AppPath + "\\Settings.ini").Contains("rememberme = false"))
                            {
                                string tmp = File.ReadAllText(@AppPath + "\\Settings.ini");
                                tmp = tmp.Replace("rememberme = false", "rememberme = true");
                                File.WriteAllText(@AppPath + "\\Settings.ini", tmp);
                            }
                        }
                        catch (Exception e)
                        {
                            Prompt.Popup(e.ToString());
                            // nothing here
                        }
                    }
                    else
                    {
                        try
                        {
                            string input = metroComboBox1.SelectedItem.ToString();
                            RegistryKey regKey = Registry.LocalMachine;
                            regKey = regKey.OpenSubKey(@"SOFTWARE\BnS Buddy\" + input + @"\");
                            string tmp_user = string.Empty;
                            string tmp_pass = string.Empty;
                            if (regKey != null)
                            {
                                Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).DeleteSubKeyTree(input);
                                if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).GetValue("lastused") != null)
                                {
                                    Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).DeleteValue("lastused");
                                }

                                if (CheckIfAny() == false)
                                {
                                    if (File.ReadAllText(@AppPath + "\\Settings.ini").Contains("rememberme = true"))
                                    {
                                        string tmp = File.ReadAllText(@AppPath + "\\Settings.ini");
                                        tmp = tmp.Replace("rememberme = true", "rememberme = false");
                                        File.WriteAllText(@AppPath + "\\Settings.ini", tmp);
                                    }
                                }
                            }
                        }
                        catch
                        {
                            // nothing here
                        }
                    }

                    this.Hide();
                    this.Close();
                }
                catch
                {
                    metroButton1.Visible = true;
                }
            }
            else if ((metroTextBox1.Text == "") || (metroTextBox2.Text == ""))
            {
                if ((metroTextBox1.Text == "") && (metroTextBox2.Text == ""))
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

        private string DataPath = Revamped_BnS_Buddy.Form1.CurrentForm.DataPath;

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        public void KillApp()
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            Prompt.Popup("Getting 'Wrong Password...' error?" + Environment.NewLine + "Password has to be the following." + Environment.NewLine + "Must be 8 - 16 characters long." + Environment.NewLine + "Must not be similar to your email address or date of birth." + Environment.NewLine + "Must contain at least one number." + Environment.NewLine + "Must contain at least one alphabetic character(A - Z)." + Environment.NewLine + "No more than 4 of the continuous number or letter in a row." + Environment.NewLine + "No more than 4 of the same number or letter in a row." + Environment.NewLine + Environment.NewLine + "If your password does not respect the following," + Environment.NewLine + "please change it.");
        }

        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            CheckLock();
            if (e.KeyCode == Keys.Enter)
            {
                Perform();
            }
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckLock();
            if (e.KeyCode == Keys.Enter)
            {
                Perform();
            }
        }

        private void CheckLock()
        {
            if (IsKeyLocked(Keys.CapsLock))
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
                string user = metroComboBox1.SelectedItem.ToString();
                //user = user.Substring(0, user.IndexOf(" "));
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\BnS Buddy\");
                string tmp_user = string.Empty;
                string tmp_pass = string.Empty;
                if (regKey != null)
                {
                    tmp_user = regKey.OpenSubKey(user).GetValue("username").ToString();
                    tmp_pass = regKey.OpenSubKey(user).GetValue("password").ToString();
                    tmp_user = Dec(tmp_user);
                    tmp_pass = Dec(tmp_pass);
                    if (tmp_user.Length > 0 && tmp_pass.Length > 0)
                    {
                        metroTextBox1.Text = tmp_user;
                        metroTextBox2.Text = tmp_pass;
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
                // nothing here
            }
        }

        public static class Prompt
        {
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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string input = metroComboBox1.SelectedItem.ToString();
                RegistryKey regKey = Registry.LocalMachine;
                regKey = regKey.OpenSubKey(@"SOFTWARE\BnS Buddy\" + input + @"\");
                string tmp_user = string.Empty;
                string tmp_pass = string.Empty;
                if (regKey != null)
                {
                    Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).DeleteSubKeyTree(input);
                    if (Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).GetValue("lastused") != null)
                    {
                        Registry.LocalMachine.OpenSubKey("SOFTWARE\\BnS Buddy", true).DeleteValue("lastused");
                    }
                    metroButton3.Visible = false;
                    metroTextBox1.Text = "";
                    metroTextBox2.Text = "";
                }
                metroComboBox1.Items.Remove(input);
            }
            catch
            {
                Prompt.Popup("Error: Could not Forget user!");
            }
        }

        private void Splash1_Shown(object sender, EventArgs e)
        {
            // Auto Login
            if (File.ReadAllText(@AppPath + "\\Settings.ini").Contains("autologin = true"))
            {
                // Skip if multiclient is active :3
                if (Form1.CurrentForm.metroLabel81.Text != "Active" && Form1.CurrentForm.metroLabel82.Text != "Active")
                {
                    if (autologinapproved)
                    {
                        Perform();
                    }
                }
            }
        }

        private static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void metroCheckBox1_Click(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                lineChanger("rememberme = true", @AppPath + "\\Settings.ini", 31);
                Form1.CurrentForm.metroToggle28.Checked = true;
            }
            else
            {
                lineChanger("rememberme = false", @AppPath + "\\Settings.ini", 31);
                Form1.CurrentForm.metroToggle28.Checked = false;
            }
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length >= 40)
            {
                metroTextBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Light;
            }
            else if (metroTextBox1.Text.Length <= 39)
            {
                metroTextBox1.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            }
        }
    }
}

namespace Security
{
    /// <summary>
    /// Generates a 16 byte Unique Identification code of a computer
    /// Example: 4876-8DB5-EE85-69D3-FE52-8CF7-395D-2EA9
    /// </summary>
    public class FingerPrint
    {
        private static string fingerPrint = string.Empty;

        public static string Value()
        {
            fingerPrint = String.Empty;
            if (string.IsNullOrEmpty(fingerPrint))
            {
                string a1 = null;
                string a2 = null;
                string a3 = null;
                try
                {
                    a1 = cpuId();
                }
                catch { a1 = ""; }
                try
                {
                    a2 = biosId();
                }
                catch { a2 = ""; }
                try
                {
                    a3 = baseId();
                }
                catch { a3 = ""; }
                string test = "";
                if (a1 != null || a1 != "")
                {
                    test += a1;
                }
                if (a2 != null || a2 != "")
                {
                    test += a2;
                }
                if (a3 != null || a3 != "")
                {
                    test += a3;
                }
                if (test.Contains(" "))
                {
                    test += test.Replace(" ", "");
                }
                fingerPrint = test.Trim();
            }
            return fingerPrint;
        }

        #region Original Device ID Getting Code

        //Return a hardware identifier
        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            ManagementClass mc = new ManagementClass(wmiClass);
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        if (mo[wmiProperty] != null)
                            result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                        // nothing here
                    }
                }
            }
            return result;
        }

        private static string cpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as it is very time consuming
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }
                }
            }
            return retVal;
        }

        //BIOS Identifier
        private static string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
            + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber")
            + identifier("Win32_BIOS", "ReleaseDate")
            + identifier("Win32_BIOS", "Version");
        }

        //Motherboard ID
        private static string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
            + identifier("Win32_BaseBoard", "Manufacturer")
            + identifier("Win32_BaseBoard", "Name")
            + identifier("Win32_BaseBoard", "SerialNumber");
        }

        #endregion Original Device ID Getting Code
    }
}