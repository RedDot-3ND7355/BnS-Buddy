using FastColoredTextBoxNS;
using Ionic.Zlib;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Win32;
using Mono.Math;
using Newtonsoft.Json.Linq;
using Revamped_BnS_Buddy.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml;
using WMI_ProcessorInformation;

namespace Revamped_BnS_Buddy
{
    public partial class Form1 : MetroForm
    {
        public static class Prompt
        {
            public static MetroColorStyle ColorSet
            {
                get;
                internal set;
            }

            public static string MultipleLang(string Description, string Title, Dictionary<int, string> languages)
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
                MetroForm metroForm = new MetroForm();
                metroForm.ShadowType = MetroFormShadowType.AeroShadow;
                metroForm.Width = 280;
                metroForm.Height = 135;
                metroForm.FormBorderStyle = FormBorderStyle.None;
                metroForm.Resizable = false;
                metroForm.Icon = (Icon)componentResourceManager.GetObject("notifyIcon1.Icon");
                metroForm.ControlBox = false;
                metroForm.Theme = MetroThemeStyle.Dark;
                metroForm.DisplayHeader = false;
                metroForm.TopMost = true;
                metroForm.Text = Title;
                metroForm.StartPosition = FormStartPosition.CenterScreen;
                MetroForm prompt = metroForm;
                MetroLabel value = new MetroLabel
                {
                    Left = 5,
                    Top = 20,
                    Text = Description,
                    Width = 270,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Theme = MetroThemeStyle.Dark
                };
                MetroComboBox metroComboBox = new MetroComboBox
                {
                    Left = 5,
                    Top = 70,
                    Width = 270,
                    Theme = MetroThemeStyle.Dark,
                    ImeMode = ImeMode.NoControl
                };
                MetroButton metroButton = new MetroButton
                {
                    Text = "Ok",
                    Left = 5,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.OK,
                    Theme = MetroThemeStyle.Dark
                };
                metroButton.Click += delegate
                {
                    prompt.Close();
                };
                metroButton.TabStop = false;
                metroComboBox.Text = "Choose Game Language";
                metroComboBox.Items.Add("Choose Game Language");
                metroComboBox.SelectedIndex = 0;
                metroComboBox.TabStop = false;
                for (int i = 0; languages.Count > i; i++)
                {
                    metroComboBox.Items.Add(languages[i]);
                }
                prompt.Controls.Add(metroComboBox);
                prompt.Controls.Add(metroButton);
                prompt.Controls.Add(value);
                prompt.AcceptButton = metroButton;
                prompt.Style = ColorSet;
                prompt.ShowDialog();
                if (metroComboBox.SelectedItem.ToString() == "Choose Game Language")
                {
                    metroComboBox.SelectedIndex = 1;
                }
                return metroComboBox.SelectedItem.ToString();
            }

            public static string MultipleInstallation(string Description, string Title, Dictionary<string, string> installs)
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
                MetroForm metroForm = new MetroForm();
                metroForm.ShadowType = MetroFormShadowType.AeroShadow;
                metroForm.Width = 280;
                metroForm.Height = 135;
                metroForm.FormBorderStyle = FormBorderStyle.None;
                metroForm.Resizable = false;
                metroForm.Icon = (Icon)componentResourceManager.GetObject("notifyIcon1.Icon");
                metroForm.ControlBox = false;
                metroForm.Theme = MetroThemeStyle.Dark;
                metroForm.DisplayHeader = false;
                metroForm.TopMost = true;
                metroForm.Text = Title;
                metroForm.StartPosition = FormStartPosition.CenterScreen;
                MetroForm prompt = metroForm;
                MetroLabel value = new MetroLabel
                {
                    Left = 5,
                    Top = 20,
                    Text = Description,
                    Width = 270,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Theme = MetroThemeStyle.Dark
                };
                MetroComboBox metroComboBox = new MetroComboBox
                {
                    Left = 5,
                    Top = 70,
                    Width = 270,
                    Theme = MetroThemeStyle.Dark,
                    ImeMode = ImeMode.NoControl
                };
                MetroButton metroButton = new MetroButton
                {
                    Text = "Ok",
                    Left = 5,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.OK,
                    Theme = MetroThemeStyle.Dark
                };
                metroButton.Click += delegate
                {
                    prompt.Close();
                };
                metroButton.TabStop = false;
                metroComboBox.Items.Add("Choose Default Installation");
                if (installs.ContainsKey("NA/EU") && installs["NA/EU"].ToString().Length > 1)
                {
                    metroComboBox.Items.Add("NA/EU");
                }
                if (installs.ContainsKey("Taiwan") && installs["Taiwan"].ToString().Length > 1)
                {
                    metroComboBox.Items.Add("Taiwan");
                }
                if (installs.ContainsKey("Japanese") && installs["Japanese"].ToString().Length > 1)
                {
                    metroComboBox.Items.Add("Japanese");
                }
                if (installs.ContainsKey("Korean") && installs["Korean"].ToString().Length > 1)
                {
                    metroComboBox.Items.Add("Korean");
                }
                if (installs.ContainsKey("Korean Test") && installs["Korean Test"].ToString().Length > 1)
                {
                    metroComboBox.Items.Add("Korean Test");
                }
                metroComboBox.TabStop = false;
                metroComboBox.SelectedIndex = 0;
                prompt.Controls.Add(metroComboBox);
                prompt.Controls.Add(metroButton);
                prompt.Controls.Add(value);
                prompt.AcceptButton = metroButton;
                prompt.Style = ColorSet;
                prompt.ShowDialog();
                if (metroComboBox.SelectedItem.ToString() == "Choose Default Installation")
                {
                    metroComboBox.SelectedIndex = 1;
                }
                return installs[metroComboBox.SelectedItem.ToString()];
            }

            public static void Popup(string Message)
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
                MetroForm obj = new MetroForm
                {
                    ShadowType = MetroFormShadowType.AeroShadow,
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    Icon = (Icon)componentResourceManager.GetObject("notifyIcon1.Icon"),
                    ControlBox = false,
                    Theme = MetroThemeStyle.Dark,
                    Style = MetroColorStyle.White,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroLabel value = new MetroLabel
                {
                    Dock = DockStyle.Fill,
                    AutoSize = true,
                    Left = 5,
                    Top = 0,
                    Text = Message + Environment.NewLine + Environment.NewLine,
                    Width = 270,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Theme = MetroThemeStyle.Dark
                };
                MetroButton metroButton = new MetroButton
                {
                    Dock = DockStyle.Bottom,
                    Text = "Ok",
                    Left = 5,
                    Width = 100,
                    Top = obj.Height - 20,
                    DialogResult = DialogResult.OK,
                    Theme = MetroThemeStyle.Dark
                };
                metroButton.TabStop = false;
                obj.Controls.Add(metroButton);
                obj.Controls.Add(value);
                obj.AcceptButton = metroButton;
                obj.Style = ColorSet;
                obj.ShowDialog();
            }

            public static DialogResult FirstTimeUse()
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
                MetroForm obj = new MetroForm
                {
                    ShadowType = MetroFormShadowType.AeroShadow,
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = (Icon)componentResourceManager.GetObject("notifyIcon1.Icon"),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroLabel value = new MetroLabel
                {
                    Text = "Would you like to run automatic updates for each run?",
                    AutoSize = true,
                    Left = 5,
                    Top = 20,
                    Width = 270,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Theme = MetroThemeStyle.Dark
                };
                MetroButton metroButton = new MetroButton
                {
                    Text = "Yes",
                    Left = 5,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.Yes,
                    Theme = MetroThemeStyle.Dark
                };
                MetroButton metroButton2 = new MetroButton
                {
                    Text = "No",
                    Left = 125,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.No,
                    Theme = MetroThemeStyle.Dark
                };
                metroButton.TabStop = false;
                metroButton2.TabStop = false;
                obj.Controls.Add(metroButton);
                obj.Controls.Add(value);
                obj.Controls.Add(metroButton2);
                obj.AcceptButton = metroButton;
                obj.AcceptButton = metroButton2;
                obj.Style = ColorSet;
                return obj.ShowDialog();
            }

            public static DialogResult RestoreConfigAsk()
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
                MetroForm metroForm = new MetroForm
                {
                    ShadowType = MetroFormShadowType.AeroShadow,
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = (Icon)componentResourceManager.GetObject("notifyIcon1.Icon"),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroLabel metroLabel = new MetroLabel();
                metroLabel.Text = "You are about to restore the selected file back to normal" + Environment.NewLine + "Please make sure the file is dated from this patch." + Environment.NewLine + "Are you willing to continue?";
                metroLabel.AutoSize = true;
                metroLabel.Left = 5;
                metroLabel.Top = 20;
                metroLabel.Width = 270;
                metroLabel.Height = 40;
                metroLabel.TextAlign = ContentAlignment.MiddleCenter;
                metroLabel.Theme = MetroThemeStyle.Dark;
                MetroLabel value = metroLabel;
                MetroButton metroButton = new MetroButton
                {
                    Text = "Yes",
                    Left = 5,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.Yes,
                    Theme = MetroThemeStyle.Dark
                };
                MetroButton metroButton2 = new MetroButton
                {
                    Text = "No",
                    Left = 125,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.No,
                    Theme = MetroThemeStyle.Dark
                };
                metroButton.TabStop = false;
                metroButton2.TabStop = false;
                metroForm.Controls.Add(metroButton);
                metroForm.Controls.Add(value);
                metroForm.Controls.Add(metroButton2);
                metroForm.AcceptButton = metroButton;
                metroForm.AcceptButton = metroButton2;
                metroForm.Style = ColorSet;
                return metroForm.ShowDialog();
            }

            public static DialogResult MultipleClient()
            {
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
                MetroForm obj = new MetroForm
                {
                    ShadowType = MetroFormShadowType.AeroShadow,
                    Width = 280,
                    Height = 135,
                    FormBorderStyle = FormBorderStyle.None,
                    Resizable = false,
                    AutoSize = true,
                    Icon = (Icon)componentResourceManager.GetObject("notifyIcon1.Icon"),
                    AutoSizeMode = AutoSizeMode.GrowOnly,
                    ControlBox = false,
                    Theme = MetroThemeStyle.Dark,
                    DisplayHeader = false,
                    TopMost = true,
                    Text = "",
                    StartPosition = FormStartPosition.CenterScreen
                };
                MetroLabel value = new MetroLabel
                {
                    Text = "32bit and 64bit clients were found. Which would you like to use by default?",
                    AutoSize = true,
                    Left = 5,
                    Top = 20,
                    Width = 270,
                    Height = 40,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Theme = MetroThemeStyle.Dark
                };
                MetroButton metroButton = new MetroButton
                {
                    Text = "32 bit",
                    Left = 5,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.Yes,
                    Theme = MetroThemeStyle.Dark
                };
                MetroButton metroButton2 = new MetroButton
                {
                    Text = "64 bit",
                    Left = 125,
                    Width = 100,
                    Top = 100,
                    DialogResult = DialogResult.No,
                    Theme = MetroThemeStyle.Dark
                };
                metroButton.TabStop = false;
                metroButton2.TabStop = false;
                obj.Controls.Add(metroButton);
                obj.Controls.Add(value);
                obj.Controls.Add(metroButton2);
                obj.AcceptButton = metroButton;
                obj.AcceptButton = metroButton2;
                obj.Style = ColorSet;
                return obj.ShowDialog();
            }
        }

        public class BNSXorEncryption
        {
            private byte[] encKey;

            private byte[] decKey;

            private int encCounter;

            private int decCounter;

            private int encSum;

            private int decSum;

            private byte[] key;

            public BNSXorEncryption(byte[] keyInt)
            {
                key = keyInt;
            }

            public byte[] Encrypt(byte[] src, int offset, int len)
            {
                if (encKey == null)
                {
                    if (key == null)
                    {
                        return null;
                    }
                    encKey = new byte[key.Length];
                    key.CopyTo(encKey, 0);
                    encCounter = 0;
                }
                return BlockEncrypt(src, encKey, ref encCounter, ref encSum);
            }

            public byte[] Decrypt(byte[] src, int offset, int len)
            {
                if (decKey == null)
                {
                    if (key == null)
                    {
                        return null;
                    }
                    decKey = new byte[key.Length];
                    key.CopyTo(decKey, 0);
                    decCounter = 0;
                }
                return BlockEncrypt(src, decKey, ref decCounter, ref decSum);
            }

            private byte[] BlockEncrypt(byte[] src, byte[] key, ref int counter, ref int sum)
            {
                for (int i = 0; i < src.Length; i++)
                {
                    int num = counter = ((counter + 1) & 0xFF);
                    int num2 = sum = ((sum + key[num]) & 0xFF);
                    int num3 = key[num];
                    key[num] = key[num2];
                    key[num2] = (byte)num3;
                    src[i] = (byte)(src[i] ^ key[(key[sum] + key[counter]) & 0xFF]);
                }
                return src;
            }
        }

        private class region
        {
            public string name;

            public string value;

            public string appId;

            public region(string n, string v, string a)
            {
                name = n;
                value = v;
                appId = a;
            }

            public override string ToString()
            {
                return name;
            }
        }

        public static Form1 CurrentForm;

        public string LauncherPath = "\\bin";

        public string LauncherPath64 = "\\bin64";

        public string regionIDValue = "";

        public string TempPath = Path.GetTempPath();

        public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

        public string mine = Process.GetCurrentProcess().Id.ToString();

        public string IP = "0.0.0.0";

        public string FinalToken = "";

        public string regionID = "0";

        public string languageID = "English";

        public string LaunchPath = "";

        public string NoTextureStreaming = "";

        public string Unattended = "";

        public string ms = " ms";

        public string s = "";

        public int ping;

        public string FullPath = "";

        public string DataPath = "";

        public string FullBackupPath = "";

        public string DatPath = "";

        public string RegPath = "";

        public string RegPathlol = "";

        public string GamePath = "";

        public string defaultclient = "";

        public string TaiwanPath = "";

        public string CustomGamePath = "";

        public string CustomClientPath = "";

        public string DefaultValues = "unattended = false" + Environment.NewLine + "notexturestreaming = false" + Environment.NewLine + "savelogs = false" + Environment.NewLine + "showlogs = true" + Environment.NewLine + "variables = false" + Environment.NewLine + "tooltips = true" + Environment.NewLine + "customgame = false" + Environment.NewLine + "customclient = false" + Environment.NewLine + "admincheck = true" + Environment.NewLine + "ncsoftlogin = false" + Environment.NewLine + "showdonate = true" + Environment.NewLine + "minimize = true" + Environment.NewLine + "launcherlogs = false" + Environment.NewLine + "modmanlogs = false" + Environment.NewLine + "customclientpath = " + Environment.NewLine + "customgamepath = " + Environment.NewLine + "updatechecker = true" + Environment.NewLine + "pingchecker = true" + Environment.NewLine + "gamekiller = true" + Environment.NewLine + "useallcores = false" + Environment.NewLine + "arguments = " + Environment.NewLine + "prtime = 5000" + Environment.NewLine + "autoupdate = true" + Environment.NewLine + "firsttime = true" + Environment.NewLine + "default = " + Environment.NewLine + "defaultset = false" + Environment.NewLine + "defaultclient = " + Environment.NewLine + "priority = Normal" + Environment.NewLine + "modfolder = " + Environment.NewLine + "modfolderset = false" + Environment.NewLine + "rememberme = false" + Environment.NewLine + "automemorycleanup = false" + Environment.NewLine + "langset = false" + Environment.NewLine + "langpath = " + Environment.NewLine + "boostprocess = true" + Environment.NewLine + "cleanint = OFF" + Environment.NewLine + "uniquepass = " + Environment.NewLine + "gcdshow = false" + Environment.NewLine + "igpshow = false" + Environment.NewLine + "autologin = false" + Environment.NewLine + "usercountcheck = true" + Environment.NewLine + "showcount = true" + Environment.NewLine + "customclientname = " + Environment.NewLine + "buddycolor = Blue" + Environment.NewLine + "lastserver = " + Environment.NewLine + "menuslidereffect = true" + Environment.NewLine + "affinityproc = All" + Environment.NewLine + "keepintray = false";

        public string ActiveDataFile = "";

        public string XmlSavePath = "";

        public string NewDat = "";

        public string UseAllCores = "";

        public string LoadingSplash = "";

        public string langremembered = "";

        public bool UseToken;

        public bool Backup;

        public bool PathFound = true;

        public bool logs_active = true;

        public bool GameStarted;

        public bool SaveLogs;

        public bool LauncherLogs;

        public bool ModManLogs;

        public bool AdminCheck = true;

        public bool AllowMinimize = true;

        public bool ShowLogs = true;

        public bool CustomGameSet;

        public bool CustomClientSet;

        public bool GameKiller = true;

        public bool UpdateChecker = true;

        public bool PingChecker = true;

        public bool nonmodded;

        public bool AutoUpdate = true;

        public bool FirstTime = true;

        public bool readyclient;

        public bool MultipleInstallationFound;

        public bool AutoClean;

        public bool KoreanTestInstalled;

        public string online = "";

        public string offline = "";

        public int bad = Convert.ToInt32("120");

        public int medium = Convert.ToInt32("65");

        public int good = Convert.ToInt32("1");

        public int wakeywakey = 500;

        public int appuniqueid;

        public BackgroundWorker bw1;

        public BackgroundWorker bw2;

        public BackgroundWorker bw3;

        public BackgroundWorker bwcount;

        public BackgroundWorker bnsdat;

        public BackgroundWorker bnsdatc;

        public Form2 s2;

        public UpdaterTransition UT;

        public OperatingSystem OSVERSION = Environment.OSVersion;

        private bool is64bit;

        private bool UserCountCheck = true;

        private bool manualcount;

        private bool Reg64;

        private Dictionary<string, string> Installs = new Dictionary<string, string>();

        private string autofinder = "";

        private string autocook = "";

        private bool Korean;

        private bool MultipleLangFound;

        private Dictionary<int, string> LangDictionary = new Dictionary<int, string>();

        public bool AppStarted;

        private ProcessPriorityClass Priority = ProcessPriorityClass.Normal;

        private string PreviousServer = "";

        private bool Conflict;

        private bool workedSRV;

        public string usedfile = "";

        public string usedfilepath = "";

        public string usedfilepathonly = "";

        public bool BNSis64;

        public bool isModded;

        private AutoResetEvent waitbw = new AutoResetEvent(initialState: false);

        public bool workedREG;

        private bool prioboost;

        private Dictionary<string, string> ClearClient = new Dictionary<string, string>();

        private string datbackup = "";

        private Dictionary<string, int> ClientHandler = new Dictionary<string, int>();

        private string datverifier = "";

        private int CleanerVal;

        private bool Maintenance;

        private bool LoginOccured;

        private string RegPathSplash = "";

        private string FullPathSplash = "";

        private string FullBackupPathSplash = "";

        private string NewFullBackupPathSplash = "";

        private string workingPathSplash = "";

        private string ModPathSplash = "";

        private string NewModPathSplash = "";

        private string NewSplash = "";

        private string ExtensionSplash = "";

        public BackgroundWorker bw;

        private string backupFolderPath = "";

        private string modFolderPath = "";

        private string modsFolderPath = "";

        private string workingPath = "";

        public string originalFolderPath = "";

        public string bnsExeFolderPath = "";

        public string ncsoftExeFolderPath = "";

        public bool bnsFolderIsSet = true;

        public bool ncsoftFolderIsSet = true;

        private string tmpdir = "";

        private string NewPath = "";

        private string FullModPathMan = "";

        private string FullModsPathMan = "";

        private string FullSettingsPathMan = "";

        private string RealModPath = "";

        public string newbackuppath = "";

        public string tmpnode = "";

        private AutoResetEvent _workerCompleted = new AutoResetEvent(initialState: false);

        private AutoResetEvent completemodding = new AutoResetEvent(initialState: false);

        private Dictionary<int, string> Donewith = new Dictionary<int, string>();

        public string catcher = "";

        private enterCode enterCodePrompt;

        private bool CustomModSet;

        public string FullAddonPath = "";

        private Dictionary<int, string> Search = new Dictionary<int, string>();

        private Dictionary<int, string> Replace = new Dictionary<int, string>();

        private bool ClearCV3;

        private bool presschk;

        private Style BlueStyle = new TextStyle(Brushes.DarkCyan, null, FontStyle.Bold);

        private Style RedStyle = new TextStyle(Brushes.OrangeRed, null, FontStyle.Regular);

        private Style MaroonStyle = new TextStyle(Brushes.Maroon, null, FontStyle.Regular);

        private Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Italic);

        public string CustomDatFile = "";

        public string directoryPath = "";

        public string filePath = "";

        private Dictionary<string, string> myDictionary = new Dictionary<string, string>();

        private bool Debugging = false;

        private BackgroundWorker worker;

        private BackgroundWorker keepAliveBw;

        private string username;

        private string password;

        private string epoch;

        private string authEmailUsername;

        private string authEmailIP;

        private string authEmailCountry;

        private string authEmailCode;

        private string pid;

        private string localIP;

        private string outsideIP;

        private string args = "{0}";

        private string token;

        private string LoginId;

        private string LoginIp;

        private string LoginProgramid;

        private int LoginPort;

        private int counter;

        private string LoginAppid;

        private BNSXorEncryption xor;

        private List<region> regions = new List<region>();

        private string currentAppId;

        private string currentValue;

        public static BigInteger N = new BigInteger("E306EBC02F1DC69F5B437683FE3851FD9AAA6E97F4CBD42FC06C72053CBCED68EC570E6666F529C58518CF7B299B5582495DB169ADF48ECEB6D65461B4D7C75DD1DA89601D5C498EE48BB950E2D8D5E0E0C692D613483B38D381EA9674DF74D67665259C4C31A29E0B3CFF7587617260E8C58FFA0AF8339CD68DB3ADB90AAFEE");

        public static BigInteger P = new BigInteger("7A39FF57BCBFAA521DCE9C7DEFAB520640AC493E1B6024B95A28390E8F05787D");

        public static byte[] staticKey = Conversions.HexStr2Bytes("AC34F3070DC0E52302C2E8DA0E3F7B3E63223697555DF54E7122A14DBC99A3E8");

        public static BigInteger Two = new BigInteger(2u);

        private BigInteger privateKey;

        private BigInteger exchangeKey = Two;

        private BigInteger exchangeKeyServer;

        private BigInteger session;

        private BigInteger validate;

        private SHA256 sha = SHA256.Create();

        private byte[] key;

        private bool encStart;

        private Dictionary<int, string[]> responseHandler;

        private TcpClient LoginServer;

        private NetworkStream ns;

        private bool uniquekeyset;

        private string uniquekey = "";

        private string customclientname = "";

        private System.Windows.Forms.Timer cooldown = new System.Windows.Forms.Timer();

        private System.Windows.Forms.Timer cooldown1 = new System.Windows.Forms.Timer();

        private bool MenuHided = true;

        public const int WM_NCLBUTTONDOWN = 161;

        public const int HT_CAPTION = 2;

        private bool SliderEffect = true;

        private Dictionary<string, string> ToClearReg = new Dictionary<string, string>();

        private System.Windows.Forms.Timer countdown = new System.Windows.Forms.Timer();

        private Dictionary<string, Dictionary<string, string[]>> filesToEdit;

        private static Mutex mutex;
        public void FileCheck()
        {
            mutex = new Mutex(true, "BnSBuddy", out bool createdNew);
            if (!createdNew)
            {
                Process[] pl = Process.GetProcessesByName("BnS Buddy");
                Process p = null;
                int current = Process.GetCurrentProcess().Id;
                foreach (Process ps in pl)
                {
                    if (ps.Id != current)
                        p = ps;
                }
                if (p != null)
                {
                    if (p.MainWindowHandle != null && p.MainWindowHandle != IntPtr.Zero)
                    {
                        var element = AutomationElement.FromHandle(p.MainWindowHandle);
                        if (element != null)
                        {
                            var pattern = element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                            if (pattern != null)
                                pattern.SetWindowVisualState(WindowVisualState.Normal);
                        }
                    }
                    else
                    {
                        IntPtr t = FindWindow();
                        if (t != null && t != IntPtr.Zero)
                        {
                            var element = AutomationElement.FromHandle(t);
                            if (element != null)
                            {
                                var pattern = element.GetCurrentPattern(WindowPattern.Pattern) as WindowPattern;
                                if (pattern != null)
                                    pattern.SetWindowVisualState(WindowVisualState.Normal);
                            }
                        }
                        else
                        {
                            Prompt.Popup("BnS Buddy is already running! Closing...");
                        }
                    }
                }
                else
                {
                    Prompt.Popup("BnS Buddy is already running! Closing...");
                }
                KillApp();
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        public static IntPtr FindWindow()
        {
            IntPtr thisPtr = FindWindow(null, "BnS Buddy");
            IntPtr parentPtr = GetParent(thisPtr);
            thisPtr = FindWindowEx(parentPtr, IntPtr.Zero, null, "BnS Buddy");
            thisPtr = FindWindowEx(parentPtr, thisPtr, null, "BnS Buddy");
            return thisPtr;
        }

        public Form1()
        {
            CurrentForm = this;
            InitializeComponent();
            Unhandler();
            initControlsRecursive(base.Controls);
            ValidateBuddy();
            SetUniqueKey();
            CheckTab();
            FileCheck();
            OSCheck();
            AdminChecker();
            FirstTimeUse();
            SplashScreen();
            KillGame();
            try
            {
                if (!CustomGameSet)
                {
                    BnSFolder();
                }
            }
            catch (Exception ex)
            {
                Prompt.Popup(ex.ToString());
            }
            CheckBackup();
            try
            {
                if (!CustomClientSet)
                {
                    CheckServer();
                }
            }
            catch (Exception ex2)
            {
                Prompt.Popup(ex2.ToString());
            }
            VerifySettings();
            GetPaths();
            Verify();
            InitializeSplash();
            InitializeManager();
            GetPath();
            JsonManager();
            PopulateTreeView(FullModPathMan);
            VerifyUsage();
            CleanMess();
            CleanOtherMess();
            DefaultDatValues();
            CreateDatPaths();
            InitializeAddons();
            IniToggles();
            GetCountFTH();
            Details();
            FixSizes();
            enterCodePrompt = new enterCode(this);
            Task.Delay(1000);
            EnableForm1();
        }

        private void OSCheck()
        {
            is64bit = Environment.Is64BitOperatingSystem;
            if (OSVERSION.Version.Major < 6)
            {
                Prompt.Popup("You must have atleast Windows Vista or above for BnS Buddy to work.");
                KillApp();
            }
        }

        private void isWin10_BoolChanged()
        {
        }

        private void initControlsRecursive(Control.ControlCollection coll)
        {
            foreach (Control item in coll)
            {
                item.Click += delegate
                {
                    if (item.GetType().ToString() == "MetroFramework.Controls.MetroButton")
                    {
                        base.ActiveControl = null;
                    }
                };
                Control.ControlCollection controls = item.Controls;
                initControlsRecursive(controls);
            }
        }

        private void AdminChecker()
        {
            if (AdminCheck && !IsAdministrator())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("cmd", "/c timeout 1 && \"" + Application.ExecutablePath + "\"")
                {
                    Verb = "runas",
                    RedirectStandardError = false,
                    RedirectStandardOutput = false,
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();
                }
                KillApp();
            }
        }

        public bool IsAdministrator()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void metroButton35_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(0);
        }

        public string urltobrowseto = "https://www.exitlag.com/refer/443658";
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start(urltobrowseto);
        }

        private void Unhandler()
        {
            if (!AppDomain.CurrentDomain.FriendlyName.Contains("vshost.exe"))
            {
                Application.ThreadException += Form1_UIThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                string str = ((Exception)e.ExceptionObject).Message.Replace(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)), "[censored]");
                Prompt.Popup("An application error occurred. Please contact Endless and report this error!" + Environment.NewLine + "Error: " + str);
            }
            catch (Exception ex)
            {
                try
                {
                    string str2 = ex.Message.Replace(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)), "[censored]");
                    Prompt.Popup("Fatal Non-UI Error, can't proceed." + Environment.NewLine + "Reason: " + str2);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            try
            {
                string str = t.Exception.ToString().Replace(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)), "[censored]");
                Prompt.Popup("Report this error to Endless along with a screenshot, thank you!" + Environment.NewLine + str);
            }
            catch
            {
                try
                {
                    Prompt.Popup("Fatal Windows Forms Error, can't proceed.");
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PerformClose();
        }

        private void ConfigureContext()
        {
            ContextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();
            MenuItem menuItem2 = new MenuItem();
            ContextMenu.MenuItems.AddRange(new MenuItem[2]
            {
            menuItem,
            menuItem2
            });
            menuItem.Index = 1;
            menuItem.Text = "Exit BnS Buddy";
            menuItem.Click += metroButton14_Click;
            menuItem2.Index = 0;
            menuItem2.Text = "Restore BnS Buddy";
            menuItem2.Click += NotifAction_Mask;
            notifyIcon1.ContextMenu = ContextMenu;
        }

        private void NotifAction_Mask(object sender, EventArgs e)
        {
            NotifAction();
        }

        public void StartupBuddy()
        {
            Process process = new Process();
            process.StartInfo.FileName = Application.ExecutablePath;
            process.Start();
            KillApp();
        }

        private void Get_Count()
        {
            if (manualcount)
            {
                string str = "false";
                if (!UserCountCheck)
                {
                    str = "true";
                }
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        webClient.Headers.Add("User-Agent", "BnSBuddy");
                        string text = webClient.DownloadString("https://bnsbuddy.com/count/usercount.php?hidden=" + str);
                        if (text.All(char.IsDigit))
                        {
                            metroLabel94.Text = text;
                        }
                        else
                        {
                            metroLabel94.Text = "Offline";
                        }
                    }
                    catch
                    {
                        metroLabel94.Text = "Error";
                    }
                }
                manualcount = false;
            }
            bwcount = new BackgroundWorker();
            bwcount.WorkerSupportsCancellation = true;
            bwcount.WorkerReportsProgress = true;
            bwcount.DoWork += bwcount_dowork;
            if (!bwcount.IsBusy)
            {
                bwcount.RunWorkerAsync();
            }
        }

        public void bwcount_dowork(object Sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            BackgroundWorker backgroundWorker = (BackgroundWorker)Sender;
            while (!backgroundWorker.CancellationPending)
            {
                backgroundWorker.ReportProgress(0);
                Thread.Sleep(300000);
                string str = "false";
                if (!UserCountCheck)
                {
                    str = "true";
                }
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        webClient.Headers.Add("User-Agent", "BnSBuddy");
                        string text = webClient.DownloadString("https://bnsbuddy.com/count/usercount.php?hidden=" + str);
                        if (text.All(char.IsDigit))
                        {
                            metroLabel94.Text = text;
                        }
                        else
                        {
                            metroLabel94.Text = "Offline";
                        }
                    }
                    catch
                    {
                        metroLabel94.Text = "Error";
                    }
                }
            }
        }

        private void Form1_Gained(object e, EventArgs a)
        {
        }

        private void Form1_Lost(object e, EventArgs a)
        {
        }

        private void ValidateBuddy()
        {
            try
            {
                if (X509Certificate.CreateFromSignedFile(Application.ExecutablePath).GetHashCode().ToString() != "1307602086")
                {
                    Prompt.Popup("BnS Buddy signature does not match! Please Delete and get a fresh copy.");
                    KillApp();
                }
            }
            catch
            {
                Prompt.Popup("BnS Buddy is not signed! Please Delete and get a fresh copy.");
                KillApp();
            }
        }

        public void KillApp()
        {
            Process.GetCurrentProcess().Kill();
        }

        public void FirstTimeUse()
        {
            if (FirstTime)
            {
                switch (Prompt.FirstTimeUse())
                {
                    case DialogResult.Yes:
                        {
                            lineChanger("firsttime = false", AppPath + "\\Settings.ini", 24);
                            if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = false"))
                            {
                                lineChanger("autoupdate = true", AppPath + "\\Settings.ini", 23);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            lineChanger("firsttime = false", AppPath + "\\Settings.ini", 24);
                            if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = true"))
                            {
                                lineChanger("autoupdate = false", AppPath + "\\Settings.ini", 23);
                            }
                            break;
                        }
                }
            }
        }

        public void GetRegDir()
        {
            AddTextLog("Reading Registry...");
            try
            {
                RegistryKey localMachine = Registry.LocalMachine;
                localMachine = localMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\NCWest\\BnS\\");
                if (localMachine != null)
                {
                    string text = (string)localMachine.GetValue("BaseDir");
                    if (text.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine.GetValue("BaseDir");
                        }
                        AddTextLog(text);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Reg64 = true;
                        Installs.Add("NA/EU", text);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine2 = Registry.LocalMachine;
                localMachine2 = localMachine2.OpenSubKey("SOFTWARE\\NCWest\\BnS\\");
                if (localMachine2 != null)
                {
                    string text2 = (string)localMachine2.GetValue("BaseDir");
                    if (text2.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine2.GetValue("BaseDir");
                        }
                        AddTextLog(text2);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Installs.Add("NA/EU", text2);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine3 = Registry.LocalMachine;
                localMachine3 = localMachine3.OpenSubKey("SOFTWARE\\NCTaiwan\\TWBNS22\\");
                if (localMachine3 != null)
                {
                    string text3 = (string)localMachine3.GetValue("BaseDir");
                    if (text3.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine3.GetValue("BaseDir");
                        }
                        AddTextLog(text3);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Installs.Add("Taiwan", text3);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine4 = Registry.LocalMachine;
                localMachine4 = localMachine4.OpenSubKey("SOFTWARE\\Wow6432Node\\NCTaiwan\\TWBNS22\\");
                if (localMachine4 != null)
                {
                    string text4 = (string)localMachine4.GetValue("BaseDir");
                    if (text4.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine4.GetValue("BaseDir");
                        }
                        AddTextLog(text4);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Reg64 = true;
                        Installs.Add("Taiwan", text4);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine5 = Registry.LocalMachine;
                localMachine5 = localMachine5.OpenSubKey("SOFTWARE\\PlayNC\\BNS_JPN\\");
                if (localMachine5 != null)
                {
                    string text5 = (string)localMachine5.GetValue("BaseDir");
                    if (text5.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine5.GetValue("BaseDir");
                        }
                        AddTextLog(text5);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Installs.Add("Japanese", text5);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine6 = Registry.LocalMachine;
                localMachine6 = localMachine6.OpenSubKey("SOFTWARE\\Wow6432Node\\PlayNC\\BNS_JPN\\");
                if (localMachine6 != null)
                {
                    string text6 = (string)localMachine6.GetValue("BaseDir");
                    if (text6.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine6.GetValue("BaseDir");
                        }
                        AddTextLog(text6);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Reg64 = true;
                        Installs.Add("Japanese", text6);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine7 = Registry.LocalMachine;
                localMachine7 = localMachine7.OpenSubKey("SOFTWARE\\plaync\\BNS_KOR\\");
                if (localMachine7 != null)
                {
                    string text7 = (string)localMachine7.GetValue("BaseDir");
                    if (text7.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine7.GetValue("BaseDir");
                        }
                        AddTextLog(text7);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Installs.Add("Korean", text7);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine8 = Registry.LocalMachine;
                localMachine8 = localMachine8.OpenSubKey("SOFTWARE\\plaync\\BNS_KOR_TEST\\");
                if (localMachine8 != null)
                {
                    string text8 = (string)localMachine8.GetValue("BaseDir");
                    if (text8.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine8.GetValue("BaseDir");
                        }
                        AddTextLog(text8);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Installs.Add("Korean Test", text8);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine9 = Registry.LocalMachine;
                localMachine9 = localMachine9.OpenSubKey("SOFTWARE\\Wow6432Node\\plaync\\BNS_KOR\\");
                if (localMachine9 != null)
                {
                    string text9 = (string)localMachine9.GetValue("BaseDir");
                    if (text9.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine9.GetValue("BaseDir");
                        }
                        AddTextLog(text9);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Reg64 = true;
                        Installs.Add("Korean", text9);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            try
            {
                RegistryKey localMachine10 = Registry.LocalMachine;
                localMachine10 = localMachine10.OpenSubKey("SOFTWARE\\Wow6432Node\\plaync\\BNS_KOR_TEST\\");
                if (localMachine10 != null)
                {
                    string text10 = (string)localMachine10.GetValue("BaseDir");
                    if (text10.Length > 0)
                    {
                        if (!workedREG)
                        {
                            RegPath = (string)localMachine10.GetValue("BaseDir");
                        }
                        AddTextLog(text10);
                        AddTextLog("Reg Key Valid!");
                        workedREG = true;
                        Reg64 = true;
                        Installs.Add("Korean Test", text10);
                    }
                }
            }
            catch
            {
                AddTextLog("Null Value of RegKey");
            }
            if (!workedREG)
            {
                RegPath = null;
                AddTextLog("Error: RegKey = " + RegPath);
            }
            if (Installs.Count > 1)
            {
                string text11 = "";
                if (!MultipleInstallationFound)
                {
                    AddTextLog("Multiple Installations Found!");
                    text11 = (RegPath = Prompt.MultipleInstallation("Multiple installations of BnS has been found!" + Environment.NewLine + "Which version would you like to use?", "Warning!", Installs));
                    SaveDefault(text11);
                    Prompt.Popup("Notice: You can always remove the default installation in settings.");
                }
                if (text11 != "" && Installs.ContainsKey("Korean Test"))
                {
                    if (text11 == Installs["Korean Test"])
                    {
                        KoreanTestInstalled = true;
                    }
                    else
                    {
                        KoreanTestInstalled = false;
                    }
                }
            }
            // last server used default
            if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("lastserver = "))
            {
                string text99 = File.ReadLines(AppPath + "\\Settings.ini").Skip(44).Take(1)
                    .First();
                text99 = text99.Replace("lastserver = ", "");
                if (text99.Length > 0)
                {
                    metroComboBox1.SelectedIndex = metroComboBox1.FindString(text99);
                    if (Installs.ContainsKey(text99) || ((text99 == "Europe" || text99 == "North America") && Installs.ContainsKey("NA/EU")))
                    {
                        AddTextLog("Last used server: " + text99);
                        PathFound = true;
                        workedSRV = true;
                    }
                }
            }
        }

        public void SaveDefaultClient(string val)
        {
            try
            {
                lineChanger("defaultclient = " + val, AppPath + "\\Settings.ini", 27);
                metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(val);
            }
            catch
            {
                AddTextLog("Error: Could not save default client!");
            }
        }

        public void SaveDefault(string val)
        {
            try
            {
                lineChanger("defaultset = true", AppPath + "\\Settings.ini", 26);
                lineChanger("default = " + val, AppPath + "\\Settings.ini", 25);
                metroLabel48.Text = val;
            }
            catch
            {
                AddTextLog("Error: Could not save default installation!");
            }
        }

        private void metroComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox5.SelectedIndex == -1)
                return;

            if (metroComboBox5.SelectedItem.ToString() == "English")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("English");
            }
            else if (metroComboBox5.SelectedItem.ToString() == "French")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("French");
            }
            else if (metroComboBox5.SelectedItem.ToString() == "German")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("German");
            }
            else if (metroComboBox5.SelectedItem.ToString() == "Taiwan")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Taiwan");
            }
            else if (metroComboBox5.SelectedItem.ToString() == "Japanese")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Japanese");
            }
            else if (metroComboBox5.SelectedItem.ToString() == "Portuguese")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Portuguese");
            }
            else if (metroComboBox5.SelectedItem.ToString() == "Korean")
            {
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Korean");
            }
            else
            {
                metroComboBox2.SelectedItem = metroComboBox5.SelectedItem;
            }
            SetDefaultLanguage(metroComboBox5.SelectedItem.ToString());
        }

        public string fl_wlng = "";
        public string fh_lang = "";
        public void AutoDirFinder()
        {
            string text = "";
            if (Directory.Exists(RegPath + "\\contents\\Local"))
            {
                DirectoryInfo[] directories = new DirectoryInfo(RegPath + "\\contents\\Local").GetDirectories();
                for (int i = 0; i < directories.Length; i++)
                {
                    string fileName = Path.GetFileName(directories[i].ToString());
                    if (Directory.Exists(RegPath + "\\contents\\Local\\" + fileName + "\\data"))
                    {
                        autofinder = fileName;
                        DirectoryInfo directoryInfo = new DirectoryInfo(RegPath + "\\contents\\Local\\" + autofinder);
                        int num = 0;
                        DirectoryInfo[] directories2 = directoryInfo.GetDirectories();
                        for (int j = 0; j < directories2.Length; j++)
                        {
                            string fileName2 = Path.GetFileName(directories2[j].ToString());
                            if (Path.GetFileName(fileName2) != "korean")
                            {
                                if (Directory.Exists(RegPath + "\\contents\\Local\\" + autofinder + "\\" + fileName2 + "\\CookedPC") && !MultipleLangFound)
                                {
                                    if (!LangDictionary.ContainsValue(fileName2) && !LangDictionary.ContainsKey(num))
                                    {
                                        LangDictionary.Add(num, fileName2);
                                        num++;
                                    }
                                    autocook = fileName2;
                                }
                            }
                            else
                            {
                                autocook = fileName2;
                            }
                        }
                    }
                }
                if (LangDictionary.Count > 1 && !MultipleLangFound)
                {
                    bool flag = false;
                    for (int k = 0; LangDictionary.Count > k; k++)
                    {
                        metroComboBox5.Items.Add(LangDictionary[k]);
                    }
                    for (int l = 0; metroComboBox5.Items.Count > l; l++)
                    {
                        if (metroComboBox5.Items[l].ToString() == langremembered)
                        {
                            flag = true;
                            autocook = langremembered;
                            metroComboBox5.SelectedIndex = metroComboBox5.FindString(langremembered);
                            MultipleLangFound = true;
                        }
                    }
                    if (!flag)
                    {
                        SetDefaultLanguage(autocook = Prompt.MultipleLang("Multiple languages of BnS has been found!" + Environment.NewLine + "Which language would you like to use?", "Warning!", LangDictionary));
                        MultipleLangFound = true;
                        if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("langset = false"))
                        {
                            lineChanger("langset = true", AppPath + "\\Settings.ini", 33);
                        }
                    }
                    metroLabel56.Text = RegPath;
                }
                if (autocook != "Korean" && autofinder != "NCSoft")
                {
                    text = RegPath + "\\contents\\Local\\" + autofinder + "\\" + autocook + "\\CookedPC";
                    text = text.Replace("\\\\", "\\");
                }
                else
                {
                    if (autocook == "")
                    {
                        autocook = "Korean";
                    }
                    text = RegPath + "\\contents\\Local\\" + autofinder + "\\" + autocook + "\\";
                    text = text.Replace("\\\\", "\\");
                }
            }
            if (Directory.Exists(text))
            {
                string text3 = "";
                string text4 = "";
                GamePath = text;
                try
                {
                    AddTextLog("Path Found!");
                    GamePath = GamePath.Replace("\\\\", "\\");
                    text4 = GamePath;
                    text3 = (text4.Contains("korean") ? Path.GetFileName(text4) : Path.GetFileName(text4.Replace("\\CookedPC", "")));
                    AddTextLog("Lang Found!");
                }
                catch (Exception ex)
                {
                    Prompt.Popup("Error: Couldnt find game Language & it's container." + Environment.NewLine + ex.ToString());
                }
                if (text3 == "ENGLISH")
                {
                    FullPath = GamePath;
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("English");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (text3 == "FRENCH")
                {
                    FullPath = GamePath;
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("French");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (text3 == "GERMAN")
                {
                    FullPath = GamePath;
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("German");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (text3 == "CHINESET")
                {
                    FullPath = GamePath;
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Taiwan");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (text3 == "JAPANESE")
                {
                    FullPath = GamePath;
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Japanese");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (text3 == "BPORTUGUESE")
                {
                    FullPath = GamePath;
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Portuguese");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = false;
                }
                else if (text3 == "korean" || autocook == "korean")
                {
                    if (!Korean)
                    {
                        FullPath = GamePath;
                        string text5 = "";
                        text5 = Directory.GetParent(FullPath).ToString();
                        text5 = Directory.GetParent(text5).ToString();
                        text5 = Directory.GetParent(text5).ToString();
                        text5 = (FullPath = Directory.GetParent(text5).ToString() + "\\bns\\CookedPC");
                    }
                    metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact("Korean");
                    AddTextLog("Path Validated!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    Korean = true;
                }
                else
                {
                    Korean = false;
                    FullPath = GamePath;
                    AddTextLog("Lang/Path Unknown!");
                    metroButton1.Enabled = true;
                    PathFound = true;
                    metroToggle1.Enabled = true;
                    if (text3.Length > 0)
                    {
                        metroComboBox2.Items.Add(text3);
                        metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact(text3);
                    }
                    else
                    {
                        metroComboBox2.Items.Add(autocook);
                        metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact(autocook);
                    }
                }
                if (PathFound)
                {
                    FullBackupPath = GamePath.Replace("\\" + text3 + "\\CookedPC", "\\data\\backup");
                    if (!Directory.Exists(FullBackupPath))
                    {
                        Directory.CreateDirectory(FullBackupPath);
                    }
                }
            }
            else
            {
                PathFound = false;
                AddTextLog("Error: Path Not Found!");
                Prompt.Popup("Please select the BnS folder name in your Blade and Soul installation!");
                AddTextLog("Opening Dialog...");
                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select BnS folder";
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (File.Exists(folderBrowserDialog.SelectedPath + "\\bin\\Client.exe") || File.Exists(folderBrowserDialog.SelectedPath + "\\bin64\\Client.exe"))
                        {
                            RegPath = folderBrowserDialog.SelectedPath;
                            AddTextLog("Path Inputed Found!");
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
                        Prompt.Popup("Cancelled operation!");
                        if (!AppStarted)
                        {
                            KillApp();
                        }
                    }
                }
            }
        }

        private void SetDefaultLanguage(string promptValue)
        {
            lineChanger("langpath = " + promptValue, AppPath + "\\Settings.ini", 34);
            autocook = promptValue;
        }

        public void SetBnSFolder()
        {
            if (autocook != "")
            {
                if (!autocook.Contains("korean") && !autocook.Contains("Korean"))
                {
                    DataPath = FullPath.Replace("\\" + autocook + "\\CookedPC", "\\data");
                }
                else if (FullPath.Contains("\\bns\\CookedPC") || FullPath.EndsWith("\\bns\\CookedPC"))
                {
                    DataPath = FullPath.Replace("\\bns\\CookedPC", "\\local\\NCSoft\\data");
                }
                else if (FullPath.Contains("\\NCSoft\\Korean") || FullPath.EndsWith("\\NCSoft\\Korean"))
                {
                    DataPath = FullPath.Replace("\\NCSoft\\Korean", "\\NCSoft\\data");
                }
                else
                {
                    DataPath = FullPath.Replace("\\" + autocook + "\\CookedPC", "\\data");
                }
                if (!Directory.Exists(DataPath))
                {
                    Prompt.Popup("Error: Invalid Data Path!" + Environment.NewLine + "Path: " + DataPath);
                }
            }
            else
            {
                AddTextLog("Could not set DataPath!");
            }
        }

        public int cpuCount = 0;

        public int CPUINIT()
        {
            if (cpuCount == 0)
            {
                return WMI_Processor_Information.GetCpuNumberOfLogicalProcessors();
            }
            else
            {
                return cpuCount;
            }
        }

        public void EnableForm1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            base.Enabled = true;
            AddScrollBars();
            CheckBGFiX();
            Task.Delay(1000).ContinueWith(delegate
            {
                UpdateCheck();
            });
            MultiCheck();
            Task.Delay(1000).ContinueWith(delegate
            {
                cpuCount = CPUINIT();
            });
            if (!is64bit)
            {
                metroComboBox4.Items.Remove("64bit");
                metroRadioButton2.Enabled = false;
            }
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            bool flag6 = false;
            bool flag7 = false;
            bool flag8 = false;
            bool flag9 = false;
            bool flag10 = false;
            foreach (TabPage tabPage3 in metroTabControl1.TabPages)
            {
                if (tabPage3.Text == "Launcher" && !flag)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(0, tabPage3);
                    flag = true;
                }
                else if (tabPage3.Text == "Dat Editor" && !flag2)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(1, tabPage3);
                    flag2 = true;
                }
                else if (tabPage3.Text == "Mod Manager" && !flag3)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(2, tabPage3);
                    flag3 = true;
                }
                else if (tabPage3.Text == "Splash Changer" && !flag5)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(4, tabPage3);
                    flag5 = true;
                }
                else if (tabPage3.Text == "Addons" && !flag4)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(3, tabPage3);
                    flag4 = true;
                }
                else if (tabPage3.Text == "Settings" && !flag6)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(5, tabPage3);
                    flag6 = true;
                }
                else if (tabPage3.Text == "About" && !flag8)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(7, tabPage3);
                    flag8 = true;
                }
                else if (tabPage3.Text == "Donators" && !flag7)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(6, tabPage3);
                    flag7 = true;
                }
                else if (tabPage3.Text == "Extras" && !flag9)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(8, tabPage3);
                    flag9 = true;
                }
                else if (tabPage3.Text == "Ads" && !flag10)
                {
                    metroTabControl1.TabPages.Remove(tabPage3);
                    metroTabControl1.TabPages.Insert(9, tabPage3);
                    flag10 = true;
                }
            }
            bool flag11 = false;
            bool flag12 = false;
            bool flag13 = false;
            foreach (TabPage tabPage4 in metroTabControl2.TabPages)
            {
                if (tabPage4.Text == "Page 1" && !flag11)
                {
                    metroTabControl2.TabPages.Remove(tabPage4);
                    metroTabControl2.TabPages.Insert(0, tabPage4);
                    flag11 = true;
                }
                else if (tabPage4.Text == "Page 2" && !flag12)
                {
                    metroTabControl2.TabPages.Remove(tabPage4);
                    metroTabControl2.TabPages.Insert(1, tabPage4);
                    flag12 = true;
                }
                else if (tabPage4.Text == "Page 3" && !flag13)
                {
                    metroTabControl2.TabPages.Remove(tabPage4);
                    metroTabControl2.TabPages.Insert(2, tabPage4);
                    flag13 = true;
                }
                metroTextBox6.Cursor = Cursors.Arrow;
            }
            if (uniquekey != metroTextBox8.Text)
            {
                metroTabControl1.SelectTab(9);
            }
            else
            {
                metroTabControl1.TabPages.RemoveAt(9);
                metroTabControl1.SelectTab(0);
            }
            metroTabControl2.SelectTab(0);
            SetPing();
            if (metroComboBox9.Items.Count > 0)
            {
                metroComboBox9.Items.Remove(metroComboBox9.Items[0]);
            }
            toolStrip1.Renderer = new MyRenderer();
            toolStrip2.Renderer = new MyRenderer();
            AppStarted = true;
            if (readyclient)
            {
                string text = File.ReadLines(AppPath + "\\Settings.ini").Skip(26).Take(1)
                    .First()
                    .Replace("defaultclient = ", "");
                metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(text);
                defaultclient = text;
            }
            manualcount = true;
            Task.Delay(1000).ContinueWith(delegate
            {
                Get_Count();
            });
            Task.Delay(1000).ContinueWith(delegate
            {
                CheckToggleForButtonAvailability();
            });
            bw3.CancelAsync();
            bw3.Dispose();
            Show();
            base.TopMost = true;
            base.TopMost = false;
        }
        
        private void AddScrollBars()
        {
            
        }

        private void CheckBGFiX()
        {
            string pathtobgfix = modsFolderPath + "\\BGFix";
            if (File.Exists(pathtobgfix + "\\00025242.upk") && File.Exists(pathtobgfix + "\\00025243.upk") && File.Exists(pathtobgfix + "\\00025244.upk"))
            {
                metroToggle41.Checked = true;
            }
        }

        private void MultiCheck()
        {
            bool flag = false;
            if (Directory.Exists(RegPath + LauncherPath))
            {
                if (File.Exists(RegPath + LauncherPath + "\\winmm.dll"))
                {
                    metroLabel81.Text = "Active";
                    flag = true;
                }
                else
                {
                    metroLabel81.Text = "Inactive";
                }
            }
            else
            {
                metroLabel81.Text = "-";
            }
            if (Directory.Exists(RegPath + LauncherPath64))
            {
                if (File.Exists(RegPath + LauncherPath64 + "\\winmm.dll"))
                {
                    metroLabel82.Text = "Active";
                    flag = true;
                }
                else
                {
                    metroLabel82.Text = "Inactive";
                }
            }
            else
            {
                metroLabel82.Text = "-";
            }
            if (flag)
            {
                metroToggle22.Checked = true;
                if (metroLabel81.Text == "Active" || metroLabel82.Text == "Active")
                {
                    metroToggle25.Enabled = false;
                }
            }
        }

        public void SplashScreen()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Hide();
            bw3 = new BackgroundWorker();
            bw3.WorkerSupportsCancellation = true;
            bw3.WorkerReportsProgress = true;
            bw3.DoWork += bw3_DoWork;
            bw3.Disposed += bw3_Dispoed;
            bw3.RunWorkerAsync();
        }

        public void bw3_Dispoed(object Sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            if (s2 != null)
            {
                s2.Close();
            }
        }

        public void bw3_DoWork(object Sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            s2 = new Form2();
            s2.ShowDialog();
        }

        public void FixSizes()
        {
            base.Size = new Size(697, 368);
            metroTextBox1.Size = new Size(229, 267);
            metroPanel2.Size = new Size(450, 318);
            fastColoredTextBox1.Location = new Point(0, 24);
            fastColoredTextBox1.Size = new Size(450, 294);
            toolStrip2.Size = new Size(450, 25);
            treeView2.Size = new Size(392, 214);
            Launcher.Size = new Size(687, 318);
            metroTabControl1.Size = new Size(695, 357);
        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Maximized;
            metroButton22.Visible = false;
            metroButton22.Enabled = false;
            metroButton23.Visible = true;
            metroButton23.Enabled = true;
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Normal;
            metroButton22.Visible = true;
            metroButton22.Enabled = true;
            metroButton23.Visible = false;
            metroButton23.Enabled = false;
        }

        public void metroTabControl1_TabChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (metroTabControl1.SelectedTab.ToString().Contains("Dat Editor"))
                {
                    base.Resizable = true;
                    FixSizes();
                    metroButton22.Enabled = true;
                    metroButton22.Visible = true;
                }
                else
                {
                    base.WindowState = FormWindowState.Normal;
                    base.Size = new Size(697, 368);
                    metroButton22.Enabled = false;
                    metroButton22.Visible = false;
                    metroButton23.Enabled = false;
                    metroButton23.Visible = false;
                    FixSizes();
                    base.Size = new Size(697, 368);
                    base.Resizable = false;
                }
                metroTabControl1.Refresh();
                foreach (TabPage tabPage in metroTabControl1.TabPages)
                {
                    tabPage.Refresh();
                    if (Debugging)
                    {
                        MessageBox.Show("Refreshed: " + tabPage.Text);
                    }
                }
            }
            metroTile3.Enabled = true;
            metroTile4.Enabled = true;
            metroTile5.Enabled = true;
            metroTile6.Enabled = true;
            metroTile7.Enabled = true;
            metroTile8.Enabled = true;
            metroTile9.Enabled = true;
            metroTile10.Enabled = true;
            metroTile11.Enabled = true;
            metroTile12.Enabled = true;
            metroTile3.UseCustomForeColor = false;
            metroTile4.UseCustomForeColor = false;
            metroTile5.UseCustomForeColor = false;
            metroTile6.UseCustomForeColor = false;
            metroTile7.UseCustomForeColor = false;
            metroTile8.UseCustomForeColor = false;
            metroTile9.UseCustomForeColor = false;
            metroTile10.UseCustomForeColor = false;
            metroTile11.UseCustomForeColor = false;
            metroTile12.UseCustomForeColor = false;
            metroTile13.UseCustomForeColor = false;
            metroTile3.UseCustomBackColor = false;
            metroTile4.UseCustomBackColor = false;
            metroTile5.UseCustomBackColor = false;
            metroTile6.UseCustomBackColor = false;
            metroTile7.UseCustomBackColor = false;
            metroTile8.UseCustomBackColor = false;
            metroTile9.UseCustomBackColor = false;
            metroTile10.UseCustomBackColor = false;
            metroTile11.UseCustomBackColor = false;
            metroTile12.UseCustomBackColor = false;
            metroTile13.UseCustomBackColor = false;


            if (Themer.Style == MetroColorStyle.White)
            {
                metroTile3.UseCustomForeColor = true;
                metroTile4.UseCustomForeColor = true;
                metroTile5.UseCustomForeColor = true;
                metroTile6.UseCustomForeColor = true;
                metroTile7.UseCustomForeColor = true;
                metroTile8.UseCustomForeColor = true;
                metroTile9.UseCustomForeColor = true;
                metroTile10.UseCustomForeColor = true;
                metroTile11.UseCustomForeColor = true;
                metroTile12.UseCustomForeColor = true;
                metroTile13.UseCustomForeColor = true;
                metroTile3.UseCustomBackColor = true;
                metroTile4.UseCustomBackColor = true;
                metroTile5.UseCustomBackColor = true;
                metroTile6.UseCustomBackColor = true;
                metroTile7.UseCustomBackColor = true;
                metroTile8.UseCustomBackColor = true;
                metroTile9.UseCustomBackColor = true;
                metroTile10.UseCustomBackColor = true;
                metroTile11.UseCustomBackColor = true;
                metroTile12.UseCustomBackColor = true;
                metroTile13.UseCustomBackColor = true;
            }
            metroTile3.Style = Themer.Style;
            metroTile4.Style = Themer.Style;
            metroTile5.Style = Themer.Style;
            metroTile6.Style = Themer.Style;
            metroTile7.Style = Themer.Style;
            metroTile8.Style = Themer.Style;
            metroTile9.Style = Themer.Style;
            metroTile10.Style = Themer.Style;
            metroTile11.Style = Themer.Style;
            metroTile12.Style = Themer.Style;
            metroTile13.Style = Themer.Style;
            Refresh();
            if (metroTabControl1.SelectedTab.ToString().Contains("Launcher"))
            {
                metroTile3.Enabled = false;
                metroTile3.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile3.UseCustomForeColor = false;
                    metroTile3.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Dat Editor"))
            {
                metroTile4.Enabled = false;
                metroTile4.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile4.UseCustomForeColor = false;
                    metroTile4.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Mod Manager"))
            {
                metroTile5.Enabled = false;
                metroTile5.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile5.UseCustomForeColor = false;
                    metroTile5.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Splash Changer"))
            {
                metroTile9.Enabled = false;
                metroTile9.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile9.UseCustomForeColor = false;
                    metroTile9.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Addons"))
            {
                metroTile8.Enabled = false;
                metroTile8.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile8.UseCustomForeColor = false;
                    metroTile8.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Settings"))
            {
                metroTile6.Enabled = false;
                metroTile6.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile6.UseCustomForeColor = false;
                    metroTile6.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Donators"))
            {
                metroTile11.Enabled = false;
                metroTile11.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile11.UseCustomForeColor = false;
                    metroTile11.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("About"))
            {
                metroTile10.Enabled = false;
                metroTile10.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile10.UseCustomForeColor = false;
                    metroTile10.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Extras"))
            {
                metroTile7.Enabled = false;
                metroTile7.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile7.UseCustomForeColor = false;
                    metroTile7.UseCustomBackColor = false;
                }
            }
            if (metroTabControl1.SelectedTab.ToString().Contains("Ads"))
            {
                metroTile12.Enabled = false;
                metroTile12.Style = MetroColorStyle.Black;
                if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    metroTile12.UseCustomForeColor = false;
                    metroTile12.UseCustomBackColor = false;
                }
            }
        }

        private void metroTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroTabControl2.Refresh();
            foreach (TabPage tabPage in metroTabControl2.TabPages)
            {
                tabPage.Refresh();
                if (Debugging)
                {
                    MessageBox.Show("Refreshed: " + tabPage.Text);
                }
            }
        }

        TextBox virtualverify = new TextBox();
        public void CheckTab()
        {
            try
            {
                if (!File.Exists(AppPath + "\\Settings.ini"))
                {
                    File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                }
                // Check if updated
                if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("keepintray"))
                {
                    if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("customlang"))
                    {
                        string[] array = File.ReadAllLines(AppPath + "\\Settings.ini");
                        File.Delete(AppPath + "\\Settings.ini");
                        File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                        int num = 0;
                        string[] array2 = array;
                        foreach (string newText in array2)
                        {
                            num++;
                            lineChanger(newText, AppPath + "\\Settings.ini", num);
                        }
                    }
                    else
                    {
                        File.Delete(AppPath + "\\Settings.ini");
                        File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                    }
                }
                try
                {
                    string[] array3 = File.ReadAllLines(AppPath + "\\Settings.ini");
                    virtualverify.Text = DefaultValues;
                    string[] array4 = virtualverify.Lines;
                    int linesfixed = 0;
                    for (int i = 0; i < array4.Length; i++)
                    {
                        string o_o = "";
                        string i_i = "";
                        int index = array3[i].IndexOf("=");
                        if (index > 0)
                        {
                            o_o = array3[i].Substring(0, index);
                        }
                        int index2 = array4[i].IndexOf("=");
                        if (index2 > 0)
                        {
                            i_i = array4[i].Substring(0, index);
                        }
                        if (o_o != i_i)
                        {
                            array3[i] = array4[i];
                            linesfixed++;
                        }
                    }
                    if (linesfixed > 0)
                    {
                        File.WriteAllLines(AppPath + "\\Settings.ini", array3);
                        Prompt.Popup($"BnS Buddy Detected {linesfixed} broken settings and fixed them for you.");
                    }
                }
                catch
                {
                    virtualverify.Text = "";
                    File.Delete(AppPath + "\\Settings.ini");
                    File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                    Prompt.Popup("Resetted Settings.ini due to bad config");
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
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("langset = true"))
                {
                    langremembered = File.ReadLines(AppPath + "\\Settings.ini").Skip(33).Take(1)
                        .First()
                        .Replace("langpath = ", "");
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("customclientname = "))
                {
                    string text = File.ReadLines(AppPath + "\\Settings.ini").Skip(42).Take(1)
                        .First()
                        .Replace("customclientname = ", "");
                    if (text.Length >= 1)
                    {
                        customclientname = text;
                        metroTextBox9.Text = customclientname;
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("customgame = true"))
                {
                    metroTextBox3.Enabled = true;
                    metroButton15.Enabled = true;
                    metroButton20.Enabled = true;
                    metroButton17.Enabled = true;
                    metroToggle3.Checked = true;
                    string text2 = File.ReadLines(AppPath + "\\Settings.ini").Skip(15).Take(1)
                        .First();
                    RegPath = text2.Replace("customgamepath = ", "");
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
                    string text3 = File.ReadLines(AppPath + "\\Settings.ini").Skip(14).Take(1)
                        .First();
                    RegPathlol = text3.Replace("customclientpath = ", "");
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
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("boostprocess = false"))
                {
                    metroToggle20.Checked = false;
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
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("arguements = "))
                {
                    string contents = File.ReadAllText(AppPath + "\\Settings.ini").Replace("arguements = ", "arguments = ");
                    File.WriteAllText(AppPath + "\\Settings.ini", contents);
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("arguments = "))
                {
                    string text4 = File.ReadLines(AppPath + "\\Settings.ini").Skip(20).Take(1)
                        .First()
                        .Replace("arguments = ", "");
                    metroTextBox5.Text = text4;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("automemorycleanup = true"))
                {
                    metroToggle18.Checked = true;
                    AutoClean = true;
                    metroButton30.Visible = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("prtime = "))
                {
                    string text5 = File.ReadLines(AppPath + "\\Settings.ini").Skip(21).Take(1)
                        .First()
                        .Replace("prtime = ", "");
                    metroLabel47.Text = text5;
                    metroLabel47.Refresh();
                    if (Convert.ToInt32(text5) < 1000)
                    {
                        text5 = "5000";
                    }
                    metroTrackBar1.Value = Convert.ToInt32(text5);
                    metroTrackBar1.Refresh();
                    wakeywakey = Convert.ToInt32(text5);
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("uniquepass = "))
                {
                    string text6 = File.ReadLines(AppPath + "\\Settings.ini").Skip(36).Take(1)
                        .First()
                        .Replace("uniquepass = ", "");
                    metroTextBox8.Text = text6;
                    metroTextBox8.Refresh();
                }
                if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("cleanint = OFF"))
                {
                    string text7 = File.ReadLines(AppPath + "\\Settings.ini").Skip(35).Take(1)
                        .First()
                        .Replace("cleanint = ", "");
                    metroComboBox7.SelectedIndex = metroComboBox7.FindStringExact(text7);
                    metroComboBox7.Refresh();
                    if (text7 != "OFF")
                    {
                        CleanerVal = Convert.ToInt32(text7);
                    }
                }
                else
                {
                    metroComboBox7.SelectedIndex = 0;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultset = true"))
                {
                    string text8 = File.ReadLines(AppPath + "\\Settings.ini").Skip(24).Take(1)
                        .First()
                        .Replace("default = ", "");
                    metroLabel48.Text = text8;
                    RegPath = text8;
                    workedREG = true;
                    MultipleInstallationFound = true;
                    GetRegDir();
                    BnSFolder();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultclient = 64bit") || File.ReadAllText(AppPath + "\\Settings.ini").Contains("defaultclient = 32bit"))
                {
                    readyclient = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("usercountcheck = false"))
                {
                    UserCountCheck = false;
                    metroToggle26.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("showcount = false"))
                {
                    metroLabel93.Visible = false;
                    metroLabel94.Visible = false;
                    metroToggle27.Checked = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autoupdate = false"))
                {
                    AutoUpdate = false;
                    metroToggle17.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("rememberme = true"))
                {
                    metroToggle28.Checked = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("priority = "))
                {
                    string a = File.ReadLines(AppPath + "\\Settings.ini").Skip(27).Take(1)
                        .First()
                        .Replace("priority = ", "");
                    if (a == "RealTime")
                    {
                        metroComboBox6.SelectedIndex = 0;
                    }
                    if (a == "High")
                    {
                        metroComboBox6.SelectedIndex = 1;
                    }
                    if (a == "AboveNormal")
                    {
                        metroComboBox6.SelectedIndex = 2;
                    }
                    if (a == "Normal")
                    {
                        metroComboBox6.SelectedIndex = 3;
                    }
                    if (a == "BelowNormal")
                    {
                        metroComboBox6.SelectedIndex = 4;
                    }
                    if (a == "Idle")
                    {
                        metroComboBox6.SelectedIndex = 5;
                    }
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("buddycolor = "))
                {
                    string a2 = File.ReadLines(AppPath + "\\Settings.ini").Skip(43).Take(1)
                        .First()
                        .Replace("buddycolor = ", "");
                    if (a2 == "Black")
                    {
                        Themer.Style = MetroColorStyle.Black;
                    }
                    else if (a2 == "Red")
                    {
                        Themer.Style = MetroColorStyle.Red;
                    }
                    else if (a2 == "Purple")
                    {
                        Themer.Style = MetroColorStyle.Purple;
                    }
                    else if (a2 == "Pink")
                    {
                        Themer.Style = MetroColorStyle.Pink;
                    }
                    else if (a2 == "Orange")
                    {
                        Themer.Style = MetroColorStyle.Orange;
                    }
                    else if (a2 == "Magenta")
                    {
                        Themer.Style = MetroColorStyle.Magenta;
                    }
                    else if (a2 == "Lime")
                    {
                        Themer.Style = MetroColorStyle.Lime;
                    }
                    else if (a2 == "Green")
                    {
                        Themer.Style = MetroColorStyle.Green;
                    }
                    else if (a2 == "Default")
                    {
                        Themer.Style = MetroColorStyle.Blue;
                    }
                    else if (a2 == "Brown")
                    {
                        Themer.Style = MetroColorStyle.Brown;
                    }
                    else if (a2 == "Blue")
                    {
                        Themer.Style = MetroColorStyle.Blue;
                    }
                    else if (a2 == "Silver")
                    {
                        Themer.Style = MetroColorStyle.Silver;
                    }
                    else if (a2 == "Teal")
                    {
                        Themer.Style = MetroColorStyle.Teal;
                    }
                    else if (a2 == "White")
                    {
                        Themer.Style = MetroColorStyle.White;
                        metroTile3.UseCustomForeColor = true;
                        metroTile4.UseCustomForeColor = true;
                        metroTile5.UseCustomForeColor = true;
                        metroTile6.UseCustomForeColor = true;
                        metroTile7.UseCustomForeColor = true;
                        metroTile8.UseCustomForeColor = true;
                        metroTile9.UseCustomForeColor = true;
                        metroTile10.UseCustomForeColor = true;
                        metroTile11.UseCustomForeColor = true;
                        metroTile12.UseCustomForeColor = true;
                        metroTile13.UseCustomForeColor = true;
                        metroTile3.UseCustomBackColor = true;
                        metroTile4.UseCustomBackColor = true;
                        metroTile5.UseCustomBackColor = true;
                        metroTile6.UseCustomBackColor = true;
                        metroTile7.UseCustomBackColor = true;
                        metroTile8.UseCustomBackColor = true;
                        metroTile9.UseCustomBackColor = true;
                        metroTile10.UseCustomBackColor = true;
                        metroTile11.UseCustomBackColor = true;
                        metroTile12.UseCustomBackColor = true;
                        metroTile13.UseCustomBackColor = true;
                    }
                    else if (a2 == "Yellow")
                    {
                        Themer.Style = MetroColorStyle.Yellow;
                    }
                    metroComboBox11.SelectedIndex = metroComboBox11.FindStringExact(Themer.Style.ToString());
                    metroToolTip1.Style = Themer.Style;
                    metroToolTip1.Theme = MetroThemeStyle.Dark;
                    base.Style = Themer.Style;

                    metroComboBox1.Style = Themer.Style;
                    metroComboBox2.Style = Themer.Style;
                    metroComboBox3.Style = Themer.Style;
                    metroComboBox4.Style = Themer.Style;
                    metroComboBox5.Style = Themer.Style;
                    metroComboBox6.Style = Themer.Style;
                    metroComboBox7.Style = Themer.Style;
                    metroComboBox8.Style = Themer.Style;
                    metroComboBox9.Style = Themer.Style;
                    metroComboBox11.Style = Themer.Style;

                    if (Themer.Style == MetroColorStyle.White)
                    {
                        metroComboBox1.Style = MetroColorStyle.Silver;
                        metroComboBox2.Style = MetroColorStyle.Silver;
                        metroComboBox3.Style = MetroColorStyle.Silver;
                        metroComboBox4.Style = MetroColorStyle.Silver;
                        metroComboBox5.Style = MetroColorStyle.Silver;
                        metroComboBox6.Style = MetroColorStyle.Silver;
                        metroComboBox7.Style = MetroColorStyle.Silver;
                        metroComboBox8.Style = MetroColorStyle.Silver;
                        metroComboBox9.Style = MetroColorStyle.Silver;
                        metroComboBox11.Style = MetroColorStyle.Silver;

                        metroComboBox1.Theme = MetroThemeStyle.Light;
                        metroComboBox2.Theme = MetroThemeStyle.Light;
                        metroComboBox3.Theme = MetroThemeStyle.Light;
                        metroComboBox4.Theme = MetroThemeStyle.Light;
                        metroComboBox5.Theme = MetroThemeStyle.Light;
                        metroComboBox6.Theme = MetroThemeStyle.Light;
                        metroComboBox7.Theme = MetroThemeStyle.Light;
                        metroComboBox8.Theme = MetroThemeStyle.Light;
                        metroComboBox9.Theme = MetroThemeStyle.Light;
                        metroComboBox11.Theme = MetroThemeStyle.Light;
                    }

                    Refresh();
                    Prompt.ColorSet = Themer.Style;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("menuslidereffect = false"))
                {
                    SliderEffect = false;
                    metroToggle38.Checked = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("firsttime = false"))
                {
                    FirstTime = false;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("modfolderset = true"))
                {
                    CustomModSet = true;
                    string text9 = File.ReadLines(AppPath + "\\Settings.ini").Skip(28).Take(1)
                        .First()
                        .Replace("modfolder = ", "");
                    metroToggle19.Checked = true;
                    metroTextBox7.Text = text9;
                    backupFolderPath = metroTextBox7.Text + "\\CookedPC_Backup";
                    FullModPathMan = metroTextBox7.Text + "\\CookedPC_Mod";
                    GetPath();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("gcdshow = true"))
                {
                    metroToggle21.Checked = true;
                    metroLabel72.Visible = true;
                    metroLabel73.Visible = true;
                    metroLabel72.Refresh();
                    metroLabel73.Refresh();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("igpshow = true"))
                {
                    metroToggle24.Checked = true;
                    metroLabel70.Visible = true;
                    metroLabel71.Visible = true;
                    metroLabel70.Refresh();
                    metroLabel71.Refresh();
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("autologin = true"))
                {
                    metroToggle25.Checked = true;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("affinityproc = "))
                {
                    string text8 = File.ReadLines(AppPath + "\\Settings.ini").Skip(46).Take(1)
                        .First()
                        .Replace("affinityproc = ", "");
                    metroLabel85.Text += text8;
                }
                if (File.ReadAllText(AppPath + "\\Settings.ini").Contains("keepintray = true"))
                {
                    metroToggle42.Checked = true;
                    AlwaysOnTray = true;
                    ActivateTray();
                }
            }
            catch
            {
                Prompt.Popup("Error reading Settings.ini");
            }
        }

        private void ActivateTray()
        {
            ConfigureContext();
            notifyIcon1.Visible = true;
        }

        private void metroComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox6.SelectedItem.ToString() == "Realtime")
            {
                Priority = ProcessPriorityClass.RealTime;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "High")
            {
                Priority = ProcessPriorityClass.High;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Above normal")
            {
                Priority = ProcessPriorityClass.AboveNormal;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Normal")
            {
                Priority = ProcessPriorityClass.Normal;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Below normal")
            {
                Priority = ProcessPriorityClass.BelowNormal;
            }
            else if (metroComboBox6.SelectedItem.ToString() == "Low")
            {
                Priority = ProcessPriorityClass.Idle;
            }
            else
            {
                Priority = ProcessPriorityClass.Normal;
            }
            if (GameStarted)
            {
                Process[] processesByName = Process.GetProcessesByName("Client");
                for (int i = 0; i < processesByName.Length; i++)
                {
                    processesByName[i].PriorityClass = Priority;
                    AddTextLog("Changed Priority.");
                }
                if (customclientname != "")
                {
                    processesByName = Process.GetProcessesByName(customclientname.Replace(".exe", ""));
                    for (int j = 0; j < processesByName.Length; j++)
                    {
                        processesByName[j].PriorityClass = Priority;
                        AddTextLog("Changed Priority.");
                    }
                }
            }
            if (AppStarted)
            {
                lineChanger("priority = " + Priority.ToString(), AppPath + "\\Settings.ini", 28);
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
            if (PathFound)
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

        private void metroComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            LauncherInfo();
            if (regions.Count != 0)
            {
                RegionCB.DataSource = regions;
            }
            Details();
        }

        public void REDO_PATHS()
        {
            try
            {
                workedREG = true;
                BnSFolder();
            }
            catch (Exception ex)
            {
                Prompt.Popup(ex.ToString());
            }
            CheckBackup();
            VerifySettings();
            GetPaths();
            Verify();
            InitializeSplash();
            InitializeManager();
            GetPath();
            JsonManager();
            PopulateTreeView(FullModPathMan);
            VerifyUsage();
            CleanMess();
            CleanOtherMess();
            DefaultDatValues();
            CreateDatPaths();
            InitializeAddons();
            Details();
            FixSizes();
        }

        public void CLEAR_PREVIOUS()
        {
            if (metroComboBox3.Items.Count > 0)
            {
                metroComboBox3.Items.Clear();
            }
            if (treeView3.Nodes.Count > 0)
            {
                treeView3.Nodes.Clear();
            }
            if (treeView2.Nodes.Count > 0)
            {
                treeView2.Nodes.Clear();
            }
            if (metroComboBox5.Items.Count > 0)
            {
                metroComboBox5.Items.Clear();
            }
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            if (LangDictionary.Count > 0)
            {
                LangDictionary.Clear();
            }
        }

        public void PreSavedPaths(string region)
        {
            if (AppStarted)
            {
                bool flag = false;
                if ((region == "North America" || region == "Europe") && Installs.ContainsKey("NA/EU"))
                {
                    RegPath = Installs["NA/EU"].ToString();
                    flag = true;
                }
                else if (region == "Japanese" && Installs.ContainsKey(region))
                {
                    RegPath = Installs[region].ToString();
                    flag = true;
                }
                else if (region == "Taiwan" && Installs.ContainsKey(region))
                {
                    RegPath = Installs[region].ToString();
                    flag = true;
                }
                else if (region == "Korean" && Installs.ContainsKey(region))
                {
                    RegPath = Installs[region].ToString();
                    flag = true;
                }

                // Save last server
                lineChanger("lastserver = " + region, AppPath + "\\Settings.ini", 45);

                if (flag)
                {
                    bool flag2 = false;
                    if (MultipleLangFound)
                    {
                        flag2 = true;
                        MultipleLangFound = false;
                    }
                    if ((!(PreviousServer == "North America") || !(region == "Europe")) && (!(PreviousServer == "Europe") || !(region == "North America")) && PreviousServer != region)
                    {
                        CLEAR_PREVIOUS();
                        REDO_PATHS();
                        REPOPULATE();
                    }
                    if (flag2)
                    {
                        MultipleLangFound = true;
                    }
                    PreviousServer = region;
                }
            }
        }

        private void REPOPULATE()
        {
            SplashPopulater();
            ReFreshMods();
            DefaultDatValues();
            RefreshAddons();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroComboBox8.Visible = false;
            if (metroComboBox1.SelectedItem.ToString() == "Europe")
            {
                IP = "18.194.180.254";
                regionID = "1";
                AddTextLog("Changed RegionID to EU!");
                regionID = "1";
                metroButton1.Text = "Play!";
                metroToolTip1.SetToolTip(metroButton1, "Patch! and/or Play!");
                PreSavedPaths("Europe");
                LauncherInfo();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "North America")
            {
                IP = "64.25.37.235";
                regionID = "0";
                AddTextLog("Changed RegionID to NA!");
                regionID = "0";
                metroButton1.Text = "Play!";
                metroToolTip1.SetToolTip(metroButton1, "Patch! and/or Play!");
                PreSavedPaths("North America");
                LauncherInfo();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Taiwan")
            {
                IP = "203.67.68.227";
                regionID = "15";
                AddTextLog("Changed RegionID to Taiwan!");
                regionID = "15";
                metroButton1.Text = "Play!";
                metroToolTip1.SetToolTip(metroButton1, "Patch! and/or Play!");
                PreSavedPaths("Taiwan");
                LauncherInfo();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Japanese")
            {
                IP = "111.87.18.30";
                regionID = "0";
                AddTextLog("Changed RegionID to Japanese!");
                regionID = "0";
                metroButton1.Text = "Patch!";
                metroToolTip1.SetToolTip(metroButton1, "Patch! and/or Play!");
                PreSavedPaths("Japanese");
                LauncherInfo();
            }
            else if (metroComboBox1.SelectedItem.ToString() == "Korean")
            {
                IP = "222.122.231.3";
                regionID = "0";
                AddTextLog("Changed RegionID to Korean!");
                regionID = "0";
                metroButton1.Text = "Play!";
                metroToolTip1.SetToolTip(metroButton1, "Patch! and/or Play!");
                PreSavedPaths("Korean");
                metroComboBox8.Visible = true;
                metroComboBox8.SelectedIndex = 0;
            }
            else
            {
                IP = "0";
            }
            if (regions.Count != 0)
            {
                RegionCB.DataSource = regions;
            }
            Details();
            PreviousServer = metroComboBox1.SelectedItem.ToString();
            if (Installs.ContainsKey(PreviousServer) || (Installs.ContainsKey("NA/EU") && (PreviousServer == "Europe" || PreviousServer == "North America")))
            {
                if (PreviousServer != "Europe" && PreviousServer != "North America")
                {
                    SaveDefault(Installs[PreviousServer]);
                }
                else
                {
                    SaveDefault(Installs["NA/EU"]);
                }
            }
            if ((metroComboBox1.SelectedItem.ToString() == "Taiwan" || metroComboBox1.SelectedItem.ToString() == "Korean") && Conflict)
            {
                metroLabel65.Visible = true;
            }
            else
            {
                metroLabel65.Visible = false;
            }
            if (metroComboBox1.SelectedItem == null)
            {
                metroButton1.Enabled = false;
                metroToolTip1.SetToolTip(metroButton1, "No Server Selected!");
            }
            else { metroButton1.Enabled = true; }
        }

        public void CheckServer()
        {
            if (workedREG)
            {
                AddTextLog("Reading Registry...");
                if (Installs.ContainsKey("NA/EU"))
                {
                    bool oldshit = true;
                    if (Installs["NA/EU"].ToString() == RegPath && Reg64)
                    {
                        if (!workedSRV)
                        {
                            try
                            {
                                RegistryKey localMachine = Registry.LocalMachine;
                                localMachine = localMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\PlayNC\\NCLauncherW\\");
                                if (localMachine != null)
                                {
                                    RegPathlol = localMachine.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                    oldshit = false;
                                }
                            }
                            catch
                            {
                                AddTextLog("Null Value of RegKey");
                            }
                        }
                    }
                    else if (Installs["NA/EU"].ToString() == RegPath && !Reg64 && !workedSRV)
                    {
                        try
                        {
                            RegistryKey localMachine2 = Registry.LocalMachine;
                            localMachine2 = localMachine2.OpenSubKey("SOFTWARE\\PlayNC\\NCLauncherW\\");
                            if (localMachine2 != null)
                            {
                                RegPathlol = localMachine2.GetValue("BaseDir").ToString();
                                AddTextLog(RegPathlol);
                                AddTextLog("Reg Key Valid!");
                                workedSRV = true;
                                oldshit = false;
                            }
                        }
                        catch
                        {
                            AddTextLog("Null Value of RegKey");
                        }
                    }
                    if (oldshit)
                    {
                        if (Installs["NA/EU"].ToString() == RegPath && Reg64)
                        {
                            if (!workedSRV)
                            {
                                try
                                {
                                    RegistryKey localMachine = Registry.LocalMachine;
                                    localMachine = localMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\NCWest\\NCLauncher\\");
                                    if (localMachine != null)
                                    {
                                        RegPathlol = localMachine.GetValue("BaseDir").ToString();
                                        AddTextLog(RegPathlol);
                                        AddTextLog("Reg Key Valid!");
                                        workedSRV = true;
                                    }
                                }
                                catch
                                {
                                    AddTextLog("Null Value of RegKey");
                                }
                            }
                        }
                        else if (Installs["NA/EU"].ToString() == RegPath && !Reg64 && !workedSRV)
                        {
                            try
                            {
                                RegistryKey localMachine2 = Registry.LocalMachine;
                                localMachine2 = localMachine2.OpenSubKey("SOFTWARE\\NCWest\\NCLauncher\\");
                                if (localMachine2 != null)
                                {
                                    RegPathlol = localMachine2.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch
                            {
                                AddTextLog("Null Value of RegKey");
                            }
                        }
                    }
                }
                if (Installs.ContainsKey("Taiwan"))
                {
                    if (Installs["Taiwan"].ToString() == RegPath && Reg64)
                    {
                        if (!workedSRV)
                        {
                            try
                            {
                                RegistryKey localMachine3 = Registry.LocalMachine;
                                localMachine3 = localMachine3.OpenSubKey("SOFTWARE\\Wow6432Node\\plaync\\NCLauncherS\\");
                                if (localMachine3 != null)
                                {
                                    RegPathlol = localMachine3.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                    localMachine3 = Registry.LocalMachine;
                                    localMachine3 = localMachine3.OpenSubKey("SOFTWARE\\Wow6432Node\\plaync\\MXM\\");
                                    if (localMachine3 != null)
                                    {
                                        Conflict = true;
                                    }
                                }
                            }
                            catch
                            {
                                AddTextLog("Null Value of RegKey");
                            }
                        }
                    }
                    else if (Installs["Taiwan"].ToString() == RegPath && !Reg64 && !workedSRV)
                    {
                        try
                        {
                            RegistryKey localMachine4 = Registry.LocalMachine;
                            localMachine4 = localMachine4.OpenSubKey("SOFTWARE\\plaync\\NCLauncherS\\");
                            if (localMachine4 != null)
                            {
                                RegPathlol = localMachine4.GetValue("BaseDir").ToString();
                                AddTextLog(RegPathlol);
                                AddTextLog("Reg Key Valid!");
                                workedSRV = true;
                                localMachine4 = Registry.LocalMachine;
                                localMachine4 = localMachine4.OpenSubKey("SOFTWARE\\plaync\\MXM\\");
                                if (localMachine4 != null)
                                {
                                    Conflict = true;
                                }
                            }
                        }
                        catch
                        {
                            AddTextLog("Null Value of RegKey");
                        }
                    }
                }
                if (Installs.ContainsKey("Japanese"))
                {
                    if (Installs["Japanese"].ToString() == RegPath && Reg64)
                    {
                        if (!workedSRV)
                        {
                            try
                            {
                                RegistryKey localMachine5 = Registry.LocalMachine;
                                localMachine5 = localMachine5.OpenSubKey("SOFTWARE\\Wow6432Node\\NCJapan\\NCLauncher\\");
                                if (localMachine5 != null)
                                {
                                    RegPathlol = localMachine5.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                }
                            }
                            catch
                            {
                                AddTextLog("Null Value of RegKey");
                            }
                        }
                    }
                    else if (Installs["Japanese"].ToString() == RegPath && !Reg64 && !workedSRV)
                    {
                        try
                        {
                            RegistryKey localMachine6 = Registry.LocalMachine;
                            localMachine6 = localMachine6.OpenSubKey("SOFTWARE\\NCJapan\\NCLauncher\\");
                            if (localMachine6 != null)
                            {
                                RegPathlol = localMachine6.GetValue("BaseDir").ToString();
                                AddTextLog(RegPathlol);
                                AddTextLog("Reg Key Valid!");
                                workedSRV = true;
                            }
                        }
                        catch
                        {
                            AddTextLog("Null Value of RegKey");
                        }
                    }
                }
                if (Installs.ContainsKey("Korean"))
                {
                    if (Installs["Korean"].ToString() == RegPath && Reg64)
                    {
                        if (!workedSRV)
                        {
                            try
                            {
                                RegistryKey localMachine7 = Registry.LocalMachine;
                                localMachine7 = localMachine7.OpenSubKey("SOFTWARE\\WOW6432Node\\plaync\\NCLauncherS\\");
                                if (localMachine7 != null)
                                {
                                    RegPathlol = localMachine7.GetValue("BaseDir").ToString();
                                    AddTextLog(RegPathlol);
                                    AddTextLog("Reg Key Valid!");
                                    workedSRV = true;
                                    localMachine7 = Registry.LocalMachine;
                                    localMachine7 = localMachine7.OpenSubKey("SOFTWARE\\Wow6432Node\\plaync\\MXM\\");
                                    if (localMachine7 != null)
                                    {
                                        Conflict = true;
                                    }
                                }
                            }
                            catch
                            {
                                AddTextLog("Null Value of RegKey");
                            }
                        }
                    }
                    else if (Installs["Korean"].ToString() == RegPath && !Reg64 && !workedSRV)
                    {
                        try
                        {
                            RegistryKey localMachine8 = Registry.LocalMachine;
                            localMachine8 = localMachine8.OpenSubKey("SOFTWARE\\plaync\\NCLauncherS\\");
                            if (localMachine8 != null)
                            {
                                RegPathlol = localMachine8.GetValue("BaseDir").ToString();
                                AddTextLog(RegPathlol);
                                AddTextLog("Reg Key Valid!");
                                workedSRV = true;
                                localMachine8 = Registry.LocalMachine;
                                localMachine8 = localMachine8.OpenSubKey("SOFTWARE\\plaync\\MXM\\");
                                if (localMachine8 != null)
                                {
                                    Conflict = true;
                                }
                            }
                        }
                        catch
                        {
                            AddTextLog("Null Value of RegKey");
                        }
                    }
                }
                if (Conflict)
                {
                    metroLabel65.Visible = true;
                }
                else
                {
                    metroLabel65.Visible = false;
                }
            }
            if (!workedSRV)
            {
                RegPathlol = null;
                AddTextLog("Error: RegKey = " + RegPathlol);
            }
            if (workedSRV)
            {
                try
                {
                    if (File.Exists(RegPathlol + "\\UserSettings.config"))
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(RegPathlol + "\\UserSettings.config");
                        bool found = false;
                        foreach (XmlNode nodes in document)
                        {
                            foreach (XmlNode node in nodes)
                            {
                                XmlAttributeCollection nodeAtt = node.Attributes;
                                if (nodeAtt["key"].Value.ToString() == "GameRegionSettings")
                                {
                                    found = true;
                                    string settings = nodeAtt["value"].Value.ToString();
                                    settings = settings.Replace("[", "").Replace("]", "");
                                    var settingsholder = JObject.Parse(@settings);
                                    if (settingsholder["GameRegionCode"].ToString() != null)
                                    {
                                        if (settingsholder["GameRegionCode"].ToString() != "")
                                        {
                                            if (settingsholder["GameRegionCode"].ToString() == "na")
                                            {
                                                metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                                            }
                                            else
                                            {
                                                metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Europe");
                                            }
                                        }
                                        else
                                        {
                                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                                        }
                                    }
                                    else
                                    {
                                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                                    }
                                }
                            }
                        }
                        if (!found)
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                        }
                    }
                    if (File.Exists(RegPathlol + "\\NCLauncher.ini"))
                    {
                        string text = File.ReadAllText(RegPathlol + "\\NCLauncher.ini");
                        if ((text.Contains("Game_Region=North America") || text.Contains("Game_Region=Nordamerika") || text.Contains("du Nord") || !text.Contains("Game_Region")) && !text.Contains("Update_ja") && !text.Contains("TWBNS22"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                        }
                        else if (text.Contains("Game_Region=Europe") || text.Contains("Game_Region=Europa") || text.Contains("Game_Region=L'Europe"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Europe");
                        }
                        else if (text.Contains("Game_Locale=ja"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Japanese");
                        }
                        else if (text.Contains("up4svr.plaync.com.tw") && !text.Contains("MXM"))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                        }
                        else if (text.Contains("up4web.plaync.co.kr") || (text.Contains("up4web.nclauncher.ncsoft.com") && !text.Contains("MXM")))
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                            if (KoreanTestInstalled)
                            {
                                metroComboBox8.SelectedIndex = metroComboBox8.FindStringExact("Test");
                            }
                        }
                        if (Conflict && metroComboBox2.SelectedItem.ToString() == "Korean")
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                            if (KoreanTestInstalled)
                            {
                                metroComboBox8.SelectedIndex = metroComboBox8.FindStringExact("Test");
                            }
                        }
                        else if (Conflict && metroComboBox2.SelectedItem.ToString() == "Taiwan")
                        {
                            metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                        }
                    }
                }
                catch (Exception ex)
                {
                    AddTextLog("Error: Could Not Find NCLauncher.ini" + Environment.NewLine + ex.ToString());
                }
            }
            else
            {
                AddTextLog("Error: Could Not Find NCLauncher Path!");
            }
        }

        public string checkMD5(string filename)
        {
            using (MD5 mD = MD5.Create())
            {
                using (FileStream inputStream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "\u200c\u200b").ToLower();
                }
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox2.SelectedItem.ToString() == "English")
            {
                languageID = "English";
                AddTextLog("languageID = English");
            }
            else if (metroComboBox2.SelectedItem.ToString() == "French")
            {
                languageID = "French";
                AddTextLog("languageID = French");
            }
            else if (metroComboBox2.SelectedItem.ToString() == "German")
            {
                languageID = "German";
                AddTextLog("languageID = German");
            }
            else if (metroComboBox2.SelectedItem.ToString() == "Taiwan")
            {
                languageID = "CHINESET";
                AddTextLog("languageID = Chineset");
            }
            else if (metroComboBox2.SelectedItem.ToString() == "Japanese")
            {
                languageID = "JAPANESE";
                AddTextLog("languageID = Japanese");
            }
            else if (metroComboBox2.SelectedItem.ToString() == "Portuguese")
            {
                languageID = "BPORTUGUESE";
                AddTextLog("languageID = Portuguese");
            }
            else if (metroComboBox2.SelectedItem.ToString() == "Korean")
            {
                languageID = "korean";
                AddTextLog("languageID = Korean");
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
            AddTextLog("Checking For Backups");
            bool flag = false;
            bool flag2 = false;
            string path = FullPath + "\\backup";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                int num = -1;
                if (File.Exists(FullPath + "\\backup\\00009368.bak"))
                {
                    if (num == -1)
                    {
                        num++;
                    }
                    if (File.Exists(FullPath + "\\00009368.upk"))
                    {
                        try
                        {
                            File.Delete(FullPath + "\\00009368.upk");
                            AddTextLog("Fixed: Loading Screen Backup! (1)");
                            num++;
                        }
                        catch
                        {
                            AddTextLog("Error: Could Not Fix Loading Screen Backup! (1)");
                        }
                    }
                }
                if (File.Exists(FullPath + "\\backup\\loading.bak"))
                {
                    if (num == -1)
                    {
                        num++;
                    }
                    if (File.Exists(FullPath + "\\Loading.pkg"))
                    {
                        try
                        {
                            File.Delete(FullPath + "\\Loading.pkg");
                            AddTextLog("Fixed: Loading Screen Backup! (2)");
                            num++;
                        }
                        catch
                        {
                            AddTextLog("Error: Could Not Fix Loading Screen Backup! (2)");
                        }
                    }
                }
                if (num == 2)
                {
                    AddTextLog("Log: Automatically reapplied Loading Screen Fix");
                }
            }
            if (File.Exists(FullPath + "\\Loading.pkg") && File.Exists(FullPath + "\\00009368.upk"))
            {
                metroToggle1.CheckState = CheckState.Unchecked;
                metroToggle1.Refresh();
            }
            else
            {
                if (File.Exists(FullPath + "\\Loading.pkg"))
                {
                    flag2 = true;
                }
                if (File.Exists(FullPath + "\\00009368.upk"))
                {
                    flag = true;
                }
                if (flag)
                {
                    try
                    {
                        File.Delete(FullPath + "\\backup\\00009368.bak");
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                        AddTextLog("Fixed: Loading Screen Backup!(2)");
                    }
                    catch
                    {
                        AddTextLog("Error: Could Not Fix Loading Screen Backup!(2)");
                    }
                }
                if (flag2)
                {
                    try
                    {
                        File.Delete(FullPath + "\\backup\\loading.bak");
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                        AddTextLog("Fixed: Loading Screen Backup!(1)");
                    }
                    catch
                    {
                        AddTextLog("Error: Could Not Fix Loading Screen Backup!(1)");
                    }
                }
                metroToggle1.CheckState = CheckState.Checked;
                metroToggle1.Refresh();
                AddTextLog("Loading Screen Backup Found!");
            }
            CheckConfigBackup();
        }

        private void metroLabel39_TextChanged(object sender, EventArgs e)
        {
            metroLabel63.Text = metroLabel39.Text;
            metroLabel63.Refresh();
        }

        public void CleanOtherMess()
        {
            string text = "";
            try
            {
                AddTextLog("Cleaning Mess");
                DirectoryInfo[] directories = new DirectoryInfo(DataPath).GetDirectories();
                foreach (DirectoryInfo directoryInfo in directories)
                {
                    string directoryName = Path.GetDirectoryName(directoryInfo.ToString());
                    if (directoryName.Length > 0)
                    {
                        if (directoryName.EndsWith(".dat.files") && directoryName.Contains(".dat.files"))
                        {
                            text = directoryName;
                            Array.ForEach(Directory.GetFiles(DataPath + "\\" + text + "\\"), File.Delete);
                            AddTextLog("Cleaned Files, now removing folder");
                            Directory.Delete(DataPath + "\\" + text + "\\", recursive: true);
                            AddTextLog("Cleaned " + text);
                        }
                    }
                    else if (directoryInfo.ToString().EndsWith(".dat.files") && directoryInfo.ToString().Contains(".dat.files"))
                    {
                        text = directoryInfo.ToString();
                        Array.ForEach(Directory.GetFiles(DataPath + "\\" + text + "\\"), File.Delete);
                        AddTextLog("Cleaned Files, now removing folder");
                        Directory.Delete(DataPath + "\\" + text + "\\", recursive: true);
                        AddTextLog("Cleaned " + text);
                    }
                }
            }
            catch
            {
                AddTextLog("Could not remove folder -> " + DataPath + "\\" + text + "\\");
            }
        }

        public void DoBackupCheck()
        {
            try
            {
                isModded = false;
                AddTextLog("Extracted");
                AddTextLog("Checking system.config2.xml if modded");
                metroButton2.Enabled = true;
                string value = "<option name=\"use-web-launching\" value=\"false\" />";
                if (virtualtext.Text.Contains(value))
                {
                    AddTextLog(usedfile + " is Modded");
                    metroLabel14.Text = "Patched!";
                    metroButton2.Enabled = true;
                    metroLabel14.Refresh();
                    metroButton1.Text = "Play!";
                    metroToolTip1.SetToolTip(metroButton1, "Patch! and/or Play!");
                    isModded = true;
                }
                else
                {
                    AddTextLog(usedfile + " is Clean");
                    metroLabel14.Text = "Clean";
                    metroLabel14.Refresh();
                    metroButton2.Enabled = false;
                    metroButton2.Enabled = false;
                }
                virtualtext.Text = "";
            }
            catch
            {
                AddTextLog("Error: Could not verify system.config2.xml (" + usedfile + " in use or corrupted?)");
            }
        }

        TextBox virtualtext = new TextBox();
        public void CheckConfigBackup()
        {
            FileInfo[] files = new DirectoryInfo(DataPath).GetFiles("*.dat");
            foreach (FileInfo fileInfo in files)
            {
                usedfile = "";
                if (!fileInfo.ToString().Contains("xml") && fileInfo.ToString().Contains("config"))
                {
                    usedfile = fileInfo.ToString();
                    usedfilepath = DataPath + "\\" + usedfile;
                    AddTextLog("Extracting system.config2.xml for verification from " + fileInfo.ToString());
                    metroButton2.Enabled = true;
                    try
                    {
                        virtualtext = new TextBox();
                        nametofile = "system.config2.xml";
                        BNSDat.BNSDat bNSDat = new BNSDat.BNSDat();
                        Dictionary<string, byte[]> dictionary = bNSDat.ExtractFile(usedfilepath, new List<string>
                        {
                        nametofile
                        }, usedfile.Contains("64"));
                        var bytes = dictionary[nametofile];
                        virtualtext.Text = System.Text.Encoding.UTF8.GetString(bytes);
                        DoBackupCheck();
                    }
                    catch (IOException)
                    {
                        AddTextLog("Skipped checking " + usedfile + ", game is already running!");
                        GameStarted = true;
                        string clientname = "Client";
                        if (customclientname != "") { clientname = customclientname.Replace(".exe", ""); }
                        Process[] processesByName = Process.GetProcessesByName(clientname);
                        for (int i = 0; i < processesByName.Length; i++)
                        {
                            ClientHandler.Add("UNKNOWN-" + i, processesByName[i].Id);
                        }
                        // Add Client process id here to kill
                        Prompt.Popup("BnS is already running! Please close the game before applying any changes.");
                    }
                    catch (Exception ex)
                    {
                        Prompt.Popup(ex.ToString());
                    }
                }
            }
            if (isModded)
            {
                metroButton2.Enabled = true;
                metroLabel14.Text = "Patched!";
            }
        }

        public void Compiler(string qwerty)
        {
            ToolTipsFix(option: false);
            if (qwerty != null)
            {
                if (qwerty.Contains("64"))
                {
                    BNSis64 = true;
                }
                else
                {
                    BNSis64 = false;
                }
                bnsdatc = new BackgroundWorker();
                bnsdatc.WorkerSupportsCancellation = true;
                bnsdatc.WorkerReportsProgress = true;
                bnsdatc.DoWork += bnsdatc_DoWork;
                bnsdatc.RunWorkerAsync();
                waitbw.WaitOne();
                waitbw.Reset();
            }
            if (metroToggle6.Checked)
            {
                ToolTipsFix(option: true);
            }
        }

        private void bnsdatc_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            if (Directory.Exists(usedfilepathonly))
            {
                new BNSDat.BNSDat().Compress(usedfilepathonly, BNSis64);
                waitbw.Set();
            }
            else
            {
                Prompt.Popup("Folder: " + usedfilepathonly + " Does not exist!");
                waitbw.Set();
            }
        }

        public void ToolTipsFix(bool option)
        {
            if (option)
            {
                metroToolTip1.Active = true;
            }
            else
            {
                metroToolTip1.Active = false;
            }
        }

        public void Extractor(string qwerty)
        {
            ToolTipsFix(option: false);
            if (qwerty != null)
            {
                if (qwerty.Contains("64"))
                {
                    BNSis64 = true;
                }
                else
                {
                    BNSis64 = false;
                }
                bnsdat = new BackgroundWorker();
                bnsdat.WorkerSupportsCancellation = true;
                bnsdat.WorkerReportsProgress = true;
                bnsdat.DoWork += bnsdat_DoWork;
                bnsdat.RunWorkerAsync(qwerty);
                waitbw.WaitOne();
                waitbw.Reset();
            }
            if (metroToggle6.Checked)
            {
                ToolTipsFix(option: true);
            }
        }

        private void bnsdat_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = (string)e.Argument;
            Control.CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(file)) // usedfilepath
            {
                new BNSDat.BNSDat().Extract(file, BNSis64);
                waitbw.Set();
            }
            else
            {
                Prompt.Popup("File: " + file + " Does not exist!");
                waitbw.Set();
            }
        }

        public void BnSFolder()
        {
            if (!workedREG)
            {
                GetRegDir();
            }
            try
            {
                AutoDirFinder();
                SetBnSFolder();
            }
            catch (Exception ex)
            {
                Prompt.Popup("Error: " + ex.ToString());
            }
        }

        private static int BinaryMatch(byte[] input, byte[] pattern)
        {
            int num = input.Length - pattern.Length + 1;
            for (int i = 0; i < num; i++)
            {
                bool flag = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (input[i + j] != pattern[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    return i;
                }
            }
            return -1;
        }

        public void UpdateCheck()
        {
            if (UpdateChecker)
            {
                try
                {
                    if (ValidateDomain())
                    {
                        try
                        {
                            try
                            {
                                X509Certificate.CreateFromSignedFile(Application.ExecutablePath).GetCertHashString();
                            }
                            catch
                            {
                                Prompt.Popup("BnS Buddy is not signed! Please Delete and get a fresh copy.");
                                KillApp();
                            }
                            string text = "updates.xxzer0modzxx.net";
                            TcpClient tcpClient = new TcpClient(text, 443);
                            RemoteCertificateValidationCallback userCertificateValidationCallback = (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors) => true;
                            using (SslStream sslStream = new SslStream(tcpClient.GetStream(), false, userCertificateValidationCallback))
                            {
                                string text2 = "";
                                sslStream.AuthenticateAsClient(text, null, SslProtocols.Tls12, checkCertificateRevocation: false);
                                tcpClient.SendTimeout = 500;
                                tcpClient.ReceiveTimeout = 1000;
                                StringBuilder stringBuilder = new StringBuilder();
                                stringBuilder.AppendLine("GET /BuddyVersion.txt HTTP/1.1");
                                stringBuilder.AppendLine("Host: updates.xxzer0modzxx.net");
                                stringBuilder.AppendLine("User-Agent: BnSBuddy/" + Application.ProductVersion + " (compatible;)");
                                stringBuilder.AppendLine("Connection: close");
                                stringBuilder.AppendLine();
                                byte[] bytes = Encoding.ASCII.GetBytes(stringBuilder.ToString());
                                sslStream.WriteAsync(bytes, 0, bytes.Length);
                                using (MemoryStream memoryStream = new MemoryStream())
                                {
                                    sslStream.CopyTo(memoryStream);
                                    memoryStream.Position = 0L;
                                    byte[] array = memoryStream.ToArray();
                                    int num = BinaryMatch(array, Encoding.ASCII.GetBytes("\r\n\r\n")) + 4;
                                    string @string = Encoding.ASCII.GetString(array, 0, num);
                                    memoryStream.Position = num;
                                    if (@string.IndexOf("Content-Encoding: gzip") > 0)
                                    {
                                        using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                                        {
                                            using (MemoryStream memoryStream2 = new MemoryStream())
                                            {
                                                gZipStream.CopyTo(memoryStream2);
                                                memoryStream2.Position = 0L;
                                                text2 = Encoding.UTF8.GetString(memoryStream2.ToArray());
                                            }
                                        }
                                    }
                                    else
                                    {
                                        text2 = Encoding.UTF8.GetString(array, num, array.Length - num);
                                    }
                                }
                                s = text2;
                            }
                            tcpClient.Close();
                        }
                        catch (Exception ex)
                        {
                            AddTextLog("Could not connect");
                            s = "Error";
                            Prompt.Popup(ex.ToString());
                        }
                        AddTextLog("Grabbed: " + s);
                    }
                    else
                    {
                        AddTextLog("Domain Invalid");
                        s = "Error";
                    }
                }
                catch (Exception ex2)
                {
                    AddTextLog("Could not connect.");
                    s = "Error";
                    Prompt.Popup(ex2.ToString());
                }
                metroLabel6.Text = s;
                metroLabel3.Text = Application.ProductVersion;
                online = s.Replace(".", "");
                offline = Application.ProductVersion.ToString().Replace(".", "");
                if (online != "Error")
                {
                    if (Convert.ToInt32(online) > Convert.ToInt32(offline))
                    {
                        if (s != "Error")
                        {
                            AddTextLog("Update available.");
                            bool autoUpdate = AutoUpdate;
                            metroButton3.Visible = true;
                        }
                        else if (online == "Error")
                        {
                            AddTextLog("Error checking update.");
                        }
                    }
                    else
                    {
                        AddTextLog("Up to date.");
                    }
                }
                else
                {
                    AddTextLog("Error checking update.");
                }
            }
            else
            {
                metroLabel6.Text = "Offline";
                metroLabel3.Text = Application.ProductVersion;
            }
        }

        private bool ValidateDomain()
        {
            string text = "";
            string text2 = "";
            try
            {
                text = X509Certificate.CreateFromSignedFile(Application.ExecutablePath).GetHashCode().ToString();
                if (text != "1307602086")
                {
                    Prompt.Popup("BnS Buddy signature does not match! Please Delete and get a fresh copy.");
                    KillApp();
                }
            }
            catch
            {
                Prompt.Popup("BnS Buddy is not signed! Please Delete and get a fresh copy.");
                KillApp();
            }
            if (text.Length > 0)
            {
                X509Certificate2 x509Certificate = null;
                try
                {
                    using (SslStream sslStream = new SslStream(new TcpClient("updates.xxzer0modzxx.net", 443).GetStream(), true, (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors) => true))
                    {
                        sslStream.AuthenticateAsClient("updates.xxzer0modzxx.net", null, SslProtocols.Tls12, checkCertificateRevocation: false);
                        x509Certificate = new X509Certificate2(sslStream.RemoteCertificate);
                    }
                }
                catch
                {
                    AddTextLog("Could not connect securely to update server");
                    return false;
                }
                if (x509Certificate != null)
                {
                    text2 = x509Certificate.GetHashCode().ToString();
                }
                if (Debugging)
                {
                    Prompt.Popup("BnS Buddy Hash: " + text + Environment.NewLine + "BnSBuddy's Server Hash: " + text2);
                }
                if (text == text2 && text == "1307602086")
                {
                    AddTextLog("Domain validated");
                    return true;
                }
            }
            return false;
        }

        public void KillGame()
        {
            if (GameKiller)
            {
                try
                {
                    Process[] processesByName = Process.GetProcessesByName("Client");
                    for (int i = 0; i < processesByName.Length; i++)
                    {
                        processesByName[i].Kill();
                        AddTextLog("Killed Game Process.");
                    }
                    if (customclientname != "")
                    {
                        processesByName = Process.GetProcessesByName(customclientname.Replace(".exe", ""));
                        for (int j = 0; j < processesByName.Length; j++)
                        {
                            processesByName[j].Kill();
                            AddTextLog("Killed Game Process.");
                        }
                    }
                }
                catch
                {
                    AddTextLog("Could Not Kill Game Process.");
                }
            }
        }

        public void AddTextLog(string text)
        {
            if (ShowLogs)
            {
                metroTextBox1.AppendText(text + Environment.NewLine);
                metroTextBox1.Refresh();
            }
            if (SaveLogs && LauncherLogs)
            {
                File.WriteAllText(AppPath + "\\Launcher_logs.txt", metroTextBox1.Text);
            }
        }

        public void AddTextBoxLog(string text)
        {
            if (ShowLogs)
            {
                metroTextBox2.AppendText(text);
            }
            if (SaveLogs && ModManLogs)
            {
                File.WriteAllText(AppPath + "\\ModManager_logs.txt", metroTextBox2.Text);
            }
        }

        public void bw1_DoWork(object Sender, DoWorkEventArgs e)
        {
            AddTextLog("Getting Ping From Server...");
            try
            {
                if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Europe") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Taiwan") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Korean"))
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Blocking = true;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    socket.Connect(IP, 10100);
                    stopwatch.Stop();
                    int num = Convert.ToInt32(stopwatch.Elapsed.TotalMilliseconds);
                    socket.Close();
                    ping = num;
                }
                else
                {
                    ping = Convert.ToInt32(new Ping().Send(IP).RoundtripTime.ToString());
                }
            }
            catch
            {
                ping = 0;
            }
            if (Regex.IsMatch(ping.ToString(), "^[0-9]+$"))
            {
                if (ping != 0)
                {
                    metroLabel11.Text = ping + ms;
                    int num2 = Convert.ToInt32(Math.Round((double)ping * 2.833333333333333));
                    int num3 = Convert.ToInt32(Math.Round((double)num2 * 1.666666666666667));
                    metroLabel70.Text = num2 + ms;
                    metroLabel72.Text = num3 + ms;
                    AddTextLog("Got Ping.");
                }
                else
                {
                    metroLabel11.Text = "Offline";
                    metroLabel70.Text = "Offline";
                    metroLabel72.Text = "Offline";
                    AddTextLog("No Ping.");
                }
            }
            else
            {
                metroLabel11.Text = "Offline";
                metroLabel70.Text = "Offline";
                metroLabel72.Text = "Offline";
                AddTextLog("No Ping.");
            }
            BackgroundWorker backgroundWorker = (BackgroundWorker)Sender;
            while (!backgroundWorker.CancellationPending)
            {
                if (metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("North America") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Europe") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Taiwan") || metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Korean"))
                {
                    backgroundWorker.ReportProgress(0);
                }
                Thread.Sleep(wakeywakey);
                try
                {
                    if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Europe") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Taiwan") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Korean"))
                    {
                        Socket socket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        socket2.Blocking = true;
                        Stopwatch stopwatch2 = new Stopwatch();
                        if (!socket2.Connected)
                        {
                            stopwatch2.Start();
                            socket2.Connect(IP, 10100);
                            stopwatch2.Stop();
                            ping = Convert.ToInt32(stopwatch2.Elapsed.TotalMilliseconds);
                        }
                        if (socket2.Connected)
                        {
                            socket2.Close();
                            backgroundWorker.ReportProgress(0);
                        }
                    }
                    else
                    {
                        ping = Convert.ToInt32(new Ping().Send(IP).RoundtripTime.ToString());
                    }
                }
                catch
                {
                    ping = 0;
                }
            }
        }

        public void bw1_ProgressChanged(object Sender, ProgressChangedEventArgs e)
        {
            if (Regex.IsMatch(ping.ToString(), "^\\d+$"))
            {
                if (ping != 0)
                {
                    metroLabel11.Text = ping + ms;
                    int num = Convert.ToInt32(Math.Round((double)ping * 2.833333333333333));
                    int num2 = Convert.ToInt32(Math.Round((double)num * 1.666666666666667));
                    metroLabel70.Text = num + ms;
                    metroLabel72.Text = num2 + ms;
                }
                else
                {
                    metroLabel11.Text = "Offline";
                    metroLabel70.Text = "Offline";
                    metroLabel72.Text = "Offline";
                }
            }
            else
            {
                metroLabel11.Text = "Offline";
                metroLabel70.Text = "Offline";
                metroLabel72.Text = "Offline";
            }
        }

        public void SetPing()
        {
            bw1 = new BackgroundWorker();
            bw1.WorkerSupportsCancellation = true;
            bw1.WorkerReportsProgress = true;
            bw1.DoWork += bw1_DoWork;
            bw1.ProgressChanged += bw1_ProgressChanged;
            if (PingChecker)
            {
                bw1.RunWorkerAsync();
            }
        }

        private bool ProcessExists(int iProcessID)
        {
            Process[] processes = Process.GetProcesses();
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].Id == iProcessID)
                {
                    return true;
                }
            }
            return false;
        }

        bool busytimer = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!busytimer)
            {
                busytimer = true;
                if (GameStarted)
                {
                    GameStarted = false;
                    foreach (string key2 in ClientHandler.Keys)
                    {
                        if (!ProcessExists(ClientHandler[key2]))
                        {
                            metroComboBox9.SelectedIndex = -1;
                            metroComboBox9.Items.Remove(key2);
                            ClearClient.Add(key2, key2);
                            if (metroComboBox9.Items.Count > 1)
                            {
                                metroComboBox9.SelectedIndex = 1;
                            }
                            else
                            {
                                metroComboBox9.SelectedIndex = -1;
                                metroPanel6.Visible = false;
                            }
                            AddTextLog(key2 + "'s Game Process Died");
                        }
                    }
                    foreach (string key3 in ClearClient.Keys)
                    {
                        ClientHandler.Remove(key3);
                    }
                    ClearClient = new Dictionary<string, string>();
                    Process[] processesByName = Process.GetProcessesByName((!(customclientname != "")) ? "Client" : customclientname.Replace(".exe", ""));
                    Process[] array = processesByName;
                    foreach (Process process in array)
                    {
                        metroLabel57.Text = "Running";
                        // Process affinity
                        try
                        {
                            if (cpuCount != 0)
                            {
                                bool modified = false;
                                int allCpu = (int)Math.Pow(2, cpuCount) - 1;
                                int firstHalf = (int)Math.Pow(2, cpuCount / 2) - 1;
                                int secondHalf = allCpu - firstHalf;
                                int odd = 0;
                                for (int i = 1; i < cpuCount; i++) { if (i % 2 != 0) { odd += (int)Math.Pow(2, i - 1); } };
                                int even = allCpu - odd;
                                string toswitch = metroLabel85.Text.Replace("Affinity: ", "");
                                switch (toswitch)
                                {
                                    case "All":
                                        if (process.ProcessorAffinity != (IntPtr)allCpu)
                                        {
                                            process.ProcessorAffinity = (IntPtr)allCpu;
                                            modified = true;
                                        }
                                        break;
                                    case "Odd":
                                        if (process.ProcessorAffinity != (IntPtr)odd)
                                        {
                                            process.ProcessorAffinity = (IntPtr)odd;
                                            modified = true;
                                        }
                                        break;
                                    case "Even":
                                        if (process.ProcessorAffinity != (IntPtr)even)
                                        {
                                            process.ProcessorAffinity = (IntPtr)even;
                                            modified = true;
                                        }
                                        break;
                                    case "First Half":
                                        if (process.ProcessorAffinity != (IntPtr)firstHalf)
                                        {
                                            process.ProcessorAffinity = (IntPtr)firstHalf;
                                            modified = true;
                                        }
                                        break;
                                    case "Second Half":
                                        if (process.ProcessorAffinity != (IntPtr)secondHalf)
                                        {
                                            process.ProcessorAffinity = (IntPtr)secondHalf;
                                            modified = true;
                                        }
                                        break;

                                }
                                if (modified)
                                {
                                    AddTextLog("Changed Affinity.");
                                }
                            }
                        }
                        catch
                        {
                        }
                        // Process priority
                        try
                        {
                            if (metroComboBox6.SelectedItem != null && process.PriorityClass != Priority)
                            {
                                process.PriorityClass = Priority;
                                AddTextLog("Changed Priority.");
                            }
                            metroLabel60.Text = process.PriorityClass.ToString();
                            if (metroToggle20.Checked && !prioboost)
                            {
                                prioboost = true;
                                process.PriorityBoostEnabled = true;
                                AddTextLog("Priority Boost Enabled.");
                            }
                        }
                        catch
                        {
                        }
                        GameStarted = true;
                        metroButton1.Enabled = true;
                        metroButton1.Text = "Kill Game";
                        metroToolTip1.SetToolTip(metroButton1, "Kill The Current Game Instance");
                    }
                    if (!GameStarted)
                    {
                        processesByName = Process.GetProcessesByName("Client");
                        for (int j = 0; j < processesByName.Length; j++)
                        {
                            Process process2 = processesByName[j];
                            GameStarted = true;
                        }
                        if (customclientname != "")
                        {
                            processesByName = Process.GetProcessesByName(customclientname.Replace(".exe", ""));
                            for (int k = 0; k < processesByName.Length; k++)
                            {
                                Process process3 = processesByName[k];
                                GameStarted = true;
                            }
                        }
                        if (GameStarted)
                        {
                            foreach (string key4 in ClientHandler.Keys)
                            {
                                if (!ProcessExists(ClientHandler[key4]))
                                {
                                    metroComboBox9.SelectedIndex = -1;
                                    metroComboBox9.Items.Remove(key4);
                                    ClearClient.Add(key4, key4);
                                    if (metroComboBox9.Items.Count > 1)
                                    {
                                        metroComboBox9.SelectedIndex = 1;
                                    }
                                    else
                                    {
                                        metroComboBox9.SelectedIndex = -1;
                                        metroPanel6.Visible = false;
                                    }
                                    AddTextLog(key4 + "'s Game Process Died");
                                }
                            }
                            foreach (string key5 in ClearClient.Keys)
                            {
                                ClientHandler.Remove(key5);
                            }
                            ClearClient = new Dictionary<string, string>();
                        }
                        if (!GameStarted)
                        {
                            metroLabel57.Text = "Closed";
                            metroLabel60.Text = "-";
                            foreach (TreeNode node in treeView2.Nodes)
                            {
                                if (node != null)
                                {
                                    if (node.Nodes.Count > 0)
                                    {
                                        foreach (TreeNode subnode in node.Nodes)
                                        {
                                            if (subnode != null)
                                            {
                                                RealModPath = FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "");
                                                if (Directory.Exists(RealModPath))
                                                {
                                                    checkButtons(output: true);
                                                }
                                                else
                                                {
                                                    subnode.Remove();
                                                }
                                            }
                                        }
                                    }
                                    if (node.Nodes.Count == 0)
                                    {
                                        RealModPath = FullModPathMan + "\\" + node.FullPath.ToString().Replace(" (Installed)", "");
                                        if (Directory.Exists(RealModPath))
                                        {
                                            checkButtons(output: true);
                                        }
                                        else
                                        {
                                            node.Remove();
                                        }
                                    }
                                }
                            }
                            metroButton1.Enabled = true;
                            metroButton1.Text = "Play!";
                            metroToolTip1.SetToolTip(metroButton1, "Patch! and/or Play!");
                            Show();
                            base.WindowState = FormWindowState.Normal;
                            notifyIcon1.Visible = false;
                            AddTextLog("Game Closed!");
                            AddTextLog("Restored UI!");
                            if (!metroLabel14.Text.Contains("Clean"))
                            {
                                metroButton2.Enabled = true;
                            }
                            CClock.Stop();
                            enableButtons();
                        }
                    }
                    MenuHandler(false);
                }
                else
                {
                    metroPanel6.Visible = false;
                    foreach (string key2 in ClientHandler.Keys)
                    {
                        if (!ProcessExists(ClientHandler[key2]))
                        {
                            metroComboBox9.SelectedIndex = -1;
                            metroComboBox9.Items.Remove(key2);
                            ClearClient.Add(key2, key2);
                            if (metroComboBox9.Items.Count > 1)
                            {
                                metroComboBox9.SelectedIndex = 1;
                            }
                            else
                            {
                                metroComboBox9.SelectedIndex = -1;
                                metroPanel6.Visible = false;
                            }
                            AddTextLog(key2 + "'s Game Process Died");
                        }
                    }
                    foreach (string key3 in ClearClient.Keys)
                    {
                        ClientHandler.Remove(key3);
                    }
                    ClearClient = new Dictionary<string, string>();
                    MenuHandler(true);
                }
                busytimer = false;
            }
        }

        private void MenuHandler(bool change)
        {
            metroTile4.Enabled = change;
            metroTile5.Enabled = change;
            metroTile7.Enabled = change;
            metroTile8.Enabled = change;
            metroTile9.Enabled = change;
        }

        private void metroLabel11_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            try
            {
                if (ping.ToString() == null || ping.ToString() == "")
                {
                    ping = 0;
                }
                num = Convert.ToInt32(ping);
            }
            catch
            {
            }
            if (num >= bad)
            {
                metroLabel12.Text = "Bad";
                metroLabel12.UseCustomForeColor = true;
                metroLabel12.ForeColor = Color.Red;
            }
            else if (num >= medium && num < bad)
            {
                metroLabel12.Text = "Playable";
                metroLabel12.UseCustomForeColor = true;
                metroLabel12.ForeColor = Color.Yellow;
            }
            else if (num >= good && num < medium)
            {
                metroLabel12.Text = "Good";
                metroLabel12.UseCustomForeColor = true;
                metroLabel12.ForeColor = Color.Green;
            }
            else
            {
                metroLabel12.Text = "Error";
                metroLabel12.UseCustomForeColor = false;
            }
        }

        private void metroToggle1_Click(object sender, EventArgs e)
        {
            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Refresh();
            metroToggle1.Enabled = false;
            metroButton1.Enabled = false;
            if (metroToggle1.Checked)
            {
                bool flag = false;
                bool flag2 = false;
                try
                {
                    if (!File.Exists(FullPath + "\\backup\\loading.bak"))
                    {
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                    }
                    else
                    {
                        File.Delete(FullPath + "\\backup\\loading.bak");
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                    }
                    flag = true;
                }
                catch
                {
                    AddTextLog("Could Not Remove Loading.pkg!");
                }
                try
                {
                    if (!File.Exists(FullPath + "\\backup\\00009368.bak"))
                    {
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    else
                    {
                        File.Delete(FullPath + "\\backup\\00009368.bak");
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    flag2 = true;
                }
                catch
                {
                    AddTextLog("Could Not Remove 00009368.upk!");
                }
                if (flag2 && flag)
                {
                    AddTextLog("Applied Loading Screen Fix!");
                }
                else if (!flag2 && !flag)
                {
                    metroToggle1.CheckState = CheckState.Checked;
                }
                else
                {
                    metroToggle1.CheckState = CheckState.Unchecked;
                    if (flag2)
                    {
                        File.Move(FullPath + "\\backup\\00009368.bak", FullPath + "\\00009368.upk");
                    }
                    if (flag)
                    {
                        File.Move(FullPath + "\\backup\\loading.bak", FullPath + "\\Loading.pkg");
                    }
                }
            }
            else
            {
                bool flag3 = false;
                bool flag4 = false;
                try
                {
                    if (File.Exists(FullPath + "\\backup\\loading.bak"))
                    {
                        File.Move(FullPath + "\\backup\\loading.bak", FullPath + "\\Loading.pkg");
                    }
                    flag3 = true;
                }
                catch
                {
                    AddTextLog("Could Not Restore Loading.pkg!");
                }
                try
                {
                    if (File.Exists(FullPath + "\\backup\\00009368.bak"))
                    {
                        File.Move(FullPath + "\\backup\\00009368.bak", FullPath + "\\00009368.upk");
                    }
                    flag4 = true;
                }
                catch
                {
                    AddTextLog("Could Not Restore 00009368.upk!");
                }
                if (flag4 && flag3)
                {
                    AddTextLog("Restored Loading Screen!");
                }
                else if (!flag4 && !flag3)
                {
                    metroToggle1.CheckState = CheckState.Unchecked;
                }
                else
                {
                    metroToggle1.CheckState = CheckState.Checked;
                    if (flag4)
                    {
                        File.Move(FullPath + "\\00009368.upk", FullPath + "\\backup\\00009368.bak");
                    }
                    if (flag3)
                    {
                        File.Move(FullPath + "\\Loading.pkg", FullPath + "\\backup\\loading.bak");
                    }
                }
            }
            metroToggle1.Enabled = true;
            if (PathFound)
            {
                metroButton1.Enabled = true;
            }
            metroToggle1.Refresh();
            metroButton1.Refresh();
            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Refresh();
        }

        private void metroToggle41_CheckedChanged(object sender, EventArgs e)
        {
            BGFiX();
        }

        private void BGFiX()
        {
            if (metroToggle41.Checked)
            {
                try
                {
                    string pathtobgfix = modsFolderPath + "\\BGFix";
                    Directory.CreateDirectory(pathtobgfix);
                    metroCheckBox1.Checked = true;
                    Unattended = "-UNATTENDED";
                    File.WriteAllBytes(pathtobgfix + "\\00025242.upk", Resources._00025242);
                    File.WriteAllBytes(pathtobgfix + "\\00025243.upk", Resources._00025243);
                    File.WriteAllBytes(pathtobgfix + "\\00025244.upk", Resources._00025244);
                }
                catch
                {
                    AddTextLog("Could not apply battleground fix!");
                }
            }
            else
            {
                try
                {
                    string pathtobgfix = modsFolderPath + "\\BGFix";
                    Directory.Delete(pathtobgfix, true);
                }
                catch
                {
                    AddTextLog("Could not remove battleground fix!");
                }
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound)
            {
                if (metroCheckBox1.Checked)
                {
                    Unattended = "-UNATTENDED";
                    try
                    {
                        lineChanger("unattended = true", AppPath + "\\Settings.ini", 1);
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
                        lineChanger("unattended = false", AppPath + "\\Settings.ini", 1);
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
            if (PathFound)
            {
                if (metroCheckBox3.Checked)
                {
                    UseAllCores = "-USEALLAVAILABLECORES";
                    try
                    {
                        lineChanger("useallcores = true", AppPath + "\\Settings.ini", 20);
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
                        lineChanger("useallcores = false", AppPath + "\\Settings.ini", 20);
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
            if (PathFound)
            {
                if (metroCheckBox2.Checked)
                {
                    NoTextureStreaming = "-NOTEXTURESTREAMING";
                    try
                    {
                        lineChanger("notexturestreaming = true", AppPath + "\\Settings.ini", 2);
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
                        lineChanger("notexturestreaming = false", AppPath + "\\Settings.ini", 2);
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
            UT = new UpdaterTransition();
            UT.DialogResult = UT.ShowDialog();
            if (UT.DialogResult != DialogResult.Cancel)
            {
                if (File.Exists(AppPath + "\\BnS Buddy Updater.exe"))
                {
                    File.Delete(AppPath + "\\BnS Buddy Updater.exe");
                }
                File.WriteAllBytes(AppPath + "\\BnS Buddy Updater.exe", Revamped_BnS_Buddy.Properties.Resources.BnS_Buddy_Updater);
                Process process = new Process();
                process.StartInfo.FileName = AppPath + "\\BnS Buddy Updater.exe";
                process.Start();
                KillApp();
            }
            else
            {
                AddTextLog("Cancelled Update");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            RestoreConfigFiles();
            metroButton2.Enabled = false;
        }

        public void RestoreConfigFiles()
        {
            FileInfo[] files = new DirectoryInfo(DataPath).GetFiles("*.dat");
            foreach (FileInfo fileInfo in files)
            {
                datbackup = fileInfo.ToString();
                try
                {
                    if (!fileInfo.ToString().Contains("xml") && fileInfo.ToString().Contains("config"))
                    {
                        AddTextLog("Extracting " + datbackup);
                        usedfile = datbackup;
                        usedfilepath = DataPath + "\\" + datbackup;
                        Extractor(usedfile);
                        DoRestoreProcess();
                    }
                }
                catch (Exception ex)
                {
                    Prompt.Popup(ex.ToString());
                }
            }
        }

        public void DoRestoreProcess()
        {
            try
            {
                AddTextLog("Extracted " + datbackup);
                AddTextLog("Checking string");
                string value = "<option name=\"use-web-launching\" value=\"false\" />";
                if (File.ReadAllText(DataPath + "\\" + datbackup + ".files\\system.config2.xml").Contains(value))
                {
                    try
                    {
                        AddTextLog("Replacing values");
                        string contents = File.ReadAllText(DataPath + "\\" + datbackup + ".files\\system.config2.xml").Replace("<option name=\"use-web-launching\" value=\"false\" />", "<option name=\"use-web-launching\" value=\"true\" />");
                        File.WriteAllText(DataPath + "\\" + datbackup + ".files\\system.config2.xml", contents);
                        AddTextLog("Replaced");
                        RepackRestoredConfig();
                    }
                    catch
                    {
                        AddTextLog("Could not modify & save system.config2.xml");
                    }
                }
            }
            catch
            {
                AddTextLog("Could not open system.config2.xml");
            }
        }

        public void RepackRestoredConfig()
        {
            AddTextLog("Repacking " + datbackup);
            try
            {
                string str = myDictionary[datbackup];
                usedfile = datbackup;
                usedfilepathonly = str + "\\" + datbackup + ".files";
                Compiler(usedfile);
                DoRepackProcessR();
            }
            catch (Exception ex)
            {
                Prompt.Popup(ex.ToString());
            }
        }

        public void DoRepackProcessR()
        {
            try
            {
                AddTextLog("Repacked & Replaced");
                metroLabel14.Text = "Clean";
                AddTextLog("Restored " + datbackup + "!");
            }
            catch
            {
                AddTextLog("Error: Could Not Copy Restored Client!");
            }
        }

        private void metroButton30_Click(object sender, EventArgs e)
        {
            CleanMem();
        }


        class DispoData : IDisposable
        {
            public void Dispose()
            {
                // automatically disposed.
            }
        }

        public void CleanMem()
        {
            if (GameStarted)
            {
                /*
                using (var Dispo = new DispoData())
                {
                    AddTextLog("Cleaning Memory...");
                    GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                    long totalMemory = GC.GetTotalMemory(forceFullCollection: false);
                    AddTextLog("Before: " + totalMemory / 1024 + " MB");
                    GC.AddMemoryPressure(totalMemory);
                    GC.Collect(0, GCCollectionMode.Forced, blocking: false);
                    GC.WaitForPendingFinalizers();
                    long totalMemory2 = GC.GetTotalMemory(forceFullCollection: false);
                    GC.RemoveMemoryPressure(totalMemory2);
                    AddTextLog("After: " + totalMemory2 / 1024 + " MB");
                    AddTextLog("Freed: " + (totalMemory - totalMemory2) / 1024 + " MB");
                    AddTextLog("Memory Cleaned");
                    Dispo.Dispose();
                }
                */
            }
            else
            {
                using (var Dispo = new DispoData())
                {
                    AddTextLog("Cleaning Memory...");
                    GCSettings.LatencyMode = GCLatencyMode.Interactive;
                    long totalMemory3 = GC.GetTotalMemory(forceFullCollection: true);
                    AddTextLog("Before: " + totalMemory3 / 1024 + " MB");
                    GC.AddMemoryPressure(totalMemory3);
                    GC.Collect(2, GCCollectionMode.Forced, blocking: false);
                    GC.WaitForPendingFinalizers();
                    long totalMemory4 = GC.GetTotalMemory(forceFullCollection: true);
                    GC.RemoveMemoryPressure(totalMemory4);
                    AddTextLog("After: " + totalMemory4 / 1024 + " MB");
                    AddTextLog("Freed: " + (totalMemory3 - totalMemory4) / 1024 + " MB");
                    AddTextLog("Memory Cleaned");
                    Dispo.Dispose();
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroComboBox2.SelectedItem != null)
            {
                if (metroComboBox2.SelectedItem.ToString() != "")
                    PlayGame(pressed: true);
                else
                    Prompt.Popup("Please select the region of your currently installed client before playing!");
            }
            else
            {
                Prompt.Popup("Please select the region of your currently installed client before playing!");
            }
        }

        private void PlayGame(bool pressed)
        {
            bool flag = false;
            if (metroComboBox9.SelectedItem != null)
            {
                flag = ((metroComboBox9.SelectedItem.ToString() == "New Instance") ? true : false);
            }
            if (GameStarted && !flag)
            {
                string text = "";
                try
                {
                    if (metroToggle22.Checked)
                    {
                        if (metroComboBox9.SelectedItem != null)
                        {
                            text = metroComboBox9.SelectedItem.ToString();
                        }
                        foreach (string key2 in ClientHandler.Keys)
                        {
                            if (text == key2 || key2.Contains("UNKNOWN-"))
                            {
                                Process.GetProcessById(ClientHandler[key2]).Kill();
                                metroComboBox9.SelectedIndex = -1;
                                if (metroComboBox9.Items.Contains(text))
                                {
                                    metroComboBox9.Items.Remove(text);
                                }
                                ClearClient.Add(key2, key2);
                                if (metroComboBox9.Items.Count > 1)
                                {
                                    try
                                    {
                                        if (metroComboBox9.Items[1] != null)
                                        {
                                            metroComboBox9.SelectedIndex = 1;
                                        }
                                        else
                                        {
                                            metroComboBox9.SelectedIndex = -1;
                                        }
                                    }
                                    catch
                                    {
                                        metroComboBox9.SelectedIndex = -1;
                                    }
                                }
                                else
                                {
                                    metroComboBox9.SelectedIndex = -1;
                                    metroPanel6.Visible = false;
                                }
                                AddTextLog("Killed Game Process");
                            }
                        }
                        foreach (string key3 in ClearClient.Keys)
                        {
                            ClientHandler.Remove(key3);
                        }
                        ClearClient = new Dictionary<string, string>();
                    }
                    else
                    {
                        bool flag2 = false;
                        Process[] processesByName = Process.GetProcessesByName((!(customclientname != "")) ? "Client" : customclientname.Replace(".exe", ""));
                        foreach (Process process in processesByName)
                        {
                            if (!flag2 && process.Id == appuniqueid)
                            {
                                flag2 = true;
                                process.Kill();
                                AddTextLog("Killed Game Process");
                                appuniqueid = 0;
                            }
                        }
                        foreach (string tokillc in ClientHandler.Keys)
                        {
                            if (tokillc.Contains("UNKNOWN-"))
                            {
                                ClearClient.Add(tokillc, tokillc);
                                Process.GetProcessById(ClientHandler[tokillc]).Kill();
                                AddTextLog("Killed Game Process");
                            }
                        }
                        foreach (string key3 in ClearClient.Keys)
                        {
                            ClientHandler.Remove(key3);
                        }
                        ClearClient = new Dictionary<string, string>();
                    }
                }
                catch
                {
                    if (text != "")
                    {
                        Prompt.Popup("Error: Could not kill process owned by " + text + "!");
                    }
                    else
                    {
                        Prompt.Popup("Error: Process not found!");
                    }
                    metroComboBox9.SelectedIndex = -1;
                    metroComboBox9.Items.Remove(text);
                    if (metroComboBox9.Items.Count > 1)
                    {
                        metroComboBox9.SelectedIndex = 1;
                    }
                }
            }
            else
            {
                bool flag3 = false;
                if (metroComboBox9.SelectedItem != null && metroComboBox9.SelectedItem.ToString() == "New Instance")
                {
                    flag3 = true;
                }
                if (pressed && flag3 && metroButton1.Text == "Kill Game")
                {
                    Prompt.Popup("Select a proper instance to kill!");
                }
                else
                {
                    AddTextLog("Using vars...");
                    metroButton1.Enabled = false;
                    if (metroLabel14.Text == "Clean" && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("North America") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Europe") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Korean") && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Taiwan"))
                    {
                        AddTextLog("Patching...");
                        patchConfigDat();
                    }
                    else
                    {
                        AddTextLog("Skipped Patching!");
                        LaunchGame();
                    }
                }
            }
        }

        private void patchConfigDat()
        {
            AddTextLog("Getting Patch...");
            try
            {
                patchDownloaded();
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
                string value = "<option name=\"use-web-launching\" value=\"true\" />";
                if (File.ReadAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml").Contains(value))
                {
                    try
                    {
                        AddTextLog("Backing up");
                        File.Copy(DataPath + "\\" + datverifier, DataPath + "\\backup\\" + datverifier, overwrite: true);
                        AddTextLog("Backup made");
                    }
                    catch
                    {
                        AddTextLog("Could not copy " + datverifier + " to backup folder");
                    }
                }
                try
                {
                    AddTextLog("Replacing values");
                    string contents = File.ReadAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml").Replace("<option name=\"use-web-launching\" value=\"true\" />", "<option name=\"use-web-launching\" value=\"false\" />");
                    File.WriteAllText(DataPath + "\\" + datverifier + ".files\\system.config2.xml", contents);
                    AddTextLog("Replaced");
                    RepackPatchedConfig();
                }
                catch
                {
                    AddTextLog("Could not modify & save system.config2.xml");
                }
            }
            catch
            {
                AddTextLog("Could not open system.config2.xml");
            }
        }

        public void InternalPatcherAndVerifier()
        {
            FileInfo[] files = new DirectoryInfo(DataPath).GetFiles("*.dat");
            foreach (FileInfo fileInfo in files)
            {
                datverifier = fileInfo.ToString();
                try
                {
                    if (!fileInfo.ToString().Contains("xml") && fileInfo.ToString().Contains("config"))
                    {
                        AddTextLog("Extracting " + datverifier);
                        usedfile = datverifier;
                        usedfilepath = DataPath + "\\" + datverifier;
                        Extractor(usedfile);
                        DoPatchingProcess();
                    }
                }
                catch (IOException)
                {
                    Prompt.Popup("BnS is already running! Please close the game before applying any changes.");
                }
                catch (Exception ex)
                {
                    Prompt.Popup(ex.ToString());
                }
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
            catch
            {
                AddTextLog("Error: Could Not Copy Patched Client!");
            }
        }

        public void RepackPatchedConfig()
        {
            AddTextLog("Repacking " + datverifier);
            try
            {
                string str = myDictionary[datverifier];
                usedfile = datverifier;
                usedfilepathonly = str + "\\" + datverifier + ".files";
                Compiler(usedfile);
                DoRepackProcess();
            }
            catch (Exception ex)
            {
                Prompt.Popup(ex.ToString());
            }
        }

        private void patchDownloaded()
        {
            nonmodded = true;
            AddTextLog("Patching Launcher...");
            metroProgressSpinner1.Visible = true;
            metroProgressSpinner1.Refresh();
            try
            {
                if (!UseToken)
                {
                    InternalPatcherAndVerifier();
                }
                CleanOtherMess();
                LaunchGame();
            }
            catch
            {
                AddTextLog("Error: Could Not Patch Client!");
                metroButton1.Enabled = true;
            }
            metroProgressSpinner1.Visible = false;
            metroProgressSpinner1.Refresh();
        }

        private void AutoCleaner()
        {
            if (metroComboBox7.Text.ToString() != "OFF")
            {
                int num = Convert.ToInt32(metroComboBox7.Text.ToString());
                CleanerVal = num * 60000;
                AutoCleanerStart();
            }
        }

        private void AutoCleanerStart()
        {
            CClock.Interval = CleanerVal;
            CClock.Start();
        }

        private void CClock_Tick(object sender, EventArgs e)
        {
            CleanMem();
        }

        private void LaunchGame()
        {
            string text = "";
            string text2 = "";
            if (customclientname != "")
            {
                text = ".\\" + customclientname;
                text2 = customclientname;
            }
            else
            {
                text = ".\\Client.exe";
                text2 = "Client.exe";
            }
            AddTextLog("Finding Client.exe...");
            int num = 0;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (Directory.Exists(RegPath + LauncherPath) || Directory.Exists(RegPath + LauncherPath64))
            {
                if (Directory.Exists(RegPath + LauncherPath))
                {
                    LaunchPath = RegPath + LauncherPath + text;
                    AddTextLog("Found! (32 bit)");
                    dictionary.Add("32bit", LauncherPath);
                    num++;
                }
                if (Directory.Exists(RegPath + LauncherPath64))
                {
                    LaunchPath = RegPath + LauncherPath64 + text;
                    AddTextLog("Found! (64 bit)");
                    dictionary.Add("64bit", LauncherPath64);
                    num++;
                }
                if (defaultclient != "")
                {
                    LaunchPath = RegPath + dictionary[defaultclient].ToString() + text;
                    AddTextLog("Using: " + defaultclient + " " + text2);
                }
                else if (num > 1)
                {
                    switch (Prompt.MultipleClient())
                    {
                        case DialogResult.Yes:
                            LaunchPath = RegPath + LauncherPath + text;
                            AddTextLog("Using 32bit " + text2);
                            SaveDefaultClient("32bit");
                            break;
                        case DialogResult.No:
                            LaunchPath = RegPath + LauncherPath64 + text;
                            AddTextLog("Using 64bit " + text2);
                            SaveDefaultClient("64bit");
                            break;
                        default:
                            AddTextLog("Skipping default launcher!");
                            break;
                    }
                }
                bool flag = false;
                foreach (TreeNode node in treeView3.Nodes)
                {
                    if (node != null && node.Checked)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    AddTextLog("Applying Addons...");
                    StartGameAddons();
                }
                AddTextLog("Starting Auth...");
                if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Europe") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Korean") || metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Taiwan"))
                {
                    if (metroLabel14.Text != "Clean" && metroComboBox1.SelectedIndex != metroComboBox1.FindStringExact("Korean"))
                    {
                        RestoreConfigFiles();
                    }
                    GetLogin();
                    if (LoginOccured && !Maintenance)
                    {
                        GrabToken();
                    }
                    else
                    {
                        metroButton1.Enabled = true;
                        if (Maintenance)
                        {
                            LauncherInfo();
                            if (Maintenance)
                            {
                                AddTextLog("Server in Maintenance");
                                AddTextLog("Cancelled");
                            }
                            else
                            {
                                GrabToken();
                            }
                        }
                        else
                        {
                            AddTextLog("Login Failed");
                            AddTextLog("Cancelled");
                        }
                    }
                }
                else if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("Japanese"))
                {
                    AddTextLog("Starting Client!");
                    Process process = new Process();
                    process.StartInfo.FileName = LaunchPath;
                    process.StartInfo.Arguments = "/LaunchByLauncher /Sesskey /SessKey:\"\" /CompanyID:\"14\" /ChannelGroupIndex:\"-1\"" + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardError = false;
                    bool flag2 = false;
                    try
                    {
                        if (AutoClean)
                        {
                            CleanMem();
                        }
                    }
                    catch
                    {
                        AddTextBoxLog("Notice: Could not clear any memory!");
                    }
                    try
                    {
                        process.Start();
                        string str = "Client.exe";
                        if (customclientname != "")
                        {
                            str = customclientname;
                        }
                        AddTextLog("Started " + str + "!");
                        appuniqueid = process.Id;
                        GameStarted = true;
                        flag2 = true;
                        disableButtons();
                        AddTextBoxLog("Notice: BnS Buddy does directly support Multiclient for Japanese server!");
                        base.WindowState = FormWindowState.Minimized;
                    }
                    catch
                    {
                        Show();
                        notifyIcon1.Visible = false;
                        metroButton1.Enabled = true;
                        foreach (TreeNode node2 in treeView2.Nodes)
                        {
                            if (node2 != null)
                            {
                                if (node2.Nodes.Count > 0)
                                {
                                    foreach (TreeNode subnode in node2.Nodes)
                                    {
                                        if (subnode != null)
                                        {
                                            RealModPath = FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "");
                                            if (Directory.Exists(RealModPath))
                                            {
                                                checkButtons(output: true);
                                            }
                                            else
                                            {
                                                subnode.Remove();
                                            }
                                        }
                                    }
                                }
                                if (node2.Nodes.Count == 0)
                                {
                                    RealModPath = FullModPathMan + "\\" + node2.FullPath.ToString().Replace(" (Installed)", "");
                                    if (Directory.Exists(RealModPath))
                                    {
                                        checkButtons(output: true);
                                    }
                                    else
                                    {
                                        node2.Remove();
                                    }
                                }
                            }
                        }
                        AddTextLog("Error: Could Not Start Client.exe!");
                    }
                    if (flag2)
                    {
                        try
                        {
                            AutoCleaner();
                        }
                        catch
                        {
                            AddTextLog("Error: Could not clean memory with autocleaner!");
                        }
                    }
                }
                else
                {
                    AddTextLog("Starting Client!");
                    Process process2 = new Process();
                    process2.StartInfo.FileName = LaunchPath;
                    process2.StartInfo.Arguments = "-lang:" + languageID + " -lite:2 -region:" + regionID + " /sesskey /launchbylauncher  /CompanyID:12 /ChannelGroupIndex:-1 " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                    process2.StartInfo.UseShellExecute = false;
                    process2.StartInfo.RedirectStandardError = false;
                    bool flag3 = false;
                    try
                    {
                        if (AutoClean)
                        {
                            CleanMem();
                        }
                    }
                    catch
                    {
                        AddTextBoxLog("Notice: Could not clear any memory!");
                    }
                    try
                    {
                        process2.Start();
                        string str2 = "Client.exe";
                        if (customclientname != "")
                        {
                            str2 = customclientname;
                        }
                        AddTextLog("Started " + str2 + "!");
                        appuniqueid = process2.Id;
                        GameStarted = true;
                        flag3 = true;
                        AddTextBoxLog("Notice: BnS Buddy does directly support Multiclient for this server!");
                        base.WindowState = FormWindowState.Minimized;
                    }
                    catch
                    {
                        Show();
                        notifyIcon1.Visible = false;
                        metroButton1.Enabled = true;
                        foreach (TreeNode node3 in treeView2.Nodes)
                        {
                            if (node3 != null)
                            {
                                if (node3.Nodes.Count > 0)
                                {
                                    foreach (TreeNode subnode in node3.Nodes)
                                    {
                                        if (subnode != null)
                                        {
                                            RealModPath = FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "");
                                            if (Directory.Exists(RealModPath))
                                            {
                                                checkButtons(output: true);
                                            }
                                            else
                                            {
                                                subnode.Remove();
                                            }
                                        }
                                    }
                                }
                                if (node3.Nodes.Count == 0)
                                {
                                    RealModPath = FullModPathMan + "\\" + node3.FullPath.ToString().Replace(" (Installed)", "");
                                    if (Directory.Exists(RealModPath))
                                    {
                                        checkButtons(output: true);
                                    }
                                    else
                                    {
                                        node3.Remove();
                                    }
                                }
                            }
                        }
                        AddTextLog("Error: Could Not Start Client.exe!");
                    }
                    if (flag3)
                    {
                        try
                        {
                            AutoCleaner();
                        }
                        catch
                        {
                            AddTextLog("Error: Could not clean memory!");
                        }
                    }
                }
            }
            else
            {
                AddTextLog("Error: Path to " + text + " not found!");
            }
        }

        private void GetLogin()
        {
            username = "";
            password = "";
            LoginOccured = false;
            Hide();
            Splash1 splash = new Splash1();
            splash.Visible = false;
            splash.ShowDialog();
            username = splash.username.ToString().ToLower();
            password = splash.password.ToString();
            if (username.Length > 1 && password.Length > 1)
            {
                if (!metroComboBox9.Items.Contains(username))
                {
                    LoginOccured = true;
                }
                else
                {
                    AddTextLog("This user is already logged in!");
                }
            }
            if (Debugging)
            {
                Prompt.Popup("Username used: " + username + Environment.NewLine + "Password used: " + password);
            }
            UseToken = true;
            Show();
            base.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            NotifAction();
        }

        public void NotifAction()
        {
            try
            {
                if (ContextMenu.IsParent && ContextMenu != null)
                {
                    ContextMenu.Dispose();
                }
            }
            catch
            {
            }
            Show();
            if (base.WindowState != 0)
            {
                base.WindowState = FormWindowState.Normal;
            }
            if (notifyIcon1.Visible)
            {
                if (!AlwaysOnTray)
                {
                    notifyIcon1.Visible = false;
                }
            }
        }

        public bool AlwaysOnTray = false;
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (AllowMinimize && base.WindowState == FormWindowState.Minimized)
            {
                if (!AlwaysOnTray)
                {
                    ConfigureContext();
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(50, "BnS Buddy", "Minimized to tray.", ToolTipIcon.Info);
                }
                Hide();
            }
            else if (WindowState == FormWindowState.Normal && notifyIcon1.Visible == true)
            {
                NotifAction();
                Focus();
            }
        }

        public void InitializeSplash()
        {
            if (PathFound)
            {
                try
                {
                    FileInfo[] files = new DirectoryInfo(NewModPathSplash + "\\").GetFiles("*.bmp");
                    foreach (FileInfo fileInfo in files)
                    {
                        listBox1.Items.Add(fileInfo.Name);
                    }
                    if (listBox1.Items.Count != 0)
                    {
                        listBox1.SelectedIndex = 0;
                        pictureBox1.Image = Image.FromFile(NewModPathSplash + "\\" + listBox1.SelectedItem.ToString());
                    }
                    else
                    {
                        listBox1.SelectedIndex = -1;
                    }
                }
                catch
                {
                    if (Directory.GetFileSystemEntries(NewModPathSplash).Length == 0)
                    {
                        if (Directory.GetFileSystemEntries(NewFullBackupPathSplash).Length == 0)
                        {
                            metroButton4.Enabled = true;
                            metroButton5.Enabled = false;
                            metroButton6.Enabled = true;
                        }
                    }
                    else if (Directory.GetFileSystemEntries(NewModPathSplash).Length != 0)
                    {
                        if (Directory.GetFileSystemEntries(NewFullBackupPathSplash).Length != 0)
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
            Directory.CreateDirectory(PathName);
        }

        public void Verify()
        {
            if (File.Exists(NewFullBackupPathSplash + "\\Splash.bmp"))
            {
                bool flag = false;
                string b = checkMD5(FullPathSplash + "\\Splash.bmp");
                string[] files = Directory.GetFiles(NewModPathSplash);
                foreach (string text in files)
                {
                    if (text.Length > 0 && checkMD5(text) == b)
                    {
                        flag = true;
                    }
                }
                if (flag)
                {
                    metroLabel17.Text = "Modded";
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = true;
                }
                else
                {
                    metroLabel17.Text = "Original";
                    metroButton5.Enabled = false;
                    metroButton4.Enabled = true;
                }
            }
            else
            {
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
                metroLabel17.Text = "Original";
            }
            if (!File.Exists(NewModPathSplash + "\\BuddySplash-Small.bmp") && !File.Exists(NewModPathSplash + "\\BuddySplash-Big.bmp"))
            {
                try
                {
                    ImageConverter imageConverter = new ImageConverter();
                    File.WriteAllBytes(NewModPathSplash + "\\BuddySplash-Small.bmp", (byte[])imageConverter.ConvertTo(Resources.buddysplash_small, typeof(byte[])));
                    File.WriteAllBytes(NewModPathSplash + "\\BuddySplash-Big.bmp", (byte[])imageConverter.ConvertTo(Resources.buddysplash_big, typeof(byte[])));
                }
                catch
                {
                    Prompt.Popup("Error: Could not extract BnS Buddy Splashes!");
                }
            }
        }

        public void GetPaths()
        {
            if (PathFound)
            {
                RegPathSplash = RegPath;
                if (!Korean)
                {
                    ExtensionSplash = "\\contents\\Local\\" + autofinder;
                    FullPathSplash = RegPathSplash + ExtensionSplash + "\\" + autocook + "\\Splash";
                }
                else
                {
                    ExtensionSplash = "\\contents\\bns";
                    FullPathSplash = RegPathSplash + ExtensionSplash + "\\Splash";
                }
                workingPathSplash = FullPathSplash;
                FullBackupPathSplash = FullPathSplash + "\\backup";
                Directory.CreateDirectory(AppPath + "\\Splashes\\backup");
                Directory.CreateDirectory(AppPath + "\\Splashes\\mods");
                NewModPathSplash = AppPath + "\\Splashes\\mods";
                NewFullBackupPathSplash = AppPath + "\\Splashes\\backup";
                ModPathSplash = FullPathSplash + "\\mods";
                FullBackupPathSplash = FullBackupPathSplash.Replace("\\\\", "\\");
                ModPathSplash = ModPathSplash.Replace("\\\\", "\\");
                if (Directory.Exists(FullBackupPathSplash))
                {
                    if (File.Exists(FullBackupPathSplash + "\\Splash.bmp"))
                    {
                        File.Move(FullBackupPathSplash + "\\Splash.bmp", NewFullBackupPathSplash + "\\Splash.bmp");
                    }
                    Directory.Delete(FullBackupPathSplash, recursive: true);
                }
                if (Directory.Exists(ModPathSplash))
                {
                    string[] files = Directory.GetFiles(ModPathSplash);
                    foreach (string text in files)
                    {
                        string fileName = Path.GetFileName(text);
                        if (text.Length > 0)
                        {
                            File.Move(text, NewModPathSplash + "\\" + fileName);
                        }
                    }
                    Directory.Delete(ModPathSplash, recursive: true);
                }
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
            if (FullPathSplash.Contains("\\\\"))
            {
                FullPathSplash = FullPathSplash.Replace("\\\\", "\\");
            }
            Process.Start("explorer.exe", NewModPathSplash);
        }

        private void metroLabel17_TextChanged(object sender, EventArgs e)
        {
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

        private void metroButton34_Click(object sender, EventArgs e)
        {
            Process.Start(NewSplash);
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            if (listBox1.SelectedItem != null)
            {
                NewSplash = NewModPathSplash + "\\" + listBox1.SelectedItem.ToString();
                if (File.Exists(NewSplash))
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(NewSplash);
                        metroLabel99.Text = "Width: " + pictureBox1.Image.Width + " | Height: " + pictureBox1.Image.Height + " | (" + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height + ")";
                        metroButton34.Enabled = true;
                    }
                    catch
                    {
                        metroLabel99.Text = "";
                        metroButton34.Enabled = false;
                        listBox1.SelectedIndex = -1;
                        Prompt.Popup("Invalid BMP File");
                    }
                }
                else
                {
                    listBox1.ClearSelected();
                    listBox1.Items.Remove(listBox1.SelectedItem.ToString());
                    metroButton34.Enabled = false;
                    metroLabel99.Text = "";
                }
            }
        }

        private void metroButton4_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                try
                {
                    File.Copy(FullPathSplash + "\\Splash.bmp", NewFullBackupPathSplash + "\\Splash.bmp", overwrite: true);
                    File.Copy(NewSplash, FullPathSplash + "\\Splash.bmp", overwrite: true);
                    metroLabel17.Text = "Modded";
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = true;
                }
                catch
                {
                    Prompt.Popup("Error: Could not replace image!");
                }
                try
                {
                    pictureBox1.Image = Image.FromFile(NewModPathSplash + "\\" + listBox1.SelectedItem.ToString());
                }
                catch
                {
                    listBox1.SelectedIndex = -1;
                    Prompt.Popup("Invalid BMP File");
                }
            }
        }

        private void metroButton5_Click_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            try
            {
                File.Copy(NewFullBackupPathSplash + "\\Splash.bmp", FullPathSplash + "\\Splash.bmp", overwrite: true);
                metroLabel17.Text = "Original";
                metroButton5.Enabled = false;
                metroButton4.Enabled = true;
            }
            catch
            {
                Prompt.Popup("Error: Could not replace image!");
            }
            try
            {
                pictureBox1.Image = Image.FromFile(NewModPathSplash + "\\" + listBox1.SelectedItem.ToString());
            }
            catch
            {
                listBox1.SelectedIndex = -1;
                Prompt.Popup("Invalid BMP File");
            }
        }

        private void metroButton7_Click_1(object sender, EventArgs e)
        {
            SplashPopulater();
        }

        public void SplashPopulater()
        {
            try
            {
                metroLabel99.Text = "";
                metroButton34.Enabled = false;
                listBox1.SelectedIndex = -1;
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                FileInfo[] files = new DirectoryInfo(NewModPathSplash + "\\").GetFiles("*.bmp");
                foreach (string item in listBox1.Items)
                {
                    if (!File.Exists(NewModPathSplash + "\\" + item))
                    {
                        listBox1.Items.Remove(item);
                    }
                }
                FileInfo[] array = files;
                foreach (FileInfo fileInfo in array)
                {
                    if (!listBox1.Items.Contains(fileInfo.Name))
                    {
                        listBox1.Items.Add(fileInfo.Name);
                    }
                }
            }
            catch
            {
                if (Directory.GetFileSystemEntries(NewModPathSplash).Length == 0)
                {
                    metroButton4.Enabled = false;
                    metroButton5.Enabled = false;
                    metroButton6.Enabled = true;
                }
                else if (Directory.GetFileSystemEntries(NewModPathSplash).Length != 0)
                {
                    metroButton4.Enabled = true;
                    metroButton5.Enabled = true;
                    metroButton6.Enabled = true;
                }
                else
                {
                    AddTextLog("Error: Was Not Able to Populate!");
                }
            }
        }

        /* CreateHardLink(@"c:\temp\New Link", @"c:\temp\Original File",IntPtr.Zero); 
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(
            string lpFileName,
            string lpExistingFileName,
            IntPtr lpSecurityAttributes
        );
        */

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

        enum SymbolicLink
        {
            File = 0,
            Directory = 1
        }

        private bool IsSymbolic(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (directoryInfo.Attributes.HasFlag(FileAttributes.Directory))
                {
                    return directoryInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
                }
            }
            if (File.Exists(path))
            {
                FileInfo pathInfo = new FileInfo(path);
                if (pathInfo.Attributes.HasFlag(FileAttributes.Normal))
                {
                    return pathInfo.Attributes.HasFlag(FileAttributes.ReparsePoint);
                }
            }
            return false;
        }

        public void InitializeManager()
        {
            FullPath = FullPath.Replace("\\\\", "\\");
            tmpdir = FullPath;
            NewPath = tmpdir.Replace("\\CookedPC", "").Replace("\\\\", "\\");
            workingPath = NewPath + "\\CookedPC_Settings";
            modsFolderPath = FullPath + "\\mod";
            if (!CustomModSet)
            {
                modFolderPath = NewPath + "\\CookedPC_Mod";
                backupFolderPath = NewPath + "\\CookedPC_Backup";
            }
            else
            {
                modFolderPath = metroTextBox7.Text + "\\CookedPC_Mod";
                backupFolderPath = metroTextBox7.Text + "\\CookedPC_Backup";
            }
            workingPath = workingPath.Replace("\\\\", "\\");
            modFolderPath = modFolderPath.Replace("\\\\", "\\");
            modsFolderPath = modsFolderPath.Replace("\\\\", "\\");
            backupFolderPath = backupFolderPath.Replace("\\\\", "\\");
        }

        private void VerifyUsage()
        {
            try
            {
                isBnsFolderSet();
            }
            catch (Exception ex)
            {
                Prompt.Popup("Error: " + ex.ToString());
            }
            foreach (TreeNode node in treeView2.Nodes)
            {
                if (node != null)
                {
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode subnode in node.Nodes)
                        {
                            if (subnode != null)
                            {
                                RealModPath = FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "");
                                if (Directory.Exists(RealModPath))
                                {
                                    checkButtons(output: true);
                                }
                                else
                                {
                                    Prompt.Popup("Removed: " + subnode.FullPath);
                                    subnode.Remove();
                                }
                            }
                        }
                    }
                    if (node.Nodes.Count == 0)
                    {
                        RealModPath = FullModPathMan + "\\" + node.FullPath.ToString().Replace(" (Installed)", "");
                        if (Directory.Exists(RealModPath))
                        {
                            checkButtons(output: true);
                        }
                        else
                        {
                            node.Remove();
                        }
                    }
                }
            }
        }

        private bool isBnsFolderSet(bool outputMessage = false)
        {
            originalFolderPath = FullPath;
            string text = originalFolderPath;
            text = text.Replace("\\contents\\Local\\" + autofinder + "\\" + autocook + "\\CookedPC", "");
            bnsExeFolderPath = text + "\\bin";
            bnsFolderIsSet = true;
            return true;
        }

        private void checkButtons(bool output = false)
        {
            int num = 0;
            int num2 = 0;
            FileInfo[] files = new DirectoryInfo(RealModPath).GetFiles("*.*");
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.Contains(".upk") || files[i].Name.Contains(".umap"))
                {
                    num++;
                }
            }
            files = new DirectoryInfo(backupFolderPath).GetFiles("*.*");
            for (int j = 0; j < files.Length; j++)
            {
                if (files[j].Name.Contains(".bak"))
                {
                    num2++;
                }
            }
            if (num2 == 0)
            {
                if (num == 0)
                {
                    if (output)
                    {
                        AddTextBoxLog(Environment.NewLine);
                        if (!RealModPath.Contains("(Installed)"))
                        {
                            AddTextBoxLog("[Notice] No modded files detected in the \"" + Path.GetFileName(RealModPath) + "\" folder. Press Mod Folder Then drag the files in there then press Refresh button.");
                        }
                        else
                        {
                            AddTextBoxLog("[Notice] " + Path.GetFileName(RealModPath) + " mod is already installed");
                        }
                    }
                }
                else if (output)
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] Found " + num.ToString() + " game files in the " + Path.GetFileName(RealModPath) + " folder.");
                }
            }
            if (num2 != 0 && output)
            {
                AddTextBoxLog(Environment.NewLine);
                AddTextBoxLog("[Log] Found " + num2.ToString() + " game files in the \"CookedPC_Backup\" folder.");
            }
            metroButton9.Enabled = true;
            metroButton11.Enabled = true;
            if (!bnsFolderIsSet)
            {
                metroButton11.Enabled = false;
                metroButton9.Enabled = false;
            }
        }

        private void checkLegacy()
        {
            int num = 0;
            int num2 = 0;
            FileInfo[] files = new DirectoryInfo(RealModPath).GetFiles("*.*");
            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Name.Contains(".txt"))
                {
                    num++;
                }
            }
            files = new DirectoryInfo(backupFolderPath).GetFiles("*.*");
            for (int j = 0; j < files.Length; j++)
            {
                if (!files[j].Name.Contains(".txt"))
                {
                    num2++;
                }
            }
        }

        public void JsonManager()
        {
            if (File.Exists(workingPath + "\\database.json"))
            {
                File.Delete(workingPath + "\\database.json");
            }
            foreach (TreeNode node in treeView2.Nodes)
            {
                if (node != null)
                {
                    RealModPath = FullModPathMan + "\\" + node.FullPath.ToString();
                    checkLegacy();
                }
            }
            bw = new BackgroundWorker();
            isBnsFolderSet(outputMessage: true);
        }

        private void GetPath()
        {
            if (PathFound)
            {
                FullModsPathMan = FullPath + "\\mod";
                FullModsPathMan = FullModsPathMan.Replace("\\\\", "\\");
                if (FullPath.Length > 0 && !Directory.Exists(FullModsPathMan))
                {
                    CreatePaths(FullModsPathMan);
                }
                if (CustomModSet)
                {
                    if (!Directory.Exists(backupFolderPath))
                    {
                        CreatePaths(backupFolderPath);
                    }
                    if (!Directory.Exists(FullModPathMan))
                    {
                        CreatePaths(FullModPathMan);
                    }
                }
                else
                {
                    backupFolderPath = NewPath + "\\CookedPC_Backup";
                    backupFolderPath = backupFolderPath.Replace("\\\\", "\\");
                    if (!Directory.Exists(backupFolderPath))
                    {
                        CreatePaths(backupFolderPath);
                    }
                    FullModPathMan = NewPath + "\\CookedPC_Mod";
                    FullModPathMan = FullModPathMan.Replace("\\\\", "\\");
                    if (!Directory.Exists(FullModPathMan))
                    {
                        CreatePaths(FullModPathMan);
                    }
                }
                FullSettingsPathMan = NewPath + "\\CookedPC_Settings";
                FullSettingsPathMan = FullSettingsPathMan.Replace("\\\\", "\\");
                if (Directory.Exists(FullSettingsPathMan))
                {
                    if (Directory.GetFiles(FullSettingsPathMan).Length == 0)
                    {
                        Directory.Delete(FullSettingsPathMan);
                    }
                    else
                    {
                        File.Delete(FullSettingsPathMan + "\\database.json");
                        Directory.Delete(FullSettingsPathMan);
                    }
                }
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
            foreach (TreeNode node in treeView2.Nodes)
            {
                if (node != null)
                {
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode subnode in node.Nodes)
                        {
                            if (subnode != null)
                            {
                                RealModPath = FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "");
                                if (Directory.Exists(RealModPath))
                                {
                                    checkButtons();
                                }
                                else
                                {
                                    subnode.Remove();
                                }
                            }
                        }
                    }
                    if (node.Nodes.Count == 0)
                    {
                        RealModPath = FullModPathMan + "\\" + node.FullPath.ToString().Replace(" (Installed)", "");
                        if (Directory.Exists(RealModPath))
                        {
                            checkButtons();
                        }
                        else
                        {
                            node.Remove();
                        }
                    }
                }
            }
        }

        private void doFileSwapV2(string obj, bool InstallFlag)
        {
            List<object> arguments = new List<object>();
            arguments.Add(obj);
            arguments.Add(InstallFlag);
            RealModPath = obj;
            disableButtons();
            bw_DoWorkV2(arguments);
        }

        private void bw_ProgressChangedV2()
        {
            var maxint = metroProgressBar2.Maximum;
            var curint = metroProgressBar2.Value;
            if (curint == maxint)
            {
                metroProgressBar2.Value = 0;
            }
        }

        private void bw_RunWorkerCompletedV2()
        {
            metroProgressBar2.Refresh();
            enableButtons();
        }

        private void bw_DoWorkV2(object Arguments)
        {
            List<object> genericlist = Arguments as List<object>;
            string text = (string)genericlist[0];
            bool installFlag = (bool)genericlist[1];
            string fileName = Path.GetFileName(text);
            string name = new DirectoryInfo(text).Name;
            if (installFlag)
            {
                RealModPath = text.ToString();
                tmpnode = fileName.ToString();
                newbackuppath = backupFolderPath + "\\" + tmpnode;
                DirectoryInfo directoryInfo = new DirectoryInfo(RealModPath);
                string empty = string.Empty;
                int num = 0;
                int num2 = 0;
                int num3 = directoryInfo.GetFiles("*.upk").Count();
                num3 += directoryInfo.GetFiles("*.umap").Count();
                int num4 = 0;
                if (num3 != 0)
                {
                    metroProgressBar2.Value = 0;
                    string[] files = Directory.GetFiles(RealModPath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        metroProgressBar2.Maximum = files.Length;
                        metroProgressBar2.PerformStep();
                        metroProgressBar2.Refresh();
                        string text2 = files[i].Split(Path.DirectorySeparatorChar).Last();
                        if (text2 != "preview.png" && text2 != "description.txt" && (text2.EndsWith(".upk") || text2.EndsWith(".umap")))
                        {
                            Control.CheckForIllegalCrossThreadCalls = false;
                            AddTextBoxLog(Environment.NewLine);
                            try
                            {
                                if (File.Exists(RealModPath + "\\" + text2))
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Creating] " + name + " [folder] at CookedPC/mod");
                                    if (!Directory.Exists(modsFolderPath + "\\" + name))
                                    {
                                        Directory.CreateDirectory(modsFolderPath + "\\" + name);
                                    }
                                    AddTextBoxLog(Environment.NewLine + "[Created] " + name + " [folder] at CookedPC/mod");
                                    AddTextBoxLog(Environment.NewLine + "[Linking] " + text2 + " [modded] to CookedPC/mod");
                                    CreateSymbolicLink(modsFolderPath + "\\" + name + "\\" + text2, RealModPath + "\\" + text2, SymbolicLink.File);
                                    AddTextBoxLog(Environment.NewLine + "[Linked] " + text2 + " [modded] to CookedPC/mod");
                                }
                            }
                            catch
                            {
                                AddTextBoxLog(Environment.NewLine + "[Error] " + text2 + " could not be touched!");
                            }
                            num++;
                            num2++;
                            num4 = num2 * 100 / num3;
                            bw_ProgressChangedV2();
                        }
                    }
                    if (num > 0)
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Done! " + num + " files were moved.");
                    }
                    else
                    {
                        AddTextBoxLog(Environment.NewLine);
                        AddTextBoxLog("[Log] Done! No files were moved.");
                    }
                }
                else
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Notice] Can't install an empty mod folder");
                }
            }
            if (!installFlag)
            {
                bool flag = false;
                int num5 = 0;
                RealModPath = text.ToString();
                tmpnode = fileName.ToString();
                newbackuppath = backupFolderPath + "\\" + tmpnode.Replace(" (Installed)", "");
                if (Directory.Exists(newbackuppath))
                {
                    DirectoryInfo directoryInfo2 = new DirectoryInfo(newbackuppath);
                    num5 = directoryInfo2.GetFiles("*.upk").Count();
                    num5 += directoryInfo2.GetFiles("*.umap").Count();
                    flag = true;
                }
                else
                {
                    DirectoryInfo directoryInfo3 = new DirectoryInfo(RealModPath);
                    num5 = directoryInfo3.GetFiles("*.upk").Count();
                    num5 += directoryInfo3.GetFiles("*.umap").Count();
                }
                string empty2 = string.Empty;
                int num6 = 0;
                int num7 = 0;
                int num8 = 0;
                if (!flag)
                {
                    metroProgressBar2.Value = 0;
                    string[] files2 = Directory.GetFiles(RealModPath);
                    for (int j = 0; j < files2.Length; j++)
                    {
                        metroProgressBar2.Maximum = files2.Length;
                        metroProgressBar2.PerformStep();
                        metroProgressBar2.Refresh();
                        string text3 = files2[j].Split(Path.DirectorySeparatorChar).Last();
                        string text4 = name.Replace(" (Installed)", "");
                        Control.CheckForIllegalCrossThreadCalls = false;
                        AddTextBoxLog(Environment.NewLine);
                        try
                        {
                            if (text3.Contains(".upk") || text3.Contains(".umap"))
                            {
                                if (File.Exists(modsFolderPath + "\\" + text4 + "\\" + text3))
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Removing] " + text3 + " [modded] from CookedPC/mod");
                                    File.Delete(modsFolderPath + "\\" + text4 + "\\" + text3);
                                    if (Directory.GetFiles(modsFolderPath + "\\" + text4).Length == 0)
                                    {
                                        Directory.Delete(modsFolderPath + "\\" + text4);
                                    }
                                    AddTextBoxLog(Environment.NewLine + "[Removed] " + text3 + " [modded] from CookedPC/mod");
                                }
                                num6++;
                                num7++;
                                num8 = num7 * 100 / num5;
                                //Thread.Sleep(50);
                                bw_ProgressChangedV2();
                            }
                        }
                        catch
                        {
                            AddTextBoxLog(Environment.NewLine + "[Error] " + text3 + " could not be touched!");
                        }
                    }
                }
                goto IL_0650;
            IL_0650:
                if (flag)
                {
                    metroProgressBar2.Value = 0;
                    string[] files3 = Directory.GetFiles(newbackuppath);
                    for (int k = 0; k < files3.Length; k++)
                    {
                        metroProgressBar2.Maximum = files3.Length;
                        metroProgressBar2.PerformStep();
                        metroProgressBar2.Refresh();
                        string text5 = files3[k].Split(Path.DirectorySeparatorChar).Last();
                        Control.CheckForIllegalCrossThreadCalls = false;
                        AddTextBoxLog(Environment.NewLine);
                        try
                        {
                            if (File.Exists(modsFolderPath + "\\" + text5))
                            {
                                AddTextBoxLog(Environment.NewLine + "[Deleting] " + text5 + " [modded] from CookedPC/mod");
                                File.Delete(modsFolderPath + "\\" + text5);
                                AddTextBoxLog(Environment.NewLine + "[Deleted] " + text5 + " [modded] from CookedPC/mod");
                            }
                        }
                        catch
                        {
                            AddTextBoxLog(Environment.NewLine + "[Error] " + text5 + " could not be touched!");
                        }
                        try
                        {
                            if (!File.Exists(newbackuppath + "\\" + text5) || text5.Contains("(unique)"))
                            {
                                try
                                {
                                    string str = text5.Replace(" (unique)", "");
                                    AddTextBoxLog(Environment.NewLine + "[Deleting] " + text5 + " [modded] from CookedPC_Mod");
                                    File.Copy(newbackuppath + "\\" + text5, RealModPath + "\\" + str, overwrite: true);
                                    File.Delete(newbackuppath + "\\" + text5);
                                    File.Delete(modsFolderPath + "\\" + str);
                                    AddTextBoxLog(Environment.NewLine + "[Deleted] " + text5 + " [modded] from CookedPC_Mod");
                                }
                                catch
                                {
                                    AddTextBoxLog(Environment.NewLine + "[Error] " + text5 + " (unique) couldn't be copied/deleted from CookedPC_Mod");
                                }
                            }
                            else
                            {
                                AddTextBoxLog(Environment.NewLine + "[Copying] " + text5 + " [original] to CookedPC");
                                File.Copy(newbackuppath + "\\" + text5, originalFolderPath + "\\" + text5, overwrite: true);
                                AddTextBoxLog(Environment.NewLine + "[Copied] " + text5 + " [original] to CookedPC");
                                AddTextBoxLog(Environment.NewLine + "[Deleting] " + text5 + " [original] from CookedPC_Backup");
                                File.Delete(newbackuppath + "\\" + text5);
                                AddTextBoxLog(Environment.NewLine + "[Deleted] " + text5 + " [original] from CookedPC_Backup");
                            }
                        }
                        catch
                        {
                            AddTextBoxLog(Environment.NewLine + "[Error] " + text5 + " could not be touched!");
                        }
                        num6++;
                        num7++;
                        num8 = num7 * 100 / num5;
                        //Thread.Sleep(50);
                        bw_ProgressChangedV2();
                    }
                }
                if (Directory.Exists(newbackuppath) && Directory.GetFiles(newbackuppath).Length == 0)
                {
                    Directory.Delete(newbackuppath);
                }
                else if (flag)
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] Error: Restoring did not complete.");
                }
                if (num6 > 0)
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] Done! " + num6 + " files were removed.");
                }
                else
                {
                    AddTextBoxLog(Environment.NewLine);
                    AddTextBoxLog("[Log] Done! No files were removed.");
                }
            }
            bw_RunWorkerCompletedV2();
        }

        public bool checkNode(string s)
        {
            foreach (TreeNode node in treeView2.Nodes)
            {
                if (node != null && node.FullPath.ToString() == s)
                {
                    return false;
                }
            }
            return true;
        }

        public void removebad()
        {
            foreach (TreeNode node in treeView2.Nodes)
            {
                if (node != null)
                {
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode subnode in node.Nodes)
                        {
                            if (subnode != null)
                            {
                                RealModPath = FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "");
                                if (Directory.Exists(RealModPath))
                                {
                                    checkButtons();
                                }
                                else
                                {
                                    subnode.Remove();
                                }
                            }
                        }
                    }
                    if (node.Nodes.Count == 0)
                    {
                        RealModPath = FullModPathMan + "\\" + node.FullPath.ToString().Replace(" (Installed)", "");
                        if (Directory.Exists(RealModPath))
                        {
                            checkButtons();
                        }
                        else
                        {
                            node.Remove();
                        }
                    }
                }
            }
            treeView2.Sort();
        }

        public void colornodes()
        {
            treeView2.Refresh();
            foreach (TreeNode ColorAT in treeView2.Nodes)
            {
                if (ColorAT != null)
                {
                    // Child support
                    if (ColorAT.Nodes.Count > 0)
                    {
                        foreach (TreeNode subnode in ColorAT.Nodes)
                        {
                            if (subnode != null)
                            {
                                if (subnode.Text.Contains(" (Installed)"))
                                {
                                    subnode.ForeColor = Color.LightGreen;
                                }
                                else
                                {
                                    subnode.ForeColor = Color.White;
                                }
                            }
                        }
                    }
                    // Parent Support
                    if (ColorAT.Text.Contains(" (Installed)"))
                    {
                        ColorAT.ForeColor = Color.LightGreen;
                    }
                    else
                    {
                        ColorAT.ForeColor = Color.White;
                    }
                }
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            ReFreshMods();
        }

        public void ReFreshMods()
        {
            AddTextBoxLog(Environment.NewLine);
            AddTextBoxLog("[Log] Checking Mods Folder...");
            treeView2.BeginUpdate();
            removebad();
            PopulateTreeView(FullModPathMan);
            treeView2.Sort();
            treeView2.EndUpdate();
            AddTextBoxLog(Environment.NewLine);
            AddTextBoxLog("[Log] Done Checking");
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            catcher = "";
            metroProgressBar2.Visible = true;
            metroProgressBar2.Refresh();
            try
            {
                List<string> todos = new List<string>();
                Thread DoSwapThreads;
                foreach (TreeNode node in treeView2.Nodes)
                {
                    if (node != null)
                    {
                        // Child support
                        if (node.Nodes.Count > 0)
                        {
                            foreach (TreeNode subnode in node.Nodes)
                            {
                                if (subnode != null)
                                {
                                    if (subnode.Checked && subnode.Text.Contains(" (Installed)"))
                                    {
                                        todos.Add(subnode.FullPath);
                                    }
                                    else if (subnode.Checked && !subnode.Text.Contains(" (Installed)"))
                                    {
                                        subnode.Checked = false;
                                        AddTextBoxLog(Environment.NewLine + "Skipping: " + subnode.Text + " (Not Installed)");
                                    }
                                }
                            }
                        }
                        // Parent support
                        if (node.Checked && node.Text.Contains(" (Installed)"))
                        {
                            todos.Add(node.FullPath);
                        }
                        else if (node.Checked && !node.Text.Contains(" (Installed)"))
                        {
                            node.Checked = false;
                            AddTextBoxLog(Environment.NewLine + "Skipping: " + node.Text + " (Not Installed)");
                        }
                    }
                }
                foreach (string olla in todos)
                {
                    foreach (TreeNode node in treeView2.Nodes)
                    {
                        if (node != null)
                        {
                            // Child support
                            if (node.Nodes.Count > 0)
                            {
                                foreach (TreeNode subnode in node.Nodes)
                                {
                                    if (subnode != null)
                                    {
                                        catcher = subnode.FullPath;
                                        if (subnode.FullPath == olla)
                                        {
                                            if (Directory.GetFiles(FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "")).Count() > 0)
                                            {
                                                DoSwapThreads = new Thread(() => doFileSwapV2(FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", ""), false));
                                                DoSwapThreads.Priority = ThreadPriority.Normal;
                                                DoSwapThreads.Start();
                                                DoSwapThreads.Join();
                                                Thread.Sleep(100);
                                                Completed_Mod_Work(catcher.Replace(" (Installed)", ""), subnode, true);
                                                PopulateTreeView(FullModPathMan);
                                            }
                                            else
                                            {
                                                AddTextBoxLog(Environment.NewLine + "Can't uninstall " + catcher + " because it's empty.");
                                            }
                                        }
                                    }
                                }
                            }
                            // Parent support
                            catcher = node.Text;
                            if (olla == node.FullPath)
                            {
                                if (Directory.GetFiles(FullModPathMan + "\\" + node.FullPath.ToString().Replace(" (Installed)", "")).Count() > 0)
                                {
                                    DoSwapThreads = new Thread(() => doFileSwapV2(FullModPathMan + "\\" + node.FullPath.ToString().Replace(" (Installed)", ""), false));
                                    DoSwapThreads.Priority = ThreadPriority.Normal;
                                    DoSwapThreads.Start();
                                    DoSwapThreads.Join();
                                    Thread.Sleep(100);
                                    Completed_Mod_Work(catcher.Replace(" (Installed)", ""), node);
                                    PopulateTreeView(FullModPathMan);
                                }
                                else
                                {
                                    AddTextBoxLog(Environment.NewLine + "Can't uninstall " + catcher + " because it's empty.");
                                }
                            }
                        }
                    }
                }
                colornodes();
                ModsConflictCheck();
                treeView2.Sort();
            }
            catch (DirectoryNotFoundException)
            {
                AddTextBoxLog(Environment.NewLine + "Error: Directory for installed mod " + catcher + " not found! ");
            }
            catch (Exception eio)
            {
                AddTextBoxLog(Environment.NewLine + "Error: Could not open " + catcher + " mod" + Environment.NewLine + eio.ToString());
            }
            metroProgressBar2.Visible = false;
            metroProgressBar2.Refresh();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            catcher = "";
            metroProgressBar2.Visible = true;
            metroProgressBar2.Refresh();
            try
            {
                Thread DoSwapThreads;
                foreach (TreeNode node in treeView2.Nodes)
                {
                    if (node != null)
                    {
                        // Child support
                        if (node.Nodes.Count > 0)
                        {
                            foreach (TreeNode subnode in node.Nodes)
                            {
                                if (subnode != null)
                                {
                                    catcher = subnode.FullPath.ToString();
                                    if (subnode.Checked && !catcher.Contains("(Installed)"))
                                    {
                                        if (Directory.GetFiles(FullModPathMan + "\\" + catcher).Count() > 0)
                                        {
                                            DoSwapThreads = new Thread(() => doFileSwapV2(FullModPathMan + "\\" + catcher, true));
                                            DoSwapThreads.Priority = ThreadPriority.Normal;
                                            DoSwapThreads.Start();
                                            DoSwapThreads.Join();
                                            Thread.Sleep(100);
                                            Completed_Mod_Work(catcher + " (Installed)", subnode, true);
                                        }
                                        else
                                        {
                                            AddTextBoxLog(Environment.NewLine + "Can't install " + catcher + " because it's empty.");
                                        }
                                    }
                                }
                            }
                        }
                        if (node.Nodes.Count == 0)
                        {
                            // Parent support
                            catcher = node.FullPath.ToString();
                            if (node.Checked && !catcher.Contains("(Installed)"))
                            {
                                if (Directory.GetFiles(FullModPathMan + "\\" + catcher).Count() > 0)
                                {
                                    DoSwapThreads = new Thread(() => doFileSwapV2(FullModPathMan + "\\" + catcher, true));
                                    DoSwapThreads.Priority = ThreadPriority.Normal;
                                    DoSwapThreads.Start();
                                    DoSwapThreads.Join();
                                    Thread.Sleep(100);
                                    Completed_Mod_Work(node.Text + " (Installed)", node);
                                }
                                else
                                {
                                    AddTextBoxLog(Environment.NewLine + "Can't install " + catcher + " because it's empty.");
                                }
                            }
                            else if (node.Checked && catcher.Contains("(Installed)"))
                            {
                                AddTextBoxLog(Environment.NewLine + "Skipping: " + catcher + " (Already Installed)");
                            }
                        }
                    }
                }
                PopulateTreeView(FullModPathMan);
                colornodes();
                ModsConflictCheck();
                treeView2.Sort();
            }
            catch (DirectoryNotFoundException)
            {
                AddTextBoxLog(Environment.NewLine + "Error: Directory for installed mod " + catcher + " not found!");
            }
            catch (Exception eio)
            {
                AddTextBoxLog(Environment.NewLine + "Error: Could not open " + catcher + " mod" + Environment.NewLine + eio.ToString());
            }
            metroProgressBar2.Visible = false;
            metroProgressBar2.Refresh();
        }

        public void Completed_Mod_Work(string newtext, TreeNode toremove, bool isChild = false)
        {
            if (isChild)
            {
                if (toremove.Parent != null)
                {
                    // Child support
                    treeView2.Nodes[toremove.Parent.Index].Nodes.Add(FullModPathMan + "\\" + newtext, newtext.Split(Path.DirectorySeparatorChar).Last());
                    treeView2.Refresh();
                    treeView2.Nodes[toremove.Parent.Index].Nodes.Remove(treeView2.Nodes[toremove.Parent.Index].Nodes[toremove.Index]);
                    treeView2.Refresh();
                }
            }
            else
            {
                // Readd childs if any
                List<TreeNode> subnodes_toadd = new List<TreeNode>();
                if (toremove.Nodes.Count > 0)
                {
                    foreach (TreeNode subnode in toremove.Nodes)
                    {
                        if (subnode != null)
                        {
                            subnodes_toadd.Add(subnode);
                        }
                    }
                }
                // Parent support
                treeView2.Nodes.Add(FullModPathMan + "\\" + newtext, newtext);
                treeView2.Refresh();
                treeView2.Nodes.Remove(treeView2.Nodes[toremove.Index]);
                treeView2.Refresh();
                // Finish child nodes
                if (subnodes_toadd.Count > 0)
                {
                    treeView2.Nodes[treeView2.Nodes.IndexOfKey(FullModPathMan + "\\" + newtext)].Nodes.AddRange(subnodes_toadd.ToArray());
                }
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                treeView2.BeginUpdate();
                if (File.Exists(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\description.txt"))
                {
                    string text = File.ReadAllText(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\description.txt").ToString();
                    metroLabel40.Text = text;
                    metroButton43.Visible = true;
                }
                else
                {
                    metroLabel40.Text = "No description provided!";
                    metroButton43.Visible = false;
                }

                try
                {
                    if (File.Exists(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\preview.png"))
                    {
                        previewImage = Image.FromFile(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\preview.png");
                        metroButton42.Enabled = true;
                    }
                    else if (File.Exists(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\preview.jpg"))
                    {
                        previewImage = Image.FromFile(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\preview.jpg");
                        metroButton42.Enabled = true;
                    }
                    else if (File.Exists(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\preview.gif"))
                    {
                        previewImage = Image.FromFile(FullModPathMan + "\\" + e.Node.FullPath.ToString().Replace(" (Installed)", "") + "\\preview.gif");
                        metroButton42.Enabled = true;
                    }
                    else
                    {
                        previewImage = null;
                        metroButton42.Enabled = false;
                    }
                }
                catch
                {
                    previewImage = null;
                    metroButton42.Enabled = false;
                }

                if (e.Node.Nodes.Count > 0)
                {
                    bool tocheck = e.Node.Checked;
                    foreach (TreeNode child in e.Node.Nodes)
                    {
                        if (child != null)
                        {
                            child.Checked = tocheck;
                        }
                    }
                }
                treeView2.EndUpdate();
            }
            catch (Exception r)
            {
                metroLabel40.Text = "Error: " + r.ToString();
                metroButton43.Visible = false;
                treeView2.EndUpdate();
            }
        }

        private void PopulateTreeView(string dir)
        {
            string empty = string.Empty;
            try
            {
                string[] directories = Directory.GetDirectories(dir);
                List<string> checkfolder = new List<string>();
                foreach (string text in directories)
                {
                    string newtext = text.Replace(" (Installed)", "");
                    if (text.Length != 0)
                    {
                        // Convert to new mod manager
                        if (text.Contains(" (Installed)"))
                        {
                            try
                            {
                                Directory.Move(text, newtext);
                            }
                            catch (IOException)
                            {
                                Prompt.Popup("Error: Folder " + text + " could not be moved due to permission error." + Environment.NewLine + "Please check your antivirus settings or windows folder protection.");
                            }
                            catch (Exception eio)
                            {
                                Prompt.Popup("Error: " + eio.ToString());
                            }
                        }
                        // continue
                        if (!treeView2.Nodes.ContainsKey(newtext) && !treeView2.Nodes.ContainsKey(newtext + " (Installed)") && !checkfolder.Exists(x => x.ToString() == newtext))
                        {
                            checkfolder.Add(newtext);
                            if (Directory.Exists(modsFolderPath + "\\" + newtext.Split(Path.DirectorySeparatorChar).Last()))
                            {
                                TreeNode tmpnode = new TreeNode();
                                int CurrentlyInstalledFiles = Directory.GetFiles(modsFolderPath + "\\" + newtext.Split(Path.DirectorySeparatorChar).Last(), "*.umap").Length;
                                CurrentlyInstalledFiles += Directory.GetFiles(modsFolderPath + "\\" + newtext.Split(Path.DirectorySeparatorChar).Last(), "*.upk").Length;
                                int LocalReadyFiles = Directory.GetFiles(FullModPathMan + "\\" + newtext.Split(Path.DirectorySeparatorChar).Last(), "*.upk").Length;
                                LocalReadyFiles += Directory.GetFiles(FullModPathMan + "\\" + newtext.Split(Path.DirectorySeparatorChar).Last(), "*.umap").Length;
                                if (CurrentlyInstalledFiles > 0 && LocalReadyFiles == CurrentlyInstalledFiles)
                                {
                                    treeView2.Nodes.Add(newtext, newtext.Split(Path.DirectorySeparatorChar).Last() + " (Installed)");
                                }
                                else
                                {
                                    treeView2.Nodes.Add(newtext, newtext.Split(Path.DirectorySeparatorChar).Last());
                                }
                            }
                            else
                            {
                                treeView2.Nodes.Add(newtext, newtext.Split(Path.DirectorySeparatorChar).Last());
                            }
                        }
                        treeView2.Refresh();
                        string[] subs = Directory.GetDirectories(newtext);
                        foreach (string names in subs)
                        {
                            string newnames = names.Replace(" (Installed)", "");
                            if (names.Length != 0)
                            {
                                // Convert to new mod manager
                                if (names.Contains(" (Installed)"))
                                {
                                    Directory.Move(names, newnames);
                                }
                                // continue
                                int indexofnode = treeView2.Nodes.IndexOfKey(newtext);
                                if (!treeView2.Nodes[indexofnode].Nodes.ContainsKey(newnames) && !treeView2.Nodes[indexofnode].Nodes.ContainsKey(newnames + " (Installed)"))
                                {
                                    if (Directory.Exists(modsFolderPath + "\\" + newnames.Split(Path.DirectorySeparatorChar).Last()))
                                    {
                                        TreeNode tmpnode = new TreeNode();
                                        int CurrentlyInstalledFiles = Directory.GetFiles(modsFolderPath + "\\" + newnames.Split(Path.DirectorySeparatorChar).Last(), "*.umap").Length;
                                        CurrentlyInstalledFiles += Directory.GetFiles(modsFolderPath + "\\" + newnames.Split(Path.DirectorySeparatorChar).Last(), "*.upk").Length;
                                        int LocalReadyFiles = Directory.GetFiles(FullModPathMan + "\\" + newtext.Split(Path.DirectorySeparatorChar).Last() + "\\" + newnames.Split(Path.DirectorySeparatorChar).Last(), "*.upk").Length;
                                        LocalReadyFiles += Directory.GetFiles(FullModPathMan + "\\" + newtext.Split(Path.DirectorySeparatorChar).Last() + "\\" + newnames.Split(Path.DirectorySeparatorChar).Last(), "*.umap").Length;
                                        if (CurrentlyInstalledFiles > 0 && LocalReadyFiles == CurrentlyInstalledFiles)
                                        {
                                            treeView2.Nodes[indexofnode].Nodes.Add(newnames, newnames.Split(Path.DirectorySeparatorChar).Last() + " (Installed)");
                                        }
                                        else
                                        {
                                            treeView2.Nodes[indexofnode].Nodes.Add(newnames, newnames.Split(Path.DirectorySeparatorChar).Last());
                                        }
                                    }
                                    else
                                    {
                                        treeView2.Nodes[indexofnode].Nodes.Add(newnames, newnames.Split(Path.DirectorySeparatorChar).Last());
                                    }

                                }
                            }
                        }
                    }
                }
                colornodes();
                ModsConflictCheck();
            }
            catch (Exception ex)
            {
                Prompt.Popup(ex.ToString());
            }
        }

        public bool CheckNodeExists(string name, TreeView tree)
        {
            foreach (TreeNode node in tree.Nodes)
            {
                if (node.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        public void ModsConflictCheck()
        {
            Dictionary<string, string> ConflictLib = new Dictionary<string, string>();
            Dictionary<string, TreeNode> NodeCollection = new Dictionary<string, TreeNode>();
            // Check Installed Mods
            foreach (TreeNode FilesAt in treeView2.Nodes)
            {
                if (FilesAt != null)
                {
                    // Ini strings
                    string non_mani = "";
                    string non_path_mani = "";
                    bool skipped = false;
                    // Child support
                    if (FilesAt.Nodes.Count > 0)
                    {
                        foreach (TreeNode SubAt in FilesAt.Nodes)
                        {
                            if (SubAt != null)
                            {
                                non_mani = SubAt.Text;
                                non_path_mani = SubAt.FullPath;
                                skipped = false;
                                if (Directory.Exists(modsFolderPath + "\\" + non_mani.Replace(" (Installed)", "")))
                                {
                                    bool conflict = false;
                                    string[] tocheck = Directory.GetFiles(modsFolderPath + "\\" + non_mani.Replace(" (Installed)", ""));
                                    foreach (string tocheckname in tocheck)
                                    {
                                        string tmp = tocheckname.Split(Path.DirectorySeparatorChar).Last();
                                        if (!ConflictLib.ContainsKey(tmp))
                                        {
                                            ConflictLib.Add(tmp, non_mani);
                                            if (!NodeCollection.ContainsKey(non_mani))
                                            {
                                                NodeCollection.Add(non_mani, SubAt);
                                            }
                                        }
                                        else
                                        {
                                            if (!skipped && ConflictLib[tmp] != non_mani)
                                            {
                                                AddTextBoxLog(Environment.NewLine + "Conflicting mod: " + ConflictLib[tmp].Replace(" (Installed)", "") + " with " + non_mani.Replace(" (Installed)", ""));
                                                treeView2.Nodes[FilesAt.Index].Nodes[treeView2.Nodes[FilesAt.Index].Nodes.IndexOf(NodeCollection[ConflictLib[tmp]])].ForeColor = Color.IndianRed;
                                                SubAt.ForeColor = Color.IndianRed;
                                                skipped = true;
                                                conflict = true;
                                            }
                                        }
                                    }
                                    if (conflict == false && SubAt.ForeColor != Color.IndianRed)
                                    {
                                        SubAt.ForeColor = Color.LightGreen;
                                    }
                                }
                                treeView2.Refresh();
                            }
                        }
                    }

                    // Parent support
                    non_mani = FilesAt.Text;
                    non_path_mani = FilesAt.FullPath;
                    skipped = false;
                    if (Directory.Exists(modsFolderPath + "\\" + non_path_mani.Split(Path.DirectorySeparatorChar).Last().Replace(" (Installed)", "")))
                    {
                        bool conflict = false;
                        string[] tocheck = Directory.GetFiles(modsFolderPath + "\\" + non_path_mani.Split(Path.DirectorySeparatorChar).Last().Replace(" (Installed)", ""));
                        foreach (string tocheckname in tocheck)
                        {
                            string tmp = tocheckname.Split(Path.DirectorySeparatorChar).Last();
                            if (!ConflictLib.ContainsKey(tmp))
                            {
                                ConflictLib.Add(tmp, non_mani);
                                if (!NodeCollection.ContainsKey(non_mani))
                                {
                                    NodeCollection.Add(non_mani, FilesAt);
                                }
                            }
                            else
                            {
                                if (!skipped && ConflictLib[tmp] != non_mani)
                                {
                                    AddTextBoxLog(Environment.NewLine + "Conflicting mod: " + ConflictLib[tmp].Replace(" (Installed)", "") + " with " + non_mani.Replace(" (Installed)", ""));
                                    treeView2.Nodes[treeView2.Nodes.IndexOf(NodeCollection[ConflictLib[tmp]])].ForeColor = Color.IndianRed;
                                    FilesAt.ForeColor = Color.IndianRed;
                                    skipped = true;
                                    conflict = true;
                                }
                            }
                        }
                        if (conflict == false && FilesAt.ForeColor != Color.IndianRed)
                        {
                            FilesAt.ForeColor = Color.LightGreen;
                        }
                    }
                    treeView2.Refresh();
                }
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (FullModPathMan.Contains("\\\\"))
            {
                FullModPathMan = FullModPathMan.Replace("\\\\", "\\");
            }
            Process.Start("explorer.exe", FullModPathMan);
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            PerformClose();
        }

        public void PerformClose()
        {
            if (bw.IsBusy)
            {
                Prompt.Popup("Please do not close this application while it's installing or uninstalling mods!");
            }
            else
            {
                CleanMess();
                CleanOtherMess();
                KillApp();
            }
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            base.WindowState = FormWindowState.Minimized;
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/nebulahosts");
        }

        private void MetroButton44_Click(object sender, EventArgs e)
        {
            if (PathFound)
            {
                try
                {
                    string backuptxt = metroLabel85.Text;
                    metroLabel85.Text = "Loading Ui...";
                    metroLabel85.Refresh();
                    DialogResult result = DialogResult.Cancel;
                    Affinity affinity = new Affinity();
                    result = affinity.ShowDialog();
                    if (result != DialogResult.OK)
                    {
                        metroLabel85.Text = backuptxt;
                        lineChanger("affinityproc = " + backuptxt.Replace("Affinity: ", ""), AppPath + "\\Settings.ini", 47);
                    }
                    else
                    {
                        metroLabel85.Text = affinity.value;
                    }
                }
                catch
                {
                    AddTextLog("Could not save option!");
                }
            }
        }

        private void metroToggle20_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound)
            {
                if (metroToggle20.Checked)
                {
                    try
                    {
                        lineChanger("boostprocess = true", AppPath + "\\Settings.ini", 35);
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
                        lineChanger("boostprocess = false", AppPath + "\\Settings.ini", 35);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound)
            {
                if (metroToggle2.Checked)
                {
                    SaveLogs = true;
                    groupBox7.Enabled = true;
                    try
                    {
                        lineChanger("savelogs = true", AppPath + "\\Settings.ini", 3);
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
                        lineChanger("savelogs = false", AppPath + "\\Settings.ini", 3);
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
            if (PathFound)
            {
                if (metroToggle5.Checked)
                {
                    ShowLogs = true;
                    try
                    {
                        lineChanger("showlogs = true", AppPath + "\\Settings.ini", 4);
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
                        lineChanger("showlogs = false", AppPath + "\\Settings.ini", 4);
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
            if (PathFound)
            {
                if (metroToggle13.Checked)
                {
                    LauncherLogs = true;
                    try
                    {
                        lineChanger("launcherlogs = true", AppPath + "\\Settings.ini", 13);
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
                        lineChanger("launcherlogs = false", AppPath + "\\Settings.ini", 13);
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
            if (PathFound)
            {
                if (metroToggle13.Checked)
                {
                    ModManLogs = true;
                    try
                    {
                        lineChanger("modmanlogs = true", AppPath + "\\Settings.ini", 14);
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
                        lineChanger("modmanlogs = false", AppPath + "\\Settings.ini", 14);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void metroToggle18_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound)
            {
                if (metroToggle18.Checked)
                {
                    AutoClean = true;
                    metroButton30.Visible = false;
                    try
                    {
                        lineChanger("automemorycleanup = true", AppPath + "\\Settings.ini", 32);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    AutoClean = false;
                    metroButton30.Visible = true;
                    try
                    {
                        lineChanger("automemorycleanup = false", AppPath + "\\Settings.ini", 32);
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
            if (PathFound)
            {
                if (metroToggle6.Checked)
                {
                    metroToolTip1.Active = true;
                    try
                    {
                        lineChanger("tooltips = true", AppPath + "\\Settings.ini", 6);
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
                        lineChanger("tooltips = false", AppPath + "\\Settings.ini", 6);
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
            if (PathFound)
            {
                if (metroToggle7.Checked)
                {
                    metroLabel22.Visible = true;
                    try
                    {
                        lineChanger("variables = true", AppPath + "\\Settings.ini", 5);
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
                        lineChanger("variables = false", AppPath + "\\Settings.ini", 5);
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
            if (PathFound)
            {
                if (metroToggle8.Checked)
                {
                    try
                    {
                        lineChanger("admincheck = true", AppPath + "\\Settings.ini", 9);
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
                        lineChanger("admincheck = false", AppPath + "\\Settings.ini", 9);
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
            if (PathFound)
            {
                if (metroToggle9.Checked)
                {
                    try
                    {
                        lineChanger("ncsoftlogin = true", AppPath + "\\Settings.ini", 10);
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
                        lineChanger("ncsoftlogin = false", AppPath + "\\Settings.ini", 10);
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
            if (PathFound)
            {
                if (metroToggle10.Checked)
                {
                    metroButton12.Visible = true;
                    try
                    {
                        lineChanger("showdonate = true", AppPath + "\\Settings.ini", 11);
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
                        lineChanger("showdonate = false", AppPath + "\\Settings.ini", 11);
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
            if (PathFound)
            {
                if (metroToggle15.Checked)
                {
                    try
                    {
                        lineChanger("gamekiller = true", AppPath + "\\Settings.ini", 19);
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
                        lineChanger("gamekiller = false", AppPath + "\\Settings.ini", 19);
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
            if (PathFound)
            {
                if (metroToggle14.Checked)
                {
                    try
                    {
                        lineChanger("pingchecker = true", AppPath + "\\Settings.ini", 18);
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
                        lineChanger("pingchecker = false", AppPath + "\\Settings.ini", 18);
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
            if (PathFound)
            {
                if (metroToggle17.Checked)
                {
                    try
                    {
                        lineChanger("autoupdate = true", AppPath + "\\Settings.ini", 23);
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
                        lineChanger("autoupdate = false", AppPath + "\\Settings.ini", 23);
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
            if (PathFound)
            {
                if (metroToggle16.Checked)
                {
                    try
                    {
                        lineChanger("updatechecker = true", AppPath + "\\Settings.ini", 17);
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
                        lineChanger("updatechecker = false", AppPath + "\\Settings.ini", 17);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
            }
        }

        private void MetroToggle42_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound) // here
            {
                if (metroToggle42.Checked)
                {
                    AlwaysOnTray = true;
                    ActivateTray();
                    try
                    {
                        lineChanger("keepintray = true", AppPath + "\\Settings.ini", 48);
                    }
                    catch
                    {
                        AddTextLog("Could not save option!");
                    }
                }
                else
                {
                    AlwaysOnTray = false;
                    NotifAction();
                    try
                    {
                        lineChanger("keepintray = false", AppPath + "\\Settings.ini", 48);
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
            if (PathFound)
            {
                if (metroToggle11.Checked)
                {
                    AllowMinimize = true;
                    try
                    {
                        lineChanger("minimize = true", AppPath + "\\Settings.ini", 12);
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
                        lineChanger("minimize = false", AppPath + "\\Settings.ini", 12);
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
            if (PathFound)
            {
                if (metroToggle3.Checked)
                {
                    metroButton15.Enabled = true;
                    metroButton20.Enabled = true;
                    metroButton17.Enabled = true;
                    metroTextBox3.Enabled = true;
                }
                else
                {
                    metroButton15.Enabled = false;
                    metroButton20.Enabled = false;
                    metroButton17.Enabled = false;
                    metroTextBox3.Enabled = false;
                }
            }
        }

        private void metroToggle4_CheckedChanged(object sender, EventArgs e)
        {
            if (PathFound)
            {
                if (metroToggle4.Checked)
                {
                    metroButton16.Enabled = true;
                    metroButton19.Enabled = true;
                    metroButton18.Enabled = true;
                    metroTextBox4.Enabled = true;
                }
                else
                {
                    metroButton16.Enabled = false;
                    metroButton19.Enabled = false;
                    metroButton18.Enabled = false;
                    metroTextBox4.Enabled = false;
                }
            }
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            lineChanger("arguments = " + metroTextBox5.Text, AppPath + "\\Settings.ini", 21);
        }

        private static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            if (File.Exists(fileName))
            {
                string[] array = File.ReadAllLines(fileName);
                array[line_to_edit - 1] = newText;
                File.WriteAllLines(fileName, array);
            }
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            CustomGameSet = true;
            lineChanger("customgamepath = " + metroTextBox3.Text, AppPath + "\\Settings.ini", 16);
            lineChanger("customgame = true", AppPath + "\\Settings.ini", 7);
            RegPath = metroTextBox3.Text;
            AutoDirFinder();
            metroButton1.Enabled = true;
            PathFound = true;
            metroToggle1.Enabled = true;
            Prompt.Popup("Please Restart App If Done Configurating");
        }

        private void metroButton33_Click(object sender, EventArgs e)
        {
            if (metroTextBox7.Text.Length < 1)
            {
                Prompt.Popup("Path is incorrect");
            }
            else
            {
                CustomModSet = true;
                lineChanger("modfolder = " + metroTextBox7.Text, AppPath + "\\Settings.ini", 29);
                lineChanger("modfolderset = true", AppPath + "\\Settings.ini", 30);
                backupFolderPath = metroTextBox7.Text + "\\CookedPC_Backup";
                FullModPathMan = metroTextBox7.Text + "\\CookedPC_Mod";
                GetPath();
                Prompt.Popup("Please Restart App If Done Configurating");
            }
        }

        private void metroButton31_Click(object sender, EventArgs e)
        {
            metroToggle19.Checked = false;
            metroTextBox7.Text = "";
            CustomModSet = false;
            GetPath();
            lineChanger("modfolderset = false", AppPath + "\\Settings.ini", 30);
        }

        private void metroToggle19_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle19.Checked)
            {
                metroButton33.Enabled = true;
                metroButton31.Enabled = true;
                metroTextBox7.Enabled = true;
                metroButton29.Enabled = true;
            }
            else
            {
                metroButton33.Enabled = false;
                metroButton31.Enabled = false;
                metroTextBox7.Enabled = false;
                metroButton29.Enabled = false;
            }
        }

        private void metroButton29_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog().ToString() == "OK")
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath + "\\"))
                {
                    metroTextBox7.Text = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for a custom Mods folder. | Path: " + folderBrowserDialog.SelectedPath);
                }
            }
            else
            {
                Prompt.Popup("Error: Cancelled operation!");
                KillApp();
            }
        }

        private void RestoreGamePath()
        {
            CustomGameSet = false;
            metroTextBox3.Text = "";
            lineChanger("customgamepath = ", AppPath + "\\Settings.ini", 16);
            lineChanger("customgame = false", AppPath + "\\Settings.ini", 7);
            BnSFolder();
            CheckBackup();
            if (!CustomClientSet)
            {
                CheckServer();
            }
            VerifySettings();
            GetPaths();
            Verify();
            InitializeSplash();
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
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog().ToString() == "OK")
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath + "\\contents"))
                {
                    metroTextBox3.Text = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for BnS Folder. | Path: " + folderBrowserDialog.SelectedPath);
                }
            }
            else
            {
                Prompt.Popup("Error: Cancelled operation!");
                KillApp();
            }
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            CustomClientSet = true;
            lineChanger("customclientpath = " + metroTextBox4.Text, AppPath + "\\Settings.ini", 15);
            lineChanger("customclient = true", AppPath + "\\Settings.ini", 8);
            RegPathlol = metroTextBox4.Text;
            try
            {
                if (File.Exists(RegPathlol + "\\UserSettings.config"))
                {
                    XmlDocument document = new XmlDocument();
                    document.LoadXml(RegPathlol + "\\UserSettings.config");
                    XmlNodeList nodes = document.SelectNodes("AppSettings");
                    foreach (XmlNode node in nodes)
                    {
                        Prompt.Popup(node.Attributes.ToString());
                        XmlAttributeCollection nodeAtt = node.Attributes;
                        if (nodeAtt["key"].Value.ToString() == "SavedGames")
                        {
                            //return childNode.SelectSingleNode("key/value").InnerText;
                        }
                        else
                        {
                            //return "did not match any documents";
                        }
                    }
                }
                if (File.Exists(RegPathlol + "\\NCLauncher.ini"))
                {
                    string text2 = File.ReadAllText(RegPathlol + "\\NCLauncher.ini");
                    if (text2.Contains("Game_Region=North America") || text2.Contains("Game_Region=Nordamerika") || text2.Contains("du Nord"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("North America");
                    }
                    else if (text2.Contains("Game_Region=Europe") || text2.Contains("Game_Region=Europa") || text2.Contains("Game_Region=L'Europe"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Europe");
                    }
                    else if (text2.Contains("Game_Locale=ja"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Japanese");
                    }
                    else if (text2.Contains("up4svr.plaync.com.tw") && !text2.Contains("MXM"))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                    }
                    else if (text2.Contains("up4web.plaync.co.kr") || (text2.Contains("up4web.nclauncher.ncsoft.com") && !text2.Contains("MXM")))
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                    }
                    if (Conflict && metroComboBox2.SelectedItem.ToString() == "Korean")
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Korean");
                        if (KoreanTestInstalled)
                        {
                            metroComboBox8.SelectedIndex = metroComboBox8.FindStringExact("Test");
                        }
                    }
                    else if (Conflict && metroComboBox2.SelectedItem.ToString() == "Taiwan")
                    {
                        metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact("Taiwan");
                    }
                }
                Prompt.Popup("Please Restart App If Done Configurating");
            }
            catch (Exception ex)
            {
                AddTextLog("Error: Could Not Find NCLauncher.ini" + Environment.NewLine + ex.ToString());
            }
        }

        private void RestoreClientPath()
        {
            CustomClientSet = false;
            metroTextBox4.Text = "";
            lineChanger("customclientpath = ", AppPath + "\\Settings.ini", 15);
            lineChanger("customclient = false", AppPath + "\\Settings.ini", 8);
            if (!CustomClientSet)
            {
                CheckServer();
            }
            VerifySettings();
            GetPaths();
            Verify();
            InitializeSplash();
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
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog().ToString() == "OK")
            {
                if (Directory.Exists(folderBrowserDialog.SelectedPath + "\\Download") || File.Exists(folderBrowserDialog.SelectedPath + "\\Matryoshka.exe"))
                {
                    metroTextBox4.Text = folderBrowserDialog.SelectedPath;
                }
                else
                {
                    Prompt.Popup("Error: Invalid Path! Browse for NCLauncher Folder. | Path: " + folderBrowserDialog.SelectedPath);
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
            try
            {
                if (File.Exists(AppPath + "\\Settings.ini"))
                {
                    File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                }
                if (!File.Exists(AppPath + "\\Settings.ini"))
                {
                    File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                }
                StartupBuddy();
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
            if (AppStarted)
            {
                lineChanger("prtime = " + metroTrackBar1.Value.ToString(), AppPath + "\\Settings.ini", 22);
                wakeywakey = metroTrackBar1.Value;
                metroLabel47.Text = metroTrackBar1.Value.ToString();
                metroLabel47.Refresh();
            }
        }

        private void metroComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                lineChanger("cleanint = " + metroComboBox7.Text.ToString(), AppPath + "\\Settings.ini", 36);
                if (metroComboBox7.Text.ToString() != "OFF")
                {
                    CleanerVal = Convert.ToInt32(metroComboBox7.Text.ToString());
                }
            }
        }

        private void metroComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox4.SelectedItem != null)
            {
                defaultclient = metroComboBox4.SelectedItem.ToString();
                if ((defaultclient == "64bit" && Directory.Exists(RegPath + LauncherPath64)) || (defaultclient == "32bit" && Directory.Exists(RegPath + LauncherPath)))
                {
                    if (defaultclient == "64bit" && !is64bit)
                    {
                        Prompt.Popup("Can't set an unsupported Client archetype because your system is 32bit!");
                        metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact("32bit");
                        metroComboBox4.Items.Remove("64bit");
                        defaultclient = "";
                    }
                    else
                    {
                        lineChanger("defaultclient = " + defaultclient, AppPath + "\\Settings.ini", 27);
                    }
                }
                else
                {
                    if (AppStarted)
                    {
                        Prompt.Popup("Error: Path to " + defaultclient + " does not exist.");
                    }
                    if (defaultclient == "32bit")
                    {
                        metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact("64bit");
                        metroComboBox4.Items.Remove("32bit");
                        metroRadioButton2.Checked = true;
                        metroRadioButton1.Enabled = false;
                        defaultclient = "";
                    }
                    else
                    {
                        metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact("32bit");
                        metroComboBox4.Items.Remove("64bit");
                        metroRadioButton1.Checked = true;
                        metroRadioButton2.Enabled = false;
                        defaultclient = "";
                    }
                }
                if (metroComboBox4.SelectedIndex == metroComboBox4.FindStringExact("64bit"))
                {
                    metroRadioButton1.Checked = false;
                    metroRadioButton2.Checked = true;
                }
                else
                {
                    metroRadioButton2.Checked = false;
                    metroRadioButton1.Checked = true;
                }
            }
        }

        public void RestoreDefault()
        {
            if (metroLabel48.Text != "None")
            {
                try
                {
                    lineChanger("defaultset = false", AppPath + "\\Settings.ini", 26);
                    lineChanger("default = ", AppPath + "\\Settings.ini", 25);
                    metroLabel48.Text = "None";
                    MultipleInstallationFound = false;
                }
                catch
                {
                    AddTextLog("Error: Could not restore default to none!");
                }
            }
        }

        private void metroLabel48_Click(object sender, EventArgs e)
        {
            if (metroLabel48.Text != "None")
            {
                RestoreDefault();
            }
            StartupBuddy();
        }

        public void InitializeAddons()
        {
            AddonPaths();
            GenerateAddons();
            treeView3.Sort();
        }

        public void RestoreAddons()
        {
            filesToEdit = new Dictionary<string, Dictionary<string, string[]>>();
            treeView3.Visible = false;
            metroLabel63.Visible = true;
            metroLabel64.Visible = true;
            metroLabel53.Visible = true;
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node != null && node.Checked)
                {
                    StartPatching(node.FullPath + ".patch", undo: true);
                }
            }
            foreach (KeyValuePair<string, Dictionary<string, string[]>> item in filesToEdit)
            {
                Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();
                foreach (KeyValuePair<string, string[]> item2 in item.Value)
                {
                    if (item2.Value[0] != item2.Value[1])
                    {
                        dictionary.Add(item2.Key.ToLower(), Encoding.UTF8.GetBytes(item2.Value[1]));
                    }
                }
                if (dictionary.Count() > 0)
                {
                    AddTextLog("Compiling " + item.Key);
                    new BNSDat.BNSDat().CompressFiles(Path.Combine(DataPath, item.Key), dictionary, item.Key.Contains("64")); // first (full path to .dat) // second (dictionary to replace) // if .dat contains 64
                    AddTextLog("Compiled.");
                }
                else
                {
                    AddTextLog("Skipped " + item.Key);
                }
            }
            foreach (TreeNode node2 in treeView3.Nodes)
            {
                if (node2 != null && node2.Checked)
                {
                    node2.Checked = false;
                }
            }
            treeView3.Visible = true;
            metroLabel53.Visible = false;
            metroLabel63.Visible = false;
            metroLabel64.Visible = false;
        }

        public void AddonPaths()
        {
            FullAddonPath = AppPath + "\\addons\\";
            string path = DataPath + "\\addons\\";
            if (!Directory.Exists(FullAddonPath))
            {
                CreatePaths(FullAddonPath);
            }
            if (Directory.Exists(path))
            {
                try
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (string text in files)
                    {
                        string str = text.Split(Path.DirectorySeparatorChar).Last();
                        if (text.Length != 0)
                        {
                            if (File.Exists(FullAddonPath + "\\" + str))
                            {
                                File.Delete(FullAddonPath + "\\" + str);
                            }
                            File.Move(text, FullAddonPath + "\\" + str);
                        }
                    }
                }
                catch
                {
                    Prompt.Popup("Error: Could not transfer addons to new path!");
                }
                try
                {
                    if (Directory.GetFiles(path).Length != 0)
                    {
                        Directory.Delete(path);
                    }
                }
                catch
                {
                    Prompt.Popup("Error: Could not delete old addon path!");
                }
            }
        }

        public void GenerateAddons()
        {
            string[] files = Directory.GetFiles(FullAddonPath);
            foreach (string text in files)
            {
                string text2 = text.Split(Path.DirectorySeparatorChar).Last();
                if (text.Length != 0 && text2.EndsWith(".patch"))
                {
                    string text3 = text2.Replace(".patch", "");
                    if (checkNode3(text3))
                    {
                        TreeNode node = new TreeNode(text3);
                        treeView3.Nodes.Add(node);
                    }
                }
            }
        }

        public void StartGameAddons()
        {
            filesToEdit = new Dictionary<string, Dictionary<string, string[]>>();
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node != null && node.Checked)
                {
                    StartPatching(node.FullPath + ".patch", undo: false);
                }
            }
            foreach (KeyValuePair<string, Dictionary<string, string[]>> item in filesToEdit)
            {
                Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();
                foreach (KeyValuePair<string, string[]> item2 in item.Value)
                {
                    if (item2.Value[0] != item2.Value[1])
                    {
                        dictionary.Add(item2.Key.ToLower(), Encoding.UTF8.GetBytes(item2.Value[1]));
                    }
                }
                if (dictionary.Count() > 0)
                {
                    AddTextLog("Compiling " + item.Key);
                    new BNSDat.BNSDat().CompressFiles(Path.Combine(DataPath, item.Key), dictionary, item.Key.Contains("64"));
                    AddTextLog("Compiled.");
                }
                else
                {
                    AddTextLog("Skipped " + item.Key);
                }
            }
            foreach (TreeNode node2 in treeView3.Nodes)
            {
                if (node2 != null && node2.Checked)
                {
                    node2.Checked = false;
                }
            }
        }

        public bool checkNode3(string s)
        {
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node != null && node.FullPath.ToString() == s)
                {
                    return false;
                }
            }
            return true;
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 form = new Form3();
            form.Visible = false;
            form.ShowDialog();
            Show();
            base.WindowState = FormWindowState.Normal;
        }

        private void metroButton28_Click(object sender, EventArgs e)
        {
            RestoreAddons();
        }

        public void StartPatching(string filename, bool undo)
        {
            if (!File.Exists(FullAddonPath + "\\" + filename))
            {
                Prompt.Popup(String.Format("Skipping Addon: {0} no longer exists in the folder", filename.Replace(".patch", "")));
                return;
            }

            Search = new Dictionary<int, string>();
            Replace = new Dictionary<int, string>();
            int num = File.ReadAllLines(FullAddonPath + "\\" + filename).Count();
            if (Debugging)
            {
                Prompt.Popup(num.ToString());
            }
            if (num == 4)
            {
                string text = File.ReadLines(FullAddonPath + "\\" + filename).Skip(0).Take(1)
                    .First()
                    .Replace("FileName = ", "");
                string text2;
                string text3;
                try
                {
                    string[] array = text.Replace("\\\\", "\\").Split(new char[1]
                    {
                    '\\'
                    }, 2);
                    text2 = array[0].Replace(".files", "").Trim();
                    text3 = array[1].ToLower().Trim();
                    if (metroRadioButton1.Checked || metroRadioButton2.Checked)
                    {
                        if (!text2.Contains("[bit]"))
                        {
                            AddTextLog(string.Format("Skipped addon: {0} because it did not contain [bit] to support both 32 & 64 bit files", filename.Replace(".patch", "")));
                            return;
                        }
                        text2 = (metroRadioButton2.Checked ? text2.Replace("[bit]", "64") : text2.Replace("[bit]", ""));
                    }
                    else
                    {
                        AddTextLog(string.Format("Skipped addon: {0} because no bitness was selected", filename.Replace(".patch", "")));
                        return;
                    }
                }
                catch
                {
                    AddTextLog(string.Format("Skipped addon: {0} because FileName field was incorrectly formatted", filename.Replace(".patch", "")));
                    return;
                }
                if (Debugging)
                {
                    Prompt.Popup("File to patch: " + text3);
                }
                if (!filesToEdit.ContainsKey(text2) || !filesToEdit[text2].ContainsKey(text3))
                {
                    BNSDat.BNSDat bNSDat = new BNSDat.BNSDat();
                    string text4 = Path.Combine(DataPath, text2);
                    if (!File.Exists(text4))
                    {
                        AddTextLog(string.Format("Skipped addon: {0} because the file {1} is missing", filename.Replace(".patch", ""), text2));
                        return;
                    }
                    Dictionary<string, byte[]> dictionary;
                    try
                    {
                        dictionary = bNSDat.ExtractFile(text4, new List<string>
                        {
                            text3
                        }, text2.Contains("64"));
                    } catch {
                        AddTextLog(string.Format("Error: file {2} is damaged/corrupted. Please do a file repair then try again", filename.Replace(".patch", ""), text3, text2));
                        return;
                    }
                    if (dictionary.Count <= 0)
                    {
                        AddTextLog(string.Format("Skipped addon: {0} because the file {1} was not found in {2}", filename.Replace(".patch", ""), text3, text2));
                        return;
                    }
                    foreach (KeyValuePair<string, byte[]> item in dictionary)
                    {
                        if (filesToEdit.ContainsKey(text2))
                        {
                            Dictionary<string, string[]> dictionary2 = filesToEdit[text2];
                            string @string = Encoding.UTF8.GetString(item.Value);
                            dictionary2.Add(item.Key.ToLower(), new string[2]
                            {
                            @string,
                            @string
                            });
                            filesToEdit[text2] = dictionary2;
                        }
                        else
                        {
                            Dictionary<string, string[]> dictionary3 = new Dictionary<string, string[]>();
                            string string2 = Encoding.UTF8.GetString(item.Value);
                            dictionary3.Add(item.Key.ToLower(), new string[2]
                            {
                            string2,
                            string2
                            });
                            filesToEdit.Add(text2, dictionary3);
                        }
                    }
                }
                string text5 = File.ReadLines(FullAddonPath + "\\" + filename).Skip(1).Take(1)
                    .First()
                    .Replace("Search = ", "");
                if (Debugging)
                {
                    Prompt.Popup("String to search: " + text5);
                }
                string text6 = File.ReadLines(FullAddonPath + "\\" + filename).Skip(2).Take(1)
                    .First()
                    .Replace("Replace = ", "");
                if (Debugging)
                {
                    Prompt.Popup("String to replace: " + text6);
                }
                string text7 = filesToEdit[text2][text3][1];
                if (Debugging)
                {
                    Prompt.Popup(text7);
                }
                string text8 = undo ? text6 : text5;
                string newValue = undo ? text5 : text6;
                if (text7.Contains(text8))
                {
                    string text9 = text7.Replace(text8, newValue);
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        string string3 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                        string text10 = text9;
                        if (text10.StartsWith(string3))
                        {
                            text10 = text10.Remove(0, string3.Length);
                        }
                        xmlDocument.LoadXml(text10);
                        filesToEdit[text2][text3][1] = text9;
                    }
                    catch (Exception ex)
                    {
                        if (Debugging)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        AddTextLog(string.Format("Restored {2}: {0} because the file {1} was invalid after replacing the text", filename.Replace(".patch", ""), text3, undo ? "addon" : "file"));
                        return;
                    }
                    AddTextLog(string.Format("{0} Addon: {1}", undo ? "Reverted" : "Applied", filename.Replace(".patch", "")));
                }
                else
                {
                    AddTextLog("Addon: " + filename.Replace(".patch", "") + " couldn't be applied!");
                    AddTextLog(string.Format("Maybe already {0}?", undo ? "reverted" : "applied"));
                }
            }
            else if (num > 4)
            {
                string text11 = File.ReadLines(FullAddonPath + "\\" + filename).Skip(0).Take(1)
                    .First()
                    .Replace("FileName = ", "");
                string text12;
                string text13;
                try
                {
                    string[] array2 = text11.Replace("\\\\", "\\").Split(new char[1]
                    {
                    '\\'
                    }, 2);
                    text12 = array2[0].Replace(".files", "").Trim();
                    text13 = array2[1].ToLower().Trim();
                    if (metroRadioButton1.Checked || metroRadioButton2.Checked)
                    {
                        if (!text12.Contains("[bit]"))
                        {
                            AddTextLog(string.Format("Skipped addon: {0} because it did not contain [bit] to support both 32 & 64 bit files", filename.Replace(".patch", "")));
                            return;
                        }
                        text12 = (metroRadioButton2.Checked ? text12.Replace("[bit]", "64") : text12.Replace("[bit]", ""));
                    }
                    else
                    {
                        AddTextLog(string.Format("Skipped addon: {0} because no bitness was selected", filename.Replace(".patch", "")));
                        return;
                    }
                }
                catch
                {
                    AddTextLog(string.Format("Skipped addon: {0} because FileName field was incorrectly formatted", filename.Replace(".patch", "")));
                    return;
                }
                if (Debugging)
                {
                    Prompt.Popup("File to patch: " + text13);
                }
                if (!filesToEdit.ContainsKey(text12) || !filesToEdit[text12].ContainsKey(text13))
                {
                    BNSDat.BNSDat bNSDat2 = new BNSDat.BNSDat();
                    string text14 = Path.Combine(DataPath, text12);
                    if (!File.Exists(text14))
                    {
                        AddTextLog(string.Format("Skipped addon: {0} because the file {1} is missing", filename.Replace(".patch", ""), text12));
                        return;
                    }
                    Dictionary<string, byte[]> dictionary4 = bNSDat2.ExtractFile(text14, new List<string> { text13 }, text12.Contains("64"));
                    if (dictionary4.Count <= 0)
                    {
                        AddTextLog(string.Format("Skipped addon: {0} because the file {1} was not found in {2}", filename.Replace(".patch", ""), text13, text12));
                        return;
                    }
                    foreach (KeyValuePair<string, byte[]> item2 in dictionary4)
                    {
                        if (filesToEdit.ContainsKey(text12))
                        {
                            Dictionary<string, string[]> dictionary5 = filesToEdit[text12];
                            string string4 = Encoding.UTF8.GetString(item2.Value);
                            dictionary5.Add(item2.Key.ToLower(), new string[2]
                            {
                            string4,
                            string4
                            });
                            filesToEdit[text12] = dictionary5;
                        }
                        else
                        {
                            Dictionary<string, string[]> dictionary6 = new Dictionary<string, string[]>();
                            string string5 = Encoding.UTF8.GetString(item2.Value);
                            dictionary6.Add(item2.Key.ToLower(), new string[2]
                            {
                            string5,
                            string5
                            });
                            filesToEdit.Add(text12, dictionary6);
                        }
                    }
                }
                int num2 = 0;
                int num3 = 0;
                IEnumerable<string> enumerable = File.ReadLines(FullAddonPath + "\\" + filename);
                foreach (string item3 in enumerable)
                {
                    if (item3.Contains("Search = "))
                    {
                        string value = item3.Replace("Search = ", "");
                        if (undo)
                        {
                            Replace.Add(num2, value);
                        }
                        else
                        {
                            Search.Add(num2, value);
                        }
                        num2++;
                    }
                }
                foreach (string item4 in enumerable)
                {
                    if (item4.Contains("Replace = "))
                    {
                        string value2 = item4.Replace("Replace = ", "");
                        if (undo)
                        {
                            Search.Add(num3, value2);
                        }
                        else
                        {
                            Replace.Add(num3, value2);
                        }
                        num3++;
                    }
                }
                if (num2 == num3)
                {
                    string text15 = filesToEdit[text12][text13][1];
                    if (Debugging)
                    {
                        Prompt.Popup("Full Text: " + text15);
                    }
                    for (int i = 0; num2 > i; i++)
                    {
                        if (Debugging)
                        {
                            Prompt.Popup("Before: " + text15);
                        }
                        if (Search.ContainsKey(i))
                        {
                            if (text15.Contains(Search[i]))
                            {
                                text15 = text15.Replace(Search[i], Replace[i]);
                                AddTextLog("Patched: " + (i + 1) + "/" + Replace.Count);
                                if (Debugging)
                                {
                                    Prompt.Popup("After: " + text15);
                                }
                            }
                            else
                            {
                                AddTextLog("Error: Could not find " + (i + 1) + "/" + Replace.Count);
                                AddTextLog(string.Format("Maybe already {0}?", undo ? "reverted" : "applied"));
                            }
                        }
                    }
                    if (text15 != filesToEdit[text12][text13][1])
                    {
                        try
                        {
                            XmlDocument xmlDocument2 = new XmlDocument();
                            string string6 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                            string text16 = text15;
                            if (text16.StartsWith(string6))
                            {
                                text16 = text16.Remove(0, string6.Length);
                            }
                            xmlDocument2.LoadXml(text16);
                            filesToEdit[text12][text13][1] = text15;
                        }
                        catch
                        {
                            AddTextLog(string.Format("Restored {2}: {0} because the file {1} was invalid after replacing the text", filename.Replace(".patch", ""), text13, undo ? "addon" : "file"));
                            return;
                        }
                    }
                    AddTextLog(string.Format("{0} Addon: {1}", undo ? "Reverted" : "Applied", filename.Replace(".patch", "")));
                }
                else if (num2 > num3)
                {
                    Prompt.Popup("Missing Replacements found. Please check your patches");
                }
                else if (num2 < num3)
                {
                    Prompt.Popup("Missing Finds found. Please check your patches");
                }
            }
            else
            {
                Prompt.Popup("Error: The following patch " + filename + " does not meet the requirements.");
            }
        }

        public void RefreshAddons()
        {
            GenerateAddons();
            CheckAddonsPaths();
            treeView3.Sort();
        }

        public void CheckAddonsPaths()
        {
            ClearCV3 = true;
            treeView3.SelectedNode = null;
            int count = treeView3.Nodes.Count;
            int num = 0;
            foreach (TreeNode node in treeView3.Nodes)
            {
                if (node != null)
                {
                    string str = node.FullPath + ".patch";
                    if (!File.Exists(FullAddonPath + "\\" + str))
                    {
                        node.Remove();
                    }
                }
            }
            num = treeView3.Nodes.Count;
            ClearCV3 = false;
            if (count != num)
            {
                CheckAddonsPaths();
            }
        }

        private void metroButton25_Click(object sender, EventArgs e)
        {
            if (FullAddonPath.Contains("\\\\"))
            {
                FullAddonPath = FullAddonPath.Replace("\\\\", "\\");
            }
            Process.Start("explorer.exe", FullAddonPath);
        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
            RefreshAddons();
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                int num = 0;
                foreach (TreeNode node in treeView3.Nodes)
                {
                    if (node != null && node.Checked)
                    {
                        num++;
                    }
                }
                if (treeView3.Nodes.Count == num && num != 0)
                {
                    metroCheckBox4.Checked = true;
                    metroCheckBox4.CheckState = CheckState.Checked;
                }
                else if (treeView3.Nodes.Count > num && num == 0)
                {
                    metroCheckBox4.Checked = false;
                    metroCheckBox4.CheckState = CheckState.Unchecked;
                }
                if (!presschk)
                {
                    if (treeView3.Nodes.Count > num && num > 0)
                    {
                        metroCheckBox4.CheckState = CheckState.Indeterminate;
                    }
                }
                else
                {
                    presschk = false;
                }
                if (!ClearCV3)
                {
                    string text = "";
                    string str = e.Node.FullPath.ToString() + ".patch";
                    foreach (string item in File.ReadLines(FullAddonPath + "\\" + str))
                    {
                        if (item.Contains("Description = "))
                        {
                            text = item.Replace("Description = ", "");
                        }
                    }
                    if (text.Length > 0)
                    {
                        metroTextBox6.Text = text;
                    }
                    else
                    {
                        metroTextBox6.Text = "No description provided!";
                    }
                }
            }
            catch
            {
                metroTextBox6.Text = "No description provided!";
            }
        }

        public void CreateDatPaths()
        {
            if (!Directory.Exists(DataPath + "\\editing\\backup"))
            {
                CreatePaths(DataPath + "\\editing\\backup");
            }
        }

        private void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            TreeNode treeNode = addInMe.Add(directoryInfo.Name);
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in files)
            {
                treeNode.Nodes.Add(fileInfo.FullName, fileInfo.Name);
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directoryInfo2 in directories)
            {
                BuildTree(directoryInfo2, treeNode.Nodes);
            }
        }

        string nametofile = "";
        TreeNode LastNode = null;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (!e.Node.Name.EndsWith(".bin") && e.Node.Name.Contains("."))
                {
                    treeView1.Enabled = false;
                    metroLabel39.Text = "Loading...";
                    metroLabel39.Refresh();
                    fastColoredTextBox1.Clear();
                    nametofile = e.Node.FullPath.Replace(ActiveDataFile + "\\", "");
                    BNSDat.BNSDat bNSDat = new BNSDat.BNSDat();
                    Dictionary<string, byte[]> dictionary = bNSDat.ExtractFile(myDictionary[ActiveDataFile] + "\\" + ActiveDataFile, new List<string>
                    {
                        nametofile
                    }, ActiveDataFile.Contains("64"));
                    var bytes = dictionary[nametofile];
                    fastColoredTextBox1.Text = System.Text.Encoding.UTF8.GetString(bytes);
                    metroLabel39.Text = "Done!";
                    metroLabel39.Refresh();
                    treeView1.Enabled = true;
                    e.Node.BackColor = ColorTranslator.FromHtml("#3399FF");
                    if (LastNode != null)
                    {
                        LastNode.BackColor = ColorTranslator.FromHtml("#111111");
                    }
                    LastNode = e.Node;
                }
            }
            catch
            {
                metroLabel39.Text = "Error: Could not open file";
            }
        }

        private TreeNode PopulateTreeNode2(string[] paths)
        {
            string pathSeparator = "\\";
            TreeNode thisnode = new TreeNode();
            TreeNode currentnode = null;
            char[] cachedpathseparator = pathSeparator.ToCharArray();
            for (int i = 0; i < paths.Length; i++)
            {
                currentnode = thisnode;
                foreach (string subPath in paths[i].Split(cachedpathseparator))
                {
                    if (null == currentnode.Nodes[subPath])
                        currentnode = currentnode.Nodes.Add(subPath, subPath);
                    else
                        currentnode = currentnode.Nodes[subPath];
                }
            }
            return thisnode;
        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString().Contains(".dat") && myDictionary[metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString()].Length > 0)
            {
                try
                {
                    metroComboBox3.Enabled = false;
                    fastColoredTextBox1.Clear();
                    metroLabel39.Text = "Loading...";
                    metroLabel39.Refresh();
                    ActiveDataFile = metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString();
                    string str = myDictionary[ActiveDataFile];
                    treeView1.Nodes.Clear();
                    if (ActiveDataFile.Contains("64")) { BNSis64 = true; } else { BNSis64 = false; }
                    BNSDat.BNSDat testingpur = new BNSDat.BNSDat();
                    string[] test = testingpur.GetFileList(str + "\\" + ActiveDataFile, BNSis64);
                    treeView1.Nodes.Add(PopulateTreeNode2(test));
                    treeView1.Nodes[0].Text = ActiveDataFile;
                    treeView1.Nodes[0].Expand();
                    //treeView1.AfterSelect += treeView1_AfterSelect;
                    treeView1.Enabled = true;
                    metroLabel39.Text = "Loaded list!";
                    metroLabel39.Refresh();
                    metroComboBox3.Enabled = true;
                }
                catch
                {
                    metroLabel39.Text = "Corrupted file!";
                    metroComboBox3.Enabled = true;
                    metroLabel39.Refresh();
                    Prompt.Popup("Error: The file " + ActiveDataFile + " is corrupted! Please do a file repair using NCLauncher.");
                }
            }
            else if (metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString() == "Select a File")
            {
                fastColoredTextBox1.Clear();
                treeView1.Nodes.Clear();
            }
        }

        private void fctb_TextChanged(object sender, TextChangedEventArgs e)
        {
            HTMLSyntaxHighlight(fastColoredTextBox1.VisibleRange);
        }

        private void fctb_VisibilityChanged(object sender, EventArgs e)
        {
            HTMLSyntaxHighlight(fastColoredTextBox1.VisibleRange);
        }

        private void HTMLSyntaxHighlight(Range range)
        {
            range.ClearStyle(BlueStyle, MaroonStyle, RedStyle, GreenStyle);
            range.SetStyle(MaroonStyle, "<|/>|</|>");
            range.SetStyle(MaroonStyle, "<(?<range>[!\\w]+)");
            range.SetStyle(MaroonStyle, "</(?<range>\\w+)>");
            range.SetStyle(RedStyle, "(?<range>\\S+?)='[^']*'|(?<range>\\S+)=\"[^\"]*\"|(?<range>\\S+)=\\S+");
            range.SetStyle(BlueStyle, "\\S+?=(?<range>'[^']*')|\\S+=(?<range>\"[^\"]*\")|\\S+=(?<range>\\S+)");
            range.SetStyle(GreenStyle, "<!--(?<range>\\S+?)-->");
        }

        private void findCTRLFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void findReplaceCTRLRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private bool CheckXmlTypos()
        {
            metroLabel39.Text = "Checking typos...";
            metroLabel39.Refresh();
            if (fastColoredTextBox1.Text.Contains("<!-- "))
            {
                fastColoredTextBox1.Text.Replace("<!-- ", "<!--");
            }
            if (fastColoredTextBox1.Text.Contains(" -->"))
            {
                fastColoredTextBox1.Text.Replace(" -->", "-->");
            }
            // Fix 0xfeff at start instead of reading string as is
            byte[] encodedString = Encoding.UTF8.GetBytes(fastColoredTextBox1.Text);
            MemoryStream ms = new MemoryStream(encodedString);
            ms.Flush();
            ms.Position = 0;
            //
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.Load(ms);
                ms.Close();
            }
            catch
            {
                ms.Close();
                metroLabel39.Text = "Invalid xml!";
                metroLabel39.Refresh();
                return false;
            }
            xmlDocument = new XmlDocument();
            return true;
        }

        public void bw2_Save(object Sender, DoWorkEventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.FullPath.ToString().Contains(".dat"))
            {
                if (CheckXmlTypos())
                {
                    metroLabel39.Text = "Saving " + nametofile + "...";
                    metroLabel39.Refresh();
                    Dictionary<string, byte[]> newdatatosave = new Dictionary<string, byte[]>();
                    var addinv2 = System.Text.Encoding.UTF8.GetBytes(fastColoredTextBox1.Text);
                    newdatatosave.Add(nametofile, addinv2);
                    new BNSDat.BNSDat().CompressFiles(myDictionary[ActiveDataFile] + "\\" + ActiveDataFile, newdatatosave, ActiveDataFile.Contains("64"));
                    metroLabel39.Text = "Saved.";
                    metroLabel39.Refresh();
                }
            }
        }

        SaveFileDialog SaveAs = new SaveFileDialog();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.FullPath.ToString().Contains(".dat"))
            {
                if (CheckXmlTypos())
                {
                    metroLabel39.Text = "Saving as xml... ";
                    metroLabel39.Refresh();

                    SaveAs.FileName = nametofile;
                    SaveAs.Filter = "xml files (*.xml)|*.xml";
                    SaveAs.DefaultExt = "xml";
                    SaveAs.Title = "Save as XML";
                    SaveAs.RestoreDirectory = true;
                    SaveAs.InitialDirectory = AppPath;
                    DialogResult result = SaveAs.ShowDialog();
                    if (result == DialogResult.Cancel || result == DialogResult.Abort)
                    {
                        metroLabel39.Text = "Cancelled!";
                        metroLabel39.Refresh();
                    }
                    else if (result == DialogResult.OK)
                    {
                        File.WriteAllText(SaveAs.FileName, fastColoredTextBox1.Text);
                        metroLabel39.Text = "Saved.";
                        metroLabel39.Refresh();
                    }
                    SaveAs = new SaveFileDialog();
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (metroComboBox3.Items[metroComboBox3.SelectedIndex].ToString() != "Select a File" && treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Text.Contains(".xml") || treeView1.SelectedNode.Text.Contains(".x16"))
                {
                    fastColoredTextBox1.Text = FormatXml(fastColoredTextBox1.Text);
                }
            }
            else { Prompt.Popup("No file selected."); }
        }

        string FormatXml(string xml)
        {
            string result = xml;
            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();
            MemoryStream ms = new MemoryStream();
            try
            {
                // Load the XmlDocument with the XML.
                byte[] encodedString = Encoding.UTF8.GetBytes(fastColoredTextBox1.Text);
                ms = new MemoryStream(encodedString);
                ms.Flush();
                ms.Position = 0;
                document.Load(ms);
                writer.Formatting = Formatting.Indented;
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();
                mStream.Position = 0;
                StreamReader sReader = new StreamReader(mStream);
                string formattedXml = sReader.ReadToEnd();
                result = formattedXml;
                metroLabel39.Text = "Formatted";
                metroLabel39.Refresh();
            }
            catch (XmlException)
            {
                metroLabel39.Text = "Can't format!";
                metroLabel39.Refresh();
            }
            mStream.Close();
            writer.Close();
            ms.Close();
            return result;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bw2 = new BackgroundWorker();
            bw2.WorkerSupportsCancellation = true;
            bw2.WorkerReportsProgress = true;
            bw2.DoWork += bw2_Save;
            if (!bw2.IsBusy)
            {
                bw2.RunWorkerAsync();
            }
            else
            {
                Prompt.Popup("Please wait until saving is finished.");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.Enabled = false;
            try
            {
                FileInfo[] files = new DirectoryInfo(DataPath).GetFiles("*.dat");
                foreach (FileInfo fileInfo in files)
                {
                    if (fileInfo.ToString().EndsWith(".dat") && myDictionary[fileInfo.ToString()].Length > 0)
                    {
                        string str = fileInfo.ToString();
                        string str2 = myDictionary[str];
                        File.Copy(str2 + "\\" + str, str2 + "\\editing\\backup\\" + str, overwrite: true);
                        metroLabel39.Text = "Backed Up Data Files";
                        toolStripButton5.Enabled = true;
                    }
                }
            }
            catch
            {
                Prompt.Popup("Error: Could not backup!");
            }
        }

        /*
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                toolStripButton2.Enabled = false;
                if (ActiveDataFile != "" && myDictionary[ActiveDataFile].Length > 0)
                {
                    string str = myDictionary[ActiveDataFile];
                    usedfile = ActiveDataFile;
                    usedfilepath = str + "\\" + ActiveDataFile;
                    if (!Directory.Exists(usedfilepath + "\\" + usedfile + ".files"))
                    {
                        metroLabel39.Text = "Decompiling data file...";
                        Extractor(usedfile);
                    }
                    treeView1.Nodes.Clear();
                    if (Directory.Exists(str + "\\" + ActiveDataFile + ".files"))
                    {
                        if (!Directory.Exists(str + "\\editing\\" + ActiveDataFile + ".files"))
                        {
                            Directory.Move(str + "\\" + ActiveDataFile + ".files", str + "\\editing\\" + ActiveDataFile + ".files");
                        }
                        else
                        {
                            string path = str + "\\" + ActiveDataFile + ".files";
                            string path2 = str + "\\editing\\" + ActiveDataFile + ".files";
                            foreach (string item in Directory.EnumerateFiles(path))
                            {
                                string destFileName = Path.Combine(path2, Path.GetFileName(item));
                                File.Copy(item, destFileName, overwrite: true);
                                File.Delete(item);
                            }
                            foreach (string item2 in Directory.EnumerateDirectories(path))
                            {
                                string destDirName = Path.Combine(path2, Path.GetFileName(item2));
                                Directory.Move(item2, destDirName);
                            }
                            Directory.Delete(path);
                        }
                        DirectoryInfo directoryInfo = new DirectoryInfo(str + "\\editing\\" + ActiveDataFile + ".files\\");
                        if (directoryInfo.Exists)
                        {
                            treeView1.AfterSelect += treeView1_AfterSelect;
                            BuildTree(directoryInfo, treeView1.Nodes);
                            treeView1.Nodes[0].Expand();
                        }
                        else
                        {
                            metroLabel39.Text = "Error: could not move folder!";
                        }
                    }
                    else
                    {
                        metroLabel39.Text = "Error: " + ActiveDataFile + " could not be extracted!";
                    }
                }
            }
            else
            {
                Prompt.Popup("Game is Running! Operation Cancelled.");
            }
        }
        */
        /*
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!GameStarted)
            {
                toolStripButton3.Enabled = false;
                if (ActiveDataFile != "" && myDictionary[ActiveDataFile].Length > 0)
                {
                    string str = myDictionary[ActiveDataFile];
                    usedfile = ActiveDataFile;
                    usedfilepathonly = str + "\\editing\\" + ActiveDataFile + ".files";
                    if (Directory.Exists(usedfilepathonly))
                    {
                        metroLabel39.Text = "Compiling data file...";
                        Compiler(usedfile);
                        toolStripButton4.Enabled = true;
                    }
                }
            }
            else
            {
                Prompt.Popup("Game is Running! Operation Cancelled.");
            }
        }
        */

        /*
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            toolStripButton4.Enabled = false;
            if (ActiveDataFile != "" && myDictionary[ActiveDataFile].Length > 0)
            {
                string str = myDictionary[ActiveDataFile];
                if (File.Exists(str + "\\editing\\" + ActiveDataFile))
                {
                    NewDat = str + "\\editing\\" + ActiveDataFile;
                    try
                    {
                        File.Copy(NewDat, str + "\\" + ActiveDataFile, overwrite: true);
                        metroLabel39.Text = "Patched " + ActiveDataFile;
                    }
                    catch
                    {
                        Prompt.Popup("Error: Could not apply patch!");
                    }
                }
                else
                {
                    Prompt.Popup("Please Compile");
                }
            }
            toolStripButton4.Enabled = true;
        }
        */

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStripButton5.Enabled = false;
            if (Prompt.RestoreConfigAsk() == DialogResult.Yes && ActiveDataFile != "" && myDictionary[ActiveDataFile].Length > 0)
            {
                string str = myDictionary[ActiveDataFile];
                try
                {
                    File.Copy(str + "\\editing\\backup\\" + ActiveDataFile, str + "\\" + ActiveDataFile, overwrite: true);
                    metroLabel39.Text = "Restored " + ActiveDataFile;
                }
                catch
                {
                    metroLabel39.Text = "Error: Could not restore " + ActiveDataFile + "!";
                }
            }
            toolStripButton5.Enabled = true;
        }

        private void DefaultDatValues()
        {
            if (metroComboBox3.Items.Count > 1)
            {
                metroComboBox3.Items.Clear();
            }
            if (myDictionary.Count > 0)
            {
                myDictionary = new Dictionary<string, string>();
            }
            string text = "";
            string text2 = "";
            if (Directory.Exists(DataPath))
            {
                FileInfo[] files = new DirectoryInfo(DataPath).GetFiles("*.dat");
                foreach (FileInfo fileInfo in files)
                {
                    if (fileInfo != null)
                    {
                        text = fileInfo.ToString();
                        text2 = Path.GetDirectoryName(fileInfo.FullName);
                        text2.Replace("\\\\", "\\");
                        if (!myDictionary.ContainsKey(fileInfo.Name))
                        {
                            myDictionary.Add(fileInfo.Name, text2);
                            metroComboBox3.Items.Add(text);
                        }
                    }
                }
            }
            fh_lang = modsFolderPath.Replace("\\CookedPC\\mod", "\\data");
            if (Directory.Exists(fh_lang))
            {
                FileInfo[] files = new DirectoryInfo(fh_lang).GetFiles("*.dat");
                foreach (FileInfo fileInfo in files)
                {
                    if (fileInfo != null)
                    {
                        text = fileInfo.ToString();
                        text2 = Path.GetDirectoryName(fileInfo.FullName);
                        text2.Replace("\\\\", "\\");
                        if (!myDictionary.ContainsKey(fileInfo.Name))
                        {
                            myDictionary.Add(fileInfo.Name, text2);
                            metroComboBox3.Items.Add(text);
                        }
                    }
                }
            }
            if (metroComboBox3.Items.Count > 0)
            {
                metroComboBox3.SelectedIndex = 0;
            }
            base.KeyPreview = true;
        }

        public void SortOutputHandler(string value)
        {
            metroLabel39.Text = value;
            metroLabel39.Refresh();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Prompt.Popup("1: Backup your config files by pressing \"Backup\"" + Environment.NewLine + "2: Select your file to work on from the drop down" + Environment.NewLine + "3: Select the file to edit in the tree then modify it with the TextBox on the right" + Environment.NewLine + "4: Save the modifications made by pressing \"Save\"" + Environment.NewLine + "Tip: Restoring your config files can be done by pressing \"Restore\"");
        }

        public class MyRenderer : ToolStripRenderer
        {
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = Color.White;
                base.OnRenderArrow(e);
            }

        }

        public void CleanMess()
        {
            string text = "";
            try
            {
                if (Directory.Exists(DataPath + "\\editing"))
                {
                    AddTextLog("Cleaning Mess");
                    DirectoryInfo[] directories = new DirectoryInfo(DataPath + "\\editing").GetDirectories();
                    for (int i = 0; i < directories.Length; i++)
                    {
                        string directoryName = Path.GetDirectoryName(directories[i].ToString());
                        if (!directoryName.Contains("backup"))
                        {
                            text = directoryName;
                            if (Directory.GetFiles(DataPath + "\\editing\\" + text).Length != 0)
                            {
                                Array.ForEach(Directory.GetFiles(DataPath + "\\editing\\" + text), File.Delete);
                            }
                            Directory.Delete(DataPath + "\\editing\\" + text, recursive: true);
                            AddTextLog("Cleaned " + text);
                        }
                    }
                    try
                    {
                        if (Directory.Exists(DataPath + "\\editing\\"))
                        {
                            Array.ForEach(Directory.GetFiles(DataPath + "\\editing\\"), File.Delete);
                            AddTextLog("Cleaned up editing folder");
                        }
                    }
                    catch (Exception ex)
                    {
                        AddTextLog("Could not remove file -> " + ex.ToString());
                    }
                }
                else
                {
                    AddTextLog("Mess Already Cleaned");
                }
            }
            catch
            {
                AddTextLog("Could not remove folder -> " + DataPath + "\\editing\\" + text);
            }
        }

        public void GrabToken()
        {
            bool flag = false;
            if (metroComboBox1.SelectedItem != null)
            {
                if (regions.Count != 0 && RegionCB.Items.Count == 0)
                {
                    AddTextLog("Attempting to fix server selection");
                    RegionCB.DataSource = regions;
                    if (RegionCB.Items.Count == 0)
                    {
                        AddTextLog("Failed");
                        AddTextLog("Attempting a second method");
                        for (int i = 0; regions.Count > i; i++)
                        {
                            RegionCB.Items.Add(regions[i]);
                        }
                    }
                    AddTextLog("Proceeding...");
                }
                string a = metroComboBox1.SelectedItem.ToString();
                if (a == "North America" || a == "Europe")
                {
                    if (RegionCB.Items.Count > 1)
                    {
                        if (metroComboBox1.SelectedIndex == metroComboBox1.FindStringExact("North America"))
                        {
                            RegionCB.SelectedIndex = (RegionCB.Items.Contains("North America") ? RegionCB.FindStringExact("North America") : RegionCB.FindStringExact("na"));
                            if (Debugging)
                            {
                                Prompt.Popup("Using North America");
                            }
                        }
                        else
                        {
                            RegionCB.SelectedIndex = (RegionCB.Items.Contains("Europe") ? RegionCB.FindStringExact("Europe") : RegionCB.FindStringExact("eu"));
                            if (Debugging)
                            {
                                Prompt.Popup("Using Europe");
                            }
                        }
                    }
                    else if (RegionCB.Items.Count == 1)
                    {
                        RegionCB.SelectedIndex = 0;
                        if (Debugging)
                        {
                            Prompt.Popup("Using " + RegionCB.SelectedItem.ToString());
                        }
                    }
                    else
                    {
                        Prompt.Popup("Error: No available servers were found for NA/EU!");
                        flag = true;
                    }
                }
            }
            termConnection();
            if (!flag)
            {
                if (metroComboBox1.SelectedItem != null)
                {
                    switch (metroComboBox1.SelectedItem.ToString())
                    {
                        case "North America":
                        case "Europe":
                            currentAppId = ((region)RegionCB.SelectedValue).appId;
                            currentValue = ((region)RegionCB.SelectedValue).value;
                            break;
                        case "Korean":
                            if (metroComboBox8.SelectedItem.ToString() == "Live")
                            {
                                currentAppId = "B0D42105-0CB6-BC9F-3CB2-BE28A0662340";
                            }
                            else
                            {
                                currentAppId = "18A2B067-7A7E-DA99-CDF1-3BBE3BE93F68";
                            }
                            break;
                        case "Taiwan":
                            currentAppId = "33BC338F-2651-8ECD-9E2A-444843707997";
                            break;
                    }
                }
                else
                {
                    metroComboBox1.SelectedIndex = 0;
                    switch (metroComboBox1.SelectedItem.ToString())
                    {
                        case "North America":
                        case "Europe":
                            currentAppId = ((region)RegionCB.SelectedValue).appId;
                            currentValue = ((region)RegionCB.SelectedValue).value;
                            break;
                        case "Korean":
                            if (metroComboBox8.SelectedItem.ToString() == "Live")
                            {
                                currentAppId = "B0D42105-0CB6-BC9F-3CB2-BE28A0662340";
                            }
                            else
                            {
                                currentAppId = "18A2B067-7A7E-DA99-CDF1-3BBE3BE93F68";
                            }
                            break;
                        case "Taiwan":
                            currentAppId = "33BC338F-2651-8ECD-9E2A-444843707997";
                            break;
                    }
                }
                try
                {
                    encStart = false;
                    key = null;
                    epoch = ((long)(DateTime.UtcNow - new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString();
                    pid = Process.GetCurrentProcess().Id.ToString();
                    privateKey = new BigInteger(sha.ComputeHash(BigInteger.genRandom(6).getBytes()));
                    exchangeKey = Two;
                    counter = 0;
                    responseHandler = new Dictionary<int, string[]>();
                    LoginServer = new TcpClient(LoginIp, LoginPort);
                    LoginServer.ReceiveBufferSize = 1024;
                    ns = LoginServer.GetStream();
                    ns.ReadTimeout = 60000;
                    ns.ReadTimeout = 60000;
                    keepAliveBw = new BackgroundWorker();
                    keepAliveBw.WorkerSupportsCancellation = true;
                    keepAliveBw.DoWork += keepAlive;
                    keepAliveBw.RunWorkerAsync();
                    worker = new BackgroundWorker();
                    worker.WorkerSupportsCancellation = true;
                    worker.DoWork += receivePackets;
                    worker.RunWorkerAsync();
                    string text = Builder("Sts", "Connect");
                    ns.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
                    text = Builder("Auth", "LoginStart");
                    ns.Write(Encoding.ASCII.GetBytes(text), 0, text.Length);
                }
                catch (Exception ex)
                {
                    Prompt.Popup(ex.ToString());
                    Prompt.Popup("Error: Could not create Session Key!");
                }
            }
            else
            {
                AddTextLog("Error: Login Failed, servers are not reachable!");
            }
        }

        public void termConnection()
        {
            if (LoginServer != null && LoginServer.Connected)
            {
                LoginServer.Close();
            }
            if (worker != null && worker.IsBusy)
            {
                worker.CancelAsync();
            }
            if (keepAliveBw != null && keepAliveBw.IsBusy)
            {
                keepAliveBw.CancelAsync();
            }
        }

        public List<string> GetServerValues(string Server, string Service)
        {
            List<string> returnedValues = new List<string>();
            if (Service == "Version")
            {
                if (Server == "Korean")
                {
                    returnedValues.Add("up4svr.plaync.co.kr");
                    if (metroComboBox8.SelectedItem.ToString() == "Live")
                    {
                        returnedValues.Add("BNS_KOR"); /* launcher version check: ncLauncherS */ // here
                    }
                    else
                    {
                        returnedValues.Add("BNS_KOR_TEST");
                    }
                }
                else if (Server == "North America" || Server == "Europe")
                {
                    returnedValues.Add("updater.nclauncher.ncsoft.com");
                    returnedValues.Add("BnS");
                }
                else if (Server == "Taiwan")
                {
                    returnedValues.Add("up4svr.plaync.com.tw");
                    returnedValues.Add("TWBNS22"); /* launcher version check: ncLauncherS */
                }
                else if (Server == "Japanese")
                {
                    returnedValues.Add("BnSUpdate.ncsoft.jp");
                    returnedValues.Add("BNS_JPN");
                }
                else
                {
                    returnedValues.Add("updater.nclauncher.ncsoft.com");
                    returnedValues.Add("BnS");
                }
                return returnedValues;
            }
            else if (Service == "Login")
            {
                if (Server == "Korean")
                {
                    returnedValues.Add("up4svr.plaync.co.kr");
                    if (metroComboBox8.SelectedItem.ToString() == "Live")
                    {
                        returnedValues.Add("ncLauncherS"); /* launcher version check: ncLauncherS */ // here
                    }
                    else
                    {
                        returnedValues.Add("ncLauncherS");
                    }
                }
                else if (Server == "North America" || Server == "Europe")
                {
                    returnedValues.Add("updater.nclauncher.ncsoft.com");
                    returnedValues.Add("BnS");
                }
                else if (Server == "Taiwan")
                {
                    returnedValues.Add("up4svr.plaync.com.tw");
                    returnedValues.Add("ncLauncherS"); /* launcher version check: ncLauncherS */
                }
                else if (Server == "Japanese")
                {
                    returnedValues.Add("BnSUpdate.ncsoft.jp");
                    returnedValues.Add("ncLauncher");
                }
                else
                {
                    returnedValues.Add("updater.nclauncher.ncsoft.com");
                    returnedValues.Add("ncLauncherS");
                }
                return returnedValues;
            }
            else
            {
                return returnedValues = null;
            }
        }

        private bool LauncherInfo()
        {
            metroButton1.Enabled = false;
            string a = metroComboBox1.SelectedItem.ToString();
            string text = GetServerValues(a, "Login")[0];
            string text2 = GetServerValues(a, "Login")[1];
            try
            {
                #region maintenace check
                int port = 27500;
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write((short)0);
                binaryWriter.Write((short)4);
                binaryWriter.Write((byte)10);
                binaryWriter.Write((byte)text2.Length);
                binaryWriter.Write(Encoding.ASCII.GetBytes(text2));
                binaryWriter.BaseStream.Position = 0L;
                binaryWriter.Write((short)memoryStream.Length);
                NetworkStream stream = new TcpClient(text, port).GetStream();
                stream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                binaryWriter.Close();
                memoryStream.Close();
                memoryStream = new MemoryStream();
                BinaryReader binaryReader = new BinaryReader(memoryStream);
                byte[] array = new byte[1024];
                int num = 0;
                do
                {
                    num = stream.Read(array, 0, array.Length);
                    if (num > 0)
                    {
                        memoryStream.Write(array, 0, num);
                    }
                }
                while (num == array.Length);
                memoryStream.Position = 9L;
                binaryReader.ReadBytes(binaryReader.ReadByte() + 1);
                bool flag = binaryReader.ReadBoolean();
                stream.Close();
                binaryReader.Close();
                memoryStream.Close();
                if (!flag && !Debugging)
                {
                    Prompt.Popup("The Game Server is currently in maintenance, please try again later.");
                    Maintenance = true;
                    metroButton1.Enabled = true;
                    return false;
                }
                Maintenance = false;
            }
            catch (Exception ex)
            {
                Prompt.Popup("There was an error connecting to the Login Server, please make sure your ip isn't blocked.");
                if (Debugging)
                {
                    Prompt.Popup(ex.ToString());
                }
                metroButton1.Enabled = true;
                return false;
            }
            #endregion
            #region Version Check
            int Version = 0;
            text = GetServerValues(a, "Version")[0];
            text2 = GetServerValues(a, "Version")[1];
            try
            {
                int port = 27500;
                MemoryStream memoryStream = new MemoryStream();
                BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                binaryWriter.Write((short)0);
                binaryWriter.Write((short)6);
                binaryWriter.Write((byte)10);
                binaryWriter.Write((byte)text2.Length);
                binaryWriter.Write(Encoding.ASCII.GetBytes(text2));
                binaryWriter.BaseStream.Position = 0L;
                binaryWriter.Write((short)memoryStream.Length);
                NetworkStream stream = new TcpClient(text, port).GetStream();
                stream.Write(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                binaryWriter.Close();
                memoryStream.Close();
                memoryStream = new MemoryStream();
                BinaryReader binaryReader = new BinaryReader(memoryStream);
                byte[] array = new byte[1024];
                int num = 0;
                do
                {
                    num = stream.Read(array, 0, array.Length);
                    if (num > 0)
                    {
                        memoryStream.Write(array, 0, num);
                    }
                }
                while (num == array.Length);
                memoryStream.Position = 9L;
                binaryReader.ReadBytes(binaryReader.ReadByte() + 5);
                Version = binaryReader.ReadByte();
                if (binaryReader.ReadInt16() != 40)
                {
                    memoryStream.Position -= 2;
                    Version += 128 * (binaryReader.ReadByte() - 1);
                }
                stream.Close();
                binaryReader.Close();
                memoryStream.Close();
            }
            catch (Exception ex)
            {
                Prompt.Popup("There was an error connecting to the Login Server, please make sure your ip isn't blocked.");
                if (Debugging)
                {
                    Prompt.Popup(ex.ToString());
                }
                metroButton1.Enabled = true;
                return false;
            }
            try
            {
                string localVersion = "0";
                string text3 = RegPath + "\\VersionInfo_" + text2 + ".ini";
                // string fix
                text3 = text3.Replace(@"\\", @"\");
                // end fix
                if (File.Exists(text3))
                {
                    foreach (string s in File.ReadAllLines(text3))
                    {
                        if (s.Contains("="))
                        {
                            string[] vp = s.Split('=');
                            if (vp[0].ToLower().Trim() == "globalversion")
                            {
                                localVersion = vp[1].Trim();
                            }
                        }
                    }
                }
                if (Version != 0)
                {
                    AddTextLog("Online Version: " + Version);
                }
                if (localVersion != "0")
                {
                    AddTextLog("Local Version: " + localVersion);
                }
                if (Version > int.Parse(localVersion))
                {
                    if (localVersion != "0")
                    {
                        //Prompt.Popup(Version + " | " + localVersion + " | " + text3);
                        Prompt.Popup("Game client update available! Please use nclauncher to update the client.");
                        AddTextLog("Client update available!");
                    }
                    else
                    {
                        Prompt.Popup("Game Client not installed/updated completely.");
                    }
                }
                else
                {
                    AddTextLog("Client up to date.");
                }
            }
            catch (Exception ex2)
            {
                Prompt.Popup("Error: Could not compare online version and local one!");
                if (Debugging)
                {
                    Prompt.Popup(RegPath + "VersionInfo_" + text2 + ".ini" + Environment.NewLine + ex2.ToString());
                }
                metroButton1.Enabled = true;
                return false;
            }
            #endregion
            #region Available regions

            if (a == "Japanese")
            {
                metroButton1.Enabled = true;
                return true;
            }

            AddTextLog("Adding available servers...");
            text = GetServerValues(a, "Login")[0];
            text2 = GetServerValues(a, "Login")[1];
            try
            {
                int port2 = 27500;
                MemoryStream memoryStream2 = new MemoryStream();
                BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
                binaryWriter2.Write((short)0);
                binaryWriter2.Write((short)8);
                binaryWriter2.Write((byte)10);
                binaryWriter2.Write((byte)text2.Length);
                binaryWriter2.Write(Encoding.ASCII.GetBytes(text2));
                binaryWriter2.BaseStream.Position = 0L;
                binaryWriter2.Write((short)memoryStream2.Length);
                TcpClient tcpClient = new TcpClient(text, port2);
                localIP = ((IPEndPoint)tcpClient.Client.LocalEndPoint).Address.ToString();
                outsideIP = new WebClient().DownloadString("https://ipv4bot.whatismyipaddress.com/");
                NetworkStream stream2 = tcpClient.GetStream();
                stream2.Write(memoryStream2.ToArray(), 0, (int)memoryStream2.Length);
                binaryWriter2.Close();
                memoryStream2.Close();
                memoryStream2 = new MemoryStream();
                BinaryReader binaryReader2 = new BinaryReader(memoryStream2);
                byte[] array2 = new byte[1024];
                int num2 = 0;
                do
                {
                    num2 = stream2.Read(array2, 0, array2.Length);
                    if (num2 > 0)
                    {
                        memoryStream2.Write(array2, 0, num2);
                    }
                }
                while (num2 == array2.Length);
                memoryStream2.Position = 9L;
                binaryReader2.ReadBytes(binaryReader2.ReadByte() + 1);
                string @string = Encoding.UTF8.GetString(binaryReader2.ReadBytes(binaryReader2.ReadByte() + 128 * (binaryReader2.ReadByte() - 1)));
                stream2.Close();
                binaryReader2.Close();
                memoryStream2.Close();
                @string = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<Settings>" + @string.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>", "").Replace("  ", "\r\n") + "\r\n</Settings>";
                LoginId = Regex.Match(@string, "id=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                LoginIp = Regex.Match(@string, "ip=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                LoginPort = int.Parse(Regex.Match(@string, "port=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value);
                LoginProgramid = Regex.Match(@string, "programid=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                if (a != "North America" && a != "Europe")
                {
                    LoginAppid = Regex.Match(@string, "appid=\"([^\"]*)\"", RegexOptions.IgnoreCase).Groups[1].Value;
                }
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(@string);
                if (a == "North America" || a == "Europe")
                {
                    foreach (XmlElement item in xmlDocument.SelectNodes("//region"))
                    {
                        regions.Add(new region(item.Attributes["name"].Value, item.Attributes["value"].Value, item.Attributes["appid"].Value));
                    }
                }
            }
            catch (Exception ex2)
            {
                Prompt.Popup("There was an error connecting to the Login Server, please make sure there isn't a maintenance.");
                if (Debugging)
                {
                    Prompt.Popup(ex2.ToString());
                }
                metroButton1.Enabled = true;
                return false;
            }
            #endregion
            metroButton1.Enabled = true;
            AddTextLog("Added");
            return true;
        }

        private void SetUniqueKey()
        {
            if (!uniquekeyset)
            {
                string str = StringToHex(Environment.GetEnvironmentVariable("COMPUTERNAME").ToString());
                string str2 = StringToHex((from nic in NetworkInterface.GetAllNetworkInterfaces()
                                           where nic.OperationalStatus == OperationalStatus.Up
                                           select nic.GetPhysicalAddress().ToString()).FirstOrDefault().ToString());
                uniquekey = str + str2;
                uniquekeyset = true;
            }
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

        private void metroTextBox8_Click(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                lineChanger("uniquepass = " + metroTextBox8.Text, AppPath + "\\Settings.ini", 37);
                metroTextBox8.Refresh();
                if (metroTextBox8.Text == uniquekey && metroTabControl1.TabPages.Count >= 9)
                {
                    metroTabControl1.TabPages.RemoveByKey("Ads");
                }
            }
            if (metroTextBox8.Text == uniquekey)
            {
                metroTile12.Visible = false;
            }
            else
            {
                metroTile12.Visible = true;
            }
        }

        private void metroComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox9.SelectedItem != null && metroComboBox9.SelectedItem.ToString() == "New Instance")
            {
                PlayGame(pressed: false);
            }
        }

        private void metroToggle22_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (metroToggle22.Checked)
                {
                    if (Directory.Exists(RegPath + LauncherPath))
                    {
                        try
                        {
                            File.WriteAllBytes(RegPath + LauncherPath + "\\winmm.dll", Resources.winmm_32);
                            metroLabel81.Text = "Active";
                        }
                        catch
                        {
                            Prompt.Popup("Error: Could not apply winmm.dll to \"" + RegPath + LauncherPath + "\"!");
                        }
                    }
                    else
                    {
                        metroLabel81.Text = "-";
                    }
                    if (Directory.Exists(RegPath + LauncherPath64))
                    {
                        try
                        {
                            File.WriteAllBytes(RegPath + LauncherPath64 + "\\winmm.dll", Resources.winmm_64);
                            metroLabel82.Text = "Active";
                        }
                        catch
                        {
                            Prompt.Popup("Error: Could not apply winmm.dll to \"" + RegPath + LauncherPath64 + "\"!");
                        }
                    }
                    else
                    {
                        metroLabel82.Text = "-";
                    }
                    if (metroLabel81.Text == "Active" || metroLabel82.Text == "Active")
                    {
                        metroToggle25.Enabled = false;
                    }
                }
                else
                {
                    if (metroLabel81.Text == "Active")
                    {
                        try
                        {
                            File.Delete(RegPath + LauncherPath + "\\winmm.dll");
                            metroLabel81.Text = "Inactive";
                        }
                        catch
                        {
                            Prompt.Popup("Error: Could not remove winmm.dll from \"" + RegPath + LauncherPath + "\"!");
                        }
                    }
                    if (metroLabel82.Text == "Active")
                    {
                        try
                        {
                            File.Delete(RegPath + LauncherPath64 + "\\winmm.dll");
                            metroLabel82.Text = "Inactive";
                        }
                        catch
                        {
                            Prompt.Popup("Error: Could not remove winmm.dll from \"" + RegPath + LauncherPath64 + "\"!");
                        }
                    }
                    if (metroLabel81.Text == "Inactive" && metroLabel82.Text == "Inactive")
                    {
                        metroToggle25.Enabled = true;
                    }
                }
            }
        }

        private void metroToggle21_CheckedChanged(object sender, EventArgs e)
        {
            groupBox17.Enabled = false;
            if (AppStarted)
            {
                if (metroToggle21.Checked)
                {
                    lineChanger("gcdshow = true", AppPath + "\\Settings.ini", 38);
                    metroLabel72.Visible = true;
                    metroLabel73.Visible = true;
                }
                else
                {
                    lineChanger("gcdshow = false", AppPath + "\\Settings.ini", 38);
                    metroLabel72.Visible = false;
                    metroLabel73.Visible = false;
                }
                metroLabel72.Refresh();
                metroLabel73.Refresh();
            }
            groupBox17.Enabled = true;
        }

        private void metroToggle24_CheckedChanged(object sender, EventArgs e)
        {
            groupBox17.Enabled = false;
            if (AppStarted)
            {
                if (metroToggle24.Checked)
                {
                    lineChanger("igpshow = true", AppPath + "\\Settings.ini", 39);
                    metroLabel70.Visible = true;
                    metroLabel71.Visible = true;
                }
                else
                {
                    lineChanger("igpshow = false", AppPath + "\\Settings.ini", 39);
                    metroLabel70.Visible = false;
                    metroLabel71.Visible = false;
                }
                metroLabel70.Refresh();
                metroLabel71.Refresh();
            }
            groupBox17.Enabled = true;
        }

        private void metroToggle25_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (metroToggle25.Checked)
                {
                    lineChanger("autologin = true", AppPath + "\\Settings.ini", 40);
                }
                else
                {
                    lineChanger("autologin = false", AppPath + "\\Settings.ini", 40);
                }
            }
        }

        private void metroToggle28_Click(object sender, EventArgs e)
        {
            if (metroToggle28.Checked)
            {
                lineChanger("rememberme = true", AppPath + "\\Settings.ini", 31);
            }
            else
            {
                lineChanger("rememberme = false", AppPath + "\\Settings.ini", 31);
            }
        }

        private void metroTextBox9_Click(object sender, EventArgs e)
        {
            customclientname = metroTextBox9.Text;
            lineChanger("customclientname = " + metroTextBox9.Text, AppPath + "\\Settings.ini", 43);
        }

        private void metroToggle26_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle26.Checked)
            {
                lineChanger("usercountcheck = true", AppPath + "\\Settings.ini", 41);
                UserCountCheck = true;
                manualcount = true;
                Task.Delay(500).ContinueWith(delegate
                {
                    Get_Count();
                });
            }
            else
            {
                lineChanger("usercountcheck = false", AppPath + "\\Settings.ini", 41);
                UserCountCheck = false;
                manualcount = true;
                Task.Delay(500).ContinueWith(delegate
                {
                    Get_Count();
                });
            }
        }

        private void metroToggle27_CheckedChanged(object sender, EventArgs e)
        {
            if (!metroToggle27.Checked)
            {
                lineChanger("showcount = true", AppPath + "\\Settings.ini", 42);
                metroLabel94.Visible = true;
                metroLabel93.Visible = true;
            }
            else
            {
                lineChanger("showcount = false", AppPath + "\\Settings.ini", 42);
                metroLabel94.Visible = false;
                metroLabel93.Visible = false;
            }
        }

        private void metroLabel94_Click(object sender, EventArgs e)
        {
            manualcount = true;
            if (!cooldown.Enabled)
            {
                cooldown.Enabled = true;
                cooldown.Interval = 5000;
                cooldown.Tick += Cooldown_Tick;
                Task.Delay(500).ContinueWith(delegate
                {
                    Get_Count();
                });
                AddTextLog("[LOG] Refreshed Count");
            }
            else
            {
                AddTextLog("[LOG] On Cooldown");
            }
        }

        private void Cooldown_Tick1(object sender, EventArgs e)
        {
            cooldown1.Enabled = false;
        }

        private void Cooldown_Tick(object sender, EventArgs e)
        {
            cooldown.Enabled = false;
        }

        private void metroComboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                metroTile3.UseCustomForeColor = false;
                metroTile4.UseCustomForeColor = false;
                metroTile5.UseCustomForeColor = false;
                metroTile6.UseCustomForeColor = false;
                metroTile7.UseCustomForeColor = false;
                metroTile8.UseCustomForeColor = false;
                metroTile9.UseCustomForeColor = false;
                metroTile10.UseCustomForeColor = false;
                metroTile11.UseCustomForeColor = false;
                metroTile12.UseCustomForeColor = false;
                metroTile13.UseCustomForeColor = false;
                metroTile3.UseCustomBackColor = false;
                metroTile4.UseCustomBackColor = false;
                metroTile5.UseCustomBackColor = false;
                metroTile6.UseCustomBackColor = false;
                metroTile7.UseCustomBackColor = false;
                metroTile8.UseCustomBackColor = false;
                metroTile9.UseCustomBackColor = false;
                metroTile10.UseCustomBackColor = false;
                metroTile11.UseCustomBackColor = false;
                metroTile12.UseCustomBackColor = false;
                metroTile13.UseCustomBackColor = false;

                metroComboBox1.Theme = MetroThemeStyle.Dark;
                metroComboBox2.Theme = MetroThemeStyle.Dark;
                metroComboBox3.Theme = MetroThemeStyle.Dark;
                metroComboBox4.Theme = MetroThemeStyle.Dark;
                metroComboBox5.Theme = MetroThemeStyle.Dark;
                metroComboBox6.Theme = MetroThemeStyle.Dark;
                metroComboBox7.Theme = MetroThemeStyle.Dark;
                metroComboBox8.Theme = MetroThemeStyle.Dark;
                metroComboBox9.Theme = MetroThemeStyle.Dark;
                metroComboBox11.Theme = MetroThemeStyle.Dark;


                if (metroComboBox11.SelectedItem.ToString() == "Black")
                {
                    Themer.Style = MetroColorStyle.Black;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Red")
                {
                    Themer.Style = MetroColorStyle.Red;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Purple")
                {
                    Themer.Style = MetroColorStyle.Purple;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Pink")
                {
                    Themer.Style = MetroColorStyle.Pink;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Orange")
                {
                    Themer.Style = MetroColorStyle.Orange;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Magenta")
                {
                    Themer.Style = MetroColorStyle.Magenta;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Lime")
                {
                    Themer.Style = MetroColorStyle.Lime;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Green")
                {
                    Themer.Style = MetroColorStyle.Green;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Default")
                {
                    Themer.Style = MetroColorStyle.Blue;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Brown")
                {
                    Themer.Style = MetroColorStyle.Brown;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Blue")
                {
                    Themer.Style = MetroColorStyle.Blue;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Silver")
                {
                    Themer.Style = MetroColorStyle.Silver;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Teal")
                {
                    Themer.Style = MetroColorStyle.Teal;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "White")
                {
                    Themer.Style = MetroColorStyle.White;
                    metroTile3.UseCustomForeColor = true;
                    metroTile4.UseCustomForeColor = true;
                    metroTile5.UseCustomForeColor = true;
                    metroTile6.UseCustomForeColor = true;
                    metroTile7.UseCustomForeColor = true;
                    metroTile8.UseCustomForeColor = true;
                    metroTile9.UseCustomForeColor = true;
                    metroTile10.UseCustomForeColor = true;
                    metroTile11.UseCustomForeColor = true;
                    metroTile12.UseCustomForeColor = true;
                    metroTile13.UseCustomForeColor = true;
                    metroTile3.UseCustomBackColor = true;
                    metroTile4.UseCustomBackColor = true;
                    metroTile5.UseCustomBackColor = true;
                    metroTile6.UseCustomBackColor = true;
                    metroTile7.UseCustomBackColor = true;
                    metroTile8.UseCustomBackColor = true;
                    metroTile9.UseCustomBackColor = true;
                    metroTile10.UseCustomBackColor = true;
                    metroTile11.UseCustomBackColor = true;
                    metroTile12.UseCustomBackColor = true;
                    metroTile13.UseCustomBackColor = true;
                }
                else if (metroComboBox11.SelectedItem.ToString() == "Yellow")
                {
                    Themer.Style = MetroColorStyle.Yellow;
                }

                metroComboBox1.Style = Themer.Style;
                metroComboBox2.Style = Themer.Style;
                metroComboBox3.Style = Themer.Style;
                metroComboBox4.Style = Themer.Style;
                metroComboBox5.Style = Themer.Style;
                metroComboBox6.Style = Themer.Style;
                metroComboBox7.Style = Themer.Style;
                metroComboBox8.Style = Themer.Style;
                metroComboBox9.Style = Themer.Style;
                metroComboBox11.Style = Themer.Style;

                if (Themer.Style == MetroColorStyle.White)
                {
                    metroComboBox1.Style = MetroColorStyle.Silver;
                    metroComboBox2.Style = MetroColorStyle.Silver;
                    metroComboBox3.Style = MetroColorStyle.Silver;
                    metroComboBox4.Style = MetroColorStyle.Silver;
                    metroComboBox5.Style = MetroColorStyle.Silver;
                    metroComboBox6.Style = MetroColorStyle.Silver;
                    metroComboBox7.Style = MetroColorStyle.Silver;
                    metroComboBox8.Style = MetroColorStyle.Silver;
                    metroComboBox9.Style = MetroColorStyle.Silver;
                    metroComboBox11.Style = MetroColorStyle.Silver;

                    metroComboBox1.Theme = MetroThemeStyle.Light;
                    metroComboBox2.Theme = MetroThemeStyle.Light;
                    metroComboBox3.Theme = MetroThemeStyle.Light;
                    metroComboBox4.Theme = MetroThemeStyle.Light;
                    metroComboBox5.Theme = MetroThemeStyle.Light;
                    metroComboBox6.Theme = MetroThemeStyle.Light;
                    metroComboBox7.Theme = MetroThemeStyle.Light;
                    metroComboBox8.Theme = MetroThemeStyle.Light;
                    metroComboBox9.Theme = MetroThemeStyle.Light;
                    metroComboBox11.Theme = MetroThemeStyle.Light;
                }

                lineChanger("buddycolor = " + Themer.Style.ToString(), AppPath + "\\Settings.ini", 44);
                metroToolTip1.Style = Themer.Style;
                metroToolTip1.Theme = MetroThemeStyle.Dark;
                base.Style = Themer.Style;
                Refresh();
                Prompt.ColorSet = Themer.Style;
                metroTile3.Style = Prompt.ColorSet;
                metroTile4.Style = Prompt.ColorSet;
                metroTile5.Style = Prompt.ColorSet;
                metroTile6.Style = Prompt.ColorSet;
                metroTile7.Style = Prompt.ColorSet;
                metroTile8.Style = Prompt.ColorSet;
                metroTile9.Style = Prompt.ColorSet;
                metroTile10.Style = Prompt.ColorSet;
                metroTile11.Style = Prompt.ColorSet;
                metroTile12.Style = Prompt.ColorSet;
                metroTile13.Style = Prompt.ColorSet;
                if (metroTabControl1.SelectedTab.ToString().Contains("Launcher"))
                {
                    metroTile3.Enabled = false;
                    metroTile3.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile3.UseCustomForeColor = false;
                        metroTile3.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Dat Editor"))
                {
                    metroTile4.Enabled = false;
                    metroTile4.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile4.UseCustomForeColor = false;
                        metroTile4.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Mod Manager"))
                {
                    metroTile5.Enabled = false;
                    metroTile5.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile5.UseCustomForeColor = false;
                        metroTile5.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Splash Changer"))
                {
                    metroTile9.Enabled = false;
                    metroTile9.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile9.UseCustomForeColor = false;
                        metroTile9.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Addons"))
                {
                    metroTile8.Enabled = false;
                    metroTile8.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile8.UseCustomForeColor = false;
                        metroTile8.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Settings"))
                {
                    metroTile6.Enabled = false;
                    metroTile6.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile6.UseCustomForeColor = false;
                        metroTile6.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Donators"))
                {
                    metroTile11.Enabled = false;
                    metroTile11.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile11.UseCustomForeColor = false;
                        metroTile11.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("About"))
                {
                    metroTile10.Enabled = false;
                    metroTile10.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile10.UseCustomForeColor = false;
                        metroTile10.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Extras"))
                {
                    metroTile7.Enabled = false;
                    metroTile7.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile7.UseCustomForeColor = false;
                        metroTile7.UseCustomBackColor = false;
                    }
                }
                if (metroTabControl1.SelectedTab.ToString().Contains("Ads"))
                {
                    metroTile12.Enabled = false;
                    metroTile12.Style = MetroColorStyle.Black;
                    if (metroComboBox11.SelectedItem.ToString() == "White")
                    {
                        metroTile12.UseCustomForeColor = false;
                        metroTile12.UseCustomBackColor = false;
                    }
                }
            }
        }

        private BigInteger GetKeyExchange()
        {
            if (exchangeKey == Two)
            {
                exchangeKey = Two.modPow(privateKey, N);
            }
            return exchangeKey;
        }

        public void IniToggles()
        {
            if (!Directory.Exists(AppPath + "\\backup"))
            {
                Directory.CreateDirectory(AppPath + "\\backup");
            }
            // ASS v
            if (File.Exists(AppPath + "\\backup\\00007916.upk") || File.Exists(AppPath + "\\backup\\00056572.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007916.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007916.upk", AppPath + "\\backup\\00007916.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007916.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056572.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056572.upk", AppPath + "\\backup\\00056572.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056572.upk");
                }
                metroToggle39.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00007916.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007916.upk") && !File.Exists(AppPath + "\\backup\\00056572.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056572.upk"))
            {
                metroToggle39.Enabled = false;
                metroToggle39.Checked = false;
            }
            // SUM v
            if (File.Exists(AppPath + "\\backup\\00007917.upk") || File.Exists(AppPath + "\\backup\\00056573.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007917.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007917.upk", AppPath + "\\backup\\00007917.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007917.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056573.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056573.upk", AppPath + "\\backup\\00056573.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056573.upk");
                }
                metroToggle36.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00007917.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007917.upk") && !File.Exists(AppPath + "\\backup\\00056573.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056573.upk"))
            {
                metroToggle36.Enabled = false;
                metroToggle36.Checked = false;
            }
            // GUN v
            if (File.Exists(AppPath + "\\backup\\00007915.upk") || File.Exists(AppPath + "\\backup\\00056571.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007915.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007915.upk", AppPath + "\\backup\\00007915.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007915.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056571.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056571.upk", AppPath + "\\backup\\00056571.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056571.upk");
                }
                metroToggle34.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00007915.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007915.upk") && !File.Exists(AppPath + "\\backup\\00056571.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056571.upk"))
            {
                metroToggle34.Enabled = false;
                metroToggle34.Checked = false;
            }
            // DES v
            if (File.Exists(AppPath + "\\backup\\00007914.upk") || File.Exists(AppPath + "\\backup\\00056570.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007914.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007914.upk", AppPath + "\\backup\\00007914.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007914.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056570.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056570.upk", AppPath + "\\backup\\00056570.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056570.upk");
                }
                metroToggle33.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00007914.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007914.upk") && !File.Exists(AppPath + "\\backup\\00056570.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056570.upk"))
            {
                metroToggle33.Enabled = false;
                metroToggle33.Checked = false;
            }
            // FM v
            if (File.Exists(AppPath + "\\backup\\00007913.upk") || File.Exists(AppPath + "\\backup\\00056569.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007913.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007913.upk", AppPath + "\\backup\\00007913.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007913.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056569.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056569.upk", AppPath + "\\backup\\00056569.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056569.upk");
                }
                metroToggle32.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00007913.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007913.upk") && !File.Exists(AppPath + "\\backup\\00056569.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056569.upk"))
            {
                metroToggle32.Enabled = false;
                metroToggle32.Checked = false;
            }
            // KFM v
            if (File.Exists(AppPath + "\\backup\\00007912.upk") || File.Exists(AppPath + "\\backup\\00056568.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007912.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007912.upk", AppPath + "\\backup\\00007912.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007912.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056568.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056568.upk", AppPath + "\\backup\\00056568.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056568.upk");
                }
                metroToggle35.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00007912.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007912.upk") && !File.Exists(AppPath + "\\backup\\00056568.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056568.upk"))
            {
                metroToggle35.Enabled = false;
                metroToggle35.Checked = false;
            }
            // BM v
            if (File.Exists(AppPath + "\\backup\\00007911.upk") || File.Exists(AppPath + "\\backup\\00056567.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007911.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007911.upk", AppPath + "\\backup\\00007911.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007911.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056567.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056567.upk", AppPath + "\\backup\\00056567.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056567.upk");
                }
                metroToggle31.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00007911.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007911.upk") && !File.Exists(AppPath + "\\backup\\00056567.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056567.upk"))
            {
                metroToggle31.Enabled = false;
                metroToggle31.Checked = false;
            }
            // WL v
            if (File.Exists(AppPath + "\\backup\\00023439.upk") || File.Exists(AppPath + "\\backup\\00056575.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00023439.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00023439.upk", AppPath + "\\backup\\00023439.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00023439.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056575.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056575.upk", AppPath + "\\backup\\00056575.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056575.upk");
                }
                metroToggle29.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00023439.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00023439.upk") && !File.Exists(AppPath + "\\backup\\00056575.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056575.upk"))
            {
                metroToggle29.Enabled = false;
                metroToggle29.Checked = false;
            }
            // SF v
            if (File.Exists(AppPath + "\\backup\\00034408.upk") || File.Exists(AppPath + "\\backup\\00056576.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00034408.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00034408.upk", AppPath + "\\backup\\00034408.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00034408.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056576.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056576.upk", AppPath + "\\backup\\00056576.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056576.upk");
                }
                metroToggle37.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00034408.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00034408.upk") && !File.Exists(AppPath + "\\backup\\00056576.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056576.upk"))
            {
                metroToggle37.Enabled = false;
                metroToggle37.Checked = false;
            }
            // BD v
            if (File.Exists(AppPath + "\\backup\\00018601.upk") || File.Exists(AppPath + "\\backup\\00056574.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00018601.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00018601.upk", AppPath + "\\backup\\00018601.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00018601.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056574.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056574.upk", AppPath + "\\backup\\00056574.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056574.upk");
                }
                metroToggle30.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00018601.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00018601.upk") && !File.Exists(AppPath + "\\backup\\00056574.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056574.upk"))
            {
                metroToggle30.Enabled = false;
                metroToggle30.Checked = false;
            }
            // WAR v
            if (File.Exists(AppPath + "\\backup\\00056126.upk") || File.Exists(AppPath + "\\backup\\00056566.upk") || File.Exists(AppPath + "\\backup\\00056577.upk"))
            {
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056126.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056126.upk", AppPath + "\\backup\\00056126.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056126.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056566.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056566.upk", AppPath + "\\backup\\00056566.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056566.upk");
                }
                if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056577.upk"))
                {
                    File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056577.upk", AppPath + "\\backup\\00056577.upk", overwrite: true);
                    File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056577.upk");
                }
                metroToggle23.Checked = false;
            }
            else if (!File.Exists(AppPath + "\\backup\\00056126.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056126.upk") && !File.Exists(AppPath + "\\backup\\00056566.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056566.upk") && !File.Exists(AppPath + "\\backup\\00056577.upk") && !File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056577.upk"))
            {
                metroToggle23.Enabled = false;
                metroToggle23.Checked = false;
            }
        }

        private void CheckToggleForButtonAvailability()
        {
            int num = 0;
            if (metroToggle23.Enabled)
            {
                num++;
            }
            if (metroToggle29.Enabled)
            {
                num++;
            }
            if (metroToggle30.Enabled)
            {
                num++;
            }
            if (metroToggle31.Enabled)
            {
                num++;
            }
            if (metroToggle32.Enabled)
            {
                num++;
            }
            if (metroToggle33.Enabled)
            {
                num++;
            }
            if (metroToggle34.Enabled)
            {
                num++;
            }
            if (metroToggle35.Enabled)
            {
                num++;
            }
            if (metroToggle36.Enabled)
            {
                num++;
            }
            if (metroToggle37.Enabled)
            {
                num++;
            }
            if (metroToggle39.Enabled)
            {
                num++;
            }
            int num2 = 0;
            if (metroToggle23.Checked && metroToggle23.Enabled)
            {
                num2++;
            }
            if (metroToggle29.Checked && metroToggle29.Enabled)
            {
                num2++;
            }
            if (metroToggle30.Checked && metroToggle30.Enabled)
            {
                num2++;
            }
            if (metroToggle31.Checked && metroToggle31.Enabled)
            {
                num2++;
            }
            if (metroToggle32.Checked && metroToggle32.Enabled)
            {
                num2++;
            }
            if (metroToggle33.Checked && metroToggle33.Enabled)
            {
                num2++;
            }
            if (metroToggle34.Checked && metroToggle34.Enabled)
            {
                num2++;
            }
            if (metroToggle35.Checked && metroToggle35.Enabled)
            {
                num2++;
            }
            if (metroToggle36.Checked && metroToggle36.Enabled)
            {
                num2++;
            }
            if (metroToggle37.Checked && metroToggle37.Enabled)
            {
                num2++;
            }
            if (metroToggle39.Checked && metroToggle39.Enabled)
            {
                num2++;
            }
            if (num2 == num && num != 0)
            {
                metroButton36.Enabled = true;
                metroButton37.Enabled = false;
            }
            else if (num2 == 0 && num != 0)
            {
                metroButton36.Enabled = false;
                metroButton37.Enabled = true;
            }
            else if (num2 < num && num2 != 0 && num != 0 && num2 > 0)
            {
                metroButton36.Enabled = true;
                metroButton37.Enabled = true;
            }
            else
            {
                metroButton36.Enabled = false;
                metroButton37.Enabled = false;
            }
        }

        private bool wardenIgnoreOnce = false;
        private void metroToggle23_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle23.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056126.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056126.upk", AppPath + "\\backup\\00056126.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056126.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056577.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056577.upk", AppPath + "\\backup\\00056577.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056577.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056566.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056566.upk", AppPath + "\\backup\\00056566.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056566.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00056126.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056126.upk", RegPath + "\\contents\\bns\\CookedPC\\00056126.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056126.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056577.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056577.upk", RegPath + "\\contents\\bns\\CookedPC\\00056577.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056577.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056566.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056566.upk", RegPath + "\\contents\\bns\\CookedPC\\00056566.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056566.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (wardenIgnoreOnce)
                    {
                        wardenIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    wardenIgnoreOnce = true;
                    metroToggle23.Checked = !metroToggle23.Checked;
                }
            }
        }

        private bool assassinIgnoreOnce = false;
        private void metroToggle39_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle39.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007916.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007916.upk", AppPath + "\\backup\\00007916.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007916.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056572.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056572.upk", AppPath + "\\backup\\00056572.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056572.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00007916.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00007916.upk", RegPath + "\\contents\\bns\\CookedPC\\00007916.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00007916.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056572.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056572.upk", RegPath + "\\contents\\bns\\CookedPC\\00056572.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056572.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (assassinIgnoreOnce)
                    {
                        assassinIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    assassinIgnoreOnce = true;
                    metroToggle39.Checked = !metroToggle39.Checked;
                }
            }
        }

        private bool summonerIgnoreOnce = false;
        private void metroToggle36_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle36.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007917.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007917.upk", AppPath + "\\backup\\00007917.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007917.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056573.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056573.upk", AppPath + "\\backup\\00056573.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056573.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00007917.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00007917.upk", RegPath + "\\contents\\bns\\CookedPC\\00007917.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00007917.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056573.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056573.upk", RegPath + "\\contents\\bns\\CookedPC\\00056573.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056573.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (summonerIgnoreOnce)
                    {
                        summonerIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    summonerIgnoreOnce = true;
                    metroToggle36.Checked = !metroToggle36.Checked;
                }
            }
        }

        private bool kungFuMasterIgoreOnce = false;
        private void metroToggle35_CheckedChanged_1(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle35.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007912.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007912.upk", AppPath + "\\backup\\00007912.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007912.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056568.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056568.upk", AppPath + "\\backup\\00056568.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056568.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00007912.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00007912.upk", RegPath + "\\contents\\bns\\CookedPC\\00007912.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00007912.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056568.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056568.upk", RegPath + "\\contents\\bns\\CookedPC\\00056568.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056568.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (kungFuMasterIgoreOnce)
                    {
                        kungFuMasterIgoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    kungFuMasterIgoreOnce = true;
                    metroToggle35.Checked = !metroToggle35.Checked;
                }
            }
        }

        private bool gunnerIgnoreOnce = false;
        private void metroToggle34_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle34.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007915.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007915.upk", AppPath + "\\backup\\00007915.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007915.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056571.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056571.upk", AppPath + "\\backup\\00056571.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056571.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00007915.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00007915.upk", RegPath + "\\contents\\bns\\CookedPC\\00007915.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00007915.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056571.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056571.upk", RegPath + "\\contents\\bns\\CookedPC\\00056571.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056571.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (gunnerIgnoreOnce)
                    {
                        gunnerIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    gunnerIgnoreOnce = true;
                    metroToggle34.Checked = !metroToggle34.Checked;
                }
            }
        }

        private bool destroyerIgnoreOnce = false;
        private void metroToggle33_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle33.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007914.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007914.upk", AppPath + "\\backup\\00007914.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007914.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056570.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056570.upk", AppPath + "\\backup\\00056570.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056570.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00007914.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00007914.upk", RegPath + "\\contents\\bns\\CookedPC\\00007914.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00007914.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056570.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056570.upk", RegPath + "\\contents\\bns\\CookedPC\\00056570.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056570.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (destroyerIgnoreOnce)
                    {
                        destroyerIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    destroyerIgnoreOnce = true;
                    metroToggle33.Checked = !metroToggle33.Checked;
                }
            }
        }

        private bool forceMasterIgnoreOnce = false;
        private void metroToggle32_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle32.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007913.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007913.upk", AppPath + "\\backup\\00007913.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007913.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056569.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056569.upk", AppPath + "\\backup\\00056569.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056569.upk");
                        }
                    }

                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00007913.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00007913.upk", RegPath + "\\contents\\bns\\CookedPC\\00007913.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00007913.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056569.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056569.upk", RegPath + "\\contents\\bns\\CookedPC\\00056569.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056569.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (forceMasterIgnoreOnce)
                    {
                        forceMasterIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    forceMasterIgnoreOnce = true;
                    metroToggle32.Checked = !metroToggle32.Checked;
                }
            }
        }

        private bool bladeMasterIgnoreOnce = false;
        private void metroToggle31_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle31.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00007911.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00007911.upk", AppPath + "\\backup\\00007911.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00007911.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056567.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056567.upk", AppPath + "\\backup\\00056567.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056567.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00007911.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00007911.upk", RegPath + "\\contents\\bns\\CookedPC\\00007911.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00007911.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056567.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056567.upk", RegPath + "\\contents\\bns\\CookedPC\\00056567.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056567.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (bladeMasterIgnoreOnce)
                    {
                        bladeMasterIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    bladeMasterIgnoreOnce = true;
                    metroToggle31.Checked = !metroToggle31.Checked;
                }
            }
        }

        private bool bladeDancerIgnoreOnce = false;
        private void metroToggle30_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle30.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00018601.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00018601.upk", AppPath + "\\backup\\00018601.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00018601.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056574.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056574.upk", AppPath + "\\backup\\00056574.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056574.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00018601.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00018601.upk", RegPath + "\\contents\\bns\\CookedPC\\00018601.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00018601.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056574.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056574.upk", RegPath + "\\contents\\bns\\CookedPC\\00056574.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056574.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (bladeDancerIgnoreOnce)
                    {
                        bladeDancerIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    bladeDancerIgnoreOnce = true;
                    metroToggle30.Checked = !metroToggle30.Checked;
                }
            }
        }

        private bool warlockIgnoreOnce = false;
        private void metroToggle29_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle29.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00023439.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00023439.upk", AppPath + "\\backup\\00023439.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00023439.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056575.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056575.upk", AppPath + "\\backup\\00056575.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056575.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00023439.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00023439.upk", RegPath + "\\contents\\bns\\CookedPC\\00023439.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00023439.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056575.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056575.upk", RegPath + "\\contents\\bns\\CookedPC\\00056575.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056575.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (warlockIgnoreOnce)
                    {
                        warlockIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    warlockIgnoreOnce = true;
                    metroToggle29.Checked = !metroToggle29.Checked;
                }
            }
        }

        private bool soulFighterIgnoreOnce = false;
        private void metroToggle37_CheckedChanged(object sender, EventArgs e)
        {
            if (AppStarted)
            {
                if (!GameStarted)
                {
                    if (!metroToggle37.Checked)
                    {
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00034408.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00034408.upk", AppPath + "\\backup\\00034408.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00034408.upk");
                        }
                        if (File.Exists(RegPath + "\\contents\\bns\\CookedPC\\00056576.upk"))
                        {
                            File.Copy(RegPath + "\\contents\\bns\\CookedPC\\00056576.upk", AppPath + "\\backup\\00056576.upk", overwrite: true);
                            File.Delete(RegPath + "\\contents\\bns\\CookedPC\\00056576.upk");
                        }
                    }
                    else
                    {
                        if (File.Exists(AppPath + "\\backup\\00034408.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00034408.upk", RegPath + "\\contents\\bns\\CookedPC\\00034408.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00034408.upk");
                        }
                        if (File.Exists(AppPath + "\\backup\\00056576.upk"))
                        {
                            File.Copy(AppPath + "\\backup\\00056576.upk", RegPath + "\\contents\\bns\\CookedPC\\00056576.upk", overwrite: true);
                            File.Delete(AppPath + "\\backup\\00056576.upk");
                        }
                    }
                    CheckToggleForButtonAvailability();
                }
                else
                {
                    if (soulFighterIgnoreOnce)
                    {
                        soulFighterIgnoreOnce = false;
                        return;
                    }

                    Prompt.Popup("Can not change value while the game is running");
                    soulFighterIgnoreOnce = true;
                    metroToggle37.Checked = !metroToggle37.Checked;
                }
            }
        }

        private void metroButton36_Click(object sender, EventArgs e)
        {
            if (GameStarted)
            {
                Prompt.Popup("Can not change value while the game is running");
                return;
            }

            if (metroToggle39.Checked && metroToggle39.Enabled)
            {
                metroToggle39.Checked = false;
            }
            if (metroToggle23.Checked && metroToggle23.Enabled)
            {
                metroToggle23.Checked = false;
            }
            if (metroToggle36.Checked && metroToggle36.Enabled)
            {
                metroToggle36.Checked = false;
            }
            if (metroToggle35.Checked && metroToggle35.Enabled)
            {
                metroToggle35.Checked = false;
            }
            if (metroToggle34.Checked && metroToggle34.Enabled)
            {
                metroToggle34.Checked = false;
            }
            if (metroToggle33.Checked && metroToggle33.Enabled)
            {
                metroToggle33.Checked = false;
            }
            if (metroToggle32.Checked && metroToggle32.Enabled)
            {
                metroToggle32.Checked = false;
            }
            if (metroToggle31.Checked && metroToggle31.Enabled)
            {
                metroToggle31.Checked = false;
            }
            if (metroToggle30.Checked && metroToggle30.Enabled)
            {
                metroToggle30.Checked = false;
            }
            if (metroToggle29.Checked && metroToggle29.Enabled)
            {
                metroToggle29.Checked = false;
            }
            if (metroToggle37.Checked && metroToggle37.Enabled)
            {
                metroToggle37.Checked = false;
            }
            metroButton37.Enabled = true;
            metroButton36.Enabled = false;
        }

        private void metroButton37_Click(object sender, EventArgs e)
        {
            if (GameStarted)
            {
                Prompt.Popup("Can not change value while the game is running");
                return;
            }

            if (!metroToggle39.Checked && metroToggle39.Enabled)
            {
                metroToggle39.Checked = true;
            }
            if (!metroToggle23.Checked && metroToggle23.Enabled)
            {
                metroToggle23.Checked = true;
            }
            if (!metroToggle36.Checked && metroToggle36.Enabled)
            {
                metroToggle36.Checked = true;
            }
            if (!metroToggle35.Checked && metroToggle35.Enabled)
            {
                metroToggle35.Checked = true;
            }
            if (!metroToggle34.Checked && metroToggle34.Enabled)
            {
                metroToggle34.Checked = true;
            }
            if (!metroToggle33.Checked && metroToggle33.Enabled)
            {
                metroToggle33.Checked = true;
            }
            if (!metroToggle32.Checked && metroToggle32.Enabled)
            {
                metroToggle32.Checked = true;
            }
            if (!metroToggle31.Checked && metroToggle31.Enabled)
            {
                metroToggle31.Checked = true;
            }
            if (!metroToggle30.Checked && metroToggle30.Enabled)
            {
                metroToggle30.Checked = true;
            }
            if (!metroToggle29.Checked && metroToggle29.Enabled)
            {
                metroToggle29.Checked = true;
            }
            if (!metroToggle37.Checked && metroToggle37.Enabled)
            {
                metroToggle37.Checked = true;
            }
            metroButton36.Enabled = true;
            metroButton37.Enabled = false;
        }

        private void metroLink12_Click(object sender, EventArgs e)
        {
            SETimer.Enabled = true;
        }

        private void metroLink11_Click(object sender, EventArgs e)
        {
            SETimer.Enabled = true;
        }

        private void SETimer_Tick(object sender, EventArgs e)
        {
            int x = metroPanel9.Location.X;
            if (metroPanel9.Location.X >= -696 && MenuHided)
            {
                if (SliderEffect)
                {
                    metroPanel9.Location = new Point(x + 24, metroPanel9.Location.Y);
                    metroPanel9.Refresh();
                    if (metroPanel9.Location.X >= 0)
                    {
                        SETimer.Enabled = false;
                        MenuHided = false;
                    }
                }
                else
                {
                    metroPanel9.Location = new Point(0, metroPanel9.Location.Y);
                    metroPanel9.Refresh();
                    MenuHided = false;
                    SETimer.Enabled = false;
                }
            }
            else if (metroPanel9.Location.X <= 0 && !MenuHided)
            {
                if (SliderEffect)
                {
                    metroPanel9.Location = new Point(x - 24, metroPanel9.Location.Y);
                    metroPanel9.Refresh();
                    if (metroPanel9.Location.X <= -696)
                    {
                        SETimer.Enabled = false;
                        MenuHided = true;
                    }
                }
                else
                {
                    metroPanel9.Location = new Point(-696, metroPanel9.Location.Y);
                    metroPanel9.Refresh();
                    MenuHided = true;
                    SETimer.Enabled = false;
                }
            }
        }

        private void metroLink5_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(4);
            SETimer.Enabled = true;
        }

        private void metroLink10_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(9);
            SETimer.Enabled = true;
        }

        private void metroLink6_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(5);
            SETimer.Enabled = true;
        }

        private void metroLink4_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(3);
            SETimer.Enabled = true;
        }

        private void metroLink8_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(7);
            SETimer.Enabled = true;
        }

        private void metroLink7_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.bnsbuddy.com/donations/");
        }

        private void metroLink9_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(8);
            SETimer.Enabled = true;
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(0);
            SETimer.Enabled = true;
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(1);
            SETimer.Enabled = true;
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            metroTabControl1.SelectTab(2);
            SETimer.Enabled = true;
        }

        private void metroLink13_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.bnsbuddy.com/index.php?pages/Merch_Store/");
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void metroPanel10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(base.Handle, 161, 2, 0);
            }
        }

        private void metroToggle38_CheckedChanged(object sender, EventArgs e)
        {
            if (!metroToggle38.Checked)
            {
                SliderEffect = false;
                try
                {
                    lineChanger("menuslidereffect = false", AppPath + "\\Settings.ini", 46);
                }
                catch
                {
                    Prompt.Popup("Could not save setting!");
                }
            }
            else
            {
                SliderEffect = true;
                try
                {
                    lineChanger("menuslidereffect = true", AppPath + "\\Settings.ini", 46);
                }
                catch
                {
                    Prompt.Popup("Could not save setting!");
                }
            }
        }

        private void GetCountFTH()
        {
            ToClearReg = new Dictionary<string, string>();
            RegistryKey localMachine = Registry.LocalMachine;
            localMachine = localMachine.OpenSubKey("SOFTWARE\\Microsoft\\FTH\\");
            if (localMachine != null)
            {
                if (localMachine.GetValue("Enabled").ToString() == "0")
                {
                    metroToggle40.Checked = false;
                }
            }
            else
            {
                metroToggle40.Checked = false;
                metroToggle40.Enabled = false;
            }
            int num = 0;
            localMachine = Registry.LocalMachine;
            localMachine = localMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\\", writable: true);
            if (localMachine != null)
            {
                string[] valueNames = localMachine.GetValueNames();
                foreach (string text in valueNames)
                {
                    if (text != null && text.ToString().Contains("Client.exe") && !ToClearReg.ContainsKey("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\\"))
                    {
                        ToClearReg.Add("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\\", text);
                        num++;
                    }
                }
            }
            localMachine = Registry.LocalMachine;
            localMachine = localMachine.OpenSubKey("SOFTWARE\\Microsoft\\FTH\\State\\", writable: true);
            if (localMachine != null)
            {
                string[] valueNames = localMachine.GetValueNames();
                foreach (string text2 in valueNames)
                {
                    if (text2 != null && text2.ToString().Contains("Client.exe") && !ToClearReg.ContainsKey("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\FTH\\State\\"))
                    {
                        ToClearReg.Add("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\FTH\\State\\", text2);
                        num++;
                    }
                }
            }
            localMachine = Registry.CurrentUser;
            localMachine = localMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\\", writable: true);
            if (localMachine != null)
            {
                string[] valueNames = localMachine.GetValueNames();
                foreach (string text3 in valueNames)
                {
                    if (text3 != null && text3.ToString().Contains("Client.exe") && !ToClearReg.ContainsKey("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\\"))
                    {
                        ToClearReg.Add("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\AppCompatFlags\\Layers\\", text3);
                        num++;
                    }
                }
            }
            if (num > 0)
            {
                metroLabel113.Text = num.ToString();
                metroButton40.Enabled = true;
            }
        }

        private void metroButton40_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int num = 0;
            foreach (string key2 in ToClearReg.Keys)
            {
                try
                {
                    if (key2 != null)
                    {
                        if (key2.Contains("HKEY_CURRENT_USER\\"))
                        {
                            string text = key2.Replace("HKEY_CURRENT_USER\\", "");
                            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(text, writable: true);
                            registryKey.DeleteValue(ToClearReg[key2], throwOnMissingValue: false);
                        }
                        if (key2.Contains("HKEY_LOCAL_MACHINE\\"))
                        {
                            string text2 = key2.Replace("HKEY_LOCAL_MACHINE\\", "");
                            RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey(text2, writable: true);
                            registryKey2.DeleteValue(ToClearReg[key2], throwOnMissingValue: false);
                        }
                        num++;
                    }
                }
                catch (Exception ex)
                {
                    Prompt.Popup("Could not delete the key: " + key2 + " | Value: " + ToClearReg[key2] + Environment.NewLine + "Error: " + ex.ToString());
                }
                if (num == ToClearReg.Count)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                metroButton40.Enabled = false;
                metroLabel113.Text = "0";
                GetCountFTH();
            }
            Prompt.Popup("A reboot of your computer may be required before this takes effect.");
        }

        private void metroLabel113_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(metroLabel113.Text) > 0)
            {
                metroLabel113.ForeColor = Color.DarkRed;
                metroButton1.Enabled = true;
            }
            else
            {
                metroLabel113.ForeColor = Color.DarkGreen;
                metroButton1.Enabled = false;
            }
        }

        private void metroToggle40_Click(object sender, EventArgs e)
        {
            if (metroToggle40.Checked)
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\FTH\\", writable: true).SetValue("Enabled", "1", RegistryValueKind.DWord);
                    Prompt.Popup("A reboot of your computer may be required before this takes effect.");
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\FTH\\", writable: true).SetValue("Enabled", "0", RegistryValueKind.DWord);
                    Prompt.Popup("A reboot of your computer may be required before this takes effect.");
                }
                catch
                {
                }
            }
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.CheckState.ToString() == "Checked")
            {
                foreach (TreeNode node in treeView3.Nodes)
                {
                    if (node != null)
                    {
                        presschk = true;
                        node.Checked = true;
                    }
                }
                metroCheckBox4.Checked = true;
            }
            else if (metroCheckBox4.CheckState.ToString() == "Unchecked")
            {
                foreach (TreeNode node2 in treeView3.Nodes)
                {
                    if (node2 != null)
                    {
                        presschk = true;
                        node2.Checked = false;
                    }
                }
                metroCheckBox4.Checked = false;
            }
            else if (metroCheckBox4.CheckState.ToString() == "Indeterminate")
            {
                int num = 0;
                foreach (TreeNode node3 in treeView3.Nodes)
                {
                    if (node3 != null && node3.Checked)
                    {
                        num++;
                    }
                }
                if (num == treeView3.Nodes.Count)
                {
                    foreach (TreeNode node4 in treeView3.Nodes)
                    {
                        if (node4 != null)
                        {
                            node4.Checked = false;
                        }
                    }
                    metroCheckBox4.Checked = false;
                }
                else if (num < treeView3.Nodes.Count)
                {
                    foreach (TreeNode node5 in treeView3.Nodes)
                    {
                        if (node5 != null)
                        {
                            node5.Checked = true;
                        }
                    }
                    metroCheckBox4.Checked = true;
                }
            }
        }

        private BigInteger SHA256Hash2ArrayInverse(byte[] tmp1, byte[] tmp2)
        {
            byte[] array = new byte[tmp1.Length + tmp2.Length];
            tmp1.CopyTo(array, 0);
            tmp2.CopyTo(array, tmp1.Length);
            byte[] buf = sha.ComputeHash(array);
            return new BigInteger(IntegerReverse(buf));
        }

        private unsafe byte[] IntegerReverse(byte[] buf)
        {
            byte[] array = new byte[buf.Length];
            for (int i = 0; i < array.Length / 4; i++)
            {
                fixed (byte* ptr = buf)
                {
                    fixed (byte* ptr3 = array)
                    {
                        int* ptr2 = (int*)ptr;
                        int* ptr4 = (int*)ptr3;
                        ptr4[i] = ptr2[array.Length / 4 - 1 - i];
                    }
                }
            }
            return array;
        }

        private byte[] GenerateEncryptionKeyRoot(byte[] src)
        {
            int num = src.Length;
            int num2 = 0;
            byte[] array = new byte[64];
            if (src.Length > 4)
            {
                while (src[num2] != 0)
                {
                    num--;
                    num2++;
                    if (num <= 4)
                    {
                        break;
                    }
                }
            }
            int num3 = num >> 1;
            byte[] array2 = new byte[num3];
            if (num3 > 0)
            {
                int num4 = num2 + num - 1;
                for (int i = 0; i < num3; i++)
                {
                    array2[i] = src[num4];
                    num4 -= 2;
                }
            }
            byte[] array3 = sha.ComputeHash(array2, 0, num3);
            for (int j = 0; j < 32; j++)
            {
                array[2 * j] = array3[j];
            }
            if (num3 > 0)
            {
                int num5 = num2 + num - 2;
                for (int k = 0; k < num3; k++)
                {
                    array2[k] = src[num5];
                    num5 -= 2;
                }
            }
            array3 = sha.ComputeHash(array2, 0, num3);
            for (int l = 0; l < 32; l++)
            {
                array[2 * l + 1] = array3[l];
            }
            return array;
        }

        private byte[] CombineBuffers(params byte[][] buffers)
        {
            int num = 0;
            foreach (byte[] array in buffers)
            {
                num += array.Length;
            }
            byte[] array2 = new byte[num];
            int num2 = 0;
            foreach (byte[] array3 in buffers)
            {
                array3.CopyTo(array2, num2);
                num2 += array3.Length;
            }
            return array2;
        }

        private byte[] Generate256BytesKey(byte[] src)
        {
            int num = 1;
            byte[] array = new byte[256];
            for (int i = 0; i < 256; i++)
            {
                array[i] = (byte)i;
            }
            int num2 = 0;
            int num3 = 0;
            for (int num4 = 64; num4 > 0; num4--)
            {
                int num5 = (num2 + src[num3] + array[num - 1]) & 0xFF;
                int num6 = array[num - 1];
                array[num - 1] = array[num5];
                int num7 = num3 + 1;
                array[num5] = (byte)num6;
                if (num7 == src.Length)
                {
                    num7 = 0;
                }
                int num8 = num5 + src[num7];
                int num9 = num7 + 1;
                int num10 = num8 + array[num];
                num8 = array[num];
                int num11 = (byte)num10;
                array[num] = array[num11];
                array[num11] = (byte)num8;
                if (num9 == src.Length)
                {
                    num9 = 0;
                }
                int num12 = (num11 + src[num9] + array[num + 1]) & 0xFF;
                int num13 = array[num + 1];
                array[num + 1] = array[num12];
                int num14 = num9 + 1;
                array[num12] = (byte)num13;
                if (num14 == src.Length)
                {
                    num14 = 0;
                }
                int num15 = num12 + src[num14];
                int num16 = array[num + 2];
                num2 = ((num15 + array[num + 2]) & 0xFF);
                num3 = num14 + 1;
                array[num + 2] = array[num2];
                array[num2] = (byte)num16;
                if (num3 == src.Length)
                {
                    num3 = 0;
                }
                num += 4;
            }
            return array;
        }

        private string Builder(string nameSpace, string function)
        {
            if (!(nameSpace == "Sts"))
            {
                if (!(nameSpace == "Auth"))
                {
                    if (!(nameSpace == "Mail"))
                    {
                        if (!(nameSpace == "IpAuthz"))
                        {
                            if (nameSpace == "Gate" && function == "LookupGeolocation")
                            {
                                string text = $"<Request>\n<NetAddress>127.0.0.1</NetAddress>\n</Request>\n";
                                int num = ++counter;
                                responseHandler.Add(num, new string[2]
                                {
                                nameSpace,
                                function
                                });
                                return string.Format("POST /Gate/LookupGeolocation STS/1.0\r\ns:{4}\r\np:*{0} 0 1 0 {1}\r\nl:{2}\r\n\r\n{3}", localIP, epoch, text.Length, text, num);
                            }
                        }
                        else
                        {
                            if (function == "RequestIpToken")
                            {
                                string text2 = "<Request/>\n";
                                int num2 = ++counter;
                                responseHandler.Add(num2, new string[2]
                                {
                                nameSpace,
                                function
                                });
                                return $"POST /IpAuthz/RequestIpToken STS/1.0\r\nf:;client={outsideIP}:80;appid={currentAppId}\r\nt:@login:{username}\r\ns:{num2}\r\nl:{text2.Length}\r\n\r\n{text2}";
                            }
                            if (function == "AddIp")
                            {
                                string text3 = $"<Request>\n<NetAddress>{outsideIP}</NetAddress>\n<Description/>\n</Request>\n";
                                return $"POST /IpAuthz/AddIp STS/1.0\r\nt:${currentAppId}\r\nl:{text3.Length}\r\n\r\n{text3}";
                            }
                        }
                    }
                    else if (function == "Mail")
                    {
                        string text4 = $"<Request>\n<Subject>[NCSOFT] Security Notification</Subject>\n<Recipient>{username}</Recipient>\n<Sender>noreply@ncsoft.com</Sender>\n<Contents>{authEmailUsername}|{authEmailIP}|{authEmailCountry}|{authEmailCode}</Contents>\n<TemplateId>1081</TemplateId>\n</Request>\n";
                        int num3 = ++counter;
                        responseHandler.Add(num3, new string[2]
                        {
                        nameSpace,
                        function
                        });
                        return string.Format("POST /Mail/Mail STS/1.0\r\ns:{2}\r\nl:{0}\r\n\r\n{1}", text4.Length, text4, counter);
                    }
                }
                else
                {
                    if (function == "LoginStart")
                    {
                        string text5 = $"<Request>\n<LoginName>{username}</LoginName>\n</Request>\n";
                        int num4 = ++counter;
                        responseHandler.Add(num4, new string[2]
                        {
                        nameSpace,
                        function
                        });
                        return string.Format("POST /Auth/LoginStart STS/1.0\r\ns:{4}\r\np:*{0} 0 1 0 {1}\r\nl:{2}\r\n\r\n{3}", localIP, epoch, text5.Length, text5, num4);
                    }
                    if (function == "KeyData")
                    {
                        byte[][] array = GenerateKeyClient(exchangeKeyServer);
                        MemoryStream memoryStream = new MemoryStream();
                        BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
                        binaryWriter.Write(exchangeKey.getBytes().Length);
                        binaryWriter.Write(exchangeKey.getBytes());
                        binaryWriter.Write(array[0].Length);
                        binaryWriter.Write(array[0]);
                        validate = new BigInteger(array[1]);
                        string text6 = $"<Request>\n<KeyData>{Convert.ToBase64String(memoryStream.ToArray())}</KeyData>\n</Request>\n";
                        binaryWriter.Close();
                        memoryStream.Close();
                        int num5 = ++counter;
                        responseHandler.Add(num5, new string[2]
                        {
                        nameSpace,
                        function
                        });
                        return string.Format("POST /Auth/KeyData STS/1.0\r\ns:{4}\r\np:*{0} 0 1 0 {1}\r\nl:{2}\r\n\r\n{3}", localIP, epoch, text6.Length, text6, num5);
                    }
                    if (function == "LoginFinish")
                    {
                        string text7 = "<Request>\n<Language>1</Language>\n</Request>\n";
                        int num6 = ++counter;
                        responseHandler.Add(num6, new string[2]
                        {
                        nameSpace,
                        function
                        });
                        return string.Format("POST /Auth/LoginFinish STS/1.0\r\ns:{2}\r\nl:{0}\r\n\r\n{1}", text7.Length, text7, num6);
                    }
                    if (function == "RequestToken")
                    {
                        string text8 = $"<Request>\n<AppId>{currentAppId}</AppId>\n</Request>\n";
                        int num7 = ++counter;
                        responseHandler.Add(num7, new string[2]
                        {
                        nameSpace,
                        function
                        });
                        return string.Format("POST /Auth/RequestToken STS/1.0\r\ns:{2}\r\nl:{0}\r\n\r\n{1}", text8.Length, text8, num7);
                    }
                    if (function == "GetUserInfo")
                    {
                        string text9 = "<Request/>\n";
                        int num8 = ++counter;
                        responseHandler.Add(num8, new string[2]
                        {
                        nameSpace,
                        function
                        });
                        return $"POST /Auth/GetUserInfo STS/1.0\r\nt:@login:{username}\r\ns:{num8}\r\np:*{localIP} 0 1 0 {epoch}\r\nl:{text9.Length}\r\n\r\n{text9}";
                    }
                    if (function == "VerifySecondaryAuth")
                    {
                        string text10 = $"<Request>\n<AuthType>8</AuthType>\n<Value>{enterCodePrompt.metroTextBox1.Text}</Value>\n</Request>\n";
                        int num9 = ++counter;
                        responseHandler.Add(num9, new string[2]
                        {
                        nameSpace,
                        function
                        });
                        return $"POST /Auth/VerifySecondaryAuth STS/1.0\r\ns:{num9}\r\np:*{localIP} 0 1 0 {epoch}\r\nl:{text10.Length}\r\n\r\n{text10}";
                    }
                }
            }
            else
            {
                if (function == "Connect")
                {
                    string text11 = $"<Connect>\n<ConnType>400</ConnType>\n<Address>{localIP}</Address>\n<ProductType>0</ProductType>\n<AppIndex>1</AppIndex>\n<Epoch>{epoch}</Epoch>\n<Program>{LoginProgramid}</Program>\n<Build>1001</Build>\n<Process>{pid}</Process>\n</Connect>\n";
                    return $"POST /Sts/Connect STS/1.0\r\nl:{text11.Length}\r\n\r\n{text11}";
                }
                if (function == "Ping")
                {
                    return "POST /Sts/Ping STS/1.0\r\nl:0\r\n\r\n";
                }
            }
            return null;
        }

        public void SlowPrompt(object sender, EventArgs e)
        {
            countdown.Stop();
            Prompt.Popup("You may need to close BnS Buddy then login again and/or check your connection.");
        }

        private void keepAlive(object sender, DoWorkEventArgs e)
        {
            DateTime now = DateTime.Now;
            int num = 30;
            while (LoginServer.Connected)
            {
                if (DateTime.Now >= now.AddSeconds((double)num))
                {
                    byte[] array = new byte[1024];
                    string text = Builder("Sts", "Ping");
                    array = Encoding.ASCII.GetBytes(text);
                    if (key != null && encStart)
                    {
                        array = xor.Encrypt(array, 0, array.Length);
                    }
                    ns.Write(array, 0, array.Length);
                    now = DateTime.Now;
                }
                Thread.Sleep(200);
            }
        }

        private void receivePackets(object sender, DoWorkEventArgs e)
        {
            while (LoginServer.Connected)
            {
                if (ns.DataAvailable)
                {
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        string text = "";
                        byte[] array = new byte[1024];
                        int num = 0;
                        do
                        {
                            num = ns.Read(array, 0, array.Length);
                            if (num > 0)
                            {
                                memoryStream.Write(array, 0, num);
                            }
                        }
                        while (num == array.Length);
                        array = memoryStream.ToArray();
                        if (key != null && encStart)
                        {
                            array = xor.Decrypt(array, 0, array.Length);
                        }
                        string text2 = Encoding.ASCII.GetString(array);
                        memoryStream.Close();
                        int result = 0;
                        int result2 = 0;
                        int.TryParse(Regex.Match(text2, "\r\nl:([0-9]*)\r\n", RegexOptions.IgnoreCase).Groups[1].Value, out result2);
                        int.TryParse(Regex.Match(text2, "\r\ns:([0-9]*)R\r\n", RegexOptions.IgnoreCase).Groups[1].Value, out result);
                        int num2 = Regex.Match(text2, "(\r\n\r\n)", RegexOptions.IgnoreCase).Groups[1].Index + 4;
                        if (num2 + result2 < text2.Length)
                        {
                            List<string> list = new List<string>();
                            while (text2 != "")
                            {
                                int.TryParse(Regex.Match(text2, "\r\nl:([0-9]*)\r\n", RegexOptions.IgnoreCase).Groups[1].Value, out result2);
                                num2 = Regex.Match(text2, "(\r\n\r\n)", RegexOptions.IgnoreCase).Groups[1].Index + 4;
                                string text3 = text2.Substring(0, result2 + num2);
                                list.Add(text3);
                                text2 = ((text2.Length == text3.Length) ? "" : text2.Substring(text3.Length));
                            }
                            foreach (string item in list)
                            {
                                int.TryParse(Regex.Match(item, "\r\ns:([0-9]*)R\r\n", RegexOptions.IgnoreCase).Groups[1].Value, out result);
                                if (responseHandler.ContainsKey(result))
                                {
                                    string[] previous = responseHandler[result];
                                    sendNext(previous, item, "");
                                }
                                else if (Debugging)
                                {
                                    Prompt.Popup(item);
                                }
                            }
                        }
                        else
                        {
                            if (num2 + result2 != text2.Length)
                            {
                                memoryStream = new MemoryStream();
                                array = new byte[1024];
                                do
                                {
                                    num = ns.Read(array, 0, array.Length);
                                    if (num > 0)
                                    {
                                        memoryStream.Write(array, 0, num);
                                    }
                                }
                                while (num == array.Length);
                                array = memoryStream.ToArray();
                                if (key != null && encStart)
                                {
                                    array = xor.Decrypt(array, 0, array.Length);
                                }
                                text = Encoding.ASCII.GetString(array);
                                memoryStream.Close();
                            }
                            if (responseHandler.ContainsKey(result))
                            {
                                string[] previous2 = responseHandler[result];
                                sendNext(previous2, text2, text);
                            }
                            else if (Debugging)
                            {
                                Prompt.Popup(text2 + text);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                Thread.Sleep(200);
            }
        }

        private void sendNext(string[] previous, string reply, string replyData)
        {
            switch (previous[0])
            {
                case "Auth":
                    switch (previous[1])
                    {
                        case "LoginStart":
                            if (replyData == "")
                            {
                                replyData = reply;
                            }
                            reply = reply.Split('\r')[0].Split(' ')[2];
                            if (!(reply == "OK"))
                            {
                                if (reply == "ErrAccountNotFound")
                                {
                                    Prompt.Popup("The provided email address wasn't found");
                                    metroButton1.Enabled = true;
                                    termConnection();
                                }
                                else
                                {
                                    Prompt.Popup("Invalidly formated email");
                                    metroButton1.Enabled = true;
                                    termConnection();
                                }
                            }
                            else
                            {
                                replyData = Regex.Match(replyData, "<KeyData>([^<]*)</KeyData>", RegexOptions.IgnoreCase).Groups[1].Value;
                                MemoryStream memoryStream2 = new MemoryStream(Convert.FromBase64String(replyData));
                                BinaryReader binaryReader2 = new BinaryReader(memoryStream2);
                                session = new BigInteger(binaryReader2.ReadBytes(binaryReader2.ReadInt32()));
                                exchangeKeyServer = new BigInteger(binaryReader2.ReadBytes(binaryReader2.ReadInt32()));
                                binaryReader2.Close();
                                memoryStream2.Close();
                                string text4 = Builder("Auth", "KeyData");
                                ns.Write(Encoding.ASCII.GetBytes(text4), 0, text4.Length);
                            }
                            break;
                        case "KeyData":
                            if (replyData == "")
                            {
                                replyData = reply;
                            }
                            reply = reply.Split('\r')[0].Split(' ')[2];
                            if (!(reply == "OK"))
                            {
                                if (reply == "ErrBadPasswd")
                                {
                                    Prompt.Popup("Wrong Password");
                                    metroButton1.Enabled = true;
                                    termConnection();
                                }
                                else
                                {
                                    Prompt.Popup("Unknown Error: " + reply);
                                    metroButton1.Enabled = true;
                                    termConnection();
                                }
                            }
                            else
                            {
                                replyData = Regex.Match(replyData, "<KeyData>([^<]*)</KeyData>", RegexOptions.IgnoreCase).Groups[1].Value;
                                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(replyData));
                                BinaryReader binaryReader = new BinaryReader(memoryStream);
                                byte[] inData = binaryReader.ReadBytes(binaryReader.ReadInt32());
                                binaryReader.Close();
                                memoryStream.Close();
                                if (new BigInteger(inData) == validate)
                                {
                                    xor = new BNSXorEncryption(key);
                                    string text3 = Builder("Auth", "LoginFinish");
                                    inData = Encoding.ASCII.GetBytes(text3);
                                    inData = xor.Encrypt(inData, 0, inData.Length);
                                    ns.Write(inData, 0, inData.Length);
                                    encStart = true;
                                }
                                else
                                {
                                    Prompt.Popup("Negotiation Failed, please try again.");
                                    key = null;
                                    metroButton1.Enabled = true;
                                    termConnection();
                                }
                            }
                            break;
                        case "LoginFinish":
                            if ((reply + replyData).Contains("<AuthType>8</AuthType>"))
                            {
                                string text5 = Builder("IpAuthz", "RequestIpToken");
                                byte[] bytes3 = Encoding.ASCII.GetBytes(text5);
                                bytes3 = xor.Encrypt(bytes3, 0, bytes3.Length);
                                ns.Write(bytes3, 0, bytes3.Length);
                            }
                            else
                            {
                                bool flag = false;
                                foreach (string[] value in responseHandler.Values)
                                {
                                    if (value[0] == "IpAuthz" && value[1] == "RequestIpToken")
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                bool @checked = enterCodePrompt.metroCheckBox1.Checked;
                                string text6;
                                byte[] bytes4;
                                if (flag && @checked)
                                {
                                    text6 = Builder("IpAuthz", "AddIp");
                                    bytes4 = Encoding.ASCII.GetBytes(text6);
                                    bytes4 = xor.Encrypt(bytes4, 0, bytes4.Length);
                                    ns.Write(bytes4, 0, bytes4.Length);
                                }
                                text6 = Builder("Auth", "RequestToken");
                                bytes4 = Encoding.ASCII.GetBytes(text6);
                                bytes4 = xor.Encrypt(bytes4, 0, bytes4.Length);
                                ns.Write(bytes4, 0, bytes4.Length);
                            }
                            break;
                        case "RequestToken":
                            {
                                reply += replyData;
                                token = Regex.Match(reply, "<AuthnToken>([^<]*)</AuthnToken>", RegexOptions.IgnoreCase).Groups[1].Value;
                                Action<bool> method = login_enable;
                                Invoke(method, true);
                                break;
                            }
                        case "GetUserInfo":
                            {
                                reply += replyData;
                                authEmailUsername = Regex.Match(reply, "<UserName>([^<]*)</UserName>", RegexOptions.IgnoreCase).Groups[1].Value;
                                string text7 = Builder("Mail", "Mail");
                                byte[] bytes5 = Encoding.ASCII.GetBytes(text7);
                                bytes5 = xor.Encrypt(bytes5, 0, bytes5.Length);
                                ns.Write(bytes5, 0, bytes5.Length);
                                break;
                            }
                        case "VerifySecondaryAuth":
                            reply = reply.Split('\r')[0].Split(' ')[2];
                            if (!(reply == "OK"))
                            {
                                if (reply == "ErrIpAuthzInvalidIpToken")
                                {
                                    Prompt.Popup("Wrong Code");
                                }
                                else
                                {
                                    Prompt.Popup("Unknown Error: " + reply);
                                    metroButton1.Enabled = true;
                                    termConnection();
                                }
                            }
                            else
                            {
                                enterCodePrompt.Invoke(new Action(enterCodePrompt.Close));
                                string text2 = Builder("Auth", "LoginFinish");
                                byte[] bytes2 = Encoding.ASCII.GetBytes(text2);
                                bytes2 = xor.Encrypt(bytes2, 0, bytes2.Length);
                                ns.Write(bytes2, 0, bytes2.Length);
                            }
                            break;
                        default:
                            Prompt.Popup("Unknown packet received");
                            break;
                    }
                    break;
                case "IpAuthz":
                    {
                        string a = previous[1];
                        if (a == "RequestIpToken")
                        {
                            reply += replyData;
                            authEmailCode = Regex.Match(reply, "<IpToken>([^<]*)</IpToken>", RegexOptions.IgnoreCase).Groups[1].Value;
                            string text = Builder("Gate", "LookupGeolocation");
                            byte[] bytes = Encoding.ASCII.GetBytes(text);
                            bytes = xor.Encrypt(bytes, 0, bytes.Length);
                            ns.Write(bytes, 0, bytes.Length);
                        }
                        else
                        {
                            Prompt.Popup("Unknown packet received");
                        }
                        break;
                    }
                case "Gate":
                    {
                        string a = previous[1];
                        if (a == "LookupGeolocation")
                        {
                            reply += replyData;
                            authEmailCountry = Regex.Match(reply, "<Geolocation>([^<]*)</Geolocation>", RegexOptions.IgnoreCase).Groups[1].Value;
                            authEmailIP = Regex.Match(reply, "<NetAddress>([^<]*)</NetAddress>", RegexOptions.IgnoreCase).Groups[1].Value;
                            string text8 = Builder("Auth", "GetUserInfo");
                            byte[] bytes6 = Encoding.ASCII.GetBytes(text8);
                            bytes6 = xor.Encrypt(bytes6, 0, bytes6.Length);
                            ns.Write(bytes6, 0, bytes6.Length);
                        }
                        else
                        {
                            Prompt.Popup("Unknown packet received");
                        }
                        break;
                    }
                case "Mail":
                    {
                        string a = previous[1];
                        if (a == "Mail")
                        {
                            BackgroundWorker backgroundWorker = new BackgroundWorker();
                            backgroundWorker.WorkerSupportsCancellation = true;
                            backgroundWorker.DoWork += delegate
                            {
                                enterCodePrompt.metroButton1.Enabled = false;
                                enterCodePrompt.metroTextBox1.Text = "";
                                enterCodePrompt = new enterCode(this);
                                enterCodePrompt.ShowDialog();
                                metroButton1.Enabled = true;
                            };
                            backgroundWorker.RunWorkerAsync();
                        }
                        else
                        {
                            Prompt.Popup("Unknown packet received");
                        }
                        break;
                    }
                default:
                    Prompt.Popup("Unknown packet received");
                    break;
            }
        }

        public void submitCode()
        {
            string text = Builder("Auth", "VerifySecondaryAuth");
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            bytes = xor.Encrypt(bytes, 0, bytes.Length);
            ns.Write(bytes, 0, bytes.Length);
        }

        private void login_enable(bool yes)
        {
            AddTextLog("Login successful!");
            if (!metroLabel14.Text.Contains("Clean"))
            {
                RestoreConfigFiles();
            }
            FinalToken = string.Format(args, token);
            AddTextLog("Starting Client!");
            Process process = new Process();
            process.StartInfo.FileName = LaunchPath;
            switch (metroComboBox1.SelectedItem.ToString())
            {
                case "North America":
                case "Europe":
                    process.StartInfo.Arguments = "-lang:" + languageID + " -lite:2 -region:" + regionID + " /AuthnToken:\"" + FinalToken + "\" /AuthProviderCode:\"np\" /sesskey /launchbylauncher  /CompanyID:12 /ChannelGroupIndex:-1 " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                    break;
                case "Korean":
                    if (metroComboBox8.SelectedItem.ToString() == "Live")
                    {
                        process.StartInfo.Arguments = "/LaunchByLauncher /UidHash:\"\" /UserAge:21 /AuthnToken:" + FinalToken + " /SessKey:" + FinalToken + " /ServiceRegion:" + LoginId + " /AuthProviderCode:np /ServiceNetwork:live /NPServerAddr:\"https://api.ncsoft.com:443\" -lite:8 /PresenceId:BNS_KOR " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                    }
                    else
                    {
                        process.StartInfo.Arguments = "/LaunchByLauncher /UidHash:\"\" /UserAge:21 /AuthnToken:" + FinalToken + " /SessKey:" + FinalToken + " /ServiceRegion:" + LoginId + " /AuthProviderCode:np /ServiceNetwork:live /NPServerAddr:\"https://api.ncsoft.com:443\" -lite:8 /PresenceId:BNS_KOR_TEST " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                    }
                    break;
                case "Taiwan":
                    process.StartInfo.Arguments = "/LaunchByLauncher /SessKey:" + FinalToken + " /ServiceRegion:15 /ChannelGroupIndex:-1 /PresenceId:TWBNS22 " + UseAllCores + " " + Unattended + " " + NoTextureStreaming + " " + metroTextBox5.Text;
                    break;
            }
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            bool flag = false;
            try
            {
                if (AutoClean)
                {
                    CleanMem();
                }
            }
            catch
            {
                AddTextBoxLog("Notice: Could not clear any memory!");
            }
            try
            {
                process.Start();
                string str = "Client.exe";
                if (customclientname != "")
                {
                    str = customclientname;
                }
                AddTextLog("Started " + str + "!");
                appuniqueid = process.Id;
                GameStarted = true;
                flag = true;
                if (metroToggle22.Checked)
                {
                    if (!ClientHandler.ContainsKey(username) || !metroComboBox9.Items.Contains(username))
                    {
                        if (!ClientHandler.ContainsValue(process.Id))
                        {
                            ClientHandler.Add(username, process.Id);
                            metroComboBox9.Items.Add(username);
                            metroComboBox9.SelectedIndex = metroComboBox9.FindStringExact(username);
                            metroPanel6.Visible = true;
                        }
                        else
                        {
                            AddTextBoxLog("Error: Somehow this process ID is already taken!");
                        }
                    }
                    else
                    {
                        AddTextBoxLog("Error: You can't login to an account that's already connected!");
                        process.Kill();
                    }
                }
                base.WindowState = FormWindowState.Minimized;
            }
            catch
            {
                Show();
                notifyIcon1.Visible = false;
                metroButton1.Enabled = true;
                foreach (TreeNode node in treeView2.Nodes)
                {
                    if (node != null)
                    {
                        if (node.Nodes.Count > 0)
                        {
                            foreach (TreeNode subnode in node.Nodes)
                            {
                                if (subnode != null)
                                {
                                    RealModPath = FullModPathMan + "\\" + subnode.FullPath.ToString().Replace(" (Installed)", "");
                                    if (Directory.Exists(RealModPath))
                                    {
                                        checkButtons(output: true);
                                    }
                                    else
                                    {
                                        subnode.Remove();
                                    }
                                }
                            }
                        }
                        if (node.Nodes.Count == 0)
                        {
                            RealModPath = FullModPathMan + "\\" + node.FullPath.ToString().Replace(" (Installed)", "");
                            if (Directory.Exists(RealModPath))
                            {
                                checkButtons(output: true);
                            }
                            else
                            {
                                node.Remove();
                            }
                        }
                    }
                }
                string str2 = "Client.exe";
                if (customclientname != "")
                {
                    str2 = customclientname;
                }
                AddTextLog("Error: Could Not Start " + str2 + "!");
            }
            if (flag)
            {
                try
                {
                    AutoCleaner();
                }
                catch
                {
                    AddTextLog("Error: Could not clean memory!");
                }
            }
        }

        public byte[][] GenerateKeyClient(BigInteger exchangeKey)
        {
            byte[] tmp = sha.ComputeHash(Encoding.ASCII.GetBytes(username + ":" + password));
            BigInteger bi = SHA256Hash2ArrayInverse(GetKeyExchange().getBytes(), exchangeKey.getBytes());
            BigInteger bigInteger = SHA256Hash2ArrayInverse(session.getBytes(), tmp);
            BigInteger bi2 = new BigInteger(exchangeKey.getBytes());
            BigInteger bi3 = Two.modPow(bigInteger, N);
            bi3 = bi3 * P % N;
            while (bi2 < bi3)
            {
                bi2 += N;
            }
            bi2 -= bi3;
            BigInteger exp = (bi * bigInteger + privateKey) % N;
            BigInteger bigInteger2 = bi2.modPow(exp, N);
            key = GenerateEncryptionKeyRoot(bigInteger2.getBytes());
            byte[] array = sha.ComputeHash(CombineBuffers(staticKey, sha.ComputeHash(Encoding.ASCII.GetBytes(username)), session.getBytes(), GetKeyExchange().getBytes(), exchangeKey.getBytes(), key));
            byte[] array2 = sha.ComputeHash(CombineBuffers(GetKeyExchange().getBytes(), array, key));
            key = Generate256BytesKey(key);
            return new byte[2][]
            {
            array,
            array2
            };
        }

        private void metroTextBox1_VisibleChanged(object sender, EventArgs e)
        {
            if (metroTextBox1.Visible)
            {
                string text = metroTextBox1.Text;
                metroTextBox1.Text = "";
                metroTextBox1.AppendText(text);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Launcher_Click(object sender, EventArgs e)
        {
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
        }

        public PictureBox exitlag = new PictureBox();
        int adscount = 1;
        int currentad = 2;
        private void PicSwap_Tick(object sender, EventArgs e)
        {
            if (exitlag.Image == null)
            {
                exitlag.Image = pictureBox2.Image;
            }

            if (metroProgressBar1.Maximum == metroProgressBar1.Value)
            {

                if (currentad == 1)
                {
                    pictureBox2.Image = exitlag.Image;
                    exitlag.Image = null;
                    urltobrowseto = "https://www.exitlag.com/refer/443658";
                }
                if (currentad == 2)
                {
                    pictureBox2.Image = Resources.ad2;
                    urltobrowseto = "https://discord.gg/ZpsmCZA";
                }
                if (currentad >= adscount)
                {
                    currentad = 0;
                }
                currentad++;
                metroProgressBar1.Value = 0;
            }

            if (adscount > 1)
            {
                metroProgressBar1.Visible = true;
                if (AppStarted)
                    metroProgressBar1.PerformStep();
            }
            else
            {
                metroProgressBar1.Visible = false;
            }
        }


        public Image previewImage = null;
        private void metroButton42_Click(object sender, EventArgs e)
        {
            if (previewImage == null)
            {
                if (File.Exists(FullModPathMan + "\\" + treeView2.SelectedNode.FullPath.ToString() + "\\preview.png"))
                {
                    previewImage = Image.FromFile(FullModPathMan + "\\" + treeView2.SelectedNode.FullPath.ToString() + "\\preview.png");
                }
                else if (File.Exists(FullModPathMan + "\\" + treeView2.SelectedNode.FullPath.ToString() + "\\preview.jpg"))
                {
                    previewImage = Image.FromFile(FullModPathMan + "\\" + treeView2.SelectedNode.FullPath.ToString() + "\\preview.jpg");
                }
                else if (File.Exists(FullModPathMan + "\\" + treeView2.SelectedNode.FullPath.ToString() + "\\preview.gif"))
                {
                    previewImage = Image.FromFile(FullModPathMan + "\\" + treeView2.SelectedNode.FullPath.ToString() + "\\preview.gif");
                }
            }
            Form previewMod = new PreviewMod();
            if (previewMod.ShowDialog() == DialogResult.Cancel)
            {
                if (previewImage != null)
                {
                    previewImage.Dispose();
                    previewImage = null;
                }
            }
        }

        private void metroButton41_Click(object sender, EventArgs e)
        {
            Prompt.Popup("Tree Colors:" + Environment.NewLine + "Red Color-> Conflicting installed mods" + Environment.NewLine + "Green Color-> Installed mods" + Environment.NewLine + "White Color-> Non-installed mods" + Environment.NewLine + "Mod Preview Supported formats:" + Environment.NewLine + "gif, png and jpg");
        }

        private void metroButton43_Click(object sender, EventArgs e)
        {
            Prompt.Popup(metroLabel40.Text);
        }

        private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!treeView1.SelectedNode.Name.EndsWith(".bin") && treeView1.SelectedNode.Name.Contains("."))
                {
                    treeView1.Enabled = false;
                    metroLabel39.Text = "Reloading...";
                    metroLabel39.Refresh();
                    fastColoredTextBox1.Clear();
                    nametofile = treeView1.SelectedNode.FullPath.Replace(ActiveDataFile + "\\", "");
                    BNSDat.BNSDat bNSDat = new BNSDat.BNSDat();
                    Dictionary<string, byte[]> dictionary = bNSDat.ExtractFile(myDictionary[ActiveDataFile] + "\\" + ActiveDataFile, new List<string>
                    {
                        nametofile
                    }, ActiveDataFile.Contains("64"));
                    var bytes = dictionary[nametofile];
                    fastColoredTextBox1.Text = System.Text.Encoding.UTF8.GetString(bytes);
                    metroLabel39.Text = "Reloaded!";
                    metroLabel39.Refresh();
                    treeView1.Enabled = true;
                }
            }
            catch
            {
                metroLabel39.Text = "Error: Could not open file";
            }
        }

    }
}