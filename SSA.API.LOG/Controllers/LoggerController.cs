using SSA.API.LOG.Filter;
using System.Web.Http;

namespace SSA.API.LOG.Controllers
{
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LoggerController : ApiController
    {
        private readonly Core.Logger _instince;

        /// <summary>
        /// 构造
        /// </summary>
        public LoggerController()
        {
            _instince = Core.Logger.GetInstance();
        }

        /// <summary>
        /// 接收参数信息
        /// </summary>
        /// <param name="logReq">Models.Request.LogReq 对象</param>
        /// <returns></returns>
        [WebApiAuthorize]
        [HttpPost]
        public Models.Reponse.Res<string> Post(Models.Request.LogReq logReq)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                var logstr = Newtonsoft.Json.JsonConvert.SerializeObject(logReq);
                _instince.Write(logstr, logReq.IsTodo);
            });
            return Models.Reponse.Res<string>.Success("Post Done");
        }

        /// <summary>
        /// 立即执行队列内容
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Models.Reponse.Res<string> DoAllQueue()
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                _instince.DoAllQueue();
            });
            return Models.Reponse.Res<string>.Success("DoAllQueue Done");

        }
    }
}
