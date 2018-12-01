using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class UpdaterTransition : MetroForm
    {
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
                File.ReadLines(AppPath + "\\Settings.ini").Skip(43).Take(1)
                    .First()
                    .Replace("buddycolor = ", "");
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
                metroLabel.AutoSize = true;
                metroLabel.Left = 5;
                metroLabel.Top = 20;
                metroLabel.Text = Message;
                metroLabel.Width = 270;
                metroLabel.Height = 40;
                metroLabel.TextAlign = ContentAlignment.MiddleCenter;
                metroLabel.Theme = MetroThemeStyle.Dark;
                MetroLabel value = metroLabel;
                MetroButton metroButton = new MetroButton();
                metroButton.Text = "Ok";
                metroButton.Left = 5;
                metroButton.Width = 100;
                metroButton.Top = 130;
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

        private WebClient client = new WebClient();

        private string BnSBuddySerial = "";

        private string BnSServerCert = "";

        public UpdaterTransition()
        {
            Prompt.AppPath = AppPath;
            InitializeComponent();
            SetFormColor();
            ValidateBuddy();
            GrabCurrentVersion();
            GrabOnlineVersion();
            GrabOnlineChangelog();
            metroButton1.DialogResult = DialogResult.OK;
            metroButton2.DialogResult = DialogResult.Cancel;
        }

        private void GrabCurrentVersion()
        {
            try
            {
                if (File.Exists(AppPath + "\\BnS Buddy.exe"))
                {
                    FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(AppPath + "\\BnS Buddy.exe");
                    CurrentLabel.Text = versionInfo.ProductVersion;
                }
                else
                {
                    CurrentLabel.Text = "Not found";
                }
            }
            catch
            {
                CurrentLabel.Text = "Not found";
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

        private void GrabOnlineChangelog()
        {
            if (ValidateDomain())
            {
                try
                {
                    string text = "updates.xxzer0modzxx.net";
                    TcpClient tcpClient = new TcpClient(text, 443);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    RemoteCertificateValidationCallback userCertificateValidationCallback = (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors) => true;
                    using (SslStream sslStream = new SslStream(tcpClient.GetStream(), false, userCertificateValidationCallback))
                    {
                        string text2 = "";
                        sslStream.AuthenticateAsClient(text, null, SslProtocols.Tls12, false);
                        tcpClient.SendTimeout = 500;
                        tcpClient.ReceiveTimeout = 1000;
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("GET /Changelog.txt HTTP/1.1");
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
                        metroTextBox1.Text = text2;
                    }
                    tcpClient.Close();
                }
                catch
                {
                    metroTextBox1.Text = "Offline";
                }
            }
        }

        private void GrabOnlineVersion()
        {
            if (ValidateDomain())
            {
                try
                {
                    string text = "updates.xxzer0modzxx.net";
                    TcpClient tcpClient = new TcpClient(text, 443);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    RemoteCertificateValidationCallback userCertificateValidationCallback = (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors) => true;
                    using (SslStream sslStream = new SslStream(tcpClient.GetStream(), false, userCertificateValidationCallback))
                    {
                        string text2 = "";
                        sslStream.AuthenticateAsClient(text, null, SslProtocols.Tls12, false);
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
                        UpdateLabel.Text = text2;
                    }
                    tcpClient.Close();
                }
                catch
                {
                    UpdateLabel.Text = "Offline";
                }
            }
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
                    metroStyleManager1.Style = MetroColorStyle.White;
                }
                else if (a == "Red")
                {
                    metroStyleManager1.Style = MetroColorStyle.Yellow;
                }
                else if (a == "Purple")
                {
                    metroStyleManager1.Style = MetroColorStyle.Red;
                }
                else if (a == "Pink")
                {
                    metroStyleManager1.Style = MetroColorStyle.Magenta;
                }
                else if (a == "Orange")
                {
                    metroStyleManager1.Style = MetroColorStyle.Brown;
                }
                else if (a == "Magenta")
                {
                    metroStyleManager1.Style = MetroColorStyle.Purple;
                }
                else if (a == "Lime")
                {
                    metroStyleManager1.Style = MetroColorStyle.Teal;
                }
                else if (a == "Green")
                {
                    metroStyleManager1.Style = MetroColorStyle.Lime;
                }
                else if (a == "Default")
                {
                    metroStyleManager1.Style = MetroColorStyle.Black;
                }
                else if (a == "Brown")
                {
                    metroStyleManager1.Style = MetroColorStyle.Pink;
                }
                else if (a == "Blue")
                {
                    metroStyleManager1.Style = MetroColorStyle.Green;
                }
                else if (a == "Silver")
                {
                    metroStyleManager1.Style = MetroColorStyle.Blue;
                }
                else if (a == "Teal")
                {
                    metroStyleManager1.Style = MetroColorStyle.Orange;
                }
                else if (a == "White")
                {
                    metroStyleManager1.Style = MetroColorStyle.Silver;
                }
                else if (a == "Yellow")
                {
                    metroStyleManager1.Style = (MetroColorStyle)14;
                }
                base.Style = metroStyleManager1.Style;
                Refresh();
                Prompt.ColorSet = metroStyleManager1.Style;
            }
        }

        private bool ValidateDomain()
        {
            if (BnSBuddySerial.Length > 0)
            {
                X509Certificate2 x509Certificate = null;
                try
                {
                    TcpClient tcpClient = new TcpClient("updates.xxzer0modzxx.net", 443);
                    using (SslStream sslStream = new SslStream(userCertificateValidationCallback: (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors) => true, innerStream: tcpClient.GetStream(), leaveInnerStreamOpen: true))
                    {
                        sslStream.AuthenticateAsClient("updates.xxzer0modzxx.net", null, SslProtocols.Tls12, checkCertificateRevocation: false);
                        x509Certificate = new X509Certificate2(sslStream.RemoteCertificate);
                    }
                }
                catch
                {
                    return false;
                }
                if (x509Certificate != null)
                {
                    BnSServerCert = x509Certificate.GetHashCode().ToString();
                }
                if (BnSBuddySerial == BnSServerCert && BnSBuddySerial == "1307602086")
                {
                    return true;
                }
            }
            return false;
        }

        private void ValidateBuddy()
        {
            X509Certificate x509Certificate = null;
            try
            {
                x509Certificate = X509Certificate.CreateFromSignedFile(Application.ExecutablePath);
                BnSBuddySerial = x509Certificate.GetHashCode().ToString();
                if (BnSBuddySerial != "1307602086")
                {
                    Prompt.Popup("BnS Buddy Updater signature does not match! Please Delete and get a fresh copy.");
                    KillApp();
                }
            }
            catch
            {
                Prompt.Popup("BnS Buddy Updater is not signed! Please Delete and get a fresh copy.");
                KillApp();
            }
        }

        public void KillApp()
        {
            Process.GetCurrentProcess().Kill();
        }

    }
}
