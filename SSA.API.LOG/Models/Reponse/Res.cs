using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSA.API.LOG.Models.Reponse
{
    /// <summary>
    /// 消息返回对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Res<T>
    {
        /// <summary>
        /// 结果标志
        /// </summary>
        public int Tag { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回内容
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Res<T> Success(T data)
        {
            return new Res<T>() {
                Tag = 1,
                Message = "Successful",
                Data = data
            };
        }

        /// <summary>
        /// 成功返回，带消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Res<T> Success(string message,T data)
        {
            return new Res<T>()
            {
                Tag = 1,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 失败返回
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Res<T> Fail(T data)
        {
            return new Res<T>()
            {
                Tag = 0,
                Message = "Fail",
                Data = data
            };
        }

        /// <summary>
        /// 失败返回、带消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Res<T> Fail(string message, T data)
        {
            return new Res<T>()
            {
                Tag = 0,
                Message = message,
                Data = data
            };
        }

        /// <summary>
        /// 默认输出
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Res<T> Defalut(int tag ,string message, T data)
        {
            return new Res<T>()
            {
                Tag = tag,
                Message = message,
                Data = data
            };
        }
    }
}