using System.Collections.Generic;

namespace Revamped_BnS_Buddy.Settings.Buddy.NCAuth
{
    class ServerValues
    {
        private static MetroFramework.Controls.MetroComboBox CurrentSelection = Form1.CurrentForm.metroComboBox8;
        public static List<string> GetServerValues(string Server, string Service)
        {
            List<string> returnedValues = new List<string>();
            if (Service == "Version")
            {
                if (Server == "Korean")
                {
                    returnedValues.Add("up4svr.plaync.co.kr");
                    if (CurrentSelection.SelectedItem.ToString() == "Live")
                    {
                        returnedValues.Add("BNS_KOR"); /* launcher version check: ncLauncherS */
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
                    if (CurrentSelection.SelectedItem.ToString() == "Live")
                    {
                        returnedValues.Add("ncLauncherS"); /* launcher version check: ncLauncherS */
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
    }
}
