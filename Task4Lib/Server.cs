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

        public delegate void ToLogMessage(string message, MessageFromEnum messageFrom);
        public event ToLogMessage LogHandler;

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
                serverSocket.BeginAccept(AcceptCallBack, null);
            }
            catch(SocketException)
            {

            }
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            clientSockets.Add(clientSocket);
            Thread thread = new Thread(ClientHandler);
            thread.Start(clientSocket);
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        private void ClientHandler(object socket)
        {
            Socket clientSocket = (Socket)socket;
            while (true)
            {
                byte[] data = new byte[256];
                int bytes = clientSocket.Receive(data);
                LogHandler(Encoding.Unicode.GetString(data, 0, bytes), MessageFromEnum.FromServer);
                //clientSocket.Send(data);
            }
        }
    }
}
