using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4Lib
{
    public class MessageHandler
    {
        private List<string> serverLog;
        private List<string> clientLog;

        public MessageHandler()
        {
            serverLog = new List<string>();
            clientLog = new List<string>();
        }

        public List<string> ServerLog { get => serverLog; }
        public List<string> ClientLog { get => serverLog; }

        public void Message(string message, MessageFromEnum messageFrom)
        {
            switch(messageFrom)
            {
                case MessageFromEnum.FromServer:
                    serverLog.Add(message);
                    break;
                case MessageFromEnum.FromClient:
                    clientLog.Add(TransliteParser.Parse(message));
                    break;
            }
        }
    }
}
