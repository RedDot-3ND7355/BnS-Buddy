using Ionic.Zip;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using Revamped_BnS_Buddy.Functions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
    public partial class DX12ModMan : MetroForm
    {
        private string AppPath = Form1.CurrentForm.AppPath;

        public DX12ModMan()
        {
            InitializeComponent();
            GetColor();
            metroProgressBar1.UseStyleColors = true;
            metroProgressBar1.Style = Themer.Style;
            metroToolTip1.Style = Themer.Style;

            if (Form1.CurrentForm.CompatibleDx12)
            {
                metroCheckBox2.Checked = Form1.CurrentForm.d912pxyCheck;
                metroToggle1.Enabled = true;
                IniBW(3);
            }
        }

        private WebClient browser = new WebClient();
        private string RegPath = Form1.CurrentForm.RegPath;
        private string LauncherPath64 = Form1.CurrentForm.LauncherPath64;
        public string tag_name;
        private string revision = "";
        public string local_simple;
        public string online_simple;
        private string download_url;
        private BackgroundWorker bw = new BackgroundWorker();

        private void IniBW(int task)
        {
            isBusy = true;
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            
            if (task == 1)
                bw.DoWork += UpdateModTask;

            if (task == 2)
                bw.DoWork += DownloadModTask;

            if (task == 3)
                bw.DoWork += CheckModTask;

            if (task == 4)
                bw.DoWork += RemoveModTask;

            bw.RunWorkerAsync();
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bw.Dispose();
        }

        private void GetColor()
        {
            base.Style = Prompt.ColorSet;
            Themer.Style = Prompt.ColorSet;
            Refresh();
        }

        private void RemoveModTask(object sender, DoWorkEventArgs e)
        {
            RemoveAction();
            StatusLabel(true, "Verifying...");
            CheckUpdate();
            StatusLabel(true, "Done");
            isBusy = false;
        }

        private void CheckModTask(object sender, DoWorkEventArgs e)
        {
            CheckUpdate();
            StatusLabel(true, "Ready");
            isBusy = false;
        }

        private void UpdateModTask(object sender, DoWorkEventArgs e)
        {
            if (!metroCheckBox1.Checked)
            {
                StatusLabel(true, "Cleaning old installation...");
                RemoveAction();
            }
            StatusLabel(true, "Grabbing new update...");
            DownloadAction();
        }

        private void DownloadModTask(object sender, DoWorkEventArgs e)
        {
            DownloadAction();
        }

        public void CheckUpdate()
        {
            StatusLabel(true, "Checking Local Version...");
            int Current = CheckCurrent();
            StatusLabel(true, "Checking Online Version...");
            int Online = CheckOnline();
            metroLabel1.Text = "Current: " + local_simple;
            metroLabel2.Text = "Online: " + online_simple;
            Form1.CurrentForm.metroLabel115.Text = "Current: " + local_simple;
            Form1.CurrentForm.metroLabel116.Text = "Online: " + online_simple;
            if (Current < Online)
            {
                if (Current > 0)
                {
                    metroButton1.Enabled = true;
                    metroCheckBox1.Enabled = true;
                }
            }
            if (Current > 0)
            {
                metroToggle1.Checked = true;
            }
            StatusLabel(false);
        }

        private void DownloadAction()
        {
            try
            {
                browser = new WebClient();
                browser.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Browser_DownloadProgressChanged);
                browser.DownloadFileCompleted += new AsyncCompletedEventHandler(Browser_DownloadFileCompleted);
                browser.DownloadFileAsync(_UriBuilder(download_url), RegPath + LauncherPath64 + "\\d912pxy.zip");
            }
            catch { Prompt.Popup("Failed to download/install D912PXY!"); }
        }

        private void StatusLabel(bool working = true, string word = "")
        {
            metroLabel3.Visible = working;
            metroLabel3.Text = word;
            metroLabel3.Refresh();
        }

        private void Browser_DownloadFileCompleted(object sender, AsyncCompletedEventArgs aes)
        {
            try
            {
                if (!aes.Cancelled || aes.Error == null)
                {
                    string FFile = RegPath + LauncherPath64 + "\\d3d9.dll";
                    string FBack = RegPath + LauncherPath64 + "\\d3d9.bak";
                    string FNewX = RegPath + LauncherPath64 + "\\d912pxy\\dll\\release\\d3d9.dll";
                    metroProgressBar1.Value = 0;
                    StatusLabel(true, "Extracting...");
                    using (ZipFile zip = ZipFile.Read(RegPath + LauncherPath64 + "\\d912pxy.zip"))
                    {
                        foreach (ZipEntry e in zip.Where(x => x.FileName.StartsWith("d912pxy")))
                        {
                            e.Extract(RegPath + LauncherPath64, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                    if (File.Exists(FFile))
                    {
                        File.Delete(FFile);
                    }
                    StatusLabel(true, "Moving and Cleaning...");
                    File.Copy(FNewX, FFile, true);
                    if (File.Exists(RegPath + LauncherPath64 + "\\d912pxy\\config.ini"))
                    {
                        File.Delete(RegPath + LauncherPath64 + "\\d912pxy\\config.ini");
                    }
                    File.Move(RegPath + LauncherPath64 + "\\d912pxy\\bns_config.ini", RegPath + LauncherPath64 + "\\d912pxy\\config.ini");
                    if (File.Exists(RegPath + LauncherPath64 + "\\d912pxy.zip"))
                        File.Delete(RegPath + LauncherPath64 + "\\d912pxy.zip");
                    StatusLabel(true, "Verifying installation...");
                    CheckUpdate();
                    StatusLabel(true, "Done");
                    isBusy = false;
                } 
                else
                {
                    if (aes.Cancelled)
                        Prompt.Popup("Download Cancelled.");
                    if (aes.Error != null)
                        Prompt.Popup("Error: Could not download file.");

                    isBusy = false;
                }
            } 
            catch(Exception ae)
            {
                Prompt.Popup("Error: Could not extract/install" + Environment.NewLine + ae.ToString());
            }
        }

        private void Browser_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            metroProgressBar1.Maximum = 100;
            metroProgressBar1.Value = e.ProgressPercentage;
            metroProgressBar1.UseStyleColors = true;
            metroProgressBar1.Refresh();
        }

        private void RemoveAction()
        {
            try
            {
                StatusLabel(true, "Deleting files and cleaning up...");
                string FPath = RegPath + LauncherPath64 + "\\d912pxy";
                string FFile = RegPath + LauncherPath64 + "\\d3d9.dll";
                string FBack = RegPath + LauncherPath64 + "\\d3d9.bak";
                string FZipp = RegPath + LauncherPath64 + "\\d912pxy.zip";
                if (Directory.Exists(FPath))
                {
                    Directory.Delete(FPath, true);
                }
                if (File.Exists(FBack))
                {
                    File.Delete(FBack);
                }
                if (File.Exists(FFile))
                {
                    File.Delete(FFile);
                }
                if (File.Exists(FZipp))
                {
                    File.Delete(FZipp);
                }
            }
            catch { Prompt.Popup("Failed to uninstall/remove D912PXY."); }
        }


        private int CheckCurrent()
        {
            string Path = RegPath + LauncherPath64 + "\\d912pxy";
            string BinPath = RegPath + LauncherPath64;
            if (Directory.Exists(Path))
            {
                if (File.Exists(BinPath + "\\d3d9.dll"))
                {
                    try
                    {
                        string curr = FileVersionInfo.GetVersionInfo(BinPath + "\\d3d9.dll").ProductVersion;
                        string tmp_local = curr;
                        tmp_local = tmp_local.Remove(tmp_local.LastIndexOf("r") + 1).Replace("d912pxy version: v", "").Replace(" r", "");
                        local_simple = tmp_local;
                        //curr = curr.Replace("d912pxy version: ", "").Replace("v", "").Replace(".", "").Replace(" r", "");
                        curr = curr.Substring(curr.LastIndexOf("r") + 1);
                        return int.Parse(curr);
                    }
                    catch
                    {
                        local_simple = "";
                        return 0;
                    }
                }

            }
            local_simple = "";
            return 0;
        }

        private Uri _UriBuilder(string url)
        {
            Uri returl = new Uri(url, UriKind.Absolute);
            return returl;
        }

        private int CheckOnline()
        {
            try
            {
                if (revision == "") {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    browser.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");
                    string json = browser.DownloadString(_UriBuilder("https://api.github.com/repos/megai2/d912pxy/releases/latest"));
                    JObject objects = JObject.Parse(json);
                    revision = (string)objects.SelectToken("assets[0].name");
                    revision = revision.Substring(revision.LastIndexOf("r") + 1).Replace(".zip", "");
                    //revision = revision.Replace("d912pxy_v", "").Replace(".", "").Replace("_r", "").Replace("zip", "");
                    download_url = (string)objects.SelectToken("assets[0].browser_download_url");
                    tag_name = (string)objects.SelectToken("tag_name");
                    tag_name = tag_name.Replace("v", "");
                    online_simple = tag_name;
                    return int.Parse(revision);
                } 
                else
                {
                    return int.Parse(revision);
                }
            }
            catch
            {
                online_simple = "";
                return 0;
            }
        }

        private void UpdateMod(object sender, EventArgs e)
        {
            metroButton1.Enabled = false;
            metroCheckBox1.Enabled = false;
            IniBW(1);
        }

        bool isBusy = true;
        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if (!isBusy)
            {
                if (metroToggle1.Checked)
                {
                    StatusLabel(false);
                    IniBW(2);
                }
                else
                {
                    StatusLabel(false);
                    IniBW(4);
                }
                while (isBusy)
                {
                    Application.DoEvents();
                }
            } 
            else
            {
                metroToggle1.Checked = !metroToggle1.Checked;
                Prompt.Popup("Task running, please wait.");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (!isBusy)
                this.Close();
            else
                Prompt.Popup("Worker is not done yet.");
        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked)
            {
                lineChanger("dx912check = true", AppPath + "\\Settings.ini", 57);
                Form1.CurrentForm.d912pxyCheck = true;
            }
            else
            {
                lineChanger("dx912check = false", AppPath + "\\Settings.ini", 57);
                Form1.CurrentForm.d912pxyCheck = false;
            }
        }

        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            if (File.Exists(fileName))
            {
                string[] array = File.ReadAllLines(fileName);
                array[line_to_edit - 1] = newText;
                File.WriteAllLines(fileName, array);
            }
        }
    }
}
