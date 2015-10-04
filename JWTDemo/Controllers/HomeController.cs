using System.Web.Http;

namespace JWTDemo.Controllers
{
    [RoutePrefix("")]
    public class HomeController : ApiController
    {
        [HttpGet, Route("")]
        public string Index()
        {
            return "ok";
        }
    }
}
