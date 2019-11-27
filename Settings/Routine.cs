namespace Revamped_BnS_Buddy.Settings
{
    class Routine
    {
        /*
        private static TextBox virtualverify = new TextBox();
        private static string AppPath = Form1.CurrentForm.AppPath;
        private static string DefaultValues = Form1.CurrentForm.DefaultValues;

        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            if (File.Exists(fileName))
            {
                string[] array = File.ReadAllLines(fileName);
                array[line_to_edit - 1] = newText;
                File.WriteAllLines(fileName, array);
            }
        }

        public static void CheckTab()
        {
            try
            {
                if (!File.Exists(AppPath + "\\Settings.ini"))
                {
                    File.WriteAllText(AppPath + "\\Settings.ini", DefaultValues);
                }
                // Check if updated
                if (!File.ReadAllText(AppPath + "\\Settings.ini").Contains("affinityman"))
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
                string settingsval = File.ReadAllText(AppPath + "\\Settings.ini");
                if (settingsval.Contains("savelogs = true"))
                {
                    Form1.CurrentForm.metroToggle2.Checked = true;
                    Form1.CurrentForm.groupBox7.Enabled = true;
                    Form1.CurrentForm.SaveLogs = true;
                    Form1.CurrentForm.groupBox7.Enabled = true;
                    if (settingsval.Contains("launcherlogs = true"))
                    {
                        Form1.CurrentForm.metroToggle13.Checked = true;
                        Form1.CurrentForm.LauncherLogs = true;
                    }
                    if (settingsval.Contains("modmanlogs = true"))
                    {
                        Form1.CurrentForm.metroToggle12.Checked = true;
                        Form1.CurrentForm.ModManLogs = true;
                    }
                }
                if (settingsval.Contains("tooltips = false"))
                {
                    Form1.CurrentForm.metroToggle6.Checked = false;
                    Form1.CurrentForm.metroToolTip1.Active = false;
                }
                if (settingsval.Contains("variables = true"))
                {
                    Form1.CurrentForm.metroToggle7.Checked = true;
                    Form1.CurrentForm.metroLabel22.Visible = true;
                }
                if (settingsval.Contains("admincheck = false"))
                {
                    Form1.CurrentForm.metroToggle8.Checked = false;
                    Form1.CurrentForm.AdminCheck = false;
                }
                if (settingsval.Contains("showdonate = false"))
                {
                    Form1.CurrentForm.metroToggle10.Checked = false;
                    Form1.CurrentForm.metroButton12.Visible = false;
                }
                if (settingsval.Contains("minimize = false"))
                {
                    Form1.CurrentForm.metroToggle11.Checked = false;
                    Form1.CurrentForm.AllowMinimize = false;
                }
                if (settingsval.Contains("showlogs = false"))
                {
                    Form1.CurrentForm.metroToggle5.Checked = false;
                    Form1.CurrentForm.ShowLogs = false;
                }
                if (settingsval.Contains("langset = true"))
                {
                    Form1.CurrentForm.langremembered = File.ReadLines(AppPath + "\\Settings.ini").Skip(33).Take(1)
                        .First()
                        .Replace("langpath = ", "");
                }
                if (settingsval.Contains("customclientname = "))
                {
                    string text = File.ReadLines(AppPath + "\\Settings.ini").Skip(42).Take(1)
                        .First()
                        .Replace("customclientname = ", "");
                    if (text.Length >= 1)
                    {
                        Form1.CurrentForm.customclientname = text;
                        Form1.CurrentForm.metroTextBox9.Text = Form1.CurrentForm.customclientname;
                    }
                }
                if (settingsval.Contains("customgame = true"))
                {
                    Form1.CurrentForm.metroTextBox3.Enabled = true;
                    Form1.CurrentForm.metroButton15.Enabled = true;
                    Form1.CurrentForm.metroButton20.Enabled = true;
                    Form1.CurrentForm.metroButton17.Enabled = true;
                    Form1.CurrentForm.metroToggle3.Checked = true;
                    string text2 = File.ReadLines(AppPath + "\\Settings.ini").Skip(15).Take(1)
                        .First();
                    Form1.CurrentForm.RegPath = text2.Replace("customgamepath = ", "");
                    Form1.CurrentForm.workedREG = true;
                    Form1.CurrentForm.BnSFolder();
                    Form1.CurrentForm.metroTextBox3.Text = Form1.CurrentForm.RegPath;
                    Form1.CurrentForm.CustomGameSet = true;
                }
                if (settingsval.Contains("customclient = true"))
                {
                    Form1.CurrentForm.metroTextBox4.Enabled = true;
                    Form1.CurrentForm.metroButton16.Enabled = true;
                    Form1.CurrentForm.metroButton19.Enabled = true;
                    Form1.CurrentForm.metroButton18.Enabled = true;
                    Form1.CurrentForm.metroToggle4.Checked = true;
                    string text3 = File.ReadLines(AppPath + "\\Settings.ini").Skip(14).Take(1)
                        .First();
                    Form1.CurrentForm.RegPathlol = text3.Replace("customclientpath = ", "");
                    Form1.CurrentForm.workedSRV = true;
                    Form1.CurrentForm.CheckServer();
                    Form1.CurrentForm.metroTextBox4.Text = Form1.CurrentForm.RegPathlol;
                    Form1.CurrentForm.CustomClientSet = true;
                }
                if (settingsval.Contains("gamekiller = false"))
                {
                    Form1.CurrentForm.GameKiller = false;
                    Form1.CurrentForm.metroToggle15.Checked = false;
                }
                if (settingsval.Contains("boostprocess = false"))
                {
                    Form1.CurrentForm.metroToggle20.Checked = false;
                }
                if (settingsval.Contains("updatechecker = false"))
                {
                    Form1.CurrentForm.UpdateChecker = false;
                    Form1.CurrentForm.metroToggle16.Checked = false;
                }
                if (settingsval.Contains("pingchecker = false"))
                {
                    Form1.CurrentForm.PingChecker = false;
                    Form1.CurrentForm.metroToggle14.Checked = false;
                }
                if (settingsval.Contains("arguements = "))
                {
                    string contents = File.ReadAllText(AppPath + "\\Settings.ini").Replace("arguements = ", "arguments = ");
                    File.WriteAllText(AppPath + "\\Settings.ini", contents);
                }
                if (settingsval.Contains("arguments = "))
                {
                    string text4 = File.ReadLines(AppPath + "\\Settings.ini").Skip(20).Take(1)
                        .First()
                        .Replace("arguments = ", "");
                    Form1.CurrentForm.metroTextBox5.Text = text4;
                }
                if (settingsval.Contains("automemorycleanup = true"))
                {
                    Form1.CurrentForm.metroToggle18.Checked = true;
                    Form1.CurrentForm.AutoClean = true;
                    Form1.CurrentForm.metroButton30.Visible = false;
                }
                if (settingsval.Contains("prtime = "))
                {
                    string text5 = File.ReadLines(AppPath + "\\Settings.ini").Skip(21).Take(1)
                        .First()
                        .Replace("prtime = ", "");
                    Form1.CurrentForm.metroLabel47.Text = text5;
                    Form1.CurrentForm.metroLabel47.Refresh();
                    if (Convert.ToInt32(text5) < 1000)
                    {
                        text5 = "5000";
                    }
                    Form1.CurrentForm.metroTrackBar1.Value = Convert.ToInt32(text5);
                    Form1.CurrentForm.metroTrackBar1.Refresh();
                    Form1.CurrentForm.wakeywakey = Convert.ToInt32(text5);
                }
                if (settingsval.Contains("uniquepass = "))
                {
                    string text6 = File.ReadLines(AppPath + "\\Settings.ini").Skip(36).Take(1)
                        .First()
                        .Replace("uniquepass = ", "");
                    Form1.CurrentForm.metroTextBox8.Text = text6;
                    Form1.CurrentForm.metroTextBox8.Refresh();
                }
                if (!settingsval.Contains("cleanint = OFF"))
                {
                    string text7 = File.ReadLines(AppPath + "\\Settings.ini").Skip(35).Take(1)
                        .First()
                        .Replace("cleanint = ", "");
                    Form1.CurrentForm.metroComboBox7.SelectedIndex = Form1.CurrentForm.metroComboBox7.FindStringExact(text7);
                    Form1.CurrentForm.metroComboBox7.Refresh();
                    if (text7 != "OFF")
                    {
                        Form1.CurrentForm.CleanerVal = Convert.ToInt32(text7);
                    }
                }
                else
                {
                    Form1.CurrentForm.metroComboBox7.SelectedIndex = 0;
                }
                if (settingsval.Contains("defaultset = true"))
                {
                    string text8 = File.ReadLines(AppPath + "\\Settings.ini").Skip(24).Take(1)
                        .First()
                        .Replace("default = ", "");
                    Form1.CurrentForm.metroLabel48.Text = text8;
                    Form1.CurrentForm.RegPath = text8;
                    Form1.CurrentForm.workedREG = true;
                    Form1.CurrentForm.MultipleInstallationFound = true;
                    Form1.CurrentForm.GetRegDir();
                    Form1.CurrentForm.BnSFolder();
                }
                if (settingsval.Contains("defaultclient = 64bit") || settingsval.Contains("defaultclient = 32bit"))
                {
                    Form1.CurrentForm.readyclient = true;
                }
                if (settingsval.Contains("usercountcheck = false"))
                {
                    Form1.CurrentForm.UserCountCheck = false;
                    Form1.CurrentForm.metroToggle26.Checked = false;
                }
                if (settingsval.Contains("showcount = false"))
                {
                    Form1.CurrentForm.metroLabel93.Visible = false;
                    Form1.CurrentForm.metroLabel94.Visible = false;
                    Form1.CurrentForm.metroToggle27.Checked = true;
                }
                if (settingsval.Contains("autoupdate = false"))
                {
                    Form1.CurrentForm.AutoUpdate = false;
                    Form1.CurrentForm.metroToggle17.Checked = false;
                }
                if (settingsval.Contains("rememberme = true"))
                {
                    Form1.CurrentForm.metroToggle28.Checked = true;
                }
                if (settingsval.Contains("priority = "))
                {
                    string a = File.ReadLines(AppPath + "\\Settings.ini").Skip(27).Take(1)
                        .First()
                        .Replace("priority = ", "");
                    if (a == "RealTime")
                    {
                        Form1.CurrentForm.metroComboBox6.SelectedIndex = 0;
                    }
                    if (a == "High")
                    {
                        Form1.CurrentForm.metroComboBox6.SelectedIndex = 1;
                    }
                    if (a == "AboveNormal")
                    {
                        Form1.CurrentForm.metroComboBox6.SelectedIndex = 2;
                    }
                    if (a == "Normal")
                    {
                        Form1.CurrentForm.metroComboBox6.SelectedIndex = 3;
                    }
                    if (a == "BelowNormal")
                    {
                        Form1.CurrentForm.metroComboBox6.SelectedIndex = 4;
                    }
                    if (a == "Idle")
                    {
                        Form1.CurrentForm.metroComboBox6.SelectedIndex = 5;
                    }
                }
                if (settingsval.Contains("buddycolor = "))
                {
                    string a2 = File.ReadLines(AppPath + "\\Settings.ini").Skip(43).Take(1)
                        .First()
                        .Replace("buddycolor = ", "");
                    if (a2 == "Black")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Black;
                    }
                    else if (a2 == "Red")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Red;
                    }
                    else if (a2 == "Purple")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Purple;
                    }
                    else if (a2 == "Pink")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Pink;
                    }
                    else if (a2 == "Orange")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Orange;
                    }
                    else if (a2 == "Magenta")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Magenta;
                    }
                    else if (a2 == "Lime")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Lime;
                    }
                    else if (a2 == "Green")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Green;
                    }
                    else if (a2 == "Default")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Blue;
                    }
                    else if (a2 == "Brown")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Brown;
                    }
                    else if (a2 == "Blue")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Blue;
                    }
                    else if (a2 == "Silver")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Silver;
                    }
                    else if (a2 == "Teal")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Teal;
                    }
                    else if (a2 == "White")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.White;
                        Form1.CurrentForm.metroTile3.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile4.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile5.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile6.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile7.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile8.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile9.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile10.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile11.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile12.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile13.UseCustomForeColor = true;
                        Form1.CurrentForm.metroTile3.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile4.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile5.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile6.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile7.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile8.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile9.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile10.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile11.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile12.UseCustomBackColor = true;
                        Form1.CurrentForm.metroTile13.UseCustomBackColor = true;
                    }
                    else if (a2 == "Yellow")
                    {
                        Form1.CurrentForm.Themer.Style = MetroColorStyle.Yellow;
                    }
                    Form1.CurrentForm.metroComboBox11.SelectedIndex = Form1.CurrentForm.metroComboBox11.FindStringExact(Form1.CurrentForm.Themer.Style.ToString());
                    Form1.CurrentForm.metroToolTip1.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroToolTip1.Theme = MetroThemeStyle.Dark;
                    Form1.CurrentForm.base.Style = Form1.CurrentForm.Themer.Style;

                    Form1.CurrentForm.metroComboBox1.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox2.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox3.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox4.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox5.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox6.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox7.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox8.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox9.Style = Form1.CurrentForm.Themer.Style;
                    Form1.CurrentForm.metroComboBox11.Style = Form1.CurrentForm.Themer.Style;

                    if (Form1.CurrentForm.Themer.Style == MetroColorStyle.White)
                    {
                        Form1.CurrentForm.metroComboBox1.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox2.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox3.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox4.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox5.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox6.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox7.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox8.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox9.Style = MetroColorStyle.Silver;
                        Form1.CurrentForm.metroComboBox11.Style = MetroColorStyle.Silver;

                        Form1.CurrentForm.metroComboBox1.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox2.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox3.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox4.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox5.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox6.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox7.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox8.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox9.Theme = MetroThemeStyle.Light;
                        Form1.CurrentForm.metroComboBox11.Theme = MetroThemeStyle.Light;
                    }

                    Form1.CurrentForm.Refresh();
                    Prompt.ColorSet = Form1.CurrentForm.Themer.Style;
                }
                if (settingsval.Contains("menuslidereffect = false"))
                {
                    Form1.CurrentForm.SliderEffect = false;
                    Form1.CurrentForm.metroToggle38.Checked = false;
                }
                if (settingsval.Contains("firsttime = false"))
                {
                    Form1.CurrentForm.FirstTime = false;
                }
                if (settingsval.Contains("modfolderset = true"))
                {
                    Form1.CurrentForm.CustomModSet = true;
                    string text9 = File.ReadLines(AppPath + "\\Settings.ini").Skip(28).Take(1)
                        .First()
                        .Replace("modfolder = ", "");
                    Form1.CurrentForm.metroToggle19.Checked = true;
                    Form1.CurrentForm.metroTextBox7.Text = text9;
                    Form1.CurrentForm.backupFolderPath = Form1.CurrentForm.metroTextBox7.Text + "\\CookedPC_Backup";
                    Form1.CurrentForm.FullModPathMan = Form1.CurrentForm.metroTextBox7.Text + "\\CookedPC_Mod";
                    Form1.CurrentForm.GetPath();
                }
                if (settingsval.Contains("gcdshow = true"))
                {
                    Form1.CurrentForm.metroToggle21.Checked = true;
                    Form1.CurrentForm.metroLabel72.Visible = true;
                    Form1.CurrentForm.metroLabel73.Visible = true;
                    Form1.CurrentForm.metroLabel72.Refresh();
                    Form1.CurrentForm.metroLabel73.Refresh();
                }
                if (settingsval.Contains("igpshow = true"))
                {
                    Form1.CurrentForm.metroToggle24.Checked = true;
                    Form1.CurrentForm.metroLabel70.Visible = true;
                    Form1.CurrentForm.metroLabel71.Visible = true;
                    Form1.CurrentForm.metroLabel70.Refresh();
                    Form1.CurrentForm.metroLabel71.Refresh();
                }
                if (settingsval.Contains("autologin = true"))
                {
                    Form1.CurrentForm.metroToggle25.Checked = true;
                }
                if (settingsval.Contains("affinityproc = "))
                {
                    string text8 = File.ReadLines(AppPath + "\\Settings.ini").Skip(46).Take(1)
                        .First()
                        .Replace("affinityproc = ", "");
                    Form1.CurrentForm.metroLabel85.Text += text8;
                    if (text8 == "Custom")
                    {
                        string text9 = File.ReadLines(AppPath + "\\Settings.ini").Skip(49).Take(1)
                        .First()
                        .Replace("customaffinity = ", "");
                        Form1.CurrentForm.customValue = int.Parse(text9);
                    }
                }
                if (settingsval.Contains("keepintray = true"))
                {
                    Form1.CurrentForm.metroToggle42.Checked = true;
                    Form1.CurrentForm.AlwaysOnTray = true;
                    Form1.CurrentForm.ActivateTray();
                }
                if (settingsval.Contains("startwWindows = true"))
                {
                    Form1.CurrentForm.metroToggle44.Checked = true;
                }
                if (settingsval.Contains("affinityman = false"))
                {
                    Form1.CurrentForm.metroToggle43.Checked = false;
                }
            }
            catch
            {
                Prompt.Popup("Error reading Settings.ini");
            }
        }
        */
    }
}
