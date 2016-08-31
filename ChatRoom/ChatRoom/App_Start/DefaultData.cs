using System.Collections.Generic;
using ChatRoom.Entity;
using ChatRoom.Entity.Entities;

namespace ChatRoom
{
    public class DefaultData
    {
        /// <summary>
        /// For the first initialize
        /// </summary>
        public static void Initializer()
        {
            using (var db = new UnitOfWork(new ChatContext()))
            {
                if (!db.Users.Any())
                {
                    var user1 = new User
                    {
                        Name = "Taras Shevchenko",
                    };

                    var user2 = new User
                    {
                        Name = "Ivan Franko",
                    };

                    var user3 = new User
                    {
                        Name = "Ivan Levytskyj",
                    };

                    var user4 = new User
                    {
                        Name = "Larisa Kvitka",
                    };

                    db.Users.AddRange(new List<User> {user1, user2, user3, user4});
                    db.Complete();
                }
            }
        }
    }
}