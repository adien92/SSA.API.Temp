using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSA.API.Repository.Logtable
{
    /// <summary>
    /// 日志请求接口
    /// </summary>
    public class LogMain
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        /// <summary>
        /// 请求方 IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 请求方操作人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 请求方应用
        /// </summary>
        public string Application { get; set; }
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
