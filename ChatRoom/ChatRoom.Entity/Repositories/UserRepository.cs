using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ChatRoom.Entity.Entities;
using ChatRoom.Entity.Interfaces;

namespace ChatRoom.Entity.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private ChatContext ChatContext => Context as ChatContext;
        public UserRepository(DbContext context) : base(context)
        {
        }

        public bool Any()
        {
            return ChatContext.Users.Any();
        }
        
        public void AddMessages(int id, IEnumerable<Message> messages)
        {
            var user = ChatContext.Users.ToList().FirstOrDefault(q => q.Id == id);
            foreach (var message in messages)
            {
                user?.Messages.Add(message);
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return ChatContext.Users.Include(q => q.Messages).ToList();
        }
    }
}
