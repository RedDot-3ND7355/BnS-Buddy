using System.Management;

namespace Security
{
	public class FingerPrint
	{
		private static string fingerPrint = string.Empty;

		public static string Value()
		{
			fingerPrint = string.Empty;
			if (string.IsNullOrEmpty(fingerPrint))
			{
				string text = null;
				string text2 = null;
				string text3 = null;
				try
				{
					text = cpuId();
				}
				catch
				{
					text = "";
				}
				try
				{
					text2 = biosId();
				}
				catch
				{
					text2 = "";
				}
				try
				{
					text3 = baseId();
				}
				catch
				{
					text3 = "";
				}
				string text4 = "";
				if (text != null || text != "")
				{
					text4 += text;
				}
				if (text2 != null || text2 != "")
				{
					text4 += text2;
				}
				if (text3 != null || text3 != "")
				{
					text4 += text3;
				}
				if (text4.Contains(" "))
				{
					text4 += text4.Replace(" ", "");
				}
				fingerPrint = text4.Trim();
			}
			return fingerPrint;
		}

		private static string identifier(string wmiClass, string wmiProperty)
		{
			string text = "";
			foreach (ManagementObject instance in new ManagementClass(wmiClass).GetInstances())
			{
				if (text == "")
				{
					try
					{
						if (instance[wmiProperty] == null)
						{
							return text;
						}
						text = instance[wmiProperty].ToString();
						return text;
					}
					catch
					{
					}
				}
			}
			return text;
		}

		private static string cpuId()
		{
			string text = identifier("Win32_Processor", "UniqueId");
			if (text == "")
			{
				text = identifier("Win32_Processor", "ProcessorId");
				if (text == "")
				{
					text = identifier("Win32_Processor", "Name");
					if (text == "")
					{
						text = identifier("Win32_Processor", "Manufacturer");
					}
				}
			}
			return text;
		}

		private static string biosId()
		{
			return identifier("Win32_BIOS", "Manufacturer") + identifier("Win32_BIOS", "SMBIOSBIOSVersion") + identifier("Win32_BIOS", "IdentificationCode") + identifier("Win32_BIOS", "SerialNumber") + identifier("Win32_BIOS", "ReleaseDate") + identifier("Win32_BIOS", "Version");
		}

		private static string baseId()
		{
			return identifier("Win32_BaseBoard", "Model") + identifier("Win32_BaseBoard", "Manufacturer") + identifier("Win32_BaseBoard", "Name") + identifier("Win32_BaseBoard", "SerialNumber");
		}
	}
}
