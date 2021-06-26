using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA.API.LOG.Core
{
    public interface IQueue<T>
    {
        int Count { get; }
        void Enqueue(T m);
        T Dequeue();
    }
}