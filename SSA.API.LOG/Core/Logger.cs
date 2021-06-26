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
        private LoggerQueue<string> _logger;
        private int maxQueueCount = System.Configuration.ConfigurationManager.AppSettings["logQueueMaxCount"] == null 
            ? 50 
            : int.Parse(System.Configuration.ConfigurationManager.AppSettings["logQueueMaxCount"]);
        private static Logger _instance;
        public Logger()
        {
            _logger = new SSA.API.LOG.Core.Queue.LoggerQueue<string>();
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

        /// <summary>
        /// 执行写入队列并控制按量存入系统
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isTodo"></param>
        public void Write(string str, bool isTodo = false)
        {
            try
            {
                _logger.Enqueue(str);
                var count = _logger.Count;
                if (isTodo)
                {
                    DoAllQueue();
                }
                if (count >= maxQueueCount)
                {
                    for (int i = 0; i < maxQueueCount; i++)
                    {
                        var de = _logger.Dequeue();
                        if (de == null)
                        {
                            break;
                        }
                        new NlogHelper().Info(de.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                new NlogHelper().Error(string.Format("Write|{0}|{1}", str, isTodo.ToString()), ex);
            }
        }

        /// <summary>
        /// 执行所有队列
        /// </summary>
        public void DoAllQueue()
        {
            try
            {
                var count = _logger.Count;
                for (int i = 0; i < count; i++)
                {
                    //执行弹出;
                    var de = _logger.Dequeue();
                    if (de == null)
                    {
                        break;
                    }
                    new NlogHelper().Info(de.ToString());
                }
            }
            catch (Exception ex)
            {
                new NlogHelper().Error(string.Format("DoAllQueue"), ex);
            }
        }
    }
}