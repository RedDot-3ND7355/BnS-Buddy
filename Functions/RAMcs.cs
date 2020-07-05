using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revamped_BnS_Buddy.Functions
{
    class RAMcs
    {
        public bool IsCounters
        {
            get;
            set;
        }

        public void _IsCounters()
        {
            try
            {
                var bool_ac = new PerformanceCounter("Memory", "Available Bytes", null);
                bool_ac.Dispose();
                IsCounters = true;
            }
            catch
            {
                IsCounters = false;
            }
        }
        public float Current_Ram()
        {
            PerformanceCounter ram = new PerformanceCounter("Memory", "Available Bytes", null);
            float available = ram.NextValue();
            ram.Dispose();
            return available;
        }
        public float Current_Usage()
        {
            var TotalRAM_Bytes = Convert.ToSingle(new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory);
            var AvailableRAM_Bytes = new PerformanceCounter("Memory", "Available Bytes", null);
            var UsedRAM_Bytes = TotalRAM_Bytes - AvailableRAM_Bytes.NextValue();
            var PercentRAM_Bytes = (100 * UsedRAM_Bytes) / TotalRAM_Bytes;
            AvailableRAM_Bytes.Dispose();
            return PercentRAM_Bytes;
        }

        public float No_Counters_Curr_Usage()
        {
            var TotalRAM_Bytes = Convert.ToSingle(new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory);
            var AvailableRAM_Bytes = Convert.ToSingle(new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory);
            var UsedRAM_Bytes = TotalRAM_Bytes - AvailableRAM_Bytes;
            var PercentRAM_Bytes = (100 * UsedRAM_Bytes) / TotalRAM_Bytes;
            return PercentRAM_Bytes;
        }
    }

    
}
