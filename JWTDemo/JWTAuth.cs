using JWTDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Hosting;

namespace JWTDemo
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class JWTAuth : AuthorizationFilterAttribute
    {
        public JWTAuth()
        {

        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext == null) throw new Exception("actionContext");

            // 过滤带有AllowAnonymous
            if (SkipAuthorization(actionContext)) return;

            var request = ((actionContext.Request.Properties[HttpPropertyKeys.RequestContextKey] as HttpWebRequest));

            // 分别从Query、Body、Header获取Token字符串
            const string key = "access_token";
            string token = "";
            // header
            if (actionContext.Request.Headers.Contains(key))
                token = actionContext.Request.Headers.GetValues(key).First();
            // query
            // body

            if (String.IsNullOrEmpty(token))
                actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.Forbidden, "请先登录。");

            try
            {
                var payload = new JWT().Decode<JWTPayload>(token, PassportConfig.SecretKey);
                // 检查token是否已经过期
                if (payload.exp < DateTime.UtcNow)
                    actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(
                        HttpStatusCode.Forbidden, "Token已经过期。");
            }
            catch (Exception ex)
            {
                actionContext.Response = actionContext.ControllerContext.Request.CreateErrorResponse(
                    HttpStatusCode.Forbidden, ex.Message);
            }
        }

        private static bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

    }
}