using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace EACSpoofer.MacAddressSpoof
{
    public class MACAddressSpoof
    {
        public void SpoofMACAddress()
        {
            WebClient web = new WebClient();
            web.DownloadFile("https://download.technitium.com/tmac/TMACv6.0.7_Setup.zip", $@"C:\Users\{Environment.UserName}\Downloads\TMACv6.0.7_Setup.zip");
            if (File.Exists($@"C:\Users\{Environment.UserName}\Downloads\TMACv6.0.7_Setup.zip"))
            {
                ZipFile.ExtractToDirectory($@"C:\Users\{Environment.UserName}\Downloads\TMACv6.0.7_Setup.zip", $@"C:\Users\{Environment.UserName}\Downloads");
                Process.Start($@"C:\Users\{Environment.UserName}\Downloads\TMACv6.0.7_Setup.exe");
                MessageBox.Show("Download TMAC and Copy to your Windows folder to Spoof your MAC Address");
            }
            else
            {
                MessageBox.Show("Please Download TMAC ZipFile to Spoof your MAC Address");
                return;
            }
            if(MessageBox.Show("Copy to your Windows folder and Spoof your MAC Address?", "EAC UserMode Spoofer", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                File.Copy(@"C:\Program Files (x86)\Technitium\TMACv6.0\TMAC.exe", @"C:\Windows\TMAC.exe");
                MessageBox.Show("Beginning to Spoof your MAC Address");
                ProcessStartInfo spoofmacaddress = new ProcessStartInfo();
                spoofmacaddress.FileName = "cmd.exe";
                spoofmacaddress.Arguments = "/c tmac -n Wi-Fi -r -nr";
                spoofmacaddress.Verb = "runas";
                spoofmacaddress.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(spoofmacaddress);
                MessageBox.Show("Spoofing your MAC Address is Complete!!!");
            }
        }
    }

}

