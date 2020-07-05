using Ionic.Zip;
using Newtonsoft.Json.Linq;
using Revamped_BnS_Buddy.Functions;
using System;
using System.ComponentModel;
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
        private static string revision = "";
        public static string local_simple;
        public static string online_simple;
        private static string download_url;
        private static BackgroundWorker bw = new BackgroundWorker();

        public void CheckUpdate()
        {
            int Current = CheckCurrent();
            int Online = CheckOnline();
            Form1.CurrentForm.metroLabel115.Text = "Current: " + local_simple;
            Form1.CurrentForm.metroLabel116.Text = "Online: " + online_simple;
            if (Current < Online)
            {
                if (Current > 0)
                {
                    UpdateAvailable = true;
                }
            }
        }

        public bool UpdateAvailable = false;

        private static int CheckCurrent()
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

        private static Uri _UriBuilder(string url)
        {
            Uri returl = new Uri(url, UriKind.Absolute);
            return returl;
        }

        private static int CheckOnline()
        {
            try
            {
                if (revision == "")
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


    }
}
