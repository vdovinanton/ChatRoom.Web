using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Entity.Interfaces
{
    /// <summary>
    /// Abtraction layer between functional and database context
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets<see cref="Users"/> context
        /// </summary>
        IUserRepository Users { get; }

        /// <summary>
        /// Gets<see cref="Messages"/> context
        /// </summary>
        IMessageRepository Messages { get; }

        int Complete();
    }
}
