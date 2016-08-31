using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatRoom.Entity.Entities
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public User()
        {
            Messages = new List<Message>();
        }
    }
}
