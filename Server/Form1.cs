using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public partial class Form1 : Form
    {
        TcpListener listener;
        TcpClient client;
        int port = 12345;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            btnStart.Enabled = false;
            StartReciving();
        }



        public async Task StartReciving()
        {
            while (true)
            {
                client = await listener.AcceptTcpClientAsync();
                ManageClient(client);
            }
        }

        private async void ManageClient(TcpClient client)
        {
            byte[] buffert = new byte[1024];
            int n;

            try
            {
                while ((n = await client.GetStream().ReadAsync(buffert, 0, buffert.Length)) != 0)
                {
                    string meddelande = Encoding.Unicode.GetString(buffert, 0, n);
                    LoggaMeddelande(meddelande);

                    // Skicka meddelandet till alla anslutna klienter om du vill
                    //SkickaTillAllaKlienter(meddelande);
                }
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); }

            client.Close();
        }

        private void LoggaMeddelande(string meddelande)
        {
            if (tbxIncommingMessages.InvokeRequired)
            {
                tbxIncommingMessages.Invoke(new MethodInvoker(delegate { tbxIncommingMessages.AppendText(meddelande + Environment.NewLine); }));
            }
            else
            {
                tbxIncommingMessages.AppendText(meddelande + Environment.NewLine);
            }
        }


        public async void StartReading(TcpClient k)
        {
            byte[] buffert = new byte[1024];
            int n = 0;
            try
            {
                n = await k.GetStream().ReadAsync(buffert, 0, buffert.Length);
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            tbxIncommingMessages.AppendText(Encoding.Unicode.GetString(buffert, 0, n));

            StartReading(k);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
