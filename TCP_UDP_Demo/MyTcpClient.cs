using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TCP_UDP_Demo
{
    internal class MyTcpClient
    {
        public void SendTcpMessage(string message)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Loopback, Settings.TCP_PORT);
            NetworkStream stream = tcpClient.GetStream();

            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Console.WriteLine("TCP Message sent: " + message);

            stream.Close();
            tcpClient.Close();
        }

    }
}
