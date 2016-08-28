using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoom.Api
{
    public class ChatController : ApiController
    {

        public ChatController()
        {
            
        }

        // GET api/chat
        public HttpResponseMessage Get()
        {
            var users = new List<string>
            {
                "Fredd Perry",
                "Lacoste",
                "Jhonn Smith"
            };
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }
    }
}
