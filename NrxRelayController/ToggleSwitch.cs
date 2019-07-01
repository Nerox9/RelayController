using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using HidLibrary;

namespace NrxRelayController
{
    public partial class ToggleSwitch : UserControl
    {
        [Description("Toggle Switch Active Background Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color ActiveColor { get; set; }
        [Description("Toggle Switch Passive Background Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color PassiveColor { get; set; }
        [Description("Toggle Switch Button Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color ButtonColor { get; set; }
        [Description("Toggle Switch Label"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Label SwitchLabel { get; set; }

        private Boolean active = false;
        private Point activePoint;
        private Point passivePoint;
        private RectangleF buttonRectangle;
        private Timer timer;
        private PointF buttonPosition;
        private StringFormat stringFormat = new StringFormat();

        public HidDevice device;
        public byte[] usbData;

        public ToggleSwitch()
        {
            // Set Default value if it is not defined in properties
            ActiveColor = Color.White;
            PassiveColor = Color.FromArgb(64, 64, 64);
            ButtonColor = Color.Silver;
            this.Text = "ON";

            InitializeComponent();

            SetTimer();

            this.passivePoint = new Point(0, 18);
            this.activePoint = new Point(0, 0);
            this.buttonPosition = passivePoint;

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }

        public Boolean isActive() { return active; }
        public void deactivateSwitch() { active = false; timer.Start(); this.Refresh(); }
        public void ToggleSwitchText(String str) { SwitchLabel.Text = str; }
        public String ToggleSwitchText() { return SwitchLabel.Text; }
        public void RefreshLabel() { SwitchLabel.Refresh(); }

        public void ToggleSwitch_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = this.Parent.BackColor;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            SolidBrush brush = new SolidBrush(active ? ActiveColor : PassiveColor);
            SolidBrush buttonBrush = new SolidBrush(ButtonColor);
            RectangleF rectangle = new RectangleF(0, 0, Width, Height - 1);
            Rectangle buttonTextRectangle = new Rectangle(0, 0, Width - 1, 26);
            buttonRectangle = new RectangleF(0, 0, Width - 1, 24);
            buttonRectangle.Location = buttonPosition;
            buttonTextRectangle.Location = new Point((int)buttonPosition.X, (int)buttonPosition.Y);

            GraphicsPath rRect = MakeRoundedRect(rectangle, Width / 2, Height / 3, true, true, true, true);
            e.Graphics.FillPath(brush, rRect);
            e.Graphics.FillEllipse(buttonBrush, buttonRectangle);
            e.Graphics.DrawString(this.Text, this.Font, brush, buttonTextRectangle, stringFormat);
        }

        private void toggleSwitch_Click(object sender, EventArgs e)
        {

        }

        private void ToggleSwitch_ButtonTimer(object sender, EventArgs e)
        {
            PointF button_loc = buttonRectangle.Location;
            int step = 3;

            if (active)
                step *= -1;

            buttonRectangle.Location = buttonPosition;

            if ((active && (button_loc.Y == activePoint.Y)) || (!active && (button_loc.Y == passivePoint.Y)))
            {
                //this.Refresh();
                timer.Stop();
            }
            else if ((button_loc.Y >= activePoint.Y) && (button_loc.Y <= passivePoint.Y))
            {
                buttonPosition = new PointF(0, buttonRectangle.Location.Y + step);
                this.Refresh();
            }
            else
            {
                timer.Stop();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (device == null)
            {
                Console.WriteLine("Device not connected");
                return;
            }

            if (usbData == null)
            {
                Console.WriteLine("USB data is null");
                return;
            }

            if (!active)
            {
                //buttonControl.deactivateAll();
                active = true;

                usbData[2] = Convert.ToByte(active);
                HidReport report = new HidReport(usbData.Length, new HidDeviceData(usbData, HidDeviceData.ReadStatus.Success));
                device.WriteReport(report);

                Console.WriteLine("Relay" + Name[Name.Length - 1] + " is " + "closed");

                timer.Start();
            }
            else
            {
                active = false;

                usbData[2] = Convert.ToByte(active);
                HidReport report = new HidReport(usbData.Length, new HidDeviceData(usbData, HidDeviceData.ReadStatus.Success));
                device.WriteReport(report);

                Console.WriteLine("Relay" + Name[Name.Length - 1] + " is " + "opened");

                timer.Start();
            }
            this.Refresh();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new Timer();
            // Hook up the Elapsed event for the timer. 
            timer.Interval = 10;
            timer.Tick += new EventHandler(ToggleSwitch_ButtonTimer);
            //timer.Start();
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
        }
    }
}
