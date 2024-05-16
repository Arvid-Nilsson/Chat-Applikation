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
        TcpClient client;
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

            if(client.Connected)
            {
                byte[] utData = Encoding.Unicode.GetBytes(tbxMessage.Text);
                client.GetStream().Write(utData, 0, utData.Length);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress adress = IPAddress.Parse(tbxIp.Text);
            client = new TcpClient();
            client.NoDelay = true;
            client.Connect(adress, port);
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnSend.Enabled = true;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSend.Enabled= false;
        }
    }
}
