using System;
using System.Collections.Generic;
using ChatRoom.Entity.Entities;

namespace ChatRoom.Entity.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Check users
        /// </summary>
        /// <returns>False if table is empty</returns>
        bool Any();

        /// <summary>
        /// Add messages to user history
        /// </summary>
        /// <param name="id">User Id</param>
        /// <param name="messages">Collection of the <see cref="Message"/></param>
        void AddMessages(int id, IEnumerable<Message> messages);

        IEnumerable<User> GetUsers();
    }
}
