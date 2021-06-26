using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA.API.LOG.Models.Request
{
    /// <summary>
    /// 日志请求接口
    /// </summary>
    public class LogReq :Req
    {
        /// <summary>
        /// 请求方 IP
        /// </summary>
        public int IP { get; set; }
        /// <summary>
        /// 请求方操作人
        /// </summary>
        public int Operator { get; set; }
        /// <summary>
        /// 请求方应用
        /// </summary>
        public int Application { get; set; }
        /// <summary>
        /// 日志发生时间
        /// </summary>
        public DateTime Opentime { get; set; }
        /// <summary>
        /// 日志保存时间
        /// </summary>
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