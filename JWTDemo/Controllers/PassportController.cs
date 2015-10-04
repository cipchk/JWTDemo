using JWTDemo.Models;
using System;
using System.Web.Http;

namespace JWTDemo.Controllers
{
    [RoutePrefix("passport")]
    public class PassportController : ApiController
    {
        [HttpGet, HttpPost, Route("login")]
        public TokenResult Login(string username, string password)
        {
            // 为了简化不做用户名和密码验证
            var expire = DateTime.UtcNow.AddSeconds(20); // DateTime.UtcNow.AddDays(7);
            var res = new TokenResult()
            {
                expires = expire
            };
            var payloadObj = new JWTPayload()
            {
                name = username,
                role = "manage",
                exp = expire
            };
            res.token = new JWT().Encode<JWTPayload>(payloadObj, PassportConfig.SecretKey);

            return res;
        }
    }
}
