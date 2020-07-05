using System;

namespace Revamped_BnS_Buddy.Functions
{
    class OSCheck
    {
        public static OperatingSystem OSVERSION = Environment.OSVersion;
        public static bool is64bit = Environment.Is64BitOperatingSystem;

        public OSCheck()
        {
            if (int.Parse(OSVERSION.Version.Major.ToString()) < 6)
            {
                Prompt.Popup("You must have atleast Windows Vista or above for BnS Buddy to work.");
                new KillApp();
            }
            else if (int.Parse(OSVERSION.Version.Major.ToString()) >= 10 || (int.Parse(OSVERSION.Version.Major.ToString()) == 6 && int.Parse(OSVERSION.Version.Minor.ToString()) == 1))
            {
                Form1.CurrentForm.CompatibleDx12 = true;
            }
        }
    }
}
