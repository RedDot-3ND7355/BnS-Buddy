using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Revamped_BnS_Buddy.Properties;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
	public class FileCheck : Form
	{
		public static class Prompt
		{
			public static string AppPath
			{
				get;
				internal set;
			}

			public static void Popup(string Message)
			{
				string a = "Default";
				if (File.Exists(AppPath + "\\Settings.ini"))
				{
					a = File.ReadLines(AppPath + "\\Settings.ini").Skip(43).Take(1)
						.First()
						.Replace("buddycolor = ", "");
				}
				ComponentResourceManager resources = new ComponentResourceManager(typeof(FileCheck));
				MetroForm metroForm = new MetroForm();
                metroForm.ShadowType = MetroFormShadowType.AeroShadow;
				metroForm.Width = 280;
				metroForm.Height = 135;
				metroForm.FormBorderStyle = FormBorderStyle.None;
				metroForm.Resizable = false;
				metroForm.AutoSize = true;
				metroForm.AutoSizeMode = AutoSizeMode.GrowOnly;
				metroForm.Icon = (Icon)resources.GetObject("notifyIcon");
				metroForm.ControlBox = false;
				metroForm.Theme = MetroThemeStyle.Dark;
				metroForm.Style = MetroColorStyle.White;
				metroForm.DisplayHeader = false;
				metroForm.TopMost = true;
				metroForm.Text = "";
				metroForm.StartPosition = FormStartPosition.CenterScreen;
				MetroForm metroForm2 = metroForm;
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
				metroForm2.Controls.Add(metroButton2);
				metroForm2.Controls.Add(value);
				metroForm2.AcceptButton = metroButton2;
				if (a == "Black")
				{
					metroForm2.Style = MetroColorStyle.Black;
				}
				else if (a == "Red")
				{
					metroForm2.Style = MetroColorStyle.Red;
				}
				else if (a == "Purple")
				{
					metroForm2.Style= MetroColorStyle.Purple;
				}
				else if (a == "Pink")
				{
					metroForm2.Style= MetroColorStyle.Pink;
				}
				else if (a == "Orange")
				{
					metroForm2.Style = MetroColorStyle.Orange;
				}
				else if (a == "Magenta")
				{
					metroForm2.Style = MetroColorStyle.Magenta;
				}
				else if (a == "Lime")
				{
					metroForm2.Style = MetroColorStyle.Lime;
				}
				else if (a == "Green")
				{
					metroForm2.Style = MetroColorStyle.Green;
				}
				else if (a == "Default")
				{
					metroForm2.Style = MetroColorStyle.Blue;
				}
				else if (a == "Brown")
				{
					metroForm2.Style = MetroColorStyle.Brown;
				}
				else if (a == "Blue")
				{
					metroForm2.Style = MetroColorStyle.Blue;
				}
				else if (a == "Silver")
				{
					metroForm2.Style = MetroColorStyle.Silver;
				}
				else if (a == "Teal")
				{
					metroForm2.Style = MetroColorStyle.Teal;
				}
				else if (a == "White")
				{
					metroForm2.Style = MetroColorStyle.White;
				}
				else if (a == "Yellow")
				{
                    metroForm2.Style = MetroColorStyle.Yellow;
				}
				metroForm2.ShowDialog();
			}
		}

		private static Mutex mutex;

		public string AppPath = Path.GetDirectoryName(Application.ExecutablePath);

		private IContainer components = null;

        public FileCheck()
		{
            mutex = new Mutex(true, "BnSBuddy", out bool createdNew);
            if (!createdNew)
            {
                Prompt.Popup("BnS Buddy is already running! Closing...");
                KillApp();
            }
            Application.Run(new Form1());
            //Dispose();
		}

		public void KillApp()
		{
			Process.GetCurrentProcess().Kill();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			SuspendLayout();
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(120, 0);
			base.ControlBox = false;
			base.Name = "FileCheck";
			Text = "FileCheck";
			ResumeLayout(false);
		}
	}
}
