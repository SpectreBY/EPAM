using System;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4Lib;

namespace Task4
{
    [TestClass]
    public class UnitTest1
    {
        private Server server;
        private Client client1;
        private Client client2;
        private Client client3;
        private Client client4;
        private Client client5;
        private MessageHandler messageHandler;

        [TestMethod]
        public void ServerLogMessagesTest()
        {
            client1 = new Client("127.0.0.1", 4455);
            client2 = new Client("127.0.0.1", 4455);
            client3 = new Client("127.0.0.1", 4455);
            client4 = new Client("127.0.0.1", 4455);
            client5 = new Client("127.0.0.1", 4455);
            server = new Server(4455);

            messageHandler = new MessageHandler();
            server.LogHandler += messageHandler.Message;

            server.InitializeServer();
            client1.InitializeClient();
            client2.InitializeClient();
            client3.InitializeClient();
            client4.InitializeClient();
            client5.InitializeClient();

            client1.SendMessage("Клиент 1");

            client1.SendMessage("Клиент 2");
            client1.SendMessage("Клиент 3");
            client1.SendMessage("Клиент 4");
            client1.SendMessage("Клиент 5");

            int logMessagesCount = 5;

            Assert.AreEqual(logMessagesCount, messageHandler.ServerLog.Count);
        }

        [TestMethod]
        public void ClientGetMessageTest()
        {
            client1 = new Client("127.0.0.1", 4455);
            server = new Server(4455);

            messageHandler = new MessageHandler();
            server.LogHandler += messageHandler.Message;

            server.InitializeServer();
            client1.InitializeClient();

            client1.SendMessage("Клиент 1");


            int logMessagesCount = 5;

            Assert.AreEqual(logMessagesCount, messageHandler.ServerLog.Count);
        }
    }
}
