using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4Lib
{
    public class Client
    {
        private Socket clientSocket;
        private IPEndPoint ipEndPoint;

        public delegate void ToLogMessage(string message, MessageFromEnum messageFrom);
        public event ToLogMessage LogHandler;

        public Client(string ip, int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void InitializeClient()
        {
            try
            {
                clientSocket.Connect(ipEndPoint);   
            }
            catch (SocketException)
            {

            }
        }

        public void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            clientSocket.Send(data);
            Thread.Sleep(10);
        }

        public void RecieveMessage()
        {
            byte[] data = new byte[256];
            int bytes = clientSocket.Receive(data);
            string message = Encoding.Unicode.GetString(data, 0, bytes);
            LogHandler(message, MessageFromEnum.FromClient);
        }
    }
}
