using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace House.Utility
{
    /// <summary>
    /// 日志辅助类。内部封装<seealso cref="NLog"/>。
    /// 直接使用静态方法输出日志即可
    /// 使用异常方法时，将错误堆栈StackTrace和msg字符串合并输出。
    /// 日志输出格式参看配置文件 https://github.com/nlog/NLog/wiki/Layout-Renderers
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// NLog组件日志对象
        /// </summary>
        private static readonly Logger log = LogManager.GetLogger(string.Empty);

        /// <summary>
        /// 严重致命级别
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="exp"></param>
        public static void Fatal(string msg, Exception exp = null)
        {
            if (exp == null)
            {
                log.Fatal(msg);
            }
            else
            {
                log.Fatal(exp, msg + exp.StackTrace);
            }
        }

        /// <summary>
        /// 错误级别
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="exp"></param>
        public static void Error(string msg, Exception exp = null)
        {
            if (exp == null)
            {
                log.Error(msg);
            }
            else
            {
                log.Error(exp, msg + exp.StackTrace);
            }
        }

        /// <summary>
        /// 信息级别
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="exp"></param>
        public static void Info(string msg, Exception exp = null)
        {
            if (exp == null)
            {
                log.Info(msg);
            }
            else
            {
                log.Info(exp, msg + exp.StackTrace);
            }
        }

        /// <summary>
        /// 警告级别
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="exp"></param>
        public static void Warn(string msg, Exception exp = null)
        {
            if (exp == null)
            {
                log.Warn(msg);
            }
            else
            {
                log.Warn(exp, msg + exp.StackTrace);
            }
        }

        /// <summary>
        /// 调试级别
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="exp"></param>
        public static void Debug(string msg, Exception exp = null)
        {
            if (exp == null)
            {
                log.Debug(msg);
            }
            else
            {
                log.Debug(exp, msg + exp.StackTrace);
            }
        }

        /// <summary>
        /// 跟踪级别
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="exp"></param>
        public static void Trace(string msg, Exception exp = null)
        {
            if (exp == null)
            {
                log.Trace(msg);
            }
            else
            {
                log.Trace(exp, msg + exp.StackTrace);
            }
        }

    }
}
