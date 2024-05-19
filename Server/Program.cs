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
        //Creating list of connected clients
        static List<TcpClient> clients = new List<TcpClient>();

        static int port = 12345;

        static void Main(string[] args)
        {
            //Creating listener
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine($"Server started on port {port}");

            //Accepting new tcp clients
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                //Add client to list of connected clients
                lock (clients)
                {
                    clients.Add(client);
                }
                Console.WriteLine("Client connected.");

                //Run code to handle client on different thread
                Task.Run(() => HandleClient(client));
            }
        }

        static void HandleClient(TcpClient client)
        {
            try
            {
                using (StreamReader reader = new StreamReader(client.GetStream(), Encoding.Unicode))
                {
                    //When a message is recieved, log it and broadcast it to all connected clients
                    while (client.Connected)
                    {
                        //Get message from client
                        string message = reader.ReadLine();

                        //Logging message
                        if (message == null)
                        {
                            Console.WriteLine("Client disconnected.");
                            break;
                        }
                        Console.WriteLine($"Message received: {message}");
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
                //Remove client from list of clients and close the client when client disconnects
                lock (clients)
                {
                    clients.Remove(client);
                }
                client.Close();
            }
        }

        static void BroadcastMessage(string message, TcpClient sender)
        {
            //Broadcast message to all clients exept the oone who sent the message
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
                            Console.WriteLine($"Error sending message to a client: {e.Message}");
                        }
                    }
                }
            }
        }
    }
}
