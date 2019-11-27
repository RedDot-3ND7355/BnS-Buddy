using System.Diagnostics;

namespace Revamped_BnS_Buddy.Functions
{
    class KillApp
    {
        public KillApp()
        {
            Process.GetCurrentProcess().Kill();
        }
    }
}
