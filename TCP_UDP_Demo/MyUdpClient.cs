using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_UDP_Demo
{
    internal class MyUdpClient
    {
        public void SendUdpMessage(string message)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, Settings.UDP_PORT);

            byte[] data = Encoding.ASCII.GetBytes(message);
            udpClient.Send(data, data.Length, serverEndPoint);
            Console.WriteLine("UDP Message sent:" +message);

            udpClient.Close();
        }
        
    }
}
