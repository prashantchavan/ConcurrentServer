using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ConcurrentServer
{
    class Program
    {
        static IPAddress ServerAddress;
        static int port = 8888;
        static void Main(string[] args)
        {
            try
            {
                int Connections = 0;
                ServerAddress = IPAddress.Parse("127.0.0.1");
                TcpListener Listner = new TcpListener(ServerAddress, port);
                TcpClient Client = default(TcpClient);
                Listner.Start();
                Console.WriteLine(">>Server started on {0}:{1}", ServerAddress.ToString(), port);
                while (true)
                {
                    Connections++;
                    Client = Listner.AcceptTcpClient();
                    Console.WriteLine(">>New Client connected, Total clients connected {0}", Connections);
                    ManageClient ClientThread = new ManageClient(Client, Convert.ToString(Connections));
                    ClientThread.run();
                }

                Client.Close();
                Listner.Stop();
                Console.WriteLine("Server Stopped");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Program Main " + ex.Message);
            }
        }
    }
}
