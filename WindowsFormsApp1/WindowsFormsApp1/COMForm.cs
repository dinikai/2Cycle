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
    public partial class COMForm : Form
    {
        public COMForm()
        {
            InitializeComponent();
            
            comPortsCombo.Items.Clear();
            comPortsCombo.Items.AddRange(SerialPort.GetPortNames());

            refreshBtn.Click += (sender, e) =>
            {
                comPortsCombo.Items.Clear();
                comPortsCombo.Items.AddRange(SerialPort.GetPortNames());
            };

            selectPortBtn.Click += (sender, e) =>
            {
                SerialSwap.GetInstance().serial.PortName = comPortsCombo.SelectedItem.ToString();
                SerialSwap.GetInstance().serial.Open();
                SerialSwap.GetInstance().serial.DiscardInBuffer();
                SerialSwap.GetInstance().serial.DiscardOutBuffer();
                FormClosing -= COMForm_FormClosing;
                Close();
            };

            FormClosing += COMForm_FormClosing;
        }

        private void COMForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
