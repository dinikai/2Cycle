using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoCycleDrive
{
    internal class SerialSwap
    {
        private static SerialSwap instance;

        public SerialPort serial;
        public event EventHandler<SerialSwapEventArgs> DataReceived;

        private SerialSwap()
        {
            serial = new SerialPort
            {
                BaudRate = 9600
            };
            serial.DataReceived += Serial_DataReceived;
        }

        public static SerialSwap GetInstance()
        {
            if (instance == null)
                instance = new SerialSwap();
            return instance;
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serial.BytesToRead >= 12)
            {
                byte[] speedBytes = new byte[4];
                byte[] rpmBytes = new byte[4];
                byte[] distanceBytes = new byte[4];

                serial.Read(speedBytes, 0, 4);
                serial.Read(rpmBytes, 0, 4);
                serial.Read(distanceBytes, 0, 4);

                float speed = BitConverter.ToSingle(speedBytes, 0);
                float rpm = BitConverter.ToSingle(rpmBytes, 0);
                float distance = BitConverter.ToSingle(distanceBytes, 0);

                DataReceived(this, new SerialSwapEventArgs(speed, rpm, distance));
            }
        }
    }

    public class SerialSwapEventArgs : EventArgs
    {
        public float Speed { get; set; }
        public float RPM { get; set; }
        public float Distance { get; set; }

        public SerialSwapEventArgs(float speed, float rpm, float distance)
        {
            Speed = speed;
            RPM = rpm;
            Distance = distance;
        }
    }
}
