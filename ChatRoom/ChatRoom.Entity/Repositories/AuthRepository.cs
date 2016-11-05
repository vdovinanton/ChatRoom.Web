using System;
using System.Threading.Tasks;
using ChatRoom.Entity.Entities.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ChatRoom.Entity.Repositories
{
    public class AuthRepository : IDisposable
    {
        private readonly ChatContext _ctx;

        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new ChatContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
