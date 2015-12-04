using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ConcurrentServer
{
    class ManageClient
    {
        string ClientToken;
        TcpClient Client;
        NetworkStream ns;
        StreamReader sr;
        StreamWriter sw;
        public ManageClient(TcpClient Client, string ClientID)
        {
            this.Client = Client;
            ClientToken = ClientID;
            ns = Client.GetStream();
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
            sw.AutoFlush = true;
        }

        public void run()
        {
            try
            {
                Thread ClientThread = new Thread(ManageStack);
                ClientThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ManageClient Run Function " + ex.Message);
            }
        }

        void ManageStack()
        {
            Stack stk = new Stack(10);
            try
            {
                while (true)
                {
                    string str = sr.ReadLine();
                    Console.WriteLine(">>Command issued by client {0} - {1}",ClientToken,str);
                    if (str.Contains("PUSH"))
                    {
                        string[] UserInput = str.Split(' ');
                        stk.push(Convert.ToInt32(UserInput[1]));
                    }
                    else if (str.Contains("POP"))
                    {
                        stk.pop();
                    }
                    else if (str.Contains("DATA"))
                    {
                        stk.GetStackData();
                    }
                    else if (str.Contains("LOG"))
                    {
                        stk.Log();
                    }
                    else
                    {
                        sw.WriteLine("Invalid Command");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ManageStack function " + ex.Message);
            }
        }
    }
}
