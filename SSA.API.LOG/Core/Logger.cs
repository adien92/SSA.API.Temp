using SSA.API.Common;
using SSA.API.LOG.Core.Queue;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SSA.API.LOG.Core
{
    public class Logger
    {
        private static readonly object _lock = new object();
        private SSA.API.LOG.Core.Queue.LoggerQueue<string> abc;
        private int maxQueueCount = 50;
        private static Logger _instance;
        public Logger()
        {
            abc = new SSA.API.LOG.Core.Queue.LoggerQueue<string>();
        }

        public static Logger GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }
            lock (_lock)
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new Logger();
            }
            return _instance;
        }
        public void Write(string j, bool isTodo = false)
        {
            abc.Enqueue(j);
            var count = abc.Count;
            if (isTodo)
            {
                DoAllQueue();
            }
            if (count >= maxQueueCount)
            {               
                var str = DateTime.Now.ToString("yyyyMMddhhmmss");
                for (int i = 0; i < maxQueueCount; i++)
                {                 
                    //执行弹出;
                    var de = abc.Dequeue();
                    if (de == null)
                    {
                        new NlogHelper().Error("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        break;
                    }
                    new NlogHelper().Info(de.ToString() + "|" + str);
                }
              

            }            

        }

        public void DoAllQueue()
        {
            //File.AppendAllLines("D:\\text.txt", list);
            //执行要操作的东西
            var str = DateTime.Now.ToString("yyyyMMddhhmmss");
            var count = abc.Count;
            for (int i = 0; i < count; i++)
            {
                //执行弹出;
                var de = abc.Dequeue();
                if (de == null)
                {
                    new NlogHelper().Error("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    break;
                }
                new NlogHelper().Info(de.ToString() + "|" + str);
            }
        }

    }
}