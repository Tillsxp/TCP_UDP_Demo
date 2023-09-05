using System.Net.Sockets;
using System.Net;
using System.Text;
using TCP_UDP_Demo;
using System.Runtime.CompilerServices;

namespace TCP_UDP_Demo
{
    internal class MyTcpServer
    {
        public async Task StartAsync()
        {

            TcpListener tcpListener = new TcpListener(IPAddress.Any, Settings.TCP_PORT);
            tcpListener.Start();
            Console.WriteLine("TCP Server started. Waiting for connections...");
            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                Console.WriteLine("TCP Client connected.");
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine("TCP Message received: " + message);
                stream.Close();
                client.Close();
                
            }
            
        }

    }
}
