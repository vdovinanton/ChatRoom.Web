using System;
using System.Data.Entity.Validation;
using ChatRoom.Entity.Interfaces;
using ChatRoom.Entity.Repositories;

namespace ChatRoom.Entity
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChatContext _context;

        public UnitOfWork(ChatContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Messages = new MessageRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IUserRepository Users { get; }
        public IMessageRepository Messages { get; }

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
        }
    }
}
