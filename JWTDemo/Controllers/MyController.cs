using System.Web.Http;

namespace JWTDemo.Controllers
{
    [JWTAuth]
    [RoutePrefix("my")]
    public class MyController : ApiController
    {
        [HttpGet, HttpPost, HttpDelete, Route("")]
        public string Index()
        {
            return "我的私人数据";
        }
    }
}