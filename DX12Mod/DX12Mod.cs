using Ionic.Zip;
using Newtonsoft.Json.Linq;
using Revamped_BnS_Buddy.Functions;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;

namespace Revamped_BnS_Buddy.DX12Mod
{
    class DX12Mod
    {
        private static WebClient browser = new WebClient();
        private static string RegPath = Form1.CurrentForm.RegPath;
        private static string LauncherPath64 = Form1.CurrentForm.LauncherPath64;
        public static string tag_name;
        private static string revision;
        public static string local_simple;
        public static string online_simple;
        private static string download_url;

        public static void CheckUpdate()
        {
            int Current = CheckCurrent();
            int Online = CheckOnline();
            Form1.CurrentForm.metroLabel115.Text = "Current: " + local_simple;
            Form1.CurrentForm.metroLabel116.Text = "Online: " + online_simple;
            if (Current < Online)
            {
                if (Current > 0)
                {
                    Form1.CurrentForm.metroButton45.Enabled = true;
                    Prompt.Popup("Update available for DX12 Mod.");
                }
            }
            if (Current > 0)
            {
                Form1.CurrentForm.metroToggle47.Enabled = true;
                Form1.CurrentForm.metroToggle47.Checked = true;
            }
        }

        public static void UpdateMod()
        {
            Status(true, false);
            RemoveAction();
            Status(true);
            DownloadAction();
            CheckUpdate();
            Status(false);
        }

        private static void DownloadAction()
        {
            try
            {
                string FFile = RegPath + LauncherPath64 + "\\d3d9.dll";
                string FBack = RegPath + LauncherPath64 + "\\d3d9.bak";
                string FNewX = RegPath + LauncherPath64 + "\\d912pxy\\dll\\release\\d3d9.dll";
                browser.DownloadFile(_UriBuilder(download_url), RegPath + LauncherPath64 + "\\d912pxy.zip");
                using (ZipFile zip = ZipFile.Read(RegPath + LauncherPath64 + "\\d912pxy.zip"))
                {
                    foreach (ZipEntry e in zip.Where(x => x.FileName.StartsWith("d912pxy")))
                    {
                        e.Extract(RegPath + LauncherPath64);
                    }
                }
                if (File.Exists(FFile))
                {
                    File.Move(FFile, FBack);
                }
                File.Copy(FNewX, FFile);
                File.Move(RegPath + LauncherPath64 + "\\d912pxy\\bns_config.ini", RegPath + LauncherPath64 + "\\d912pxy\\config.ini");
                File.Delete(RegPath + LauncherPath64 + "\\d912pxy.zip");
            }
            catch { Prompt.Popup("Failed to download/install D912PXY."); }
        }

        private static void Status(bool value, bool install = true)
        {
            Form1.CurrentForm.metroProgressSpinner2.Visible = value;
            Form1.CurrentForm.metroProgressSpinner2.Backwards = !install;
        }

        public static void DownloadMod()
        {
            Status(true);
            DownloadAction();
            CheckUpdate();
            Status(false);
        }

        private static void RemoveAction()
        {
            try
            {
                string FPath = RegPath + LauncherPath64 + "\\d912pxy";
                string FFile = RegPath + LauncherPath64 + "\\d3d9.dll";
                string FBack = RegPath + LauncherPath64 + "\\d3d9.bak";
                string FZipp = RegPath + LauncherPath64 + "\\d912pxy.zip";
                if (Directory.Exists(FPath))
                {
                    Directory.Delete(FPath, true);
                }
                if (File.Exists(FFile) && File.Exists(FBack))
                {
                    File.Delete(FFile);
                    File.Delete(FBack);
                }
                else if (File.Exists(FFile))
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

        public static void RemoveMod()
        {
            Status(true, false);
            RemoveAction();
            CheckUpdate();
            Status(false);
        }

        private static int CheckCurrent()
        {
            string Path = RegPath + LauncherPath64 + "\\d912pxy";
            if (Directory.Exists(Path))
            {
                if (File.Exists(Path + "\\dll\\release\\d3d9.dll"))
                {
                    try
                    {
                        string curr = FileVersionInfo.GetVersionInfo(Path + "\\dll\\release\\d3d9.dll").ProductVersion;
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

        private static Uri _UriBuilder(string url)
        {
            Uri returl = new Uri(url, UriKind.Absolute);
            return returl;
        }

        private static int CheckOnline()
        {
            try
            {
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
            catch
            {
                online_simple = "";
                return 0;
            }
        }


    }
}
