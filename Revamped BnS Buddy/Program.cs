using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Revamped_BnS_Buddy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string resource1 = "Revamped_BnS_Buddy.MetroFramework.dll";
            EmbeddedAssembly.Load(resource1, "MetroFramework.dll");
            string resource2 = "Revamped_BnS_Buddy.MetroFramework.Fonts.dll";
            EmbeddedAssembly.Load(resource2, "MetroFramework.Fonts.dll");
            string resource3 = "Revamped_BnS_Buddy.SharpCompress.dll";
            EmbeddedAssembly.Load(resource3, "SharpCompress.dll");
            string resource4 = "Revamped_BnS_Buddy.FastColoredTextBox.dll";
            EmbeddedAssembly.Load(resource4, "FastColoredTextBox.dll");
            string resource5 = "Revamped_BnS_Buddy.Ionic.Zlib.dll";
            EmbeddedAssembly.Load(resource5, "Ionic.Zlib.dll");
            string resource6 = "Revamped_BnS_Buddy.BigInteger.dll";
            EmbeddedAssembly.Load(resource6, "BigInteger.dll");
            /*string resource6 = "Revamped_BnS_Buddy.BNSDat.dll";
            EmbeddedAssembly.Load(resource6, "BNSDat.dll");*/
            //string resource2 = "WindowsFormsApplication3.cscompmgd.dll";
            //EmbeddedAssembly.Load(resource2, "cscompmgd.dll");

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            if (!AppDomain.CurrentDomain.FriendlyName.Contains("vshost.exe"))
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}
