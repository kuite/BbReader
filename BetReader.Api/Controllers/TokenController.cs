using System.Net;
using System.Web.Http;
using BetReader.Api.Filters;
using BetReader.Api.Models.Repositores;

namespace BetReader.Api.Controllers
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        public string Get(string username, string password)
        {
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
}
