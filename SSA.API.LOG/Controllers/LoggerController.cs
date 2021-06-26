using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSA.API.LOG.Controllers
{
    public class LoggerController : ApiController
    {
        private readonly SSA.API.LOG.Core.Logger _instince;

        public LoggerController()
        {
            _instince = SSA.API.LOG.Core.Logger.GetInstance();
        }
        [HttpPost]
        public void Post(Models.Request.LogReq logReq)
        {            
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {           
                //for (int i = 0; i < 1000; i++)
                //{
                //    //new SSA.API.LOG.Core.Queue.LoggerQueue<int>().Enqueue(i);
                //    instince.Write(i.ToString() + "||" + DateTime.Now.Year);
                //}
                var logstr = Newtonsoft.Json.JsonConvert.SerializeObject(logReq);
                _instince.Write(logstr);
            });
        }
        [HttpGet]
        public void DoAllQueue()
        {            
            _instince.DoAllQueue();
        }
    }
}
