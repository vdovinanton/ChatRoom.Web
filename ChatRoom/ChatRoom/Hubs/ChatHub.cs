using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ChatRoom.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}