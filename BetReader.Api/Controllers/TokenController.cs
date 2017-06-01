using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using BetReader.Api.Filters;
using BetReader.Api.Models.Repositores;

namespace BetReader.Api.Controllers
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public string GetToken([FromBody]LoginModel model)
        {
            string username = model.Email;
            string password = model.Password;
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username, 360);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private bool CheckUser(string username, string password)
        {
            var auth = new AuthRepository();

            var user = auth.GetUser(username, password);

            if (user != null)
            {
                return true;
            }

            return false;
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
