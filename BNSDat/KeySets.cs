using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Revamped_BnS_Buddy.Functions;

namespace Revamped_BnS_Buddy.BNSDat
{
    class KeySets
    {
        public KeySets()
        {
            try
            {
                List<string> KeyGot = new List<string>();
                WebClient browser = new WebClient();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                browser.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36 BnSBuddy");
                string json = browser.DownloadString(_UriBuilder("https://bnsbuddy.com/count/keysets.php"));
                JObject objects = JObject.Parse(json);
                JToken KeyArray = objects["keysets"];
                for (int i = 0; i < KeyArray.Count(); i++)
                {
                    KeyGot.Add((string)KeyArray.SelectToken(i.ToString()));
                }
                KeySet = KeyGot;
            } 
            catch
            {
                KeySet = null;
            }
        }

        public static List<string> KeySet
        {
            get;
            internal set;
        }

        private Uri _UriBuilder(string url)
        {
            Uri returl = new Uri(url, UriKind.Absolute);
            return returl;
        }
    }
}
