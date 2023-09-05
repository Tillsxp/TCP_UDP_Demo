using Microsoft.VisualBasic.FileIO;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_UDP_Demo
{
    internal class Program
    {

        static async Task Main(string[] args)


        {
            MyTcpServer tcpServer = new MyTcpServer();
            MyUdpServer udpServer = new MyUdpServer();
            MyTcpClient tcpClient = new MyTcpClient();
            MyUdpClient udpClient = new MyUdpClient();

                Console.WriteLine(
                "1. Start TCP Server för anslutning \n" +
                "2. Start UDP Server för anslutning\n" +
                "3. Skicka meddelande från TCP klient\n" +
                "4. Skicka meddelande från UDP klient\n" +
                "5. Avsluta");

            while (true)
            {



                int opt;
                if (int.TryParse(Console.ReadLine(), out opt))
                    switch (opt)
            {
                case 1:

                            await tcpServer.StartAsync();
                        Console.ReadLine();

                    break;
                case 2:

                            udpServer.Start();
                        
                    break;
                case 3:
                            tcpClient.SendTcpMessage("TcpClient message recieved");
                        
                    break;
                case 4:
                            udpClient.SendUdpMessage("UdpClient message recieved");
                        
                    break;
                case 5:
                            return;
                default:
                    Console.WriteLine("That option doesn't exist. Please try again");
                        
                    break;
            }
                
           
            }
        }
    }
}