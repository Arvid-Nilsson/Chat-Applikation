using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Server
    {
        static List<TcpClient> clients = new List<TcpClient>();
        static int port = 12345;

        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Server started and listening on port " + port);

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                lock (clients)
                {
                    clients.Add(client);
                }
                Console.WriteLine("Client connected.");
                Task.Run(() => HandleClient(client));
            }
        }

        static void HandleClient(TcpClient client)
        {
            try
            {
                using (StreamReader reader = new StreamReader(client.GetStream(), Encoding.Unicode))
                {
                    while (client.Connected)
                    {
                        string message = reader.ReadLine();
                        if (message == null)
                        {
                            Console.WriteLine("Client disconnected.");
                            break;
                        }
                        Console.WriteLine("Received: " + message);
                        BroadcastMessage(message, client);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                lock (clients)
                {
                    clients.Remove(client);
                }
                client.Close();
            }
        }

        static void BroadcastMessage(string message, TcpClient sender)
        {
            lock (clients)
            {
                foreach (var client in clients)
                {
                    if (client != sender)
                    {
                        try
                        {
                            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.Unicode);
                            writer.WriteLine(message);
                            writer.Flush();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error sending message to a client: " + e.Message);
                        }
                    }
                }
            }
        }
    }
}
