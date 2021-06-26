using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA.API.LOG.Core.Queue
{
    public class LoggerQueue<T> : IQueue<T>
    {
        private Queue<T> _queue;

        private readonly object _lockEn;
        private readonly object _lockDe;

        public int Count => _queue.Count;

        public LoggerQueue()
        {
            _queue = new Queue<T>();
            _lockDe = new object();
            _lockEn = new object();
        }

        /// <summary>
        /// 释放
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            lock (_lockDe)
            {
                if (_queue.Count == 0)
                    return default(T);
                return _queue.Dequeue();
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="m"></param>
        public void Enqueue(T m)
        {
            lock (_lockEn)
            {              
                _queue.Enqueue(m);
            }
        }
    }
}