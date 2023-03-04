using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoCycleDrive
{
    public partial class Form1 : Form
    {
        public float speed, rpm, distance;
        private COMForm comForm;

        public Form1()
        {
            InitializeComponent();

            comForm = new COMForm();
            comForm.ShowDialog();

            SerialSwap.GetInstance().DataReceived += (sender, e) =>
            {
                speed = e.Speed;
                rpm = e.RPM;
                distance = e.Distance;

                speedLabel.Invoke((MethodInvoker)delegate { speedLabel.Text = Math.Round(speed).ToString(); });
                rpmLabel.Invoke((MethodInvoker)delegate { rpmLabel.Text = Math.Round(rpm).ToString(); });
                distanceLabel.Invoke((MethodInvoker)delegate { distanceLabel.Text = Math.Round(distance, 2).ToString() + " км"; });
                consoleBox.Invoke((MethodInvoker)delegate
                {
                    consoleBox.AppendText(speed != 0 ?
                        "Получен оборот колеса: " + Math.Round(speed, 2).ToString() + " км/ч\n"
                        : "Получен стоп-сигнал\n");
                    consoleBox.AppendText("\t" + Math.Round(rpm, 2).ToString() + " об/мин\n");
                });
            };
        }
    }
}
