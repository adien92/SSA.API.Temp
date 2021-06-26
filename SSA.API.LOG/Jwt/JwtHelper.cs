using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SSA.API.LOG.Jwt
{
    /// <summary>
    /// Jwt 帮助类
    /// </summary>
    public static class JwtHelper
    {
        const string secretKey = "Hello World";//口令加密秘钥

        /// <summary>
        /// 创建TOKEN
        /// </summary>
        /// <param name="authInfo"></param>
        public static string CreateToken(AuthInfo authInfo)
        {
            try
            {

                byte[] key = Encoding.UTF8.GetBytes(secretKey);
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();//加密方式
                IJsonSerializer serializer = new JsonNetSerializer();//序列化Json
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64加解密
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);//JWT编码
                var token = encoder.Encode(authInfo, key);//生成令牌
                return token;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 解析token
        /// </summary>
        /// <param name="token"></param>
        public static AuthInfo AnalysisToken(string token)
        {
            try
            {
                byte[] key = Encoding.UTF8.GetBytes(secretKey);
                IJsonSerializer serializer = new JsonNetSerializer();//序列化Json
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64加解密
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                //解密
                var json = decoder.DecodeToObject<AuthInfo>(token, key, verify: true);
                return json;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// 刷新TOKEN
        /// </summary>
        /// <param name="token"></param>
        public static string RefreshToken(string token)
        {
            try
            {
                var currentAuthInfo = AnalysisToken(token);                
                if (currentAuthInfo.ExpiryDateTime >= DateTime.Now)
                {
                    currentAuthInfo.ExpiryDateTime = DateTime.Now.AddHours(2);
                    //修改token内信息，若登录账号存在，重新获取账号信息，生成token
                    var newToken = CreateToken(currentAuthInfo);
                    return newToken;
                }
                else
                {
                    throw new Exception( "Token已过期，请重新登录");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
    /// <summary>
    /// 身份验证信息 模拟JWT的payload
    /// </summary>
    public class AuthInfo
    {
        ///// <summary>
        ///// 用户名
        ///// </summary>
        //public string UserName { get; set; }

        ///// <summary>
        ///// 角色
        ///// </summary>
        //public List<string> Roles { get; set; }

        ///// <summary>
        ///// 是否管理员
        ///// </summary>
        //public bool IsAdmin { get; set; }

        /// <summary>
        /// 口令过期时间
        /// </summary>
        public DateTime? ExpiryDateTime { get; set; }
    }
}