using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatRoom.Entity.Entities;

namespace ChatRoom.Entity.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
    }
}
