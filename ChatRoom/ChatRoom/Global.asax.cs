using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using ChatRoom.Api;
using ChatRoom.Entity;
using ChatRoom.Entity.Entities;
using User = ChatRoom.Entity.Entities.User;

namespace ChatRoom
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DefaultData.Initializer();
        }
    }

    public class DefaultData
    {
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


                    /*var user = new User {Name = "Takitaka otomo"};
                    db.Users.Add(user);
                    db.Complete();
                    var temp = user;*/
                }
            }
        }
    }
}
