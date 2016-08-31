using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoom.Api
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    [RoutePrefix("api/chat")]
    public class ChatController : ApiController
    {
        public List<User> Users { get; set; } = new List<User>
            {
                new User { Name = "Fredd Perry", Id = "58E85959-F2F2-44FB-930A-204668518263"} ,
                new User { Name = "Lacoste", Id = "68E85959-F2F2-44FB-930A-204668518263"} ,
                new User { Name = "Jhonn Smith", Id = "78E85959-F2F2-44FB-930A-204668518263"}
            };

        public ChatController()
        {
            
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create([FromBody]User user)
        {
            HttpResponseMessage result;
            if (string.IsNullOrEmpty(user.Name))
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Name can not be a null or empty");
            }
            else
            {
                user.Id = Guid.NewGuid().ToString();
                Users.Add(user);
                result = Request.CreateResponse(HttpStatusCode.OK, user);
            }
            
            return result;
        }

        [Route("Users")]
        public HttpResponseMessage GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Users);
        }

        [Route("User/{id}")]
        public HttpResponseMessage GetUser(string id)
        {
            var user = Users.FirstOrDefault(q => q.Id == id);

            var result = Request.CreateResponse(HttpStatusCode.OK, user);
            if (user == null) result = Request.CreateResponse(HttpStatusCode.NotFound, id);

            return result;
        }

        [Route("RootDomian")]
        public HttpResponseMessage GetDomian()
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
