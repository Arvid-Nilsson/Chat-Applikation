using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        private TcpClient client;
        private StreamWriter writer;
        private StreamReader reader;
        private int port = 12345;

        public Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialization code if needed
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                string message = tbxSendMessage.Text;
                writer.WriteLine(message);
                writer.Flush(); // Ensure the message is sent immediately
                Invoke(new MethodInvoker(() =>
                {
                    tbxMessages.AppendText(message + Environment.NewLine);
                }));
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Parse(tbxIp.Text);
            client = new TcpClient();
            client.NoDelay = true;
            client.Connect(address, port);

            writer = new StreamWriter(client.GetStream(), Encoding.Unicode);
            reader = new StreamReader(client.GetStream(), Encoding.Unicode);

            writer.AutoFlush = true; // Automatically flush after every write

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnSend.Enabled = true;

            Task.Run(() => ReceiveMessages());
        }

        private void ReceiveMessages()
        {
            try
            {
                while (client.Connected)
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        Invoke(new MethodInvoker(() =>
                        {
                            tbxMessages.AppendText(message + Environment.NewLine);
                        }));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (writer != null)
                writer.Close();
            if (reader != null)
                reader.Close();
            if (client != null)
                client.Close();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (writer != null)
                writer.Close();
            if (reader != null)
                reader.Close();
            if (client != null)
                client.Close();

            base.OnFormClosing(e);
        }
    }
}