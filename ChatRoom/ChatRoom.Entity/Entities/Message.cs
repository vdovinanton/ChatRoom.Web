using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatRoom.Entity.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public virtual ICollection<User> User { get; set; }

        public string Body { get; set; }
        public DateTime DateTime { get; set; }
        public string Image { get; set; }

        public Message()
        {
            User = new List<User>();
        }
    }
}
