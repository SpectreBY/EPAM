using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4Lib;

namespace Task4
{
    [TestClass]
    public class ClientServerTests
    {
        private Server server;
        private Client client1;
        private Client client2;
        private Client client3;
        private Client client4;
        private Client client5;

        private MessageHandler messageHandler;

        private List<string> serverMessagesCase = new List<string>
        {
            "Клиент 1",
            "Клиент 2",
            "Клиент 3",
            "Клиент 4",
            "Клиент 5"
        };
        private List<string> clientMessagesCase = new List<string>
        {
            "banan",
            "khlyeb",
            "yabloko",
            "privyet",
            "soobshchyeniye"
        };

        private List<string> serverMessagesResult;
        private List<string> clientMessagesResult;

        [TestMethod]
        public void ServerLogMessagesTest()
        {
            serverMessagesResult = new List<string>();
            server = new Server(4455);
            client1 = new Client("127.0.0.1", 4455);
            client2 = new Client("127.0.0.1", 4455);
            client3 = new Client("127.0.0.1", 4455);
            client4 = new Client("127.0.0.1", 4455);
            client5 = new Client("127.0.0.1", 4455);
            
            server.LogHandler += (message) =>
            {
                serverMessagesResult.Add(message);
            };

            server.InitializeServer();
            client1.InitializeClient();
            client2.InitializeClient();
            client3.InitializeClient();
            client4.InitializeClient();
            client5.InitializeClient();

            client1.SendMessage("Клиент 1");
            client2.SendMessage("Клиент 2");
            client3.SendMessage("Клиент 3");
            client4.SendMessage("Клиент 4");
            client5.SendMessage("Клиент 5");

            bool isSame = true;

            foreach (var item in serverMessagesResult)
            {
                if (!serverMessagesCase.Contains(item))
                {
                    isSame = false;
                }
            }

            Assert.AreEqual(isSame, true);
        }

        [TestMethod]
        public void ClientGetMessageTest()
        {
            clientMessagesResult = new List<string>();
            server = new Server(4455);
            client1 = new Client("127.0.0.1", 4455);
            client2 = new Client("127.0.0.1", 4455);
            client3 = new Client("127.0.0.1", 4455);
            client4 = new Client("127.0.0.1", 4455);
            client5 = new Client("127.0.0.1", 4455);
            
            messageHandler = new MessageHandler();

            server.LogHandler += (message) => { };

            client1.LogHandler += (message) =>
            {
                clientMessagesResult.Add(TransliteParser.Parse(message));
            };
            client2.LogHandler += (message) =>
            {
                clientMessagesResult.Add(TransliteParser.Parse(message));
            };
            client3.LogHandler += (message) =>
            {
                clientMessagesResult.Add(TransliteParser.Parse(message));
            };
            client4.LogHandler += (message) =>
            {
                clientMessagesResult.Add(TransliteParser.Parse(message));
            };
            client5.LogHandler += (message) =>
            {
                clientMessagesResult.Add(TransliteParser.Parse(message));
            };

            server.InitializeServer();
            client1.InitializeClient();
            client2.InitializeClient();
            client3.InitializeClient();
            client4.InitializeClient();
            client5.InitializeClient();

            client1.SendMessage("банан");
            client2.SendMessage("хлеб");
            client3.SendMessage("яблоко");
            client4.SendMessage("привет");
            client5.SendMessage("сообщение");

            client1.RecieveMessage();
            client2.RecieveMessage();
            client3.RecieveMessage();
            client4.RecieveMessage();
            client5.RecieveMessage();

            bool isSame = true;

            foreach (var item in clientMessagesResult)
            {
                if (!clientMessagesCase.Contains(item))
                {
                    isSame = false;
                }
            }

            Assert.AreEqual(isSame, true);
        }
    }
}
