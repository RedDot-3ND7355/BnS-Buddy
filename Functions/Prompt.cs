using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy.Functions
{
    class Prompt
    {
        public static MetroColorStyle ColorSet
        {
            get;
            internal set;
        }

        public static string AppPath
        {
            get;
            internal set;
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
            if (installs.ContainsKey("Korean Frontier") && installs["Korean Frontier"].ToString().Length > 1)
            {
                metroComboBox.Items.Add("Korean Frontier");
            }
            if (installs.ContainsKey("Russia") && installs["Russia"].ToString().Length > 1)
            {
                metroComboBox.Items.Add("Russia");
            }
            if (installs.ContainsKey("Garena") && installs["Garena"].ToString().Length > 1)
            {
                metroComboBox.Items.Add("Garena");
            }
            if (installs.ContainsKey("Chinese") && installs["Chinese"].ToString().Length > 1)
            {
                metroComboBox.Items.Add("Chinese");
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
            obj.TopMost = true;
            obj.ShowDialog();
        }
    }
}
