using System.Net;
using System.Web.Http;

namespace BetReader.Api.Controllers
{
    public class TokenController : ApiController
    {
        // THis is naive endpoint for demo, it should use Basic authentication to provdie token or POST request
        [Route("api/Token/Get")]
        [AllowAnonymous]
        public string Get(string username, string password)
        {
            if (CheckUser(username, password))
            {
                return JwtManager.GenerateToken(username);
            }

            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        private bool CheckUser(string username, string password)
        {
            // should check in the database
            return true;
        }
    }
}
