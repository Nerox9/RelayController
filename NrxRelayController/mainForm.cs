using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HidLibrary;
//using HidSharp;

namespace NrxRelayController
{
    public partial class mainForm : Form
    {
        private const int VendorId  =  1155;
        private const int ProductId = 22352;

        private const int ReportLength = 65;
        private HidDevice device;

        private static readonly Random Random = new Random();

        public mainForm()
        {
            InitializeComponent();

            DeviceConnect();

            toggleSwitch1.device = this.device;
            toggleSwitch2.device = this.device;
            toggleSwitch1.usbData = new byte[] { 0, 0, 0 };
            toggleSwitch2.usbData = new byte[] { 0, 1, 0 };
        }

        private int DeviceConnect()
        {
            device = HidDevices.Enumerate(VendorId, ProductId).FirstOrDefault();

            if (device == null)
            {
                Console.WriteLine("No device connected");
                return 1;
            }
            else
            {
                device.OpenDevice();

                device.Inserted += DeviceAttachedHandler;
                device.Removed += DeviceRemovedHandler;

                device.MonitorDeviceEvents = true;

                //device.ReadReport(ReadReportCallback);

                //device.CloseDevice();

                return 0;
            }
        }

        private void ReadReportCallback(HidReport report)
        {
            Console.WriteLine("recv: {0}", string.Join(", ", report.Data.Select(b => b.ToString("X2"))));
            device.ReadReport(ReadReportCallback);
        }

        private void DeviceAttachedHandler()
        {
            Console.WriteLine("Device attached.");
            //device.ReadReport(ReadReportCallback);
        }

        private void DeviceRemovedHandler()
        {
            Console.WriteLine("Device removed.");
        }
    }
}
