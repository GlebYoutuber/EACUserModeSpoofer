using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EACSpoofer.HWID.GetHWID
{
     class GetHWID
    {
        public static String GetSystemBIOSMajorVersion()
        {
                ManagementClass bioshwid = new ManagementClass("win32_BIOS");
                ManagementObjectCollection bbios = bioshwid.GetInstances();
                string id = String.Empty;
                foreach (ManagementObject hwidbios in bbios)
                {
                    id = hwidbios.Properties["SystemBiosMajorVersion"].Value.ToString();
                    
                }
                return id;
        }
        public static String BIOSSerialNimber()
        {
            ManagementClass serbiosnumber = new ManagementClass("win32_BIOS");
            ManagementObjectCollection ser123 = serbiosnumber.GetInstances();
            string id3 = String.Empty;
            foreach (ManagementObject bios in ser123)
            {
                id3 = bios.Properties["SerialNumber"].Value.ToString();
            }
            return id3;
        }
        public static String GetNameBIOS()
        {
            ManagementClass namebios = new ManagementClass("win32_BIOS");
            ManagementObjectCollection namejbios = namebios.GetInstances();
            string ccc = String.Empty;
            foreach(ManagementObject manbios in namejbios)
            {
                ccc = manbios.Properties["Name"].Value.ToString();
            }
            return ccc;
        }
        public static String GetLogicalDrive1()
        {
            ManagementClass logicaldrive = new ManagementClass("win32_LogicalDisk");
            ManagementObjectCollection logdrive = logicaldrive.GetInstances();
            string bnmb = String.Empty;
            foreach (ManagementObject getlog in logdrive)
            {
                bnmb = getlog.Properties["SystemName"].Value.ToString();
            }
            return bnmb;
        }
        public static String GetLogicalDrive2()
        {
            ManagementClass manlogdrive = new ManagementClass("win32_LogicalDisk");
            ManagementObjectCollection logdrive = manlogdrive.GetInstances();
            string mmbwob = String.Empty;
            foreach (ManagementObject management in logdrive)
            {
                mmbwob = management.Properties["FileSystem"].Value.ToString();
            }
            return mmbwob;
        }
        public static String GetLogicalDrive3()
        {
            ManagementClass logdrive3 = new ManagementClass("win32_LogicalDisk");
            ManagementObjectCollection logdrive123 = logdrive3.GetInstances();
            string bubil = String.Empty;
            foreach (ManagementObject getlogdrive in logdrive123)
            {
                bubil = getlogdrive.Properties["VolumeName"].Value.ToString();
            }
            return bubil;
        }
        public static String GetLogicalDrive4()
        {
            ManagementClass drivelogical = new ManagementClass("win32_LogicalDisk");
            ManagementObjectCollection baseObjects = drivelogical.GetInstances();
            string drive = String.Empty;
            foreach (ManagementObject drivedisk in baseObjects)
            {
                drive = drivedisk.Properties["VolumeName"].Value.ToString();
            }
            return drive;
        }
        public static String GetLogDrive5()
        {
            ManagementClass logdrive456 = new ManagementClass("win32_LogicalDisk");
            ManagementObjectCollection drivelog555 = logdrive456.GetInstances();
            string busser = String.Empty;
            foreach (ManagementObject boohen in drivelog555)
            {
                busser = boohen.Properties["VolumeSerialNumber"].Value.ToString();
            }
            return busser;
        }
        public void ShowHWID()
        {
            Directory.CreateDirectory(@"C:\Temp");
            File.WriteAllText(@"C:\Temp\HWID.txt", "BIOS: "+ Environment.NewLine + GetSystemBIOSMajorVersion() + Environment.NewLine + BIOSSerialNimber() + Environment.NewLine + GetNameBIOS()
                + Environment.NewLine + "Logical Disk: " + Environment.NewLine + GetLogicalDrive1() + Environment.NewLine + GetLogicalDrive2() + Environment.NewLine + GetLogicalDrive3()
                + Environment.NewLine + GetLogicalDrive4() + Environment.NewLine + GetLogDrive5());
            Process.Start("notepad", @"C:\Temp\HWID.txt");
        }
    }
}
