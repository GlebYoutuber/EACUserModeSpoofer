using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EACSpoofer.HWID.Spoof
{
    class Spoofer
    {
        private string IDgenerate;

        //generates random string
        private static Random rndhwid = new Random();
        public static string randstring(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[rndhwid.Next(s.Length)]).ToArray());
        }

		private string[] regkeyshwid = new string[]
		{
			"HARDWARE\\Description\\System\\CentralProcessor\\0",
			"HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0",
			"SYSTEM\\CurrentControlSet\\Control\\SystemInformation",
			"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
			"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate",
			"HARDWARE\\DESCRIPTION\\System\\BIOS",
		};

		//nop - no operations
		private string[,] ValuesKeysHWID = new string[,]
		{
			{"SystemProductName", "Identifier", "Previous Update Revision", "ProcessorNameString", "VendorIdentifier", "Platform Specific Field1", "Component Information"},
			{"SerialNumber", "Identifier", "SystemManufacturer", "nop", "nop", "nop", "nop"},
			{"ComputerHardwareId", "ComputerHardwareIds", "BIOSVendor", "ProductId", "ProcessorNameString", "BIOSReleaseDate", "nop"},
			{"ProductId", "InstallDate", "InstallTime", "nop", "nop", "nop", "nop"},
			{"SusClientId", "nop", "nop", "nop", "nop", "nop", "nop"},
			{"BaseBoardManufacturer", "BaseBoardProduct", "BIOSVersion", "nop", "SystemManufacturer", "SystemProductName", "nop"},
		};
		public void SpoofHWID()
        {
			//Spoofing Hardware ID(for avoid EAC ban FOREVER)
			IDgenerate = randstring(20);
			for (int ctr = 0; ctr < regkeyshwid.Length; ctr++)
			{
				spoofRegistryKey(ctr);
			}
		}
		private void spoofRegistryKey(int regKeyIndex)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regkeyshwid[regKeyIndex], true);

			if (registryKey == null)
				return;

			for (int ctr = 0; ctr < ValuesKeysHWID.GetLength(1); ctr++)
			{
				if (ValuesKeysHWID[regKeyIndex, ctr] == "nop")
					break;

				registryKey.SetValue(ValuesKeysHWID[regKeyIndex, ctr], IDgenerate);
				IDgenerate = randstring(20);
			}

			registryKey.Close();
		}

		public string[] getSpoofingRegistryKeys()
		{
			return regkeyshwid;
		}
		public string[,] getSpoofingRegistryKeyValues()
		{
			return ValuesKeysHWID;
		}
	}
}
