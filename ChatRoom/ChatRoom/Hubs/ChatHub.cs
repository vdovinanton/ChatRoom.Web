using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatRoom.Hubs
{
    public class MessageViewModel
    {
        public string SenderName { get; set; }
        public string Body { get; set; }
        public string Attachment { get; set; }
    }

    public class ChatHub : Hub
    {
        public void SendMessage(MessageViewModel message)
        {
            Clients.All.broadcastMessage(message);
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}