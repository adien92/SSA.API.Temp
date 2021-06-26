using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA.API.LOG.Models.Request
{
    public class LogReq
    {
        public int IP { get; set; }
        public int Operator { get; set; }
        public int Application { get; set; }
        public DateTime Opentime { get; set; }
        public DateTime Createtime { get; set; } 
        /// <summary>
        /// 日志等级名称
        /// </summary>
        public string LevelName { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        ///异常
        /// </summary>
        public string Exception { get; set; }

    }
}