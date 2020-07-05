using MetroFramework.Forms;
using Revamped_BnS_Buddy.Functions;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class UpdaterTransition : MetroForm
    {

        private WebClient client = new WebClient();

        private string BnSBuddySerial = "";

        private bool BnSServerCert = false;

        public UpdaterTransition()
        {
            InitializeComponent();
            SetFormColor();
            ValidateBuddy();
            GrabCurrentVersion();
            Task.Delay(1000).ContinueWith(delegate
            {
                GrabOnlineVersion();
            });
            Task.Delay(1000).ContinueWith(delegate
            {
                GrabOnlineChangelog();
            });
            metroButton1.DialogResult = DialogResult.OK;
            metroButton2.DialogResult = DialogResult.Cancel;
        }

        private void GrabCurrentVersion()
        {
            try
            {
                if (File.Exists(Prompt.AppPath + "\\BnS Buddy.exe"))
                {
                    FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Prompt.AppPath + "\\BnS Buddy.exe");
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
                    string text = "updates.bnsbuddy.com";
                    TcpClient tcpClient = new TcpClient(text, 443);
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    RemoteCertificateValidationCallback userCertificateValidationCallback = (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors) => true;
                    using (SslStream sslStream = new SslStream(tcpClient.GetStream(), false, userCertificateValidationCallback))
                    {
                        string text2 = "";
                        sslStream.AuthenticateAsClient(text, null, SslProtocols.Tls12, true);
                        tcpClient.SendTimeout = 500;
                        tcpClient.ReceiveTimeout = 1000;
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine("GET /Changelog.txt HTTP/1.1");
                        stringBuilder.AppendLine("Host: updates.bnsbuddy.com");
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
                    string text = "updates.bnsbuddy.com";
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
                        stringBuilder.AppendLine("Host: updates.bnsbuddy.com");
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
            metroStyleManager1.Style = Prompt.ColorSet;
            base.Style = metroStyleManager1.Style;
            Refresh();
        }

        private bool ValidateDomain()
        {
            if (BnSBuddySerial.Length > 0)
            {
                X509Certificate2 x509Certificate = null;
                try
                {
                    TcpClient tcpClient = new TcpClient("updates.bnsbuddy.com", 443);
                    using (SslStream sslStream = new SslStream(userCertificateValidationCallback: (object snd, X509Certificate certificate, X509Chain chainLocal, SslPolicyErrors sslPolicyErrors) => true, innerStream: tcpClient.GetStream(), leaveInnerStreamOpen: true))
                    {
                        sslStream.AuthenticateAsClient("updates.bnsbuddy.com", null, SslProtocols.Tls12, checkCertificateRevocation: true);
                        x509Certificate = new X509Certificate2(sslStream.RemoteCertificate);
                    }
                }
                catch
                {
                    return false;
                }
                if (x509Certificate != null)
                {
                    if (x509Certificate.Subject.Replace("CN=", "") == "updates.bnsbuddy.com")
                    {
                        BnSServerCert = x509Certificate.Verify();
                    }
                }
                if (BnSServerCert && BnSBuddySerial == "341c5692cb780377c82154ab75fdd99ef1c4813f")
                {
                    return true;
                }
            }
            return false;
        }

        private void ValidateBuddy()
        {
            X509Certificate2 x509Certificate = null;
            try
            {
                var thecert = X509Certificate2.CreateFromSignedFile(Application.ExecutablePath);
                x509Certificate = new X509Certificate2(thecert);
                var theCertificateChain = new X509Chain();
                theCertificateChain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                theCertificateChain.ChainPolicy.RevocationMode = X509RevocationMode.Offline;
                theCertificateChain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                theCertificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
                bool chainIsValid = theCertificateChain.Build(x509Certificate);
                
                if (chainIsValid)
                {
                    BnSBuddySerial = x509Certificate.Thumbprint.ToLower();
                    if (BnSBuddySerial != "341c5692cb780377c82154ab75fdd99ef1c4813f")
                    {
                        Prompt.Popup("BnS Buddy Updater signature does not match! Please Delete and get a fresh copy.");
                        KillApp();
                    }
                } 
                else
                {
                    Prompt.Popup("BnS Buddy Updater has been altered! Please Delete and get a fresh copy.");
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
