using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatRoom.Entity.Entities;

namespace ChatRoom.Model
{
    public class MessageViewModel
    {
        public string SenderName { get; set; }
        public int SenderId { get; set; }
        public string Body { get; set; }
        public string Attachment { get; set; }
        public double DateTime { get; set; }


        /// <summary>
        /// Map <see cref="Message"/> to <see cref="MessageViewModel"/>
        /// </summary>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static List<MessageViewModel>  MessageMapping(IEnumerable<Message> messages) => messages.Select(message => new MessageViewModel
        {
            SenderName = message.User.FirstOrDefault()?.Name,
            Body = message.Body,
            Attachment = message.Image,
            DateTime = (System.DateTime.Now - message.DateTime).TotalMilliseconds
        }).ToList();
    }
}