using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace NguyenHoangLong
{
    public partial class Form1 : Form
    {
        string data = "";
        string nhietdo = "";
        public Form1()
        {
            InitializeComponent();
        }

        string[] pause = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "14880" };
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] listnamecom = SerialPort.GetPortNames();//quét tên các cổng com add vào listnamecom
            congCOM.Items.AddRange(listnamecom);//sau quét tên các cổng com thì add nó vào combobox tên listcom
            congBaud.Items.AddRange(pause);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(congCOM.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn cổng COM", "Thông Báo");
            }    
            else if(congBaud.Text =="")
            {
                MessageBox.Show("Bạn chưa chọn tốc độ Baud", "Thông Báo");
            } 
            
            if(serialPort1.IsOpen)
            {
                serialPort1.Close();
                btnConnect.Text = "Connect";

            }   
            else
            {
                serialPort1.PortName = congCOM.Text;
                serialPort1.BaudRate = int.Parse(congBaud.Text);
                serialPort1.Open();
                btnConnect.Text = "Disconnect";
            }    

        }
        bool led1 = true;
        private void den1_Click(object sender, EventArgs e)
        {
            try
            {
                if(led1 == true)
                {
                    serialPort1.Write("DEN11");
                    den1.Text = "OFF";
                    imgden1.Image = global::NguyenHoangLong.Properties.Resources.denon;
                    led1 = false;
                    
                }

                else
                {
                    serialPort1.Write("DEN10");
                    den1.Text = "ON";
                    imgden1.Image = global::NguyenHoangLong.Properties.Resources.denoff;
                    led1 = true;

                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool led2 = true;
        private void den2_Click(object sender, EventArgs e)
        {
            try
            {
                if (led2 == true)
                {
                    serialPort1.Write("DEN21");
                    den2.Text = "OFF";
                    imgden2.Image = global::NguyenHoangLong.Properties.Resources.denon;
                    led2 = false;

                }

                else
                {
                    serialPort1.Write("DEN20");
                    den2.Text = "ON";
                    imgden2.Image = global::NguyenHoangLong.Properties.Resources.denoff;
                    led2 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool led3 = true;
        private void den3_Click(object sender, EventArgs e)
        {
            try
            {
                if (led3 == true)
                {
                    serialPort1.Write("DEN31");
                    den3.Text = "OFF";
                    imgden3.Image = global::NguyenHoangLong.Properties.Resources.denon;
                    led3 = false;

                }

                else
                {
                    serialPort1.Write("DEN30");
                    den3.Text = "ON";
                    imgden3.Image = global::NguyenHoangLong.Properties.Resources.denoff;
                    led3 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
        bool led4 = true;
        private void den4_Click(object sender, EventArgs e)
        {
            try
            {
                if (led4 == true)
                {
                    serialPort1.Write("DEN41");
                    den4.Text = "OFF";
                    imgden4.Image = global::NguyenHoangLong.Properties.Resources.denon;
                    led4 = false;

                }

                else
                {
                    serialPort1.Write("DEN40");
                    den4.Text = "ON";
                    imgden4.Image = global::NguyenHoangLong.Properties.Resources.denoff;
                    led4 = true;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort1.ReadTo("\n");
            this.Invoke(new EventHandler(serialFunction));
        }
        private void serialFunction(object sender, EventArgs e)
        {
            nhietdo = data.Substring(0, 2);
            temp.Text = nhietdo + "°C";
        }
    }
}
