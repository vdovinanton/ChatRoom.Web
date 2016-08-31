using System.Data.Entity;
using ChatRoom.Entity.Entities;

namespace ChatRoom.Entity
{
    public class ChatContext: DbContext
    {
        public ChatContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
}
