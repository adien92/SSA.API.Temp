using JWT;
using JWT.Serializers;
using SSA.API.LOG.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace SSA.API.LOG.Filter
{
    /// <summary>
    /// 身份认证拦截器
    /// </summary>
    public class WebApiAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 指示指定的控件是否已获得授权
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            new Common.NlogHelper().Info(Newtonsoft.Json.JsonConvert.SerializeObject(actionContext.Request.Headers));
            //前端请求api时会将token存放在名为"auth"的请求头中
            var authHeader = from t in actionContext.Request.Headers where t.Key == "Authorization" select t.Value.FirstOrDefault();
            if (authHeader != null)
            {               
                string token = authHeader.FirstOrDefault();//获取token
                if (!string.IsNullOrEmpty(token))
                {
                    try
                    {
                        //解密
                        var json = JwtHelper.AnalysisToken(token);
                        if (json != null)
                        {
                            //判断口令过期时间
                            if (json.ExpiryDateTime < DateTime.Now)
                            {
                                return false;
                            }
                            actionContext.RequestContext.RouteData.Values.Add("Authorization", json);
                            return true;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        new Common.NlogHelper().Error(token, ex);
                        return false;
                    }
                }
            }
            return false;
        }


        /// <summary>
        /// 处理授权失败的请求
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            var erModel = new
            {
                Success = "false",
                ErrorCode = "401"
            };
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.OK, erModel, "application/json");
        }
    }
}