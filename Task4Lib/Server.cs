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
        private Socket serverSocket;
        private IPEndPoint ipEndPoint;

        public delegate void ToLogMessage(string message);
        public event ToLogMessage LogHandler;

        public Server(int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Any, port);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSockets = new List<Socket>();
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
                string message = Encoding.Unicode.GetString(data, 0, bytes);
                LogHandler.Invoke(message);
                Thread.Sleep(10);
                clientSocket.Send(data, bytes, SocketFlags.None);
            }
        }
    }
}
