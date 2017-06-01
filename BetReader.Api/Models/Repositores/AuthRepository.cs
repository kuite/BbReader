using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BetReader.Api.Models.Database;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BetReader.Api.Models.Repositores
{
    public class AuthRepository : IDisposable
    {
        private BetReaderContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new BetReaderContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

//        public async Task<IdentityResult> RegisterUser(RegisterViewModel userModel)
//        {
//            IdentityUser user = new IdentityUser
//            {
//                UserName = userModel.Email
//            };
//
//            var result = await _userManager.CreateAsync(user, userModel.Password);
//
//            return result;
//        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public IdentityUser GetUser(string userName, string password)
        {
            IdentityUser user = _userManager.Find(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}