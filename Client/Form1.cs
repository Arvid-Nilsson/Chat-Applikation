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
        public user currentUser = new user();

        public Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //If client exists and is connected
            if (client != null && client.Connected)
            {
                //Take message from textbox and formating it with pronouns and name
                string message = tbxSendMessage.Text;
                message = currentUser.formatMessage(message);

                //Sending message to server 
                writer.WriteLine(message);
                writer.Flush(); 

                //Write message to textbox and clearing sending textbox
                Invoke(new MethodInvoker(() =>
                {
                    tbxMessages.AppendText(message + Environment.NewLine);
                }));
                tbxSendMessage.Text = string.Empty;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Create client
            IPAddress address = IPAddress.Parse(tbxIp.Text);
            client = new TcpClient();
            client.NoDelay = true;
            client.Connect(address, port);

            //Create writer and reader to comunicate with server
            writer = new StreamWriter(client.GetStream(), Encoding.Unicode);
            reader = new StreamReader(client.GetStream(), Encoding.Unicode);
            writer.AutoFlush = true;

            //Set user credentials
            currentUser.username = tbxName.Text;
            currentUser.pronouns = tbxPronouns.Text;

            btnConnect.Enabled = false;
            btnDisconnect.Enabled = true;
            btnSend.Enabled = true;
            tbxName.Enabled = false;
            tbxPronouns.Enabled = false;

            //Runs receiveMessages function in parallel 
            Task.Run(() => ReceiveMessages());
        }

        private void ReceiveMessages()
        {
            try
            {
                //writes all incomming messages to textbox
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
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //Disconnect from server
            if (writer != null)
                writer.Close();
            if (reader != null)
                reader.Close();
            if (client != null)
                client.Close();

            btnConnect.Enabled = true;
            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;
            tbxName.Enabled = true;
            tbxPronouns.Enabled = true;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            //Disconnect from server
            if (writer != null)
                writer.Close();
            if (reader != null)
                reader.Close();
            if (client != null)
                client.Close();

            base.OnFormClosing(e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}