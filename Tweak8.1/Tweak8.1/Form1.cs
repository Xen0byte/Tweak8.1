using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using Microsoft.VisualBasic.Devices;

namespace Tweak8._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //
        //      Win32 Provider (for getting all software/hardware info)
        //

        public static string OSbit()
        {
            bool is64bit = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"));
            if (is64bit == true)
                return "64-Bit";
            else
                return "32-Bit";
        }

        static ulong GetTotalMemoryInBytes()
        {
            return new ComputerInfo().TotalPhysicalMemory;
        }

        public ulong MemInMB = GetTotalMemoryInBytes() / 1048576;

        static ulong GetAvailableMemoryInBytes()
        {
            return new ComputerInfo().AvailablePhysicalMemory;
        }

        public ulong AvMemInMB = GetAvailableMemoryInBytes() / 1048576;

        static string GetOSVersion()
        {
            return new ComputerInfo().OSVersion;
        }

        public static string SendBackProcessorName()
        {
            ManagementObjectSearcher mosProcessor = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            string ProcName = null;

            foreach (ManagementObject moProcessor in mosProcessor.Get())
            {
                if (moProcessor["name"] != null)
                {
                    ProcName = moProcessor["name"].ToString();
                }
            }

            ProcName = ProcName
                   .Replace("(TM)", "™")
                   .Replace("(tm)", "™")
                   .Replace("(R)", "®")
                   .Replace("(r)", "®")
                   .Replace("(C)", "©")
                   .Replace("(c)", "©")
                   .Replace("    ", " ")
                   .Replace("  ", " ");

            return ProcName;
        }

        public string cpuName = SendBackProcessorName();

        public static string GetBoardMaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Manufacturer: " + wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "Manufacturer: Unknown";
        }

        public static string GetBoardModel()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Model: " + wmi.GetPropertyValue("Model").ToString();
                }
                catch { }
            }
            return "Model: Unknown";
        }

        public static string GetBIOSmanufacturer()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Manufacturer: " + wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            return "Manufacturer: Unknown";
        }

        public static string GetBIOSvesion()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BIOS");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return "Version: " + wmi.GetPropertyValue("SMBIOSBIOSVersion").ToString();
                }
                catch { }
            }
            return "Version: Unknown";
        }

        public static string GPUname()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Name").ToString();
                }
                catch { }
            }
            return "GPU: Unknown";
        }

        public static string SoundCardName()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_SoundDevice");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Description").ToString() + " !? (do an 'if primary' check)";
                }
                catch { }
            }
            return "Sound Card: Unknown";
        }

        private void HideAll()
        {
            pictureBox1.Visible = false;
            tabControl2.Visible = false;
            tabControl3.Visible = false;
            tabControl4.Visible = false;
            tabControl5.Visible = false;
            tabControl6.Visible = false;
            tabControl7.Visible = false;
            tabControl8.Visible = false;
            tabControl9.Visible = false;
            tabControl1.Visible = false;
            label1.Font = new Font(label1.Font, FontStyle.Regular);
            label2.Font = new Font(label2.Font, FontStyle.Regular);
            label3.Font = new Font(label2.Font, FontStyle.Regular);
            label4.Font = new Font(label2.Font, FontStyle.Regular);
            label5.Font = new Font(label2.Font, FontStyle.Regular);
            label6.Font = new Font(label2.Font, FontStyle.Regular);
            label7.Font = new Font(label2.Font, FontStyle.Regular);
            label8.Font = new Font(label2.Font, FontStyle.Regular);
            label9.Font = new Font(label2.Font, FontStyle.Regular);
        }

        private void EnableSet(int i)
        {
            HideAll();

            if (i == 1)
            {
                label11.Text = GetOSFriendlyName() + ", " + OSbit() + " (Build " + GetOSVersion() + ")";
                label13.Text = cpuName;
                label14.Text = "Processor Architecture: " + GetCpuArch();
                label16.Text = MemInMB + " MB of RAM (" + AvMemInMB + " MB Available)";
                label18.Text = GetBoardMaker();
                label19.Text = GetBoardModel();
                label21.Text = GetBIOSmanufacturer();
                label24.Text = GetBIOSvesion();
                label23.Text = GPUname();
                label26.Text = SoundCardName();
                tabControl1.Visible = true;
                label1.Font = new Font(label1.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 2)
            {
                tabControl2.Visible = true;
                label2.Font = new Font(label2.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 3)
            {
                tabControl3.Visible = true;
                label3.Font = new Font(label3.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 4)
            {
                tabControl4.Visible = true;
                label4.Font = new Font(label4.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 5)
            {
                tabControl5.Visible = true;
                label5.Font = new Font(label5.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 6)
            {
                tabControl6.Visible = true;
                label6.Font = new Font(label6.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 7)
            {
                tabControl7.Visible = true;
                label7.Font = new Font(label7.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 8)
            {
                tabControl8.Visible = true;
                label8.Font = new Font(label8.Font, FontStyle.Underline | FontStyle.Bold);
            }
            else if (i == 9)
            {
                tabControl9.Visible = true;
                label9.Font = new Font(label9.Font, FontStyle.Underline | FontStyle.Bold);
            }
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label.Font.Bold)
                label.Font = new Font(label.Font, FontStyle.Bold | FontStyle.Underline);
            else
                label.Font = new Font(label.Font, FontStyle.Underline);
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label.Font.Bold)
                label.Font = new Font(label.Font, FontStyle.Bold);
            else
                label.Font = new Font(label.Font, FontStyle.Regular);
        }

        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }

            if (Environment.OSVersion.ServicePack.Length == 0)
                return result;
            else
                return result + " " + Environment.OSVersion.ServicePack;
        }

        public static string GetCpuArch()
        {
            ManagementScope scope = new ManagementScope();
            ObjectQuery query = new ObjectQuery("SELECT Architecture FROM Win32_Processor");
            ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection results = search.Get();

            ManagementObjectCollection.ManagementObjectEnumerator e = results.GetEnumerator();
            e.MoveNext();
            ushort arch = (ushort)e.Current["Architecture"];

            switch (arch)
            {
                case 0:
                    return "x86";
                case 1:
                    return "MIPS";
                case 2:
                    return "Alpha";
                case 3:
                    return "PowerPC";
                case 6:
                    return "Itanium";
                case 9:
                    return "x64";
                default:
                    return "Unknown Architecture (WMI ID " + arch.ToString() + ")";
            }
        }

// Labels
        private void label1_Click(object sender, EventArgs e)
        {
            EnableSet(1);
        }
        private void label2_Click(object sender, EventArgs e)
        {
            EnableSet(2);
        }
        private void label3_Click(object sender, EventArgs e)
        {
            EnableSet(3);
        }
        private void label4_Click(object sender, EventArgs e)
        {
            EnableSet(4);
        }
        private void label5_Click(object sender, EventArgs e)
        {
            EnableSet(5);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            EnableSet(6);
        }
        private void label7_Click(object sender, EventArgs e)
        {
            EnableSet(7);
        }
        private void label8_Click(object sender, EventArgs e)
        {
            EnableSet(8);
        }
        private void label9_Click(object sender, EventArgs e)
        {
            EnableSet(9);
            pictureBox1.Visible = true;
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
