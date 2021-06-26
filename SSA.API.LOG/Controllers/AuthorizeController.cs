using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSA.API.LOG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [AllowAnonymous]
    public class AuthorizeController : ApiController
    {
        /// <summary>
        /// 返回token
        /// </summary>
        /// <returns></returns>
        public Models.Reponse.Res<string> GetToken()
        {
            var token = Jwt.JwtHelper.CreateToken(new Jwt.AuthInfo()
            {
                ExpiryDateTime = DateTime.Now.AddDays(1)                      
            }) ;
            return Models.Reponse.Res<string>.Success(token);
        }
    }
}