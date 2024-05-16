using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Client : Form
    {
        TcpClient klient;
        int port = 12345;
        public Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            IPAddress adress = IPAddress.Parse(tbxIp.Text);
            klient = new TcpClient();
            klient.NoDelay = true;
            klient.Connect(adress, port);

            if(klient.Connected)
            {
                byte[] utData = Encoding.Unicode.GetBytes(tbxMessage.Text);
                klient.GetStream().Write(utData, 0, utData.Length);
                klient.Close();

            }
        }
    }
}
