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
    /// A class that represents a client-side network application
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client socket
        /// </summary>
        private Socket clientSocket;

        /// <summary>
        /// Represents a network endpoint of client
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
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public Client(string ip, int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>
        /// Start connection to remote server
        /// </summary>
        public void InitializeClient()
        {
            try
            {
                clientSocket.Connect(ipEndPoint);   
            }
            catch (SocketException)
            {
                return;
            }
        }

        /// <summary>
        /// Send data to remote server
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            clientSocket.Send(data);
            Thread.Sleep(10);
        }

        /// <summary>
        /// Recieve data from remote server
        /// </summary>
        public void RecieveMessage()
        {
            byte[] data = new byte[256];
            int bytes = clientSocket.Receive(data);
            string message = Encoding.Unicode.GetString(data, 0, bytes);
            LogHandler.Invoke(message);
            Thread.Sleep(10);
        }
    }
}
