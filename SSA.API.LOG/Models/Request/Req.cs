using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA.API.LOG.Models.Request
{
    /// <summary>
    /// 日期请求基类
    /// </summary>
    public class Req
    {
        /// <summary>
        /// 是否立即执行
        /// </summary>
        public bool IsTodo { get; set; }
    }
}