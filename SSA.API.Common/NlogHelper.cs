using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SSA.API.Common
{
    public sealed class NlogHelper
    {
        /// <summary>
        /// 实例化nLog，即为获取配置文件相关信息
        /// </summary>
        private readonly static NLog.Logger _logger = LogManager.GetCurrentClassLogger();

        private static NlogHelper _obj;

        public static NlogHelper _
        {
            get => _obj ?? (new NlogHelper());
            set => _obj = value;
        }

        #region Debug，调试
        public static void Debug(string msg)
        {
            _logger.Debug(msg);
        }

        public static void Debug(string msg, Exception err)
        {
            _logger.Debug(err, msg);
        }
        #endregion

        #region Info，信息
        public static void Info(string msg)
        {
            _logger.Info(msg);
        }

        public static void Info(string msg, Exception err)
        {
            _logger.Info(err, msg);
        }
        #endregion

        #region Warn，警告
        public static void Warn(string msg)
        {
            _logger.Warn(msg);
        }

        public static void Warn(string msg, Exception err)
        {
            _logger.Warn(err, msg);
        }
        #endregion

        #region Trace，追踪
        public static void Trace(string msg)
        {
            _logger.Trace(msg);
        }

        public static void Trace(string msg, Exception err)
        {
            _logger.Trace(err, msg);
        }
        #endregion

        #region Error，错误
        public static void Error(string msg)
        {
            _logger.Error(msg);
        }

        public static void Error(string msg, Exception err)
        {
            _logger.Error(err, msg);
        }
        #endregion

        #region Fatal,致命错误
        public static void Fatal(string msg)
        {
            _logger.Fatal(msg);
        }

        public static void Fatal(string msg, Exception err)
        {
            _logger.Fatal(err, msg);
        }
        #endregion
    }
}