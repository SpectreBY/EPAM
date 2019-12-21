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
    public class Server
    {
        private List<Socket> clientSockets;
        private List<Thread> threads;
        private Socket serverSocket;
        private IPEndPoint ipEndPoint;
 

        public Server(int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Any, port);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSockets = new List<Socket>();
            threads = new List<Thread>();
        }

        public void InitializeServer()
        {
            try
            {
                serverSocket.Bind(ipEndPoint);
                serverSocket.Listen(0);
                Socket client = serverSocket.Accept();
                clientSockets.Add(client);
                Thread thread = new Thread(new ParameterizedThreadStart(SendRecieveMessage));
                thread.Start(client);
            }
            catch(SocketException)
            {

            }
        }

        public void SendRecieveMessage(object client)
        {
            Socket socket = (Socket)client;
            StringBuilder message = new StringBuilder();
            int bytes = 0;
            byte[] byteMessage = new byte[256];
            while(true)
            {
                bytes = socket.Receive(byteMessage);
                message.AppendLine()
            }
        }
    }
}
