using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Revamped_BnS_Buddy
{
	internal static class Program
	{
		[STAThread]
		public static void Main()
		{
            var AppPath = Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(AppPath + "\\MetroFramework.dll")) { File.Delete(AppPath + "\\MetroFramework.dll"); }

            EmbeddedAssembly.Load("Revamped_BnS_Buddy.Resources.MetroFramework.dll", "MetroFramework.dll");
			EmbeddedAssembly.Load("Revamped_BnS_Buddy.Resources.MetroFramework.Fonts.dll", "MetroFramework.Fonts.dll");
			EmbeddedAssembly.Load("Revamped_BnS_Buddy.Resources.SharpCompress.dll", "SharpCompress.dll");
			EmbeddedAssembly.Load("Revamped_BnS_Buddy.Resources.FastColoredTextBox.dll", "FastColoredTextBox.dll");
			EmbeddedAssembly.Load("Revamped_BnS_Buddy.Resources.Ionic.Zlib.dll", "Ionic.Zlib.dll");
			EmbeddedAssembly.Load("Revamped_BnS_Buddy.Resources.BigInteger.dll", "BigInteger.dll");
			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Program.CurrentDomain_AssemblyResolve);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Preload());
		}

		private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			return EmbeddedAssembly.Get(args.Name);
		}
	}
}
