using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EACSpoofer.HWID.Spoof;
using EACSpoofer.HWID.GetHWID;
using EACSpoofer.MacAddressSpoof;
using EACSpoofer.VolumeIDSpoofer;
using System.IO;
using System.Reflection;

namespace EACUserModeSpoofer
{
    public partial class EasyAntiCheatSpoofer : Form
    {
        public static void Extract(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //This is Very Important Code... DON'T CHANGE THIS!!! 

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        public EasyAntiCheatSpoofer()
        {
            InitializeComponent();
            //Show MessageBox!!!
            MessageBox.Show("WARNING: THIS IS SPOOFER FOR AVOID HWID BAN(HARDWARE ID), BE CAREFUL TO USE THIS!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Directory.CreateDirectory(@"C:\Temp");
            Extract("EACUserModeSpoofer", @"C:\Temp", "Resources", "Volumeid.exe");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you Want Spoofing your PC???", "EAC UserMode Spoofer", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MACAddressSpoof macspoof = new MACAddressSpoof();
                macspoof.SpoofMACAddress();
                Spoofer xzspoof = new Spoofer();
                xzspoof.SpoofHWID();
                VolumeIDSpoofer idspoofer = new VolumeIDSpoofer();
                idspoofer.VolumeIDSpoof();
            }
            if(MessageBox.Show("Do you want to show your HWID?!", "EAC UserMode Spoofer", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                GetHWID hwidshow = new GetHWID();
                hwidshow.ShowHWID();
                File.WriteAllText(@"C:\Temp\Readme.txt", "Hi, thank you for using this EAC UserMode Spoofer for Avoiding HWID Ban(EasyAntiCheat.exe is collect information about your Registry Keys" + Environment.NewLine + "EasyAntiCheat.sys is protecting anyone game from Third Party Programs), Made by GlebYoutuber");
                Process.Start("notepad", @"C:\Temp\Readme.txt");
            }
            MessageBox.Show("Spoofing your PC is Completed, Automatic Restart is Begin...");
            Process.Start("shutdown", "/r /t 120");
            Environment.Exit(-1254);
        }
    }
}
