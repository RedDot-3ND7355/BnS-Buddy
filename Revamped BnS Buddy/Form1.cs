using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Net;
using System.Security.Cryptography;
using Revamped_BnS_Buddy.Properties;
using System.Threading;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using System.Xml;
using System.Drawing;
using FastColoredTextBoxNS;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using SharpCompress;
using SharpCompress.Archive;
using SharpCompress.Common;
using System.Windows.Controls;
using Ionic.Zlib;

namespace Revamped_BnS_Buddy
{
    

    // Things marked with "HEY!" Are unfinished and to be completed :)
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        // static form
        public static Form1 CurrentForm;
        //
        public string LauncherPath = "\\bin";
        public string LauncherPath64 = "\\bin64";
        public string regionIDValue = "";
        public string TempPath = Path.GetTempPath();
        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);
        public string mine = Process.GetCurrentProcess().Id.ToString();
        public string IP = "64.25.35.100";
        public string regionID = "0";
        public string languageID = "English";
        public string LaunchPath = "";
        public string NoTextureStreaming = "";
        public string Unattended = "";
        public string ms = " ms";
        public string s = "";
        public string ping = "";
        public string FullPath = "";
        public string DataPath = "";
        public string FullBackupPath = "";
        public string DatPath = "";
        public string RegPath = "";
        public string RegPathlol = "";
        public string GamePath = "";
        public string defaultclient = "";
        // Taiwan
        public string TaiwanPath = "";
        // End Taiwan
        public string CustomGamePath = "";
        public string CustomClientPath = "";
        public string DefaultValues = "unattended = false" + Environment.NewLine + "notexturestreaming = false" + Environment.NewLine + "savelogs = false" + Environment.NewLine + "showlogs = true" + Environment.NewLine + "variables = false" + Environment.NewLine + "tooltips = true" + Environment.NewLine + "customgame = false" + Environment.NewLine + "customclient = false" + Environment.NewLine + "admincheck = true" + Environment.NewLine + "ncsoftlogin = false" + Environment.NewLine + "showdonate = true" + Environment.NewLine + "minimize = true" + Environment.NewLine + "launcherlogs = false" + Environment.NewLine + "modmanlogs = false" + Environment.NewLine + "customclientpath = " + Environment.NewLine + "customgamepath = " + Environment.NewLine + "updatechecker = true" + Environment.NewLine + "pingchecker = true" + Environment.NewLine + "gamekiller = true" + Environment.NewLine + "useallcores = false" + Environment.NewLine + "arguements = " + Environment.NewLine + "prtime = 500" + Environment.NewLine + "autoupdate = true" + Environment.NewLine + "firsttime = true" + Environment.NewLine + "default = " + Environment.NewLine + "defaultset = false" + Environment.NewLine + "defaultclient =  ";
        public string ActiveDataFile = "";
        public string XmlSavePath = "";
        public string NewDat = "";
        public string UseAllCores = "";
        public string LoadingSplash = "";
        public bool Backup = false;
        public bool PathFound = true;
        public bool logs_active = true;
        public bool GameStarted = false;
        public bool SaveLogs = false;
        public bool LauncherLogs = false;
        public bool ModManLogs = false;
        public bool AdminCheck = true;
        public bool AllowMinimize = true;
        public bool ShowLogs = true;
        public bool CustomGameSet = false;
        public bool CustomClientSet = false;
        public bool GameKiller = true;
        public bool UpdateChecker = true;
        public bool PingChecker = true;
        public bool nonmodded = false;
        public bool AutoUpdate = true;
        public bool FirstTime = true;
        public bool MultipleInstallationFound = false;
        public string online = "";
        public string offline = "";
        public int bad = Convert.ToInt32("120");
        public int medium = Convert.ToInt32("65");
        public int good = Convert.ToInt32("1");
        public int wakeywakey = 500;
        public BackgroundWorker bw1;
        public BackgroundWorker bw2;
        public BackgroundWorker bw3;
        public BackgroundWorker bnsdat;
        public BackgroundWorker bnsdatc;
        public Form2 s2;
        // Seperator
        public Form1()
        {
            /* Static Form */
            CurrentForm = this;
            /* Initialize Form */
            InitializeComponent();
            /* Check Settings Tab */
            CheckTab();
            /* First time user setting */
            FirstTimeUse();
            /* Splash to hide loading */
            SplashScreen();
            /* Kill Game if running */
            KillGame();
            //////////////////
            //  Seperator   //
            // Launcher Tab //
            //////////////////
            // Set Ping to Server
            SetPing();
            // 1: Check Registry for Dir(Game) | 2: Auto browser and Set Path to CookedPC | 3: Set Global Variables
            try
            {
                if (CustomGameSet == false)
                {
                    BnSFolder();
                }
            } catch(Exception e) { Prompt.Popup(e.ToString()); }
            // Check backup for Loading Screen
            CheckBackup();
            // 1: Check Registry for Dir(Client) | 2: Auto ini reader to Path | 3: Set Global Variables
            try
            {
                if (CustomClientSet == false)
                {
                    CheckServer();
                }
            } catch(Exception e) { Prompt.Popup(e.ToString()); }
            VerifySettings();
            ///////////////////////
            //     Seperator     //
            // Splash Screen Tab //
            ///////////////////////
            GetPaths();
            Verify();
            InitializeSplash();
            /////////////////////
            //    Seperator    //
            // Mod Manager Tab //
            /////////////////////
            InitializeManager();
            GetPath();
            JsonManager();
            PopulateTreeView(FullModPathMan);
            VerifyUsage();
            ////////////////////
            //    Seperator   //
            // Dat Editor Tab //
            ////////////////////
            CleanMess();
            DefaultDatValues();
            CreateDatPaths();
            ///////////////
            // Seperator //
            //   MISCS   //
            ///////////////
            // Launching Details
            Details();
            // Fix .Dat Sizes
            FixSizes();
            // Form Ready!
            EnableForm1();
        }

        public void KillApp()
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }

        public void FirstTimeUse() 
        {
            if (FirstTime == true)
            {
                DialogResult dialogResult = Prompt.FirstTimeUse();
                if (dialogResult == DialogResult.Yes)
                {
                    var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                    fileContents = fileContents.Replace("firsttime = true", "firsttime = false");
                    System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = false"))
                    {
                        fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = false", "autoupdate = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                    fileContents = fileContents.Replace("firsttime = true", "firsttime = false");
                    System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = true"))
                    {
                        fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = true", "autoupdate = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                } else { /* skip */ }
            }
        }

        bool Reg64 = false;
        Dictionary<string, string> Installs = new Dictionary<string, string>();
        public void GetRegDir()
        {
            // Step 1
            // Get Dir
                AddTextLog("Reading Registry...");
                try
                {
                    RegistryKey regKey = Registry.LocalMachine;
                    regKey = regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\NCWest\BnS\");
                    if (regKey != null)
                    {
                        string unique = regKey.GetValue("BaseDir").ToString();
                        if (workedREG == false)
                        {
                            RegPath = regKey.GetValue("BaseDir").ToString();
                        }
                        AddTextLog(unique);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Reg64 = true;
                        Installs.Add("NA/EU", unique);
                    }
                }
                catch { AddTextLog("Null Value of RegKey"); }
                try
                {
                    RegistryKey regKey = Registry.LocalMachine;
                    regKey = regKey.OpenSubKey(@"SOFTWARE\NCWest\BnS\");
                    if (regKey != null)
                    {
                        string unique = regKey.GetValue("BaseDir").ToString();
                        if (workedREG == false)
                        {
                            RegPath = regKey.GetValue("BaseDir").ToString();
                        }
                        AddTextLog(unique);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Installs.Add("NA/EU", unique);
                    }
                }
                catch { AddTextLog("Null Value of RegKey"); }
                try
                {
                    RegistryKey regKey = Registry.LocalMachine;
                    regKey = regKey.OpenSubKey(@"SOFTWARE\NCTaiwan\TWBNS22\");
                    if (regKey != null)
                    {
                        string unique = regKey.GetValue("BaseDir").ToString();
                        if (workedREG == false)
                        {
                            RegPath = regKey.GetValue("BaseDir").ToString();
                        }
                        AddTextLog(unique);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Installs.Add("Taiwan", unique);
                    }
                }
                catch { AddTextLog("Null Value of RegKey"); }
                try
                {
                    RegistryKey regKey = Registry.LocalMachine;
                    regKey = regKey.OpenSubKey(@"SOFTWARE\Wow6432Node\NCTaiwan\TWBNS22\");
                    if (regKey != null)
                    {
                        string unique = regKey.GetValue("BaseDir").ToString();
                        if (workedREG == false)
                        {
                            RegPath = regKey.GetValue("BaseDir").ToString();
                        }
                        AddTextLog(unique);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Reg64 = true;
                        Installs.Add("Taiwan", unique);
                    }
                }
                catch { AddTextLog("Null Value of RegKey"); }
            if (workedREG == false)
            {
                RegPath = null;
                AddTextLog("Error: RegKey = " + RegPath);
            }
            if (Installs.Count > 1)
            {
                if (MultipleInstallationFound == false)
                {
                    AddTextLog("Multiple Installations Found!");
                    string promptValue = Prompt.MultipleInstallation("Multiple installations of BnS has been found!" + Environment.NewLine + "Wich version would you like to use?", "Warning!", Installs);
                    RegPath = promptValue;
                    SaveDefault(promptValue);
                    Prompt.Popup("Notice: You can always remove the default installation in settings.");
                }
            }
        }

        public void SaveDefaultClient(string val)
        {
            try
            {
                // Do default = path
                lineChanger("defaultclient = " + val, @AppPath + "\\Settings.ini", 27);
                // Change label val
                metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(val);
                // Done
            }
            catch { AddTextLog("Error: Could not save default client!"); }
        }

        public void SaveDefault(string val)
        {
            try
            {
                // Do defaultset = true
                var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                fileContents = fileContents.Replace("defaultset = false", "defaultset = true");
                System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                // Do default = path
                lineChanger("default = " + val, @AppPath + "\\Settings.ini", 25);
                // Change label val
                metroLabel48.Text = val;
                // Done
            } catch { AddTextLog("Error: Could not save default installation!"); }
        }

        public static class Prompt
        {
            public static string MultipleInstallation(string Description, string Title, Dictionary<string, string> installs)
            {
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = Title,
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Left = 5, Top = 20, Text = Description, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroComboBox combobox = new MetroFramework.Controls.MetroComboBox() { Left = 5, Top = 70, Width = 270, Theme = MetroFramework.MetroThemeStyle.Dark, ImeMode = ImeMode.NoControl };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Ok", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.OK, Theme = MetroFramework.MetroThemeStyle.Dark };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                combobox.Text = "Choose Default Installation";
                if (installs.ContainsKey("NA/EU"))
                { 
                    if (installs["NA/EU"].ToString().Length > 1)
                    {
                        combobox.Items.Add("NA/EU");
                    }
                }
                if (installs.ContainsKey("NA/EU"))
                {
                    if (installs["Taiwan"].ToString().Length > 1)
                    {
                        combobox.Items.Add("Taiwan");
                    }
                }
                prompt.Controls.Add(combobox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                prompt.ShowDialog();
                if (combobox.SelectedItem.ToString() == "Choose Default Installation")
                {
                    combobox.SelectedIndex = 0;
                }
                return installs[combobox.SelectedItem.ToString()].ToString();
            }

            public static void Popup(string Message)
            {
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
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { AutoSize = true, Left = 5, Top = 20, Text = Message, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Ok", Left = 5, Width = 100, Top = 130, DialogResult = DialogResult.OK, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                prompt.ShowDialog();
            }

            public static DialogResult FirstTimeUse()
            {
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Text = "Would you like to run automatic updates for each run?", AutoSize = true, Left = 5, Top = 20, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "Yes", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.Yes, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton nobutton = new MetroFramework.Controls.MetroButton() { Text = "No", Left = 125, Width = 100, Top = 100, DialogResult = DialogResult.No, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(nobutton);
                prompt.AcceptButton = confirmation;
                prompt.AcceptButton = nobutton;
                DialogResult test = prompt.ShowDialog();
                return test;
            }

            public static DialogResult MultipleClient()
            {
                ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
                MetroFramework.Forms.MetroForm prompt = new MetroFramework.Forms.MetroForm()
                {
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon"))),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroFramework.MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroFramework.Controls.MetroLabel textLabel = new MetroFramework.Controls.MetroLabel() { Text = "32bit and 64bit clients were found. Wich would you like to use by default?", AutoSize = true, Left = 5, Top = 20, Width = 270, Height = 40, TextAlign = ContentAlignment.MiddleCenter, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton confirmation = new MetroFramework.Controls.MetroButton() { Text = "32 bit", Left = 5, Width = 100, Top = 100, DialogResult = DialogResult.Yes, Theme = MetroFramework.MetroThemeStyle.Dark };
                MetroFramework.Controls.MetroButton nobutton = new MetroFramework.Controls.MetroButton() { Text = "64 bit", Left = 125, Width = 100, Top = 100, DialogResult = DialogResult.No, Theme = MetroFramework.MetroThemeStyle.Dark };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(nobutton);
                prompt.AcceptButton = confirmation;
                prompt.AcceptButton = nobutton;
                DialogResult test = prompt.ShowDialog();
                return test;
            }
        }

        string autofinder = "";
        string autocook = "";
        public void AutoDirFinder()
        {
            // Step 2
            string AutoFoundModPath = "";
            if (Directory.Exists(RegPath + "\\contents\\Local"))
            {
                DirectoryInfo path = new DirectoryInfo(RegPath + "\\contents\\Local");
                foreach (DirectoryInfo subdir in path.GetDirectories())
                {
                    if (Directory.Exists(RegPath + "\\contents\\Local\\" + subdir.ToString() + "\\data"))
                    {
                        autofinder = subdir.ToString();
                        DirectoryInfo path2 = new DirectoryInfo(RegPath + "\\contents\\Local\\" + autofinder);
                        foreach (DirectoryInfo subdir2 in path2.GetDirectories())
                        {
                            if (Directory.Exists(RegPath + "\\contents\\Local\\" + autofinder + "\\" + subdir2.ToString() + "\\CookedPC"))
                            {
                                autocook = subdir2.ToString();
                            }
                        }
                    }
                }
                AutoFoundModPath = RegPath + "\\contents\\Local\\" + autofinder + "\\" + autocook + "\\CookedPC";
            }
            
            if (Directory.Exists(AutoFoundModPath))
            {
                // Permanent
                string langpath = "";
                // Temporary
                string orig = "";
                string tmp = "";
                // Default
                GamePath = AutoFoundModPath;
                try
                {
                    //////////////////////////
                    AddTextLog("Path Found!");
                    //////////////////////////
                    //   Find Lang of game  //
                    //////////////////////////
                    orig = GamePath; ;
                    tmp = Path.GetFileName(orig.Replace("\\CookedPC", "")).ToString();
                    langpath = tmp;
                    //////////////////////////
                    AddTextLog("Lang Found!");
                    //////////////////////////
                    //    Set after Found   //
                    //////////////////////////
                } catch(Exception e) { Prompt.Popup("Error: Couldnt find game Language & it's container." + Environment.NewLine + e.ToString()); }

                if (langpath == "ENGLISH")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("English");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                }
                else if (langpath == "FRENCH")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("French");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                }
                else if (langpath == "GERMAN")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("German");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                }
                else if (langpath == "CHINESET")
                {
                    FullPath = GamePath; metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Taiwan");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                }
                else
                {
                    FullPath = GamePath;
                    AddTextLog("Lang/Path Unknown!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    // Add custom option since we don't know what it is.
                    metroComboBox2.Items.Add(langpath);
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact(langpath);
                    // End adding
                }
                if (PathFound == true)
                {
                    FullBackupPath = GamePath.Replace("\\" + langpath + "\\CookedPC", "\\data\\backup");
                    if (!Directory.Exists(FullBackupPath)) { Directory.CreateDirectory(FullBackupPath); }
                }
            }
            else
            {
                PathFound = false;
                AddTextLog("Error: Path Not Found!");
                Prompt.Popup("Please select the BnS folder name in your Blade and Soul installation!");
                AddTextLog("Opening Dialog...");
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Select BnS folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(dlg.SelectedPath + "\\bin\\Client.exe") || File.Exists(dlg.SelectedPath + "\\bin64\\Client.exe"))
                        {
                            RegPath = dlg.SelectedPath;
                            AddTextLog("Path Inputed Found!");
                            // Auto Dir Finder
                            AutoDirFinder();
                            metroButton1.Enabled = true;
                            PathFound = true;
                            metroToggle1.Enabled = true;
                        }
                        else
                        {
                            AddTextLog("BnS Folder Not Found!");
                        }
                    }
                    else
                    {
                        Prompt.Popup("Error: Cancelled operation!");
                        KillApp();
                    }
                }
            }
        }

        public void SetBnSFolder()
        {
            // Step 3
            if (autocook != "")
            {
                DataPath = FullPath.Replace("\\" + autocook + "\\CookedPC", "\\data");
                if (!Directory.Exists(DataPath)) { Prompt.Popup("Error: Invalid Data Path!" + Environment.NewLine + "Path: " + DataPath); }
            }
            else
            {
                AddTextLog("Could not set DataPath!");
            }
        }

        public bool AppStarted = false;
        public void EnableForm1()
        {
            CheckForIllegalCrossThreadCalls = false;
            Enabled = true;
            bw3.Dispose();
            bw3.CancelAsync();
            Show();
            AppStarted = true;
            // Check for updates
            UpdateCheck();
            // Make sure app shows after load
            TopMost = true;
            TopMost = false;
            // Switch tab to Launcher
            metroTabControl1.SelectTab(0);
            // Switch Settings tab to Page 1
            metroTabControl2.SelectTab(0);
        }

        public void SplashScreen()
        {
            CheckForIllegalCrossThreadCalls = false;
            Hide();
            bw3 = new BackgroundWorker();
            bw3.WorkerSupportsCancellation = true;
            bw3.WorkerReportsProgress = true;
            bw3.DoWork += new DoWorkEventHandler(bw3_DoWork);
            bw3.Disposed += new EventHandler(bw3_Dispoed);
            bw3.RunWorkerAsync();
        }

        public void bw3_Dispoed(object Sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            s2.Close();
        }
        public void bw3_DoWork(object Sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            s2 = new Form2();
            s2.ShowDialog();
        }

        public void FixSizes()
        {
            // Global Form
            this.Size = new Size(697, 422);
            // Dat editor
            metroPanel2.Size = new Size(450, 318);
            fastColoredTextBox1.Location = new Point(0, 24);
            fastColoredTextBox1.Size = new Size(450, 294);
            toolStrip2.Size = new Size(450, 25);
            treeView2.Size = new Size(392, 214);
            // Launcher
            metroTabPage1.Size = new Size(687, 318);
            // Global Tabs
            metroTabControl1.Size = new Size(695, 357);
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            metroButton22.Visible = false;
            metroButton23.Visible = true;
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            metroButton22.Visible = true;
            metroButton23.Visible = false;
        }

        public void metroTabControl1_TabChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(metroTabControl1.SelectedTab.ToString());
            //MessageBox.Show(metroTabControl1.TabIndex.ToString());
            // results ex: {Splash Changer} & index ex: 0
            if (metroTabControl1.SelectedTab.ToString().Contains("Dat Editor"))
            {
                Resizable = true;
                metroButton22.Enabled = true;
                metroButton22.Visible = true;
            }
            else
            {
                // Restore windows state
                this.WindowState = FormWindowState.Normal;
                // Make it unresizable
                Resizable = false;
                // Fix size of global form
                Size = new Size(697, 422);
                // Disable resize buttons
                metroButton22.Enabled = false;
                metroButton22.Visible = false;
                // Fix sizes
                FixSizes();
            }
        }

        public void CheckTab()
        {
            // Check settings <3
            try
            {
                // Create if missing
                if (!File.Exists(AppPath + "\\Settings.ini")) { File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues); }
                // Check if updated.
                if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultclient"))
                {
                    // Save current settigns
                    string[] currentsettings = File.ReadAllLines(AppPath + "\\Settings.ini");
                    // Create new file
                    File.Delete(AppPath + "\\Settings.ini");
                    File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                    // Start saving old settings
                    int i = 0;
                    foreach (string line in currentsettings)
                    {
                        i++;
                        lineChanger(line, AppPath + "\\Settings.ini", i);
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("savelogs = true"))
                {
                    metroToggle2.Checked = true;
                    groupBox7.Enabled = true;
                    SaveLogs = true;
                    groupBox7.Enabled = true;
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("launcherlogs = true"))
                    {
                        metroToggle13.Checked = true;
                        LauncherLogs = true;
                    }
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("modmanlogs = true"))
                    {
                        metroToggle12.Checked = true;
                        ModManLogs = true;
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("tooltips = false"))
                {
                    metroToggle6.Checked = false;
                    metroToolTip1.Active = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("variables = true"))
                {
                    metroToggle7.Checked = true;
                    metroLabel22.Visible = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("admincheck = false"))
                {
                    metroToggle8.Checked = false;
                    AdminCheck = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("ncsoftlogin = true"))
                {
                    metroToggle9.Checked = true;
                    Hide();
                    Splash1 s1 = new Splash1();
                    s1.ShowDialog();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("showdonate = false"))
                {
                    metroToggle10.Checked = false;
                    metroButton12.Visible = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("minimize = false"))
                {
                    metroToggle11.Checked = false;
                    AllowMinimize = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("showlogs = false"))
                {
                    metroToggle5.Checked = false;
                    ShowLogs = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("customgame = true"))
                {
                    metroTextBox3.Enabled = true;
                    metroButton15.Enabled = true;
                    metroButton20.Enabled = true;
                    metroButton17.Enabled = true;
                    metroToggle3.Checked = true;
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(15).Take(1).First();
                    RegPath = line.Replace("customgamepath = ", "");
                    workedREG = true;
                    BnSFolder();
                    metroTextBox3.Text = RegPath;
                    CustomGameSet = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("customclient = true"))
                {
                    metroTextBox4.Enabled = true;
                    metroButton16.Enabled = true;
                    metroButton19.Enabled = true;
                    metroButton18.Enabled = true;
                    metroToggle4.Checked = true;
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(14).Take(1).First();
                    RegPathlol = line.Replace("customclientpath = ", "");
                    workedSRV = true;
                    CheckServer();
                    metroTextBox4.Text = RegPathlol;
                    CustomClientSet = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("gamekiller = false"))
                {
                    GameKiller = false;
                    metroToggle15.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("updatechecker = false"))
                {
                    UpdateChecker = false;
                    metroToggle16.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("pingchecker = false"))
                {
                    PingChecker = false;
                    metroToggle14.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"arguements = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(20).Take(1).First().Replace("arguements = ", "");
                    metroTextBox5.Text = line;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains(@"prtime = "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(21).Take(1).First().Replace("prtime = ", "");
                    metroLabel47.Text = line;
                    metroLabel47.Refresh();
                    metroTrackBar1.Value = Convert.ToInt32(line);
                    metroTrackBar1.Refresh();
                    wakeywakey = Convert.ToInt32(line);
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultset = true"))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(24).Take(1).First().Replace("default = ", "");
                    metroLabel48.Text = line; //lineChanger
                    RegPath = line;
                    workedREG = true;
                    MultipleInstallationFound = true;
                    GetRegDir();
                    BnSFolder();
                }
                if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultclient =  "))
                {
                    string line = File.ReadLines(@AppPath + "\\Settings.ini").Skip(26).Take(1).First().Replace("defaultclient = ", "");
                    metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(line);
                    defaultclient = line;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = false"))
                {
                    AutoUpdate = false;
                    metroToggle17.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("firsttime = false"))
                {
                    FirstTime = false;
                }
            }
            catch
            {
                //
            }

        }

        public void Details()
        {
            metroLabel22.Text = "Language: " + languageID + " | Region: " + regionID;
            metroLabel47.Text = metroTrackBar1.Value.ToString();
            metroLabel47.Refresh();
        }

        public void VerifySettings()
        {
            // Check settings <3
            if (PathFound == true)
            {
                try
                {
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("unattended = true"))
                    {
                        metroCheckBox1.Checked = true;
                        Unattended = "-UNATTENDED";
                    }
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("notexturestreaming = true"))
                    {
                        metroCheckBox2.Checked = true;
                        NoTextureStreaming = "-NOTEXTURESTREAMING";
                    }
                    if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("useallcores = true"))
                    {
                        metroCheckBox3.Checked = true;
                        UseAllCores = "-USEALLAVAILABLECORES";
                    }
                }
                catch
                {
                    AddTextLog("Run as admin.");
                }
            }
            else
            {
                AddTextLog("Could not load Pre-Settings");
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check Server & IP
            if (metroComboBox1.SelectedItem.ToString() == "Europe")
            {
                IP = "206.127.148.171";
                regionID = "1";
                metroLabel11.Text = ping + ms;
                AddTextLog("Changed RegionID to EU!");
                regionID = "1";
            }
            else if (metroComboBox1.SelectedItem.ToString() == "North America")
            {
                IP = "64.25.35.100";
                regionID = "0";
                metroLabel11.Text = ping + ms;
                AddTextLog("Changed RegionID to NA!");
                regionID = "0";
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Taiwan")
            {
                IP = "139.175.50.166";
                regionID = "15";
                metroLabel11.Text = ping + ms;
                AddTextLog("Changed RegionID to Taiwan!");
                regionID = "15";
            }
            Details();
        }

        bool workedSRV = false;
        public void CheckServer()
        {
            // Check Server Usage
            // NA/EU
            if (workedREG == true)
            {
                if (Installs.ContainsKey("NA/EU"))
                {
                    if (Installs["NA/EU"].ToString() == RegPath && Reg64 == true)
                    {
                        if (workedSRV == false)
                        {
                            AddTextLog("Reading Registry...");
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\Wow6432Node\NCWest\NCLauncher\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                    else if (Installs["NA/EU"].ToString() == RegPath && Reg64 == false)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\NCWest\NCLauncher\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                }
                if (Installs.ContainsKey("Taiwan"))
                {
                    if (Installs["Taiwan"].ToString() == RegPath && Reg64 == true)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\Wow6432Node\plaync\NCLauncherS\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                    else if (Installs["Taiwan"].ToString() == RegPath && Reg64 == false)
                    {
                        if (workedSRV == false)
                        {
                            try
                            {
                                RegistryKey regKeylol = Registry.LocalMachine;
                                regKeylol = regKeylol.OpenSubKey(@"SOFTWARE\plaync\NCLauncherS\");
                                if (regKeylol != null)
                                {
                                    RegPathlol = regKeylol.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch { AddTextLog("Null Value of RegKey"); }
                        }
                    }
                }
            }
            
            if (workedSRV == false)
            {
                RegPathlol = null;
                AddTextLog("Error: RegKey = " + RegPathlol);
            }

            if (workedSRV == true)
            {
                try
                {
                    if (File.ReadAllText(RegPathlol + "\\NCLauncher.ini").Contains("Game_Region=North America"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                    }
                    else if (File.ReadAllText(RegPathlol + "\\NCLauncher.ini").Contains("Game_Region=Europe"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Europe");
                    }
                    else
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                    }
                }
                catch
                {
                    AddTextLog("Error: Could Not Find NCLauncher.ini");
                }
            }
            else
            {
                AddTextLog("Error: Could Not Find NCLauncher Path!");
            }
        }

        public string checkMD5(string filename)
        {
            // MD5 File Check
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
                }
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox2.SelectedItem.ToString() == "English")
            {
                languageID = "English";
                AddTextLog("languageID = English");
            } else
            if (metroComboBox2.SelectedItem.ToString() == "French")
            {
                languageID = "French";
                AddTextLog("languageID = French");
            } else
            if (metroComboBox2.SelectedItem.ToString() == "German")
            {
                languageID = "German";
                AddTextLog("languageID = German");
            } else
            if (metroComboBox2.SelectedItem.ToString() == "Taiwan")
            {
                languageID = "CHINESET";
                AddTextLog("languageID = Chineset");
            }
            else
            {
                languageID = metroComboBox2.SelectedItem.ToString();
                AddTextLog("languageID = " + languageID + " (unknown)");
            }
            Details();
        }

        public void CheckBackup()
        {
            // Backup Checks
            AddTextLog("Checking For Backups");
            // Create backup if it doesn't exist
            string BackupPath = FullPath + "\\backup";
            if (!Directory.Exists(BackupPath)) { Directory.CreateDirectory(BackupPath); }
            // Check if No Loading Screen is Enabled or not and set value if it is.
            if (File.Exists(FullPath + "\\Loading.pkg"))
            {
                metroToggle1.CheckState = CheckState.Unchecked;
                metroToggle1.Refresh();
                AddTextLog("Loading Screen Backup Not Found!");
            }
            else
            {
                if (File.Exists(FullPath + "\\backup\\Loading.bak"))
                {
                    metroToggle1.CheckState = CheckState.Checked;
                    metroToggle1.Refresh();
                    AddTextLog("Loading Screen Backup Found!");
                }
                else
                {
                    AddTextLog("Error: No Files Found!");
                }
            }
            
            CheckConfigBackup();
            CleanOtherMess();

        }

        public void CleanOtherMess()
        {
            string localvar = "";
            try
            {
                AddTextLog("Cleaning Mess");
                DirectoryInfo path = new DirectoryInfo(DataPath);
                foreach (DirectoryInfo subdir in path.GetDirectories())
                {
                    if (subdir.ToString().EndsWith(".dat.files"))
                    {
                        localvar = subdir.ToString();
                        Array.ForEach(Directory.GetFiles(@DataPath + "\\" + localvar + "\\"), File.Delete);
                        Directory.Delete(DataPath + "\\" + localvar + "\\", true);
                        AddTextLog("Cleaned " + localvar);
                    }
                }
            }
            catch { AddTextLog("Could not remove folder -> " + DataPath + "\\" + localvar + "\\"); }
        }

        public void DoBackupCheck()
        {
            try
            {
                AddTextLog("Extracted");
                AddTextLog("Checking system.config2.xml if modded");
                metroButton2.Enabled = true;
                string String = @"<option name=""use-web-launching"" value=""false"" />";
                if (File.ReadAllText(DataPath + "\\" + usedfile + ".files\\system.config2.xml").Contains(String))
                {
                    AddTextLog(usedfile + " is Modded");
                    metroLabel14.Text = "Patched!"; metroButton2.Enabled = true; metroLabel14.Refresh(); metroButton1.Text = "Play!";
                    AddTextLog("Config Backup Found");
                }
                else
                {
                    AddTextLog(usedfile + " is Clean");
                    metroLabel14.Text = "Clean"; metroLabel14.Refresh(); metroButton2.Enabled = false;
                    metroButton2.Enabled = false;
                    AddTextLog("No Config Backup");
                }
            }
            catch { AddTextLog("Error: Could not verify system.config2.xml (" + usedfile + " in use)"); }
        }

        public string usedfile = "";
        public string usedfilepath = "";
        public string usedfilepathonly = "";
        public bool BNSis64 = false;
        private AutoResetEvent waitbw = new AutoResetEvent(false);
        public void CheckConfigBackup()
        {
            DirectoryInfo configfolder = new DirectoryInfo(DataPath);
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                usedfile = "";
                if ((!configfile.ToString().Contains("xml")) && (configfile.ToString().Contains("config"))) // Skipping xml.dat as it is too large and not needed
                {
                    usedfile = configfile.ToString();
                    usedfilepath = DataPath + "\\" + usedfile;
                    AddTextLog("Extracting " + usedfile + " for verification");
                    metroButton2.Enabled = true;
                    // Start new patching routine!
                    try
                    {
                        Extractor(usedfile);
                        DoBackupCheck();
                    } catch(Exception e) { Prompt.Popup(e.ToString()); }
                }
            }
        }

        public void Compiler(string qwerty)
        {
            // Check if 64bit or 32bit
            if (qwerty.Contains("64"))
            {
                BNSis64 = true;
            }
            else { BNSis64 = false; }
            // Go to task
            bnsdatc = new BackgroundWorker();
            bnsdatc.WorkerSupportsCancellation = true;
            bnsdatc.WorkerReportsProgress = true;
            bnsdatc.DoWork += new DoWorkEventHandler(bnsdatc_DoWork);
            bnsdatc.RunWorkerAsync();
            // Wait until task is complete
            waitbw.WaitOne();
            waitbw.Reset();
        }

        private void bnsdatc_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            BNSDat.BNSDat BnsDat = new BNSDat.BNSDat();
            BnsDat.Compress(usedfilepathonly, BNSis64);
            // set task as completed
            waitbw.Set();
        }

        public void Extractor(string qwerty)
        {
            // Check if 64bit or 32bit
            if (qwerty.Contains("64"))
            {
                BNSis64 = true;
            } else { BNSis64 = false; }
            // Go to task
            bnsdat = new BackgroundWorker();
            bnsdat.WorkerSupportsCancellation = true;
            bnsdat.WorkerReportsProgress = true;
            bnsdat.DoWork += new DoWorkEventHandler(bnsdat_DoWork);
            bnsdat.RunWorkerAsync();
            // Wait until task is complete
            waitbw.WaitOne();
            waitbw.Reset();
        }

        private void bnsdat_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            BNSDat.BNSDat BnsDat = new BNSDat.BNSDat();
            BnsDat.Extract(usedfilepath, BNSis64);
            // set task as completed
            waitbw.Set();
        }

        public bool workedREG = false;
        public void BnSFolder()
        {
            // Check if ain't already in settings
            if (workedREG == false)
            {
                // Run if not
                GetRegDir();
            }
            // Recursively find path
            try
            {
                AutoDirFinder();
                SetBnSFolder();
            } catch(Exception e) { Prompt.Popup("Error: " + e.ToString()); }
        }

        public void UpdateCheck()
        {
            if (UpdateChecker == true)
            {
                // Check, Validate & Notify
                using (WebClient client = new WebClient())
                {
                    // Check
                    try
                    {
                        AddTextLog("Grabbing Online Version...");
                        client.Headers.Add("user-agent", "BnSBuddy/" + Application.ProductVersion + " (compatible;)");
                        s = client.DownloadString("https://www.nebulahosts.com/BuddyVersion.txt");
                        AddTextLog("Grabbed: " + s);
                    }
                    catch
                    {
                        AddTextLog("Could not connect.");
                        s = "Error";
                    }
                }
                // Validate
                metroLabel6.Text = s;
                metroLabel3.Text = Application.ProductVersion;
                online = s.Replace(".", "");
                offline = Application.ProductVersion.ToString().Replace(".", "");
                // Notify
                if (online != "Error")
                {
                    if (Convert.ToInt32(online) > Convert.ToInt32(offline))
                    {
                        if (s != "Error")
                        {
                            /*
                            metroButton3.Enabled = true;
                            */
                            AddTextLog("Update available.");

                            if (AutoUpdate == true)
                            {
                                startDownload();
                            }
                            else
                            {
                                metroButton3.Visible = true;
                            }
                        }
                        else if(online == "Error")
                        {
                            // If update check is off
                            AddTextLog("Error checking update.");
                        }
                    }
                    else
                    {
                        AddTextLog("Up to date.");
                    }
                } else { AddTextLog("Error checking update."); }
            }
            else
            {
                metroLabel6.Text = "Offline";
                metroLabel3.Text = Application.ProductVersion;
            }
        }

        public void KillGame()
        {
            if (GameKiller == true)
            {
                // Kill game process
                foreach (var process in Process.GetProcessesByName("Client"))
                {
                    process.Kill();
                    AddTextLog("Killed Game Process.");
                }
            }
        }


        public void AddTextLog(string text)
        {
            // Append text to log
            if (ShowLogs == true)
            {
                metroTextBox1.AppendText(text + Environment.NewLine);
            }
            // Settings log checker
            if (SaveLogs == true)
            {
                if (LauncherLogs == true)
                {
                    File.WriteAllText(AppPath + "\\Launcher_logs.txt", metroTextBox1.Text);
                }
            }
            // End Checker
        }

        public void AddTextBoxLog(string text)
        {
            // Append text to log
            if (ShowLogs == true)
            {
                metroTextBox2.AppendText(text);
            }
            // Settings log checker
            if (SaveLogs == true)
            {
                if (ModManLogs == true)
                {
                    File.WriteAllText(AppPath + "\\ModManager_logs.txt", metroTextBox2.Text);
                }
            }
            // End Checker
        }
        
        public void bw1_DoWork(object Sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)Sender;
            while (!worker.CancellationPending)
            {
                // Loop Progress
                worker.ReportProgress(0);
                // Input Ping Into Label
                Thread.Sleep(wakeywakey);
                try
                {
                    ping = new Ping().Send(IP).RoundtripTime.ToString();
                }
                catch { ping = "0"; }
            }
        }

        public void bw1_ProgressChanged(object Sender, ProgressChangedEventArgs e)
        {
            if (Regex.IsMatch(ping, @"^\d+$") == true)
            {
                if (ping != "0")
                {
                    metroLabel11.Text = ping + ms;
                }
                else
                {
                    metroLabel11.Text = "Offline";
                }
            }
            else
            {
                metroLabel11.Text = "Offline";
            }
        }

        public void SetPing()
        {
            // Set ping
            AddTextLog("Getting Ping From Server...");
            try
            {
                ping = new Ping().Send(IP).RoundtripTime.ToString();
            }
            catch { ping = "0"; }
            if (Regex.IsMatch(ping, @"^\d+$") == true)
            {
                if (ping != "0")
                {
                    metroLabel11.Text = ping + ms;
                    AddTextLog("Got Ping.");
                }
                else
                {
                    metroLabel11.Text = "Offline";
                    AddTextLog("No Ping.");
                }
            }
            else
            {
                metroLabel11.Text = "Offline";
                AddTextLog("No Ping.");
            }

            bw1 = new BackgroundWorker();
            bw1.WorkerSupportsCancellation = true;
            bw1.WorkerReportsProgress = true;
            bw1.DoWork += new DoWorkEventHandler(bw1_DoWork);
            bw1.ProgressChanged += new ProgressChangedEventHandler(bw1_ProgressChanged);
            
            if (PingChecker == true)
            {
                bw1.RunWorkerAsync();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Imported from Splash
            foreach (string i in listBox1.Items.OfType<string>().ToList())
            {
                string NewSplashCheck = FullPathSplash + "\\mods\\" + i;
                if (!File.Exists(NewSplashCheck))
                {
                    listBox1.Items.Remove(i);
                }
            }
            // End Import
            // Check Client.exe in background
            if (GameStarted == true) {
                GameStarted = false;
                foreach (var process in Process.GetProcessesByName("Client"))
                {
                    GameStarted = true;
                }
                if (GameStarted == false)
                {
                    // Verify mod manager
                    foreach (TreeNode nodes in treeView2.Nodes)
                    {
                        RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                        if (Directory.Exists(RealModPath))
                        {
                            checkButtons(true);
                        }
                        else
                        {
                            nodes.Remove();
                        }
                    }
                    //
                    metroButton1.Enabled = true;
                    metroButton1.Text = "Play!";
                    Show(); // Shows the program on taskbar
                    this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
                    notifyIcon1.Visible = false; // Hides tray icon again
                    AddTextLog("Game Closed!");
                    AddTextLog("Restored UI!");
                    metroButton2.Enabled = true;
                }
            }
            //End Check
        }

        private void metroLabel11_TextChanged(object sender, EventArgs e)
        {
            // Ping Status
            int pinger = Convert.ToInt32(ping);
            if (pinger >= bad)
            {
                metroLabel12.Text = "Bad";
            }
            else
            {
                if ((pinger >= medium) && (pinger < bad))
                {
                    metroLabel12.Text = "Playable";
                }
                else
                {
                    if ((pinger >= good) && (pinger < medium))
                    {
                        metroLabel12.Text = "Good";
                    }
                    else
                    {
                        metroLabel12.Text = "Error";
                    }
                }
            }
        }

        private void metroToggle1_Click(object sender, EventArgs e)
        {
            // Toggle for Loading Screen
            if (File.Exists(FullPath + "\\Loading.pkg") && File.Exists(FullPath + "\\00009368.upk"))
            {
                metroProgressSpinner1.Visible = true;
                metroProgressSpinner1.Refresh();
                try
                {
                    metroToggle1.Enabled = false;
                    metroButton1.Enabled = false;
                    if ((!File.Exists(FullPath + "\\backup\\loading.bak")) && (!File.Exists(FullPath + "\\backup\\00009368.bak")))
                    {
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    else
                    {
                        File.Delete(FullPath + "\\backup\\loading.bak");
                        File.Delete(FullPath + "\\backup\\00009368.bak");
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    metroToggle1.Enabled = true;
                    metroToggle1.CheckState = CheckState.Checked;
                    if (PathFound == true)
                    {
                        metroButton1.Enabled = true;
                    }
                    metroToggle1.Refresh();
                    metroButton1.Refresh();

                    AddTextLog("Removed Loading Screen!");
                }
                catch
                {
                    metroToggle1.Enabled = true;
                    metroToggle1.CheckState = CheckState.Unchecked;
                    if (PathFound == true)
                    {
                        metroButton1.Enabled = true;
                    }
                    metroToggle1.Refresh();
                    metroButton1.Refresh();

                    AddTextLog("Could Not Remove Loading Screen!");
                }
                metroProgressSpinner1.Visible = false;
                metroProgressSpinner1.Refresh();
            }
            else
            {
                metroProgressSpinner1.Visible = true;
                metroProgressSpinner1.Refresh();
                if (File.Exists(FullPath + "\\backup\\loading.bak") && File.Exists(FullPath + "\\backup\\00009368.bak"))
                {
                    try
                    {
                        metroToggle1.Enabled = false;
                        metroButton1.Enabled = false;
                        File.Move(FullPath + "\\backup\\loading.bak", FullPath + "\\Loading.pkg");
                        File.Move(FullPath + "\\backup\\00009368.bak", FullPath + "\\00009368.upk");
                        metroToggle1.Enabled = true;
                        metroToggle1.CheckState = CheckState.Unchecked;
                        if (PathFound == true)
                        {
                            metroButton1.Enabled = true;
                        }
                        metroToggle1.Refresh();
                        metroButton1.Refresh();

                        AddTextLog("Restored Loading Screen!");
                    }
                    catch
                    {
                        metroToggle1.Enabled = true;
                        metroToggle1.CheckState = CheckState.Checked;
                        if (PathFound == true)
                        {
                            metroButton1.Enabled = true;
                        }
                        metroToggle1.Refresh();
                        metroButton1.Refresh();

                        AddTextLog("Could Not Restore Loading Screen!");
                    }
                }
                metroProgressSpinner1.Visible = false;
                metroProgressSpinner1.Refresh();
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroCheckBox1.Checked == true)
                {
                    Unattended = "-UNATTENDED";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("unattended = false", "unattended = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    Unattended = "";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("unattended = true", "unattended = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }

                }
            }
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroCheckBox3.Checked == true)
                {
                    UseAllCores = "-USEALLAVAILABLECORES";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("useallcores = false", "useallcores = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    UseAllCores = "";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("useallcores = true", "useallcores = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroCheckBox2.Checked == true)
                {
                    NoTextureStreaming = "-NOTEXTURESTREAMING";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("notexturestreaming = false", "notexturestreaming = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    NoTextureStreaming = "";
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("notexturestreaming = true", "notexturestreaming = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            startDownload();
        }

        private void startDownload()
        {
            // Extract updater if needed.
            if (!File.Exists(AppPath + "\\BnS Buddy Updater.exe"))
            {
                File.WriteAllBytes(AppPath + "\\BnS Buddy Updater.exe", Resources.BnS_Buddy_Updater);
            }
            // Run updater
            Process BnSBuddyUpdater = new Process();
            BnSBuddyUpdater.StartInfo.FileName = AppPath + "\\BnS Buddy Updater.exe";
            BnSBuddyUpdater.Start();
            // Kill current app
            KillApp();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            // Restore!
            metroButton2.Enabled = false;
            DirectoryInfo configfolder = new DirectoryInfo(DataPath + "\\backup\\");
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                string nameoffile = configfile.Name;
                string PathtoFull = configfile.FullName;
                if (File.Exists(DataPath + "\\backup\\" + nameoffile))
                {
                    try
                    {
                        AddTextLog("Restoring " + nameoffile + "!");
                        File.Copy(DataPath + "\\backup\\" + nameoffile, DataPath + "\\" + nameoffile, true);
                        metroLabel14.Text = "Clean";
                        AddTextLog("Restored!");
                        metroButton1.Enabled = true;
                        metroButton1.Text = "Patch!";
                    }
                    catch
                    {
                        AddTextLog("Error: Could Not Restore " + nameoffile + "!");
                        metroButton2.Enabled = true;
                    }
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Patch & Play!
            AddTextLog("Using vars...");
            metroButton1.Enabled = false;
            // Patch client launcher!
            if (metroLabel14.Text == "Clean")
            {
                AddTextLog("Patching...");
                patchConfigDat(e);
            }
            else
            {
                AddTextLog("Skipped Patching!");
                LaunchGame(e);
            }
        }

        private void patchConfigDat(EventArgs e)
        {
            // Patch Config
            AddTextLog("Getting Patch...");
            try
            {
                patchDownloaded(e);
            }
            catch
            {
                AddTextLog("Error: Unable To Retrieve Patch!");
            }
        }

        public void DoPatchingProcess()
        {
            try
            {
                AddTextLog("Extracted " + datverifier);
                AddTextLog("Checking string");
                string String = @"<option name=""use-web-launching"" value=""true"" />";
                if (File.ReadAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml").Contains(String))
                {
                    try
                    {
                        AddTextLog("Backing up");
                        File.Copy(DataPath + "\\" + datverifier + "", DataPath + "\\backup\\" + datverifier + "", true);
                        AddTextLog("Backup made");
                    }
                    catch { AddTextLog("Could not copy " + datverifier + " to backup folder"); }
                }
                try
                {
                    AddTextLog("Replacing values");
                    var filecontent = File.ReadAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml").Replace(@"<option name=""use-web-launching"" value=""true"" />", @"<option name=""use-web-launching"" value=""false"" />");
                    File.WriteAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml", filecontent);
                    AddTextLog("Replaced");
                    RepackPatchedConfig();
                } catch { AddTextLog("Could not modify & save system.config2.xml"); }
            } catch { AddTextLog("Could not open system.config2.xml"); }
        }

        string datverifier = "";
        public void InternalPatcherAndVerifier()
        {
            DirectoryInfo configfolder = new DirectoryInfo(DataPath);
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                datverifier = configfile.ToString();
                try
                {
                    if ((!configfile.ToString().Contains("xml")) && (configfile.ToString().Contains("config")))
                    {
                        //
                        AddTextLog("Extracting " + datverifier);
                        usedfile = datverifier;
                        usedfilepath = DataPath + "\\" + datverifier;
                        Extractor(usedfile);
                        DoPatchingProcess();
                    }
                } catch(Exception e) { Prompt.Popup(e.ToString()); }
            }
        }

        public void DoRepackProcess()
        {
            try
            {
                AddTextLog("Repacked & Replaced");
                metroLabel14.Text = "Patched";
                AddTextLog("Patched " + datverifier + "!");
            }
            catch { AddTextLog("Error: Could Not Copy Patched Client!"); }
        }

        public void RepackPatchedConfig()
        {
            AddTextLog("Repacking " + datverifier);
            try
            {
                string PathtoDat = myDictionary[datverifier];
                usedfile = datverifier;
                usedfilepathonly = PathtoDat + "\\" + datverifier + ".files";
                Compiler(usedfile);
                DoRepackProcess();
            } catch(Exception e) { Prompt.Popup(e.ToString()); }
        }

        private void patchDownloaded(EventArgs e)
        {
            nonmodded = true;
            // Patch Downloaded then proceed
            AddTextLog("Patching Launcher...");
            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Refresh();
            try
            {
                InternalPatcherAndVerifier();
                CleanOtherMess();
                LaunchGame(e);
            }
            catch
            {
                AddTextLog("Error: Could Not Patch Client!");
                metroButton1.Enabled = true;
            }
            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Refresh();
        }

        private void LaunchGame(EventArgs e)
        {
            // Disable mod window
            metroButton8.Enabled = false;
            metroButton9.Enabled = false;
            metroButton10.Enabled = false;
            metroButton11.Enabled = false;
            // Start Client.exe
            AddTextLog("Finding Client.exe...");
            int i = 0;
            Dictionary<string, string> clients = new Dictionary<string, string>();
            if (Directory.Exists(RegPath + LauncherPath) || Directory.Exists(RegPath + LauncherPath64))
            {
                if (Directory.Exists(RegPath + LauncherPath))
                {
                    LaunchPath = RegPath + LauncherPath + ".\\Client.exe";
                    AddTextLog("Found! (32 bit)");
                    clients.Add("32bit", LauncherPath);
                    i++;
                }
                if (Directory.Exists(RegPath + LauncherPath64))
                {
                    LaunchPath = RegPath + LauncherPath64 + ".\\Client.exe";
                    AddTextLog("Found! (64 bit)");
                    clients.Add("64bit", LauncherPath);
                    i++;
                }
            }
            else
            {
                AddTextLog("Error: Path to Client.exe not found!");
                return;
            }
            if (defaultclient != "")
            {
                LauncherPath = clients[defaultclient].ToString();
                AddTextLog("Using: " + defaultclient + " Client.exe");
            }
            else if (i > 1)
            {
                // HEY!
                DialogResult dialogResult = Prompt.MultipleClient(); 
                if (dialogResult == DialogResult.Yes)
                {
                    LauncherPath = clients["32bit"].ToString();
                    AddTextLog("Using 32 bit Client.exe");
                    SaveDefaultClient("32bit");
                }
                else 
                if (dialogResult == DialogResult.No )
                {
                    LauncherPath = clients["64bit"].ToString();
                    AddTextLog("Using 64 bit Client.exe");
                    SaveDefaultClient("64bit");
                }
                else
                {
                    AddTextLog("Skipping default launcher!");
                }
            }
            AddTextLog("Starting Client...");
            Process proc = new Process();
            proc.StartInfo.FileName = LaunchPath;
            // Default values
            // /launchbylauncher -lang:english /CompanyID:"12" /ChannelGroupIndex:"-1" -lang:English -lite:2 -region:0 /* NA VARS */
            // -lite:2 /sesskey /LaunchByLauncher /ServiceRegion:"15" /AuthProviderCode:"np" /ServiceNetwork:"live" /NPServerAddr:"210.64.136.126:6600" /PresenceId:"TWBNS22" /* TAIWAN VARS */
            proc.StartInfo.Arguments = "-lang:" + languageID + " -lite:2 -region:" + regionID + " /sesskey /launchbylauncher  /CompanyID:12 /ChannelGroupIndex:-1 " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            try
            {
                proc.Start();
                AddTextLog("Started Client.exe!");
                GameStarted = true;
                this.WindowState = FormWindowState.Minimized;
            }
            catch
            {
                Show();
                notifyIcon1.Visible = false;
                metroButton1.Enabled = true;
                // Verify mod manager
                foreach (TreeNode nodes in treeView2.Nodes)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    if (Directory.Exists(RealModPath))
                    {
                        checkButtons(true);
                    }
                    else
                    {
                        nodes.Remove();
                    }
                }
                //
                AddTextLog("Error: Could Not Start Client.exe!");
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show(); // Shows the program on taskbar
            this.WindowState = FormWindowState.Normal; // Undoes the minimized state of the form
            notifyIcon1.Visible = false; // Hides tray icon again
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (AllowMinimize == true)
            {
                if (this.WindowState == FormWindowState.Minimized)//this code gets fired on every resize
                {
                    //so we check if the form was minimized
                    //this.Visible = false;//
                    this.Hide();//hides the program on the taskbar
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(50, "BnS Launcher", "Minimized to tray.", ToolTipIcon.Info);
                } 
            }
        }
        
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        string RegPathSplash = "";
        string FullPathSplash = "";
        string FullBackupPathSplash = "";
        string workingPathSplash = "";
        string ModPathSplash = "";
        string NewSplash = "";
        string ExtensionSplash = "";

        public void InitializeSplash()
        {
            if (PathFound == true)
            {
                // List Splash Images
                try
                {
                    DirectoryInfo dinfo2 = new DirectoryInfo(@FullPathSplash + "\\mods\\");
                    FileInfo[] Files2 = dinfo2.GetFiles("*.bmp");
                    foreach (FileInfo file2 in Files2)
                    {
                        listBox1.Items.Add(file2.Name);
                    }
                    if (listBox1.Items.Count != 0)
                    {
                        listBox1.SelectedIndex = 0;
                        pictureBox1.Image = System.Drawing.Image.FromFile(FullPathSplash + "\\mods\\" + listBox1.SelectedItem.ToString());
                    }
                    else
                    {
                        listBox1.SelectedIndex = -1;
                    }
                }
                catch
                {
                    if (Directory.GetFileSystemEntries(ModPathSplash).Length == 0)
                    {
                        if (Directory.GetFileSystemEntries(FullBackupPathSplash).Length == 0)
                        {
                            metroButton4.Enabled = true;
                            metroButton5.Enabled = false;
                            metroButton6.Enabled = true;
                        }
                        return;
                    }
                    if (Directory.GetFileSystemEntries(ModPathSplash).Length != 0)
                    {
                        if (Directory.GetFileSystemEntries(FullBackupPathSplash).Length != 0)
                        {
                            metroButton4.Enabled = false;
                            metroButton5.Enabled = true;
                            metroButton6.Enabled = true;
                        }
                        else
                        {
                            metroButton4.Enabled = true;
                            metroButton5.Enabled = false;
                            metroButton6.Enabled = true;
                        }
                        return;
                    }
                    else
                    {
                        AddTextLog("Error: Was Not Able to Populate!");
                    }
                }
            }
        }

        private void CreatePaths(string PathName)
        {
            // Create the missing path
            Directory.CreateDirectory(PathName);
        }

        public void Verify()
        {
            // Verify Backup
            if (File.Exists(FullBackupPathSplash + "\\Splash.bmp"))
            {
                metroLabel17.Text = "Modded";
                metroButton4.Enabled = false;
                metroButton5.Enabled = true;
                string md52 = checkMD5(FullBackupPathSplash + "\\Splash.bmp");
                string md51 = checkMD5(FullPathSplash + "\\Splash.bmp");
                if (md52 == md51) { metroLabel17.Text = "Original"; metroButton5.Enabled = false; metroButton4.Enabled = true; }
            }
            else
            {
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
                metroLabel17.Text = "Original";
            }
            // Check if already modded or not.
        }

        public void GetPaths()
        {
            // Grab Path to Splash
            if (PathFound == true)
            {
                RegPathSplash = RegPath;
                ExtensionSplash = "\\contents\\Local\\" + autofinder;
                FullPathSplash = RegPathSplash + ExtensionSplash + "\\" + autocook + "\\Splash";
                workingPathSplash = FullPathSplash;
                // Get Backup Path & Mods Path then create if missing
                FullBackupPathSplash = FullPathSplash + "\\backup";
                ModPathSplash = FullPathSplash + "\\mods";
                if (!Directory.Exists(FullBackupPathSplash)) { CreatePaths(FullBackupPathSplash); }
                if (!Directory.Exists(ModPathSplash)) { CreatePaths(ModPathSplash); }
            }
            else
            {
                metroButton5.Enabled = false;
                metroButton4.Enabled = false;
                metroButton6.Enabled = false;
                listBox1.Enabled = false;
                pictureBox1.Enabled = false;
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            // Browse folder
            Process.Start("explorer.exe", FullPathSplash);
        }

        private void metroLabel17_TextChanged(object sender, EventArgs e)
        {
            // Set Status & Buttons
            if (metroLabel17.Text == "Original")
            {
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
            }
            if (metroLabel17.Text == "Modded")
            {
                metroButton4.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            NewSplash = FullPathSplash + "\\mods\\" + listBox1.SelectedItem.ToString();
            if (File.Exists(NewSplash))
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(NewSplash);
            }
            else
            {
                listBox1.ClearSelected();
            }
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                try
                {
                    // Backup
                    if (File.Exists(FullBackupPathSplash + "\\Splash.bmp")) { File.Delete(FullBackupPathSplash + "\\Splash.bmp"); }
                    File.Move(FullPathSplash + "\\Splash.bmp", FullBackupPathSplash + "\\Splash.bmp");
                    // Add new
                    File.Copy(NewSplash, FullPathSplash + "\\Splash.bmp", true);
                    metroLabel17.Text = "Modded";
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = true;
                }
                catch
                {
                    Prompt.Popup("Error: Could not replace image!");
                }
                pictureBox1.Image = System.Drawing.Image.FromFile(FullPathSplash + "\\mods\\" + listBox1.SelectedItem.ToString());
            }
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            try
            {
                // Destroy modded
                File.Delete(FullPathSplash + "\\Splash.bmp");
                // Restore
                File.Move(FullPathSplash + "\\backup\\Splash.bmp", FullPathSplash + "\\Splash.bmp");
                metroLabel17.Text = "Original";
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
            }
            catch
            {
                Prompt.Popup("Error: Could not replace image!");
            }
            pictureBox1.Image = System.Drawing.Image.FromFile(FullPathSplash + "\\mods\\" + listBox1.SelectedItem.ToString());

        }

        private void metroButton7_Click_1(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo dinfo2 = new DirectoryInfo(@FullPathSplash + "\\mods\\");
                FileInfo[] Files2 = dinfo2.GetFiles("*.bmp");
                foreach (FileInfo file2 in Files2)
                {
                    if (!listBox1.Items.Contains(file2.Name))
                    {
                        listBox1.Items.Add(file2.Name);
                    }
                }
                listBox1.SelectedIndex = 0;
                pictureBox1.Image = System.Drawing.Image.FromFile(FullPathSplash + "\\mods\\" + listBox1.SelectedItem.ToString());
            }
            catch
            {
                if (Directory.GetFileSystemEntries(ModPathSplash).Length == 0)
                {
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = false;
                    metroButton6.Enabled = true;
                    return;
                }
                if (Directory.GetFileSystemEntries(ModPathSplash).Length != 0)
                {
                    metroButton4.Enabled = true;
                    metroButton5.Enabled = true;
                    metroButton6.Enabled = true;
                    return;
                }
                else
                {
                    AddTextLog("Error: Was Not Able to Populate!");
                }
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        //Imported
        public BackgroundWorker bw;
        string backupFolderPath = "";
        string modFolderPath = "";
        string modsFolderPath = "";
        string workingPath = "";
        public string originalFolderPath = "";
        public string bnsExeFolderPath = "";
        public string ncsoftExeFolderPath = "";
        public bool bnsFolderIsSet = true;
        public bool ncsoftFolderIsSet = true;
        public bool installFlag = true;
        //Imported
        string tmpdir = "";
        string NewPath = "";
        string FullModPathMan = "";
        string FullModsPathMan = "";
        string FullSettingsPathMan = "";
        string RealModPath = "";

        

        public void InitializeManager()
        {
            tmpdir = FullPath;
            NewPath = tmpdir.Replace("\\CookedPC", "");
            workingPath = NewPath + "\\CookedPC_Settings";
            modFolderPath = NewPath + "\\CookedPC_Mod";
            modsFolderPath = FullPath + "\\mod";
            backupFolderPath = NewPath + "\\CookedPC_Backup";
        }

        private void VerifyUsage()
        {
            isBnsFolderSet();
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                if (Directory.Exists(RealModPath))
                {
                    checkButtons(true);
                }
                else
                {
                    nodes.Remove();
                }
                
            }
        }

        private bool isBnsFolderSet(bool outputMessage = false)
        {
            originalFolderPath = FullPath;
            // Grab the client.exe location
            string tmp = originalFolderPath;
            tmp = tmp.Replace("\\contents\\Local\\" + autofinder + "\\" + autocook + "\\CookedPC", ""); // Remove the path to CookedPC
            bnsExeFolderPath = tmp + "\\bin";
            bnsFolderIsSet = true;
            return true;
        }

        private void checkButtons(bool output = false)
        {
            // Check how many upk files there are in the mods folder.
            int i = 0;
            int j = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(RealModPath);
            foreach (var file in dirInfo.GetFiles("*.upk"))
            {
                i++;
            }
            // Check how many upk files there are in the backup folder
            dirInfo = new DirectoryInfo(backupFolderPath);
            foreach (var file in dirInfo.GetFiles("*.upk"))
            {
                j++;
            }
            // Are there files in the backups folder?
            if (j == 0)
            {
                // How about the mods folder?
                if (i == 0)
                {
                    if (output)
                    {
                        // No .upk files anywhere, start panicking!
                        AddTextBoxLog(Environment.NewLine);
                        if (!RealModPath.Contains("(Installed)")) { 
                            AddTextBoxLog("[Notice] " + "No modded files detected in the \"" + Path.GetFileName(RealModPath) + "\" folder. Press Mod Folder" + "Then drag the upk's in there then press Refresh button.");
                        } else {
                            AddTextBoxLog("[Notice] " + Path.GetFileName(RealModPath) + " mod is already installed");
                        }
                    }
                }
                else
                {
                    if (output)
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] " + "Found " + i.ToString() + " .upk files in the " + Path.GetFileName(RealModPath) + " folder.");
                    }
                }
            }
            if (j != 0)
            {
                // "Found files in the "backups" folder, this takes priority as they are original files
                if (output)
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] " + "Found " + j.ToString() + " .upk files in the \"CookedPC_Backup\" folder.");
                }
            }
            // Determine whether the install or deinstall button should be enabled
                metroButton9.Enabled = true;
                metroButton11.Enabled = true;
            
                // Check if the BnS directory is set
            if (!bnsFolderIsSet)
            {
                metroButton11.Enabled = false;
                metroButton9.Enabled = false;
            }
        }

        private void checkLegacy()
        {
            // If we are indeed running it for the first time (firstEverRun was not set
            // to false by the imported JSON, or it didn't exist in the first place)
            
                // Check how many upk files there are in the mods folder.
                int i = 0;
                int j = 0;
                DirectoryInfo dirInfo = new DirectoryInfo(RealModPath);
                foreach (var file in dirInfo.GetFiles("*.upk"))
                {
                    i++;
                }
                // Check how many upk files there are in the backup folder
                dirInfo = new DirectoryInfo(backupFolderPath);
                foreach (var file in dirInfo.GetFiles("*.upk"))
                {
                    j++;
                }
        }

       

        public void JsonManager()
        {
            // Determine the install flag from the legacy way of checking things
            if (File.Exists(workingPath + "\\database.json")) { File.Delete(workingPath + "\\database.json"); }

            foreach (TreeNode nodes in treeView2.Nodes)
            {
                RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                checkLegacy();
            }
            bw = new BackgroundWorker();
            isBnsFolderSet(true);
        }

        private void GetPath()
        {
            if (PathFound == true)
            {
                FullModsPathMan = FullPath + "\\mod";
                if (!Directory.Exists(FullModsPathMan)) { CreatePaths(FullModsPathMan); }
                FullBackupPath = NewPath + "\\CookedPC_Backup";
                if (!Directory.Exists(FullBackupPath)) { CreatePaths(FullBackupPath); }
                FullModPathMan = NewPath + "\\CookedPC_Mod";
                if (!Directory.Exists(FullModPathMan)) { CreatePaths(FullModPathMan); }
                FullSettingsPathMan = NewPath + "\\CookedPC_Settings";
                if (Directory.Exists(FullSettingsPathMan)) { if (Directory.GetFiles(FullSettingsPathMan).Length == 0) { Directory.Delete(FullSettingsPathMan); } else { File.Delete(FullSettingsPathMan + "\\database.json"); Directory.Delete(FullSettingsPathMan); ; } }
            }
        }

        private void disableButtons()
        {
            metroButton8.Enabled = false;
            metroButton9.Enabled = false;
            metroButton10.Enabled = false;
            metroButton11.Enabled = false;
            metroButton14.Enabled = false;
        }

        private void enableButtons()
        {
            metroButton8.Enabled = true;
            metroButton9.Enabled = true;
            metroButton10.Enabled = true;
            metroButton11.Enabled = true;
            metroButton14.Enabled = true;
            treeView2.Refresh();
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    if (Directory.Exists(RealModPath))
                    {
                        checkButtons();
                    }
                    else
                    {
                        nodes.Remove();
                    }
                }
            }
        }

        private void doFileSwap(string obj)
        {
            RealModPath = FullModPathMan + obj;
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            // Disable all the buttons
            disableButtons();

            // If the background worker is not busy, which it shouldn't be
            if (!bw.IsBusy)
            {
                // If the background worker is not busy, lets get this thing started
                bw.RunWorkerAsync();
            }
        }

        public string newbackuppath = "";
        public string tmpnode = ""; 
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (_workerCompleted.Set() == true)
                if ((nodes.Checked) && (installFlag == true) && (!nodes.FullPath.ToString().Contains("(Installed)"))) //catcher
                {
                    RealModPath = @FullModPathMan + "\\" + nodes.FullPath.ToString();
                    tmpnode = nodes.FullPath.ToString();
                    newbackuppath = @backupFolderPath + "\\" + tmpnode;
                    DirectoryInfo dirInfo = new DirectoryInfo(RealModPath);
                    BackgroundWorker worker = sender as BackgroundWorker;
                    dirInfo = new DirectoryInfo(RealModPath);
                    string message = string.Empty;
                    int fileCounter = 0;
                    int i = 0;
                    int max = dirInfo.GetFiles("*.upk").Count();
                    int curPercent = 0;

                    if (max != 0)
                    {

                        foreach (string fileName in Directory.GetFiles(RealModPath))
                        {
                            string realfileName = fileName.Split(Path.DirectorySeparatorChar).Last();
                            if (realfileName != "description.txt")
                            {
                                CheckForIllegalCrossThreadCalls = false;
                                AddTextBoxLog(Environment.NewLine);

                                try
                                {
                                    // Create original files backup directory of the mod applied
                                    if (!Directory.Exists(backupFolderPath + "\\" + tmpnode))
                                    {
                                        CreatePaths(backupFolderPath + "\\" + tmpnode);
                                        newbackuppath = backupFolderPath + "\\" + tmpnode;
                                    }
                                    // Set folder path for the original files to go to

                                    // Check if the file we're about to install, exists in CookedPC or not.
                                    // If yes, move it away
                                    if (File.Exists(originalFolderPath + "\\" + realfileName))
                                    {
                                        AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [original] to CookedPC_Backup");
                                        File.Copy(originalFolderPath + "\\" + realfileName, newbackuppath + "\\" + realfileName, true);
                                        AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [original] to CookedPC_Backup" + "/" + tmpnode);
                                        AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [original] from CookedPC");
                                        File.Delete(originalFolderPath + "\\" + realfileName);
                                        AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [original] from CookedPC");
                                    }
                                    else
                                    {
                                            try
                                            {
                                                AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " (unique) [modded] to CookedPC_Mod");
                                                File.Copy(RealModPath + "\\" + realfileName, RealModPath + "\\" + realfileName + " (unique)", true);
                                                AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " (unique) [modded] to CookedPC_Mod");
                                            } 
                                            catch
                                            {
                                                AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " (unique) couldn't be copied to CookedPC_Mod");
                                            }
                                    }
                                }
                                catch
                                {
                                    // Message error
                                    AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                                }
                                try
                                {
                                    // Now move over the mod to the CookedPC folder
                                    if (File.Exists(RealModPath + "\\" + realfileName))
                                    {
                                        AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [modded] to CookedPC/mod");
                                        File.Copy(RealModPath + "\\" + realfileName, modsFolderPath + "\\" + realfileName, true);
                                        AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [modded] to CookedPC/mod");
                                        AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [modded] from CookedPC_Mod");
                                        File.Delete(RealModPath + "\\" + realfileName);
                                        AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [modded] from CookedPC_Mod");
                                    }
                                }
                                catch
                                {
                                    // Message error
                                    AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                                }
                                fileCounter++;
                                // Increment & update stats as well as progress bar
                                i++;
                                // This operating will only get to 50%, and the file transfer will be the other 50%
                                curPercent = ((i * 100) / max);

                                // Update the UI
                                if ((worker.CancellationPending == true))
                                {
                                    e.Cancel = true;
                                    break;
                                }
                                else
                                {
                                    // Perform a time consuming operation and report progress.
                                    Thread.Sleep(50);
                                    worker.ReportProgress(curPercent);
                                }
                            }
                        }

                        // Show how many files we moved
                        if (fileCounter > 0)
                        {
                            AddTextBoxLog(Environment.NewLine);
                            AddTextBoxLog("[Log] Done! " + fileCounter + " files were moved.");
                        }
                        else
                        {
                            AddTextBoxLog(Environment.NewLine);
                            AddTextBoxLog("[Log] Done! No files were moved.");
                        }
                        try
                        {
                            // Rename folder to installed
                            string originalcopy = FullModPathMan + "\\" + tmpnode;
                            string altererdcopy = FullModPathMan + "\\" + tmpnode + " (Installed)";
                            Directory.Move(originalcopy, altererdcopy);
                        }
                        catch (Exception a) { Prompt.Popup(a.Message); }
                    } else { AddTextBoxLog(Environment.NewLine);  AddTextBoxLog("[Notice] Can't install an empty mod folder"); }
                }
                else if ((nodes.Checked) && (installFlag == false) && (nodes.FullPath.ToString().Contains("(Installed)"))) //catcher
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    tmpnode = nodes.FullPath.ToString();
                    newbackuppath = @backupFolderPath + "\\" + tmpnode.Replace(" (Installed)", "");
                    DirectoryInfo dirInfo = new DirectoryInfo(newbackuppath);
                    BackgroundWorker worker = sender as BackgroundWorker;
                    dirInfo = new DirectoryInfo(newbackuppath);
                    string message = string.Empty;
                    int fileCounter = 0;
                    int i = 0;
                    int max = dirInfo.GetFiles("*.upk").Count();
                    int curPercent = 0;
                    

                    foreach (string fileName in Directory.GetFiles(newbackuppath))
                    {
                        string realfileName = fileName.Split(Path.DirectorySeparatorChar).Last();
                        CheckForIllegalCrossThreadCalls = false;
                        AddTextBoxLog(Environment.NewLine);
                        
                        
                            try
                            {
                                // Move the mod file back into the mods folder
                                if (File.Exists(modsFolderPath + "\\" + realfileName))
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [modded] to CookedPC_Mod"); //
                                    File.Copy(modsFolderPath + "\\" + realfileName, RealModPath + "\\" + realfileName, true);
                                    AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [modded] to CookedPC_Mod"); //
                                    AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [modded] from CookedPC/mod"); //
                                    File.Delete(modsFolderPath + "\\" + realfileName);
                                    AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [modded] from CookedPC/mod"); //
                                }
                            }
                            catch
                            {
                                AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                            }
                            try
                            {
                                // Check if the mod file we just uninstalled has a backup in the backup folder.
                                // If yes, move that back as the original
                                if (File.Exists(newbackuppath + "\\" + realfileName))
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Copying] " + realfileName + " [original] to CookedPC"); //
                                    File.Copy(newbackuppath + "\\" + realfileName, originalFolderPath + "\\" + realfileName, true);
                                    AddTextBoxLog(Environment.NewLine + "[Copied] " + realfileName + " [original] to CookedPC"); //
                                    AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [original] from CookedPC_Backup"); //
                                    File.Delete(newbackuppath + "\\" + realfileName);
                                    AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [original] from CookedPC_Backup"); //
                                }
                                else
                                {
                                    try
                                    {
                                        AddTextBoxLog(Environment.NewLine + "[Deleting] " + realfileName + " [modded] from CookedPC_Mod");
                                        File.Copy(RealModPath + "\\" + realfileName + " (unique)", RealModPath + "\\" + realfileName, true);
                                        File.Delete(RealModPath + "\\" + realfileName + " (unique)");
                                        AddTextBoxLog(Environment.NewLine + "[Deleted] " + realfileName + " [modded] from CookedPC_Mod");
                                    }
                                    catch
                                    {
                                        AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " (unique) couldn't be copied/deleted from CookedPC_Mod");
                                    }
                                }
                            }
                            catch
                            {
                                AddTextBoxLog(Environment.NewLine + "[Error] " + realfileName + " could not be touched!");
                            }
                        

                        fileCounter++;

                        // Increment & update stats as well as progress bar
                        i++;
                        // This operating will only get to 50%, and the file transfer will be the other 50%
                        curPercent = ((i * 100) / max);

                        // Update the UI
                        if ((worker.CancellationPending == true))
                        {
                            e.Cancel = true;
                            break;
                        }
                        else
                        {
                            // Perform a time consuming operation and report progress.
                            Thread.Sleep(50);
                            worker.ReportProgress(curPercent);
                        }
                    }

                    if (Directory.Exists(newbackuppath) && Directory.GetFiles(newbackuppath).Length == 0)
                    {
                        Directory.Delete(newbackuppath);
                    } else {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Error: Restoring did not complete.");
                    }

                    // Show how many files we moved
                    if (fileCounter > 0)
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Done! " + fileCounter + " files were moved.");
                    }
                    else
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Done! No files were moved.");
                    }
                    // Rename folder to uninstalled
                    try { 
                        string originalcopy = FullModPathMan + "\\" + tmpnode;
                        string altererdcopy = FullModPathMan + "\\" + tmpnode.Replace(" (Installed)", "");
                        Directory.Move(originalcopy, altererdcopy);
                    } catch (Exception a) { Prompt.Popup(a.Message); }

                }
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.metroProgressBar2.Value = e.ProgressPercentage;
            this.metroProgressBar2.Refresh();
        }

        private AutoResetEvent _workerCompleted = new AutoResetEvent(false);
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                AddTextBoxLog(Convert.ToString(e.Cancelled));
            }
            else if (!(e.Error == null))
            {
                AddTextBoxLog(Convert.ToString(e.Error));
            }
            else
            {
                // Done enable buttons and set the progressbar to 100%
                this.metroProgressBar2.Value = 100;
                this.metroProgressBar2.Refresh();
                // Enable the buttons again
                enableButtons();
            }
            _workerCompleted.Set();
        }

        public bool checkNode(string s)
        {
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    if (nodes.FullPath.ToString() == s)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            // Check Folder, add new ones and check for clones
            AddTextBoxLog(Environment.NewLine);
            AddTextBoxLog("[Log] Checking Mods Folder...");
            
            foreach (string directories in Directory.GetDirectories(FullModPathMan))
            {
                string directory = directories.Split(Path.DirectorySeparatorChar).Last();
                if (directories.Length != 0)
                {
                    if (checkNode(directory) == true)
                    {
                        treeView2.Nodes.Add(new TreeNode(directory));
                    }
                }
            }


            // Validate Paths and remove bad ones
            
            foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    if (Directory.Exists(RealModPath))
                    {
                        checkButtons(true);
                    }
                    else
                    {
                        nodes.Remove();
                    }
                }
            }


            AddTextBoxLog(Environment.NewLine);
            AddTextBoxLog("[Log] Done Checking");

            // Original
            /*foreach (TreeNode nodes in treeView2.Nodes)
            {
                if (nodes != null)
                {
                    RealModPath = FullModPathMan + "\\" + nodes.FullPath.ToString();
                    if (Directory.Exists(RealModPath))
                    {
                        checkButtons(true);
                    }
                    else
                    {
                        nodes.Remove();
                    }
                }
                else
                {
                    treeView2.Nodes.Clear();
                    treeView2 = new TreeView();
                    Directory.GetFiles(FullModPathMan);
                    PopulateTreeView(FullModPathMan);
                }
            }*/
        }

        public string catcher = "";
        private void metroButton9_Click(object sender, EventArgs e)
        {
            catcher = "";
            metroProgressBar2.Visible = true;
            metroProgressBar2.Refresh();
            // Restore files
            installFlag = false;
            try
            {
                foreach (TreeNode nodes in treeView2.Nodes)
                {
                    catcher = nodes.FullPath.ToString();
                    if ((nodes.Checked) && (catcher.Contains("(Installed)")))
                    {
                        tmpnode = "";
                        doFileSwap(FullModPathMan + "\\" + nodes.FullPath.ToString());
                        _workerCompleted.WaitOne();
                        // Remove old and put new
                        Directory.GetFiles(FullModPathMan);
                        Thread.Sleep(50);
                        if (catcher == tmpnode)
                        {
                            Directory.GetFiles(FullModPathMan);
                            Thread.Sleep(50);
                            treeView2.Nodes.Remove(new TreeNode(tmpnode));
                            treeView2.Refresh();
                            Directory.GetFiles(FullModPathMan);
                            Thread.Sleep(50);
                            treeView2.Nodes.Add(tmpnode.Replace(" (Installed)", ""));
                            treeView2.Refresh();
                            Directory.GetFiles(FullModPathMan);
                            Thread.Sleep(50);
                        }
                        _workerCompleted.Reset();
                    }
                    if ((nodes.Checked) && (!catcher.Contains("(Installed)")))
                    {
                        AddTextBoxLog(Environment.NewLine + "Skipping: " + catcher + " (Not Installed)");
                    }
                }
            }
            catch
            {
                AddTextBoxLog("Error: Could not open" + catcher + " mod");
            }
            metroProgressBar2.Visible = false;
            metroProgressBar2.Refresh();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            catcher = "";
            metroProgressBar2.Visible = true;
            metroProgressBar2.Refresh();
            // Switch files
            installFlag = true;
            try
            {
                foreach (TreeNode nodes in treeView2.Nodes)
                {
                    catcher = nodes.FullPath.ToString();
                    if ((nodes.Checked) && (!catcher.Contains("(Installed)")))
                    {
                        tmpnode = "";
                        doFileSwap(FullModPathMan + "\\" + nodes.FullPath.ToString());
                        _workerCompleted.WaitOne();
                        // Remove old and put new
                        Directory.GetFiles(FullModPathMan);
                        Thread.Sleep(50);
                        if (catcher == tmpnode)
                        {
                            Directory.GetFiles(FullModPathMan);
                            Thread.Sleep(50);
                            treeView2.Nodes.Remove(new TreeNode(tmpnode));
                            treeView2.Refresh();
                            Directory.GetFiles(FullModPathMan);
                            Thread.Sleep(50);
                            treeView2.Nodes.Add(tmpnode + " (Installed)");
                            treeView2.Refresh();
                            Directory.GetFiles(FullModPathMan);
                            Thread.Sleep(50);
                        }
                        _workerCompleted.Reset();
                    }
                    if ((nodes.Checked) && (catcher.Contains("(Installed)")))
                    {
                        AddTextBoxLog(Environment.NewLine + "Skipping: " + catcher + " (Already Installed)");
                    }
                }
            }
            catch
            {
                AddTextBoxLog("Error: Could not open" + catcher + " mod");
            }
            metroProgressBar2.Visible = false;
            metroProgressBar2.Refresh();
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string description = File.ReadAllText(FullModPathMan + "\\" + e.Node.FullPath.ToString() + "\\description.txt").ToString();
                metroLabel40.Text = description;
            } catch { metroLabel40.Text = "No description provided!"; }
        }

        private void PopulateTreeView(string dir)
        {
            string folder = string.Empty;
            try
            {
                foreach (string directories in Directory.GetDirectories(dir))
                {
                    if (directories.Length != 0)
                    {
                        treeView2.Nodes.Add(directories.Split(Path.DirectorySeparatorChar).Last());
                        Directory.GetFiles(directories);
                        Thread.Sleep(50);
                        PopulateTreeView(directories);
                    }
                }
            }
            catch(Exception e)
            {
                Prompt.Popup(e.ToString());
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        private void metroButton10_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", FullModPathMan);
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            // Prevent closing if running and close if not
            if (bw.IsBusy)
            {
                Prompt.Popup("Please do not close this application while it's installing or uninstalling mods!");
                return;
            }
            else
            {
                KillApp();
            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/nebulahosts");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle2.Checked == true)
                {
                    SaveLogs = true;
                    groupBox7.Enabled = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("savelogs = false", "savelogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    SaveLogs = false;
                    groupBox7.Enabled = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("savelogs = true", "savelogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle5_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle5.Checked == true)
                {
                    ShowLogs = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showlogs = false", "showlogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    ShowLogs = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showlogs = true", "showlogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle13_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle13.Checked == true)
                {
                    LauncherLogs = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("launcherlogs = false", "launcherlogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    LauncherLogs = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("launcherlogs = true", "launcherlogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle12_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle13.Checked == true)
                {
                    ModManLogs = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("modmanlogs = false", "modmanlogs = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    ModManLogs = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("modmanlogs = true", "modmanlogs = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle6_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle6.Checked == true)
                {
                    metroToolTip1.Active = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("tooltips = false", "tooltips = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    metroToolTip1.Active = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("tooltips = true", "tooltips = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle7_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle7.Checked == true)
                {
                    metroLabel22.Visible = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("variables = false", "variables = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    metroLabel22.Visible = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("variables = true", "variables = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle8_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle8.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("admincheck = false", "admincheck = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("admincheck = true", "admincheck = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle9_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle9.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("ncsoftlogin = false", "ncsoftlogin = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("ncsoftlogin = true", "ncsoftlogin = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle10_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle10.Checked == true)
                {
                    metroButton12.Visible = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showdonate = false", "showdonate = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    metroButton12.Visible = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("showdonate = true", "showdonate = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle15_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle15.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("gamekiller = false", "gamekiller = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("gamekiller = true", "gamekiller = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }
        private void metroToggle14_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle14.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("pingchecker = false", "pingchecker = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                        // Resume worker
                        bw1.RunWorkerAsync();
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("pingchecker = true", "pingchecker = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                        // Pause worker
                        bw1.CancelAsync();
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle17_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle17.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = false", "autoupdate = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("autoupdate = true", "autoupdate = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle16_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle16.Checked == true)
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("updatechecker = false", "updatechecker = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("updatechecker = true", "updatechecker = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle11_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle11.Checked == true)
                {
                    AllowMinimize = true;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("minimize = false", "minimize = true");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    AllowMinimize = false;
                    try
                    {
                        // Check Settings
                        var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                        fileContents = fileContents.Replace("minimize = true", "minimize = false");
                        System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle3_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle3.Checked == true)
                {
                    // Check Settings
                    metroButton15.Enabled = true;
                    metroButton20.Enabled = true;
                    metroButton17.Enabled = true;
                    metroTextBox3.Enabled = true;
                }
                else
                {
                    // Check Settings
                    metroButton15.Enabled = false;
                    metroButton20.Enabled = false;
                    metroButton17.Enabled = false;
                    metroTextBox3.Enabled = false;
                }
            }
        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound == true)
            {
                if (metroToggle4.Checked == true)
                {
                    // Check Settings
                    metroButton16.Enabled = true;
                    metroButton19.Enabled = true;
                    metroButton18.Enabled = true;
                    metroTextBox4.Enabled = true;
                }
                else
                {
                    // Check Settings
                    metroButton16.Enabled = false;
                    metroButton19.Enabled = false;
                    metroButton18.Enabled = false;
                    metroTextBox4.Enabled = false;
                }
            }
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            lineChanger("arguements = " + metroTextBox5.Text , @AppPath + "\\Settings.ini", 21);
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            CustomGameSet = true;
            // Replace current line with new one
            lineChanger("customgamepath = " + metroTextBox3.Text, @AppPath + "\\Settings.ini", 16);
            // Write Setting to ini
            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customgame = false", "customgame = true");
            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Set values
            RegPath = metroTextBox3.Text;
            // Auto Get Dir
            AutoDirFinder();
            // Continue
            metroButton1.Enabled = true;
            PathFound = true;
            metroToggle1.Enabled = true;
            Prompt.Popup("Please Restart App If Done Configurating");
        }

        private void RestoreGamePath()
        {
            CustomGameSet = false;
            // Remove custom values
            metroTextBox3.Text = "";
            // Revert Settings.ini
            lineChanger("customgamepath = ", @AppPath + "\\Settings.ini", 16);
            // Write Setting to ini
            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customgame = true", "customgame = false");
            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Launcher Default
            BnSFolder();
            CheckBackup();
            if (CustomClientSet == false)
            {
                CheckServer();
            }
            VerifySettings();
            // Splash Screen Default
            GetPaths();
            Verify();
            InitializeSplash();
            // Mod Manager Default
            InitializeManager();
            GetPath();
            JsonManager();
            VerifyUsage();
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            RestoreGamePath();
        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result.ToString() == "OK")
            {
                if (Directory.Exists(fbd.SelectedPath + "\\contents"))
                {
                    metroTextBox3.Text = fbd.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for BnS Folder." + " | Path: " + fbd.SelectedPath);
                }
            } else
            {
                Prompt.Popup("Error: Cancelled operation!");
                KillApp();
            }
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            CustomClientSet = true;
            // Rewrite settings to ini
            lineChanger("customclientpath = " + metroTextBox4.Text, @AppPath + "\\Settings.ini", 15);
            // Write Setting to ini
            var fileContents2 = File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customclient = false", "customclient = true");
            System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Set values
            RegPathlol = metroTextBox4.Text;
            try
            {
                if (File.ReadAllText(RegPathlol + "\\NCLauncher.ini").Contains("Game_Region=North America"))
                {
                    metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                }
                else if (File.ReadAllText(RegPathlol + "\\NCLauncher.ini").Contains("Game_Region=Europe"))
                {
                    metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Europe");
                } 
                else // that's for now
                {
                    metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                }
                Prompt.Popup("Please Restart App If Done Configurating");
            }
            catch
            {
                AddTextLog("Error: Could Not Find NCLauncher.ini");
            }
        }

        private void RestoreClientPath()
        {
            CustomClientSet = false;
            // Remove custom values
            metroTextBox4.Text = "";
            // Revert Settings.ini
            lineChanger("customclientpath = ", @AppPath + "\\Settings.ini", 15);
            // Write Setting to ini
            var fileContents2 = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
            fileContents2 = fileContents2.Replace("customclient = true", "customclient = false");
            File.WriteAllText(@AppPath + "\\Settings.ini", fileContents2);
            // Launcher Default
            if (CustomClientSet == false)
            {
                CheckServer();
            }
            VerifySettings();
            // Splash Screen Default
            GetPaths();
            Verify();
            InitializeSplash();
            // Mod Manager Default
            InitializeManager();
            GetPath();
            JsonManager();
            VerifyUsage();
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            RestoreClientPath();
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result.ToString() == "OK")
            {
                if (Directory.Exists(fbd.SelectedPath + "\\Download"))
                {
                    metroTextBox4.Text = fbd.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for NCLauncher Folder." + " | Path: " + fbd.SelectedPath);
                }
            }
            else
            {
                Prompt.Popup("Error: Operation cancelled!");
                KillApp();
            }
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            metroTrackBar1.Value = 500;
            if (metroToggle3.Checked == true)
            {
                metroToggle3.Checked = false;
            }
            if (metroToggle4.Checked == true)
            {
                metroToggle4.Checked = false;
            }
            RestoreGamePath();
            RestoreClientPath();
            RestoreDefault();
            if (metroToggle2.Checked == true)
            {
                metroToggle2.Checked = false;
            }
            if (metroToggle12.Checked == true)
            {
                metroToggle12.Checked = false;
            }
            if (metroToggle13.Checked == true)
            {
                metroToggle13.Checked = false;
            }
            if (metroToggle9.Checked == true)
            {
                metroToggle9.Checked = false;
            }
            if (metroToggle5.Checked == false)
            {
                metroToggle5.Checked = true;
            }
            if (metroToggle6.Checked == false)
            {
                metroToggle6.Checked = true;
            }
            if (metroToggle7.Checked == true)
            {
                metroToggle7.Checked = false;
                metroLabel22.Visible = false;
            }
            if (metroToggle8.Checked == false)
            {
                metroToggle8.Checked = true;
            }
            if (metroToggle10.Checked == false)
            {
                metroToggle10.Checked = true;
            }
            if (metroToggle11.Checked == false)
            {
                metroToggle11.Checked = true;
            }
            if (metroToggle14.Checked == false)
            {
                metroToggle14.Checked = true;
            }
            if (metroToggle15.Checked == false)
            {
                metroToggle15.Checked = true;
            }
            if (metroToggle16.Checked == false)
            {
                metroToggle16.Checked = true;
            }
            try
            {
                // Create if exists
                if (File.Exists(AppPath + "\\Settings.ini")) { File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues); }
                // Create if missing
                if (!File.Exists(AppPath + "\\Settings.ini")) { File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues); }
            }
            catch
            {
                Prompt.Popup("Error: Could Not Restore Settings.ini!");
            }
        }

        private void metroLabel46_Click(object sender, EventArgs e)
        {
            Process.Start("https://udn.epicgames.com/Three/CommandLineArguments.html");
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (AppStarted == true)
            {
                // Get
                string tracker = File.ReadLines(@AppPath + "\\Settings.ini").Skip(21).Take(1).First().Replace("prtime = ", "");
                // Set, replace , write
                var fileContents2 = File.ReadAllText(@AppPath + "\\Settings.ini");
                var newfileContents2 = fileContents2.Replace(tracker, metroTrackBar1.Value.ToString());
                File.WriteAllText(@AppPath + "\\Settings.ini", newfileContents2);
                // Actualise
                wakeywakey = metroTrackBar1.Value;
                metroLabel47.Text = metroTrackBar1.Value.ToString();
                metroLabel47.Refresh();
            }
        }

        private void metroComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            defaultclient = metroComboBox4.SelectedItem.ToString();
            lineChanger("defaultclient = " + defaultclient, @AppPath + "\\Settings.ini", 27);
        }

        public void RestoreDefault()
        {
            if (metroLabel48.Text != "None")
            {
                try
                {
                    // Do defaultset = true
                    var fileContents = System.IO.File.ReadAllText(@AppPath + "\\Settings.ini");
                    fileContents = fileContents.Replace("defaultset = true", "defaultset = false");
                    System.IO.File.WriteAllText(@AppPath + "\\Settings.ini", fileContents);
                    // Do default = path
                    lineChanger("default = ", @AppPath + "\\Settings.ini", 25);
                    // Change label val
                    metroLabel48.Text = "None";
                    // Done
                    MultipleInstallationFound = false;
                }
                catch { AddTextLog("Error: Could not restore default to none!"); }
            }
        }

        private void metroLabel48_Click(object sender, EventArgs e)
        {
            if (metroLabel48.Text != "None")
                RestoreDefault();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Seperator!
        ///////////////////////////////////////////////////////////////////////////////////////////////

        Style BlueStyle = new TextStyle(Brushes.DarkCyan, null, FontStyle.Bold);
        Style RedStyle = new TextStyle(Brushes.OrangeRed, null, FontStyle.Regular);
        Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);
        Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        public string CustomDatFile = "";

        public void CreateDatPaths()
        {
            if (!Directory.Exists(DataPath + "\\editing\\backup"))
            {
                CreatePaths(DataPath + "\\editing\\backup");
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode curNode = addInMe.Add(directoryInfo.Name);

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                curNode.Nodes.Add(file.FullName, file.Name);
            }
            foreach (DirectoryInfo subdir in directoryInfo.GetDirectories())
            {
                BuildTree(subdir, curNode.Nodes);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Name.EndsWith(".xml"))
                {
                    metroLabel39.Text = "Loading...";
                    metroLabel39.Refresh();
                    // Clear text
                    this.fastColoredTextBox1.Clear();
                    // Load text 
                    StreamReader reader = new StreamReader(e.Node.Name);
                    this.fastColoredTextBox1.Text = reader.ReadToEnd();
                    // Close
                    reader.Close();
                    metroLabel39.Text = "Done!";
                    metroLabel39.Refresh();
                }
            }
            catch
            {
                metroLabel39.Text = "Error: Could not open file";
            }
        }

        public string directoryPath = "";
        public string filePath = "";
        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString().Contains(".dat")) && (myDictionary[metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString()].Length > 0))
            {
                ActiveDataFile = metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString();
                string PathAutoFinder = myDictionary[ActiveDataFile];
                treeView1.Nodes.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(PathAutoFinder + ".\\editing\\" + ActiveDataFile + ".files\\");
                if (directoryInfo.Exists)
                {
                    treeView1.AfterSelect += treeView1_AfterSelect;
                    BuildTree(directoryInfo, treeView1.Nodes);
                    treeView1.Nodes[0].Expand();
                }
            }
        }

        private void fctb_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //highlight only visible area of text
            HTMLSyntaxHighlight(fastColoredTextBox1.VisibleRange);
        }
        private void fctb_VisibilityChanged(object sender, EventArgs e)
        {
            //highlight only visible area of text
            HTMLSyntaxHighlight(fastColoredTextBox1.VisibleRange);
        }
        private void HTMLSyntaxHighlight(Range range)
        {
            //clear style of changed range
            range.ClearStyle(BlueStyle, MaroonStyle, RedStyle, GreenStyle);
            //tag brackets highlighting
            range.SetStyle(MaroonStyle, @"<|/>|</|>");
            //tag name
            range.SetStyle(MaroonStyle, @"<(?<range>[!\w]+)");
            //end of tag
            range.SetStyle(MaroonStyle, @"</(?<range>\w+)>");
            //attributes
            range.SetStyle(RedStyle, @"(?<range>\S+?)='[^']*'|(?<range>\S+)=""[^""]*""|(?<range>\S+)=\S+");
            //attribute values
            range.SetStyle(BlueStyle, @"\S+?=(?<range>'[^']*')|\S+=(?<range>""[^""]*"")|\S+=(?<range>\S+)");
            //comment values
            range.SetStyle(GreenStyle, @"<!--(?<range>\S+?)-->");
        }

        private void findCTRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void findReplaceCTRLRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        public void bw2_Save(object Sender, DoWorkEventArgs e)
        {
            if (treeView1.SelectedNode.FullPath.ToString().Contains(".dat"))
            {
                try
                {
                    XmlSavePath = DataPath + "\\editing\\" + treeView1.SelectedNode.FullPath.ToString();
                    try
                    {
                        File.WriteAllText(XmlSavePath, fastColoredTextBox1.Text);
                        metroLabel39.Text = ("Saved!");
                    }
                    catch
                    {
                        metroLabel39.Text = ("Failed to save file!");
                    }
                }
                catch { metroLabel39.Text = ("No file opened in editor!"); }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
                // Save Edited File
                bw2 = new BackgroundWorker();
                bw2.WorkerSupportsCancellation = true;
                bw2.WorkerReportsProgress = true;
                bw2.DoWork += new DoWorkEventHandler(bw2_Save);
            if (!bw2.IsBusy)
            {
                bw2.RunWorkerAsync();
            } else { Prompt.Popup("Please wait until saving is finished."); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                try
                {
                    // Backup the data files
                    DirectoryInfo configfolder = new DirectoryInfo(DataPath);
                    FileInfo[] configfiles = configfolder.GetFiles("*.dat");
                    foreach (FileInfo configfile in configfiles)
                    {
                        if ((configfile.ToString().EndsWith(".dat")) && (myDictionary[configfile.ToString()].Length > 0)) {
                            string tobackup = configfile.ToString();
                            string topath = myDictionary[tobackup];
                            File.Copy(topath + "\\" + tobackup, topath + "\\editing\\backup\\" + tobackup, true);
                            metroLabel39.Text = "Backed Up Data Files";
                        }
                    }
                } catch { Prompt.Popup("Error: Could not backup!"); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            metroLabel39.Text = "Decompiling data file...";
            if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
            {
                string PathtoDat = myDictionary[ActiveDataFile];
                usedfile = ActiveDataFile;
                usedfilepath = PathtoDat + "\\" + ActiveDataFile;
                Extractor(usedfile);
                // SortOutputHandler -> updates text for progress
                treeView1.Nodes.Clear();
                // Seperator
                if (Directory.Exists(PathtoDat + "\\" + ActiveDataFile + ".files")) {
                    if (!Directory.Exists(PathtoDat + "\\editing\\" + ActiveDataFile + ".files"))
                    {
                        Directory.Move(PathtoDat + "\\" + ActiveDataFile + ".files", PathtoDat + "\\editing\\" + ActiveDataFile + ".files");
                    }
                    else
                    {
                        string source = PathtoDat + "\\" + ActiveDataFile + ".files";
                        string target = PathtoDat + "\\editing\\" + ActiveDataFile + ".files";
                        foreach (var file in Directory.EnumerateFiles(source))
                        {
                            var dest = Path.Combine(target, Path.GetFileName(file));
                            File.Copy(file, dest, true);
                            File.Delete(file);
                        }
                        foreach (var dir in Directory.EnumerateDirectories(source))
                        {
                            var dest = Path.Combine(target, Path.GetFileName(dir));
                            Directory.Move(dir, dest);
                        }
                        Directory.Delete(source);
                    }
                    DirectoryInfo directoryInfo = new DirectoryInfo(@PathtoDat + "\\editing\\" + ActiveDataFile + ".files\\");
                    if (directoryInfo.Exists)
                    {
                        treeView1.AfterSelect += treeView1_AfterSelect;
                        BuildTree(directoryInfo, treeView1.Nodes);
                        treeView1.Nodes[0].Expand();
                    } else { metroLabel39.Text = "Error: could not move folder!"; }
                } else { metroLabel39.Text = "Error: " + ActiveDataFile + " could not be extracted!"; }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            metroLabel39.Text = "Compiling data file...";
            if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
            {
                string PathtoDat = myDictionary[ActiveDataFile];
                usedfile = ActiveDataFile;
                usedfilepathonly = PathtoDat + "\\editing\\" + ActiveDataFile + ".files";
                Compiler(usedfile);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
            {
                string PathtoDat = myDictionary[ActiveDataFile];
                if (File.Exists(PathtoDat + "\\editing\\" + ActiveDataFile + ""))
                {
                    NewDat = PathtoDat + "\\editing\\" + ActiveDataFile + ""; 
                    try
                    {
                        File.Copy(NewDat, PathtoDat + "\\" + ActiveDataFile + "", true);
                        metroLabel39.Text = "Patched " + ActiveDataFile + "";
                    }
                    catch
                    {
                        Prompt.Popup("Error: Could not apply patch!");
                    }
                } else { Prompt.Popup("Please Compile"); }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if ((ActiveDataFile != "") && (myDictionary[ActiveDataFile].Length > 0))
            {
                string PathtoDat = myDictionary[ActiveDataFile];
                try
                {
                    File.Copy(PathtoDat + "\\editing\\backup\\" + ActiveDataFile + "", PathtoDat + "\\" + ActiveDataFile + "", true);
                    metroLabel39.Text = "Restored " + ActiveDataFile + "";
                }
                catch
                {
                    metroLabel39.Text = ("Error: Could not restore " + ActiveDataFile + "!");
                }
            }
        }
        
        Dictionary<string, string> myDictionary = new Dictionary<string, string>();
        private void DefaultDatValues()
        {
            // Generate members
            string filesource = "";
            string filesourcepath = "";
            DirectoryInfo configfolder = new DirectoryInfo(DataPath);
            FileInfo[] configfiles = configfolder.GetFiles("*.dat");
            foreach (FileInfo configfile in configfiles)
            {
                filesource = configfile.ToString();
                filesourcepath = Path.GetDirectoryName(configfile.FullName);
                myDictionary.Add(configfile.Name, filesourcepath);
                metroComboBox3.Items.Add(filesource);
            }
            // Select default after compiling
            metroComboBox3.SelectedIndex = 0;
            // Extract Dat Tool
            //bnsdat();
            // Activate Keyboard shortcuts for dat editor
            KeyPreview = true;
        }

        public void SortOutputHandler(string value)
        {
            metroLabel39.Text = value;
            metroLabel39.Refresh();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Prompt.Popup("1: Backup your config files by pressing \"Backup\"" + Environment.NewLine + "2: Select your file to work on then press \"Decompile\" to extract the .dat file" + Environment.NewLine + "3: Select the file to edit in the tree then modify it with the TextBox on the right" + Environment.NewLine + "4: Save the modifications made by pressing \"Save\"" + Environment.NewLine + "5: Compile it all by pressing \"Compile\"" + Environment.NewLine + "6: Apply changes to change from your games untouched config files to the modified ones by pressing \"Apply\"" + Environment.NewLine + "Tip: Restoring your config files can be done by pressing \"Restore\"");
        }

        public void CleanMess()
        {
            string localvar = "";
            try
            {
                AddTextLog("Cleaning Mess");
                DirectoryInfo path = new DirectoryInfo(DataPath + "\\editing");
                foreach (DirectoryInfo subdir in path.GetDirectories())
                {
                    if (subdir.ToString().EndsWith(".dat.files"))
                    {
                        localvar = subdir.ToString();
                        Array.ForEach(Directory.GetFiles(@DataPath + "\\editing\\" + localvar + "\\"), File.Delete);
                        Directory.Delete(DataPath + "\\editing\\" + localvar + "\\", true);
                        AddTextLog("Cleaned " + localvar);
                    }
                }
            } catch { AddTextLog("Could not remove folder -> " + DataPath + "\\editing\\" + localvar + "\\"); } 
        }
    }
   
}

namespace BNSDat
{
    enum BXML_TYPE
    {
        BXML_PLAIN,
        BXML_BINARY,
        BXML_UNKNOWN
    };

    class BPKG_FTE
    {
        public int FilePathLength;
        public string FilePath;
        public byte Unknown_001;
        public bool IsCompressed;
        public bool IsEncrypted;
        public byte Unknown_002;
        public int FileDataSizeUnpacked;
        public int FileDataSizeSheared; // without padding for AES
        public int FileDataSizeStored;
        public int FileDataOffset; // (relative) offset
        public byte[] Padding;

    }

    public class BNSDat
    {

        public string AES_KEY = "bns_obt_kr_2014#";

        public byte[] XOR_KEY = new byte[16] { 164, 159, 216, 179, 246, 142, 57, 194, 45, 224, 97, 117, 92, 75, 26, 7 };

        private byte[] Decrypt(byte[] buffer, int size)
        {
            // AES requires buffer to consist of blocks with 16 bytes (each)
            // expand last block by padding zeros if required...
            // -> the encrypted data in BnS seems already to be aligned to blocks
            int AES_BLOCK_SIZE = AES_KEY.Length;
            int sizePadded = size + AES_BLOCK_SIZE;
            byte[] output = new byte[sizePadded];
            byte[] tmp = new byte[sizePadded];
            buffer.CopyTo(tmp, 0);
            buffer = null;

            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;
            ICryptoTransform decrypt = aes.CreateDecryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            decrypt.TransformBlock(tmp, 0, sizePadded, output, 0);
            tmp = output;
            output = new byte[size];
            Array.Copy(tmp, 0, output, 0, size);
            tmp = null;

            return output;
        }

        private byte[] Deflate(byte[] buffer, int sizeCompressed, int sizeDecompressed)
        {
            byte[] tmp = Ionic.Zlib.ZlibStream.UncompressBuffer(buffer);

            if (tmp.Length != sizeDecompressed)
            {
                byte[] tmp2 = new byte[sizeDecompressed];

                if (tmp.Length > sizeDecompressed)
                    Array.Copy(tmp, 0, tmp2, 0, sizeDecompressed);
                else
                    Array.Copy(tmp, 0, tmp2, 0, tmp.Length);
                tmp = tmp2;
                tmp2 = null;
            }
            return tmp;
        }

        private byte[] Unpack(byte[] buffer, int sizeStored, int sizeSheared, int sizeUnpacked, bool isEncrypted, bool isCompressed)
        {
            byte[] output = buffer;

            if (isEncrypted)
            {
                output = Decrypt(output, sizeStored);
            }

            if (isCompressed)
            {
                output = Deflate(output, sizeSheared, sizeUnpacked);
            }

            // neither encrypted, nor compressed -> raw copy
            if (output == buffer)
            {
                output = new byte[sizeUnpacked];
                if (sizeSheared < sizeUnpacked)
                {
                    Array.Copy(buffer, 0, output, 0, sizeSheared);
                }
                else
                {
                    Array.Copy(buffer, 0, output, 0, sizeUnpacked);
                }
            }

            return output;
        }

        private byte[] Inflate(byte[] buffer, int sizeDecompressed, out int sizeCompressed, int compressionLevel)
        {

            MemoryStream output = new MemoryStream();
            Ionic.Zlib.ZlibStream zs = new Ionic.Zlib.ZlibStream(output, Ionic.Zlib.CompressionMode.Compress, (Ionic.Zlib.CompressionLevel)compressionLevel, true);
            zs.Write(buffer, 0, sizeDecompressed);
            zs.Flush();
            zs.Close();
            sizeCompressed = (int)output.Length;
            return output.ToArray();
        }

        private byte[] Encrypt(byte[] buffer, int size, out int sizePadded)
        {
            int AES_BLOCK_SIZE = AES_KEY.Length;
            sizePadded = size + (AES_BLOCK_SIZE - (size % AES_BLOCK_SIZE));
            byte[] output = new byte[sizePadded];
            byte[] temp = new byte[sizePadded];
            Array.Copy(buffer, 0, temp, 0, buffer.Length);
            buffer = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.ECB;

            ICryptoTransform encrypt = aes.CreateEncryptor(Encoding.ASCII.GetBytes(AES_KEY), new byte[16]);
            encrypt.TransformBlock(temp, 0, sizePadded, output, 0);
            temp = null;
            return output;
        }

        private byte[] Pack(byte[] buffer, int sizeUnpacked, out int sizeSheared, out int sizeStored, bool encrypt, bool compress, int compressionLevel)
        {
            byte[] output = buffer;
            buffer = null;
            sizeSheared = sizeUnpacked;
            sizeStored = sizeSheared;

            if (compress)
            {
                byte[] tmp = Inflate(output, sizeUnpacked, out sizeSheared, compressionLevel);
                sizeStored = sizeSheared;
                output = tmp;
                tmp = null;
            }

            if (encrypt)
            {
                byte[] tmp = Encrypt(output, sizeSheared, out sizeStored);
                output = tmp;
                tmp = null;
            }
            return output;
        }

        public void Extract(string FileName, bool is64 = false)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            string file_path;
            byte[] buffer_packed;
            byte[] buffer_unpacked;

            byte[] Signature = br.ReadBytes(8);
            uint Version = br.ReadUInt32();

            byte[] Unknown_001 = br.ReadBytes(5);
            int FileDataSizePacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            int FileCount = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            bool IsCompressed = br.ReadByte() == 1;
            bool IsEncrypted = br.ReadByte() == 1;
            byte[] Unknown_002 = br.ReadBytes(62);
            int FileTableSizePacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            int FileTableSizeUnpacked = is64 ? (int)br.ReadInt64() : br.ReadInt32();

            buffer_packed = br.ReadBytes(FileTableSizePacked);
            int OffsetGlobal = is64 ? (int)br.ReadInt64() : br.ReadInt32();
            OffsetGlobal = (int)br.BaseStream.Position; // don't trust value, read current stream location.

            byte[] FileTableUnpacked = Unpack(buffer_packed, FileTableSizePacked, FileTableSizePacked, FileTableSizeUnpacked, IsEncrypted, IsCompressed);
            buffer_packed = null;
            MemoryStream ms = new MemoryStream(FileTableUnpacked);
            BinaryReader br2 = new BinaryReader(ms);

            for (int i = 0; i < FileCount; i++)
            {
                BPKG_FTE FileTableEntry = new BPKG_FTE();
                FileTableEntry.FilePathLength = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FilePath = Encoding.Unicode.GetString(br2.ReadBytes(FileTableEntry.FilePathLength * 2));
                FileTableEntry.Unknown_001 = br2.ReadByte();
                FileTableEntry.IsCompressed = br2.ReadByte() == 1;
                FileTableEntry.IsEncrypted = br2.ReadByte() == 1;
                FileTableEntry.Unknown_002 = br2.ReadByte();
                FileTableEntry.FileDataSizeUnpacked = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FileDataSizeSheared = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FileDataSizeStored = is64 ? (int)br2.ReadInt64() : br2.ReadInt32();
                FileTableEntry.FileDataOffset = (is64 ? (int)br2.ReadInt64() : br2.ReadInt32()) + OffsetGlobal;
                FileTableEntry.Padding = br2.ReadBytes(60);

                file_path = String.Format("{0}.files\\{1}", FileName, FileTableEntry.FilePath);
                if (!Directory.Exists((new FileInfo(file_path)).DirectoryName))
                    Directory.CreateDirectory((new FileInfo(file_path)).DirectoryName);

                br.BaseStream.Position = FileTableEntry.FileDataOffset;
                buffer_packed = br.ReadBytes(FileTableEntry.FileDataSizeStored);
                buffer_unpacked = Unpack(buffer_packed, FileTableEntry.FileDataSizeStored, FileTableEntry.FileDataSizeSheared, FileTableEntry.FileDataSizeUnpacked, FileTableEntry.IsEncrypted, FileTableEntry.IsCompressed);
                buffer_packed = null;
                FileTableEntry = null;

                if (file_path.EndsWith("xml") || file_path.EndsWith("x16"))
                {
                    // decode bxml
                    MemoryStream temp = new MemoryStream();
                    MemoryStream temp2 = new MemoryStream(buffer_unpacked);
                    BXML bns_xml = new BXML(XOR_KEY);
                    Convert(temp2, bns_xml.DetectType(temp2), temp, BXML_TYPE.BXML_PLAIN);
                    temp2.Close();
                    File.WriteAllBytes(file_path, temp.ToArray());
                    temp.Close();
                    buffer_unpacked = null;
                }
                else
                {
                    // extract raw
                    File.WriteAllBytes(file_path, buffer_unpacked);
                    buffer_unpacked = null;
                }

                // Report progress
                string whattosend = "Extracting: " + i.ToString() + "/" + FileCount.ToString();
                Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler(whattosend);
                // End report progress
            }

            // Report job done
            Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler("Done!");
            // End report

            br2.Close();
            ms.Close();
            br2 = null;
            ms = null;
            br.Close();
            fs.Close();
            br = null;
            fs = null;
        }

        public void Compress(string Folder, bool is64 = false, int compression = 9)
        {
            string file_path;
            byte[] buffer_packed;
            byte[] buffer_unpacked;

            string[] files = Directory.EnumerateFiles(Folder, "*", SearchOption.AllDirectories).ToArray();

            int FileCount = files.Count();

            BPKG_FTE FileTableEntry = new BPKG_FTE();
            MemoryStream mosTablems = new MemoryStream();
            BinaryWriter mosTable = new BinaryWriter(mosTablems);
            MemoryStream mosFilesms = new MemoryStream();
            BinaryWriter mosFiles = new BinaryWriter(mosFilesms);

            for (int i = 0; i < FileCount; i++)
            {
                file_path = files[i].Replace(Folder, "").TrimStart('\\');
                FileTableEntry.FilePathLength = file_path.Length;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FilePathLength);
                else
                    mosTable.Write(FileTableEntry.FilePathLength);

                FileTableEntry.FilePath = file_path;
                mosTable.Write(Encoding.Unicode.GetBytes(FileTableEntry.FilePath));
                FileTableEntry.Unknown_001 = 2;
                mosTable.Write(FileTableEntry.Unknown_001);
                FileTableEntry.IsCompressed = true;
                mosTable.Write(FileTableEntry.IsCompressed);
                FileTableEntry.IsEncrypted = true;
                mosTable.Write(FileTableEntry.IsEncrypted);
                FileTableEntry.Unknown_002 = 0;
                mosTable.Write(FileTableEntry.Unknown_002);

                FileStream fis = new FileStream(files[i], FileMode.Open);
                MemoryStream tmp = new MemoryStream();

                if (file_path.EndsWith(".xml") || file_path.EndsWith(".x16"))
                {
                    // encode bxml
                    BXML bxml = new BXML(XOR_KEY);
                    Convert(fis, bxml.DetectType(fis), tmp, BXML_TYPE.BXML_BINARY);
                }
                else
                {
                    // compress raw
                    fis.CopyTo(tmp);
                }
                fis.Close();
                fis = null;

                FileTableEntry.FileDataOffset = (int)mosFiles.BaseStream.Position;
                FileTableEntry.FileDataSizeUnpacked = (int)tmp.Length;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeUnpacked);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeUnpacked);

                buffer_unpacked = tmp.ToArray();
                tmp.Close();
                tmp = null;
                buffer_packed = Pack(buffer_unpacked, FileTableEntry.FileDataSizeUnpacked, out FileTableEntry.FileDataSizeSheared, out FileTableEntry.FileDataSizeStored, FileTableEntry.IsEncrypted, FileTableEntry.IsCompressed, compression);
                buffer_unpacked = null;
                mosFiles.Write(buffer_packed);
                buffer_packed = null;

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeSheared);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeSheared);

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataSizeStored);
                else
                    mosTable.Write(FileTableEntry.FileDataSizeStored);

                if (is64)
                    mosTable.Write((long)FileTableEntry.FileDataOffset);
                else
                    mosTable.Write(FileTableEntry.FileDataOffset);

                FileTableEntry.Padding = new byte[60];
                mosTable.Write(FileTableEntry.Padding);

                // Report progress
                string whattosend = "Compiling: " + i.ToString() + "/" + FileCount.ToString();
                Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler(whattosend);
                // End report progress
            }

            // Report job done
            Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler("Packing!");
            // End report

            MemoryStream output = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(output);
            byte[] Signature = new byte[8] { (byte)'U', (byte)'O', (byte)'S', (byte)'E', (byte)'D', (byte)'A', (byte)'L', (byte)'B' };
            bw.Write(Signature);
            int Version = 2;
            bw.Write(Version);
            byte[] Unknown_001 = new byte[5] { 0, 0, 0, 0, 0 };
            bw.Write(Unknown_001);
            int FileDataSizePacked = (int)mosFiles.BaseStream.Length;

            if (is64)
            {
                bw.Write((long)FileDataSizePacked);
                bw.Write((long)FileCount);
            }
            else
            {
                bw.Write(FileDataSizePacked);
                bw.Write(FileCount);
            }

            bool IsCompressed = true;
            bw.Write(IsCompressed);
            bool IsEncrypted = true;
            bw.Write(IsEncrypted);
            byte[] Unknown_002 = new byte[62];
            bw.Write(Unknown_002);

            int FileTableSizeUnpacked = (int)mosTable.BaseStream.Length;
            int FileTableSizeSheared = FileTableSizeUnpacked;
            int FileTableSizePacked = FileTableSizeUnpacked;
            buffer_unpacked = mosTablems.ToArray();
            mosTable.Close();
            mosTablems.Close();
            mosTable = null;
            mosTablems = null;
            buffer_packed = Pack(buffer_unpacked, FileTableSizeUnpacked, out FileTableSizeSheared, out FileTableSizePacked, IsEncrypted, IsCompressed, compression);
            buffer_unpacked = null;

            if (is64)
                bw.Write((long)FileTableSizePacked);
            else
                bw.Write(FileTableSizePacked);

            if (is64)
                bw.Write((long)FileTableSizeUnpacked);
            else
                bw.Write(FileTableSizeUnpacked);

            bw.Write(buffer_packed);
            buffer_packed = null;

            int OffsetGlobal = (int)output.Position + (is64 ? 8 : 4);

            if (is64)
                bw.Write((long)OffsetGlobal);
            else
                bw.Write(OffsetGlobal);

            buffer_packed = mosFilesms.ToArray();
            mosFiles.Close();
            mosFilesms.Close();
            mosFiles = null;
            mosFilesms = null;
            bw.Write(buffer_packed);
            buffer_packed = null;
            File.WriteAllBytes(Folder.Replace(".files", ""), output.ToArray());
            bw.Close();
            output.Close();
            bw = null;
            output = null;

            // Report job done
            Revamped_BnS_Buddy.Form1.CurrentForm.SortOutputHandler("Done!");
            // End report
        }

        private void Convert(Stream iStream, BXML_TYPE iType, Stream oStream, BXML_TYPE oType)
        {
            if ((iType == BXML_TYPE.BXML_PLAIN && oType == BXML_TYPE.BXML_BINARY) || (iType == BXML_TYPE.BXML_BINARY && oType == BXML_TYPE.BXML_PLAIN))
            {
                BXML bns_xml = new BXML(XOR_KEY);
                bns_xml.Load(iStream, iType);
                bns_xml.Save(oStream, oType);
            }
            else
            {
                iStream.CopyTo(oStream);
            }
        }
    }

    class BXML_CONTENT
    {
        public byte[] XOR_KEY;

        void Xor(byte[] buffer, int size)
        {
            for (int i = 0; i < size; i++)
            {
                buffer[i] = (byte)(buffer[i] ^ XOR_KEY[i % XOR_KEY.Length]);
            }
        }

        bool Keep_XML_WhiteSpace = true;

        public void Read(Stream iStream, BXML_TYPE iType)
        {
            if (iType == BXML_TYPE.BXML_PLAIN)
            {
                Signature = new byte[8] { (byte)'L', (byte)'M', (byte)'X', (byte)'B', (byte)'O', (byte)'S', (byte)'L', (byte)'B' };
                Version = 3;
                FileSize = 85;
                Padding = new byte[64];
                Unknown = true;
                OriginalPathLength = 0;

                // NOTE: keep whitespace text nodes (to be compliant with the whitespace TEXT_NODES in bns xml)
                // no we don't keep them, we remove them because it is cleaner
                Nodes.PreserveWhitespace = Keep_XML_WhiteSpace;
                Nodes.Load(iStream);

                // get original path from first comment node
                XmlNode node = Nodes.DocumentElement.ChildNodes.OfType<XmlComment>().First();
                if (node != null && node.NodeType == XmlNodeType.Comment)
                {
                    string Text = node.InnerText;
                    OriginalPathLength = Text.Length;
                    OriginalPath = Encoding.Unicode.GetBytes(Text);
                    Xor(OriginalPath, 2 * OriginalPathLength);
                    if (Nodes.PreserveWhitespace && node.NextSibling.NodeType == XmlNodeType.Whitespace)
                        Nodes.DocumentElement.RemoveChild(node.NextSibling);
                }
                else
                {
                    OriginalPath = new byte[2 * OriginalPathLength];
                }
            }

            if (iType == BXML_TYPE.BXML_BINARY)
            {
                Signature = new byte[8];
                BinaryReader br = new BinaryReader(iStream);
                br.BaseStream.Position = 0;
                Signature = br.ReadBytes(8);
                Version = br.ReadInt32();
                FileSize = br.ReadInt32();
                Padding = br.ReadBytes(64);
                Unknown = br.ReadByte() == 1;
                OriginalPathLength = br.ReadInt32();
                OriginalPath = br.ReadBytes(2 * OriginalPathLength);
                AutoID = 1;
                ReadNode(iStream);

                // add original path as first comment node
                byte[] Path = OriginalPath;
                Xor(Path, 2 * OriginalPathLength);
                XmlComment node = Nodes.CreateComment(Encoding.Unicode.GetString(Path));
                Nodes.DocumentElement.PrependChild(node);
                XmlNode docNode = Nodes.CreateXmlDeclaration("1.0", "utf-8", null);
                Nodes.PrependChild(docNode);
                if (FileSize != iStream.Position)
                {
                    throw new Exception(String.Format("Filesize Mismatch, expected size was {0} while actual size was {1}.", FileSize, iStream.Position));
                }
            }
        }

        public void Write(Stream oStream, BXML_TYPE oType)
        {
            if (oType == BXML_TYPE.BXML_PLAIN)
            {
                Nodes.Save(oStream);
            }
            if (oType == BXML_TYPE.BXML_BINARY)
            {
                BinaryWriter bw = new BinaryWriter(oStream);
                bw.Write(Signature);
                bw.Write(Version);
                bw.Write(FileSize);
                bw.Write(Padding);
                bw.Write(Unknown);
                bw.Write(OriginalPathLength);
                bw.Write(OriginalPath);

                AutoID = 1;
                WriteNode(oStream);

                FileSize = (int)oStream.Position;
                oStream.Position = 12;
                bw.Write(FileSize);
            }

        }

        private void ReadNode(Stream iStream, XmlNode parent = null)
        {

            XmlNode node = null;
            BinaryReader br = new BinaryReader(iStream);
            int Type = 1;
            if (parent != null)
            {
                Type = br.ReadInt32();
            }


            if (Type == 1)
            {
                node = Nodes.CreateElement("Text");

                int ParameterCount = br.ReadInt32();
                for (int i = 0; i < ParameterCount; i++)
                {
                    int NameLength = br.ReadInt32();
                    byte[] Name = br.ReadBytes(2 * NameLength);
                    Xor(Name, 2 * NameLength);

                    int ValueLength = br.ReadInt32();
                    byte[] Value = br.ReadBytes(2 * ValueLength);
                    Xor(Value, 2 * ValueLength);

                    ((XmlElement)node).SetAttribute(Encoding.Unicode.GetString(Name), Encoding.Unicode.GetString(Value));
                }
            }

            if (Type == 2)
            {
                node = Nodes.CreateTextNode("");

                int TextLength = br.ReadInt32();
                byte[] Text = br.ReadBytes(TextLength * 2);
                Xor(Text, 2 * TextLength);

                ((XmlText)node).Value = Encoding.Unicode.GetString(Text);
            }

            if (Type > 2)
            {
                throw new Exception("Unknown XML Node Type");
            }

            bool Closed = br.ReadByte() == 1;
            int TagLength = br.ReadInt32();
            byte[] Tag = br.ReadBytes(2 * TagLength);
            Xor(Tag, 2 * TagLength);
            if (Type == 1)
            {
                node = RenameNode(node, Encoding.Unicode.GetString(Tag));
            }

            int ChildCount = br.ReadInt32();
            AutoID = br.ReadInt32();
            AutoID++;

            for (int i = 0; i < ChildCount; i++)
            {
                ReadNode(iStream, node);
            }

            if (parent != null)
            {
                if (Keep_XML_WhiteSpace || Type != 2 || !String.IsNullOrWhiteSpace(node.Value))
                {
                    parent.AppendChild(node);
                }
            }
            else
            {
                Nodes.AppendChild(node);
            }
        }

        public static XmlNode RenameNode(XmlNode node, string Name)
        {
            if (node.NodeType == XmlNodeType.Element)
            {
                XmlElement oldElement = (XmlElement)node;
                XmlElement newElement =
                node.OwnerDocument.CreateElement(Name);

                while (oldElement.HasAttributes)
                {
                    newElement.SetAttributeNode(oldElement.RemoveAttributeNode(oldElement.Attributes[0]));
                }

                while (oldElement.HasChildNodes)
                {
                    newElement.AppendChild(oldElement.FirstChild);
                }

                if (oldElement.ParentNode != null)
                {
                    oldElement.ParentNode.ReplaceChild(newElement, oldElement);
                }

                return newElement;
            }
            else
                return node;
        }

        private bool WriteNode(Stream oStream, XmlNode parent = null)
        {
            BinaryWriter bw = new BinaryWriter(oStream);
            XmlNode node = null;

            int Type = 1;
            if (parent != null)
            {
                node = parent;
                if (node.NodeType == XmlNodeType.Element)
                {
                    Type = 1;
                }
                if (node.NodeType == XmlNodeType.Text || node.NodeType == XmlNodeType.Whitespace)
                {
                    Type = 2;
                }
                if (node.NodeType == XmlNodeType.Comment)
                {
                    return false;
                }
                bw.Write(Type);
            }
            else
            {
                node = Nodes.DocumentElement;
            }

            if (Type == 1)
            {
                int OffsetAttributeCount = (int)oStream.Position;
                int AttributeCount = 0;
                bw.Write(AttributeCount);

                foreach (XmlAttribute attribute in node.Attributes)
                {
                    string Name = attribute.Name;
                    int NameLength = Name.Length;
                    bw.Write(NameLength);
                    byte[] NameBuffer = Encoding.Unicode.GetBytes(Name);
                    Xor(NameBuffer, 2 * NameLength);
                    bw.Write(NameBuffer);

                    String Value = attribute.Value;
                    int ValueLength = Value.Length;
                    bw.Write(ValueLength);
                    byte[] ValueBuffer = Encoding.Unicode.GetBytes(Value);
                    Xor(ValueBuffer, 2 * ValueLength);
                    bw.Write(ValueBuffer);
                    AttributeCount++;
                }

                int OffsetCurrent = (int)oStream.Position;
                oStream.Position = OffsetAttributeCount;
                bw.Write(AttributeCount);
                oStream.Position = OffsetCurrent;
            }

            if (Type == 2)
            {
                string Text = node.Value;
                int TextLength = Text.Length;
                bw.Write(TextLength);
                byte[] TextBuffer = Encoding.Unicode.GetBytes(Text);
                Xor(TextBuffer, 2 * TextLength);
                bw.Write(TextBuffer);

            }

            if (Type > 2)
            {
                throw new Exception(String.Format("ERROR: XML NODE TYPE [{0}] UNKNOWN", node.NodeType.ToString()));
            }

            bool Closed = true;
            bw.Write(Closed);
            string Tag = node.Name;
            int TagLength = Tag.Length;
            bw.Write(TagLength);
            byte[] TagBuffer = Encoding.Unicode.GetBytes(Tag);
            Xor(TagBuffer, 2 * TagLength);
            bw.Write(TagBuffer);

            int OffsetChildCount = (int)oStream.Position;
            int ChildCount = 0;
            bw.Write(ChildCount);
            bw.Write(AutoID);
            AutoID++;

            foreach (XmlNode child in node.ChildNodes)
            {
                if (WriteNode(oStream, child))
                {
                    ChildCount++;
                }
            }

            int OffsetCurrent2 = (int)oStream.Position;
            oStream.Position = OffsetChildCount;
            bw.Write(ChildCount);
            oStream.Position = OffsetCurrent2;
            return true;
        }

        byte[] Signature;                  // 8 byte
        int Version;                   // 4 byte
        int FileSize;                  // 4 byte
        byte[] Padding;                    // 64 byte
        bool Unknown;                       // 1 byte
        // TODO: add to CDATA ?
        int OriginalPathLength;        // 4 byte
        byte[] OriginalPath;               // 2*OriginalPathLength bytes

        int AutoID;
        XmlDocument Nodes = new XmlDocument();
    }

    class BXML
    {
        private BXML_CONTENT _content = new BXML_CONTENT();

        private byte[] XOR_KEY { get { return _content.XOR_KEY; } set { _content.XOR_KEY = value; } }

        public BXML(byte[] xor)
        {
            XOR_KEY = xor;
        }

        public void Load(Stream iStream, BXML_TYPE iType)
        {
            _content.Read(iStream, iType);
        }

        public void Save(Stream oStream, BXML_TYPE oType)
        {
            _content.Write(oStream, oType);
        }

        public BXML_TYPE DetectType(Stream iStream)
        {
            int offset = (int)iStream.Position;
            iStream.Position = 0;
            byte[] Signature = new byte[13];
            iStream.Read(Signature, 0, 13);
            iStream.Position = offset;

            BXML_TYPE result = BXML_TYPE.BXML_UNKNOWN;

            if (
                BitConverter.ToString(Signature).Replace("-", "").Replace("00", "").Contains(BitConverter.ToString(new byte[] { (byte)'<', (byte)'?', (byte)'x', (byte)'m', (byte)'l' }).Replace("-", ""))
            )
            {
                result = BXML_TYPE.BXML_PLAIN;
            }

            if (
                Signature[7] == 'B' &&
                Signature[6] == 'L' &&
                Signature[5] == 'S' &&
                Signature[4] == 'O' &&
                Signature[3] == 'B' &&
                Signature[2] == 'X' &&
                Signature[1] == 'M' &&
                Signature[0] == 'L'
            )
            {
                result = BXML_TYPE.BXML_BINARY;
            }

            return result;
        }
    }
}

