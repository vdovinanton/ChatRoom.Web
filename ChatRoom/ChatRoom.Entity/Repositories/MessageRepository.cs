using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public override IEnumerable<Message> GetAll()
        {
            return ChatContext.Messages.Include(q => q.User).ToList();
        }
    }
}
