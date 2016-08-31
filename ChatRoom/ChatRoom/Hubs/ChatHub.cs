using ChatRoom.Entity;
using ChatRoom.Entity.Interfaces;
using ChatRoom.Model;
using Microsoft.AspNet.SignalR;

namespace ChatRoom.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUnitOfWork _repository;
        public ChatHub()
        {
            _repository = new UnitOfWork(new ChatContext());
        }

        public void SendMessage(MessageViewModel message)
        {
            Clients.All.broadcastMessage(message);

            _repository.Users.AddMessages(message.SenderId, message.Body, message.Attachment);
            _repository.Complete();
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}