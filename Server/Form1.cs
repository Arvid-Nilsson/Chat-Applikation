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
        TcpListener lyssnare;
        TcpClient klient;
        int port = 12345;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                lyssnare = new TcpListener(IPAddress.Any, port);
                lyssnare.Start();
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            btnStart.Enabled = false;
            StartaMottagning();
        }



        public async Task StartaMottagning()
        {
            while (true)
            {
                TcpClient klient = await lyssnare.AcceptTcpClientAsync();
                HanteraKlient(klient);
            }
        }

        private async void HanteraKlient(TcpClient klient)
        {
            byte[] buffert = new byte[1024];
            int n;

            try
            {
                while ((n = await klient.GetStream().ReadAsync(buffert, 0, buffert.Length)) != 0)
                {
                    string meddelande = Encoding.Unicode.GetString(buffert, 0, n);
                    LoggaMeddelande(meddelande);

                    // Skicka meddelandet till alla anslutna klienter om du vill
                    // SkickaTillAllaKlienter(meddelande);
                }
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); }

            klient.Close();
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


        public async void StartaLäsning(TcpClient k)
        {
            byte[] buffert = new byte[1024];
            int n = 0;
            try
            {
                n = await k.GetStream().ReadAsync(buffert, 0, buffert.Length);
            }
            catch (Exception error) { MessageBox.Show(error.Message, Text); return; }

            tbxIncommingMessages.AppendText(Encoding.Unicode.GetString(buffert, 0, n));

            StartaLäsning(k);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
