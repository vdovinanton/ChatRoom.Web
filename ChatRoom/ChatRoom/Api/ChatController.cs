using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChatRoom.Entity;
using ChatRoom.Entity.Interfaces;
using ChatRoom.Entity.Entities;

namespace ChatRoom.Api
{
    [RoutePrefix("api/chat")]
    public class ChatController : ApiController
    {
        private readonly IUnitOfWork _repository;

        public ChatController()
        {
            _repository = new UnitOfWork(new ChatContext());
        }

        [HttpPost, Route("Create")]
        public HttpResponseMessage Create([FromBody]User user)
        {
            HttpResponseMessage result;
            if (string.IsNullOrEmpty(user.Name))
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Name can not be a null or empty");
            }
            else
            {
                var newUser = new User { Name = user.Name };

                _repository.Users.Add(newUser);
                _repository.Complete();
                result = Request.CreateResponse(HttpStatusCode.OK, newUser);
            }
            
            return result;
        }

        [Route("Users")]
        public HttpResponseMessage GetUsers()
        {
            var user = _repository.Users.GetUsers();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Route("User/{id}")]
        public HttpResponseMessage GetUser(int id)
        {
            var user = _repository.Users.Get(id);

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
