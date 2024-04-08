using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UdpClient server = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 12345);

            Thread sendThread = new Thread(() =>
            {
                while (true)
                {
                    byte[] data = Encoding.ASCII.GetBytes(DateTime.Now.ToString());
                    server.Send(data, data.Length, endPoint);
                    Thread.Sleep(1000); 
                }
            });
            sendThread.Start();

            while (true)
            {
                byte[] receivedData = server.Receive(ref endPoint);
                string receivedText = Encoding.ASCII.GetString(receivedData);
                Console.WriteLine("Received: " + receivedText);
            }
        }
    }
}
