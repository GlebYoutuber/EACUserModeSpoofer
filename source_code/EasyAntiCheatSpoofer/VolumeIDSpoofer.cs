using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EACSpoofer.VolumeIDSpoofer
{
    class VolumeIDSpoofer
    {

        private static Random random = new Random();
        public static string rndString(int length)
        {
            const string chars = "ABCDEF0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void VolumeIDSpoof()
        {
            //Copy VolumeID.exe to your Logical Disk
            File.Copy(@"C:\Temp\Volumeid.exe", @"C:\Volumeid.exe");
            //Get Logical Disks for Spoof DISKS ID!!!!
            DriveInfo[] drives = DriveInfo.GetDrives();
 
            for (int ctr = 0; ctr < drives.Length; ctr++)
            {
                //Start VolumeID.exe(Spoof your ID Disks to avoid EAC BAN for FOREVER)
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();
                process.StandardInput.WriteLine("cd C:/");
                process.StandardInput.Flush();
                process.StandardInput.WriteLine("start Volumeid.exe");
                process.StandardInput.Flush();
                process.StandardInput.WriteLine("volumeid " + drives[ctr].Name.Substring(0, 2) + " " + rndString(4) + "-" + rndString(4));
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
            }
        }
    }
}
