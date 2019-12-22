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
    /// <summary>
    /// A class that represents a server-side network application
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Collection of connected clients
        /// </summary>
        private List<Socket> clientSockets;

        /// <summary>
        /// Server socket
        /// </summary>
        private Socket serverSocket;

        /// <summary>
        /// Represents a network endpoint of server
        /// </summary>
        private IPEndPoint ipEndPoint;

        /// <summary>
        /// The delegate that stores the reference to the anonymous method
        /// </summary>
        /// <param name="message"></param>
        public delegate void ToLogMessage(string message);

        /// <summary>
        /// An event that fires when receiving data from a client
        /// </summary>
        public event ToLogMessage LogHandler;

        /// <summary>
        /// Contructor of class
        /// </summary>
        /// <param name="port"></param>
        public Server(int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Any, port);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSockets = new List<Socket>();
        }

        /// <summary>
        /// Start listening of port for accept connections
        /// </summary>
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
                return;
            }
        }

        /// <summary>
        /// Asynchronous accept connections from clients
        /// </summary>
        /// <param name="ar"></param>
        private void AcceptCallBack(IAsyncResult ar)
        {
            Socket clientSocket = serverSocket.EndAccept(ar);
            clientSockets.Add(clientSocket);
            Thread thread = new Thread(ClientHandler);
            thread.Start(clientSocket);
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        /// <summary>
        /// Receiving and sending data received from the client is performed in a separate threads
        /// </summary>
        /// <param name="socket"></param>
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
