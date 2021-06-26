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
        [HttpGet]
        public void Post()
        {            
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                var instince = SSA.API.LOG.Core.Logger.GetInstance();
                for (int i = 0; i < 1000; i++)
                {
                    //new SSA.API.LOG.Core.Queue.LoggerQueue<int>().Enqueue(i);
                    instince.Write(i.ToString() + "||" + DateTime.Now.Year);
                }
            });
           
            
        }
    }
}
