using System.Data.Entity;
using ChatRoom.Entity.Entities;
using ChatRoom.Entity.Interfaces;

namespace ChatRoom.Entity.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        private ChatContext ChatContext => Context as ChatContext;
        public MessageRepository(DbContext context) : base(context)
        {
        }
    }
}
