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
            int Connections = 0;
            ServerAddress = IPAddress.Parse("127.0.0.1");
            TcpListener Listner = new TcpListener(ServerAddress, port);
            TcpClient Client = default(TcpClient);
            Listner.Start();

            while (true)
            {
                Connections++;
                Client = Listner.AcceptTcpClient();
                Console.WriteLine(">>New Client connected, Total clients connected {0}", Connections);
                ManageClient ClientThread = new ManageClient(Client,Convert.ToString(Connections));
                ClientThread.run();
            }
        }
    }
}
