using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using log4net.Config;
using log4net;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]
namespace XF.Common
{
    public class Logger
    {
        private static ILog logger;
        private static ILog zlogger;

        private static ILog GetLogger(string appenderName)
        {
            if (appenderName.Equals("RollingLogFileAppender"))
            {
                if (logger == null)
                {
                    InitLog4Net();
                    logger = LogManager.GetLogger("RollingLogFileAppender");
                }
                return logger;
            }
            else if (appenderName.Equals("ZRollingLogFileAppender"))
            {
                if (zlogger == null)
                {
                    InitLog4Net(); 
                    zlogger = LogManager.GetLogger("ZRollingLogFileAppender");
                }
                return zlogger;
            }
            else
            {
                return null;
            }
        }
        #region RollingLogFileAppender
        public static void Debug(object message)
        {
            GetLogger("RollingLogFileAppender").Debug(message);
        }
        public static void Debug(object message, Exception exception)
        {
            GetLogger("RollingLogFileAppender").Debug(message, exception);
        }
        public static void DebugFormat(string format, object arg0)
        {
            GetLogger("RollingLogFileAppender").DebugFormat(format, arg0);
        }
        public static void DebugFormat(string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").DebugFormat(format, args);
        }
        public static void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").DebugFormat(provider, format, args);
        }
        public static void DebugFormat(string format, object arg0, object arg1)
        {
            GetLogger("RollingLogFileAppender").DebugFormat(format, arg0, arg1);
        }
        public static void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("RollingLogFileAppender").DebugFormat(format, arg0, arg1, arg2);
        }
        public static void Error(object message)
        {
            GetLogger("RollingLogFileAppender").Error(message);
        }
        public static void Error(object message, Exception exception)
        {
            GetLogger("RollingLogFileAppender").Error(message, exception);
        }
        public static void ErrorFormat(string format, object arg0)
        {
            GetLogger("RollingLogFileAppender").ErrorFormat(format, arg0);
        }
        public static void ErrorFormat(string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").ErrorFormat(format, args);
        }
        public static void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").ErrorFormat(provider, format, args);
        }
        public static void ErrorFormat(string format, object arg0, object arg1)
        {
            GetLogger("RollingLogFileAppender").ErrorFormat(format, arg0, arg1);
        }
        public static void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("RollingLogFileAppender").ErrorFormat(format, arg0, arg1, arg2);
        }
        public static void Fatal(object message)
        {
            GetLogger("RollingLogFileAppender").Fatal(message);
        }
        public static void Fatal(object message, Exception exception)
        {
            GetLogger("RollingLogFileAppender").Fatal(message, exception);
        }
        public static void FatalFormat(string format, object arg0)
        {
            GetLogger("RollingLogFileAppender").FatalFormat(format, arg0);
        }
        public static void FatalFormat(string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").FatalFormat(format, args);
        }
        public static void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").FatalFormat(provider, format, args);
        }
        public static void FatalFormat(string format, object arg0, object arg1)
        {
            GetLogger("RollingLogFileAppender").FatalFormat(format, arg0, arg1);
        }
        public static void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("RollingLogFileAppender").FatalFormat(format, arg0, arg1, arg2);
        }
        public static void Info(object message)
        {
            GetLogger("RollingLogFileAppender").Info(message);
        }
        public static void Info(object message, Exception exception)
        {
            GetLogger("RollingLogFileAppender").Info(message, exception);
        }
        public static void InfoFormat(string format, object arg0)
        {
            GetLogger("RollingLogFileAppender").InfoFormat(format, arg0);
        }
        public static void InfoFormat(string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").InfoFormat(format, args);
        }
        public static void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").InfoFormat(provider, format, args);
        }
        public static void InfoFormat(string format, object arg0, object arg1)
        {
            GetLogger("RollingLogFileAppender").InfoFormat(format, arg0, arg1);
        }
        public static void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("RollingLogFileAppender").InfoFormat(format, arg0, arg1, arg2);
        }
        public static void Warn(object message)
        {
            GetLogger("RollingLogFileAppender").Warn(message);
        }
        public static void Warn(object message, Exception exception)
        {
            GetLogger("RollingLogFileAppender").Warn(message, exception);
        }
        public static void WarnFormat(string format, object arg0)
        {
            GetLogger("RollingLogFileAppender").WarnFormat(format, arg0);
        }
        public static void WarnFormat(string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").WarnFormat(format, args);
        }
        public static void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("RollingLogFileAppender").WarnFormat(provider, format, args);
        }
        public static void WarnFormat(string format, object arg0, object arg1)
        {
            GetLogger("RollingLogFileAppender").WarnFormat(format, arg0, arg1);
        }
        public static void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("RollingLogFileAppender").WarnFormat(format, arg0, arg1, arg2);
        }
        #endregion
        #region ZRollingLogFileAppender
        public static void ZDebug(object message)
        {
            GetLogger("ZRollingLogFileAppender").Debug(message);
        }
        public static void ZDebug(object message, Exception exception)
        {
            GetLogger("ZRollingLogFileAppender").Debug(message, exception);
        }
        public static void ZDebugFormat(string format, object arg0)
        {
            GetLogger("ZRollingLogFileAppender").DebugFormat(format, arg0);
        }
        public static void ZDebugFormat(string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").DebugFormat(format, args);
        }
        public static void ZDebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").DebugFormat(provider, format, args);
        }
        public static void ZDebugFormat(string format, object arg0, object arg1)
        {
            GetLogger("ZRollingLogFileAppender").DebugFormat(format, arg0, arg1);
        }
        public static void ZDebugFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("ZRollingLogFileAppender").DebugFormat(format, arg0, arg1, arg2);
        }
        public static void ZError(object message)
        {
            GetLogger("ZRollingLogFileAppender").Error(message);
        }
        public static void ZError(object message, Exception exception)
        {
            GetLogger("ZRollingLogFileAppender").Error(message, exception);
        }
        public static void ZErrorFormat(string format, object arg0)
        {
            GetLogger("ZRollingLogFileAppender").ErrorFormat(format, arg0);
        }
        public static void ZErrorFormat(string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").ErrorFormat(format, args);
        }
        public static void ZErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").ErrorFormat(provider, format, args);
        }
        public static void ZErrorFormat(string format, object arg0, object arg1)
        {
            GetLogger("ZRollingLogFileAppender").ErrorFormat(format, arg0, arg1);
        }
        public static void ZErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("ZRollingLogFileAppender").ErrorFormat(format, arg0, arg1, arg2);
        }
        public static void ZFatal(object message)
        {
            GetLogger("ZRollingLogFileAppender").Fatal(message);
        }
        public static void ZFatal(object message, Exception exception)
        {
            GetLogger("ZRollingLogFileAppender").Fatal(message, exception);
        }
        public static void ZFatalFormat(string format, object arg0)
        {
            GetLogger("ZRollingLogFileAppender").FatalFormat(format, arg0);
        }
        public static void ZFatalFormat(string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").FatalFormat(format, args);
        }
        public static void ZFatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").FatalFormat(provider, format, args);
        }
        public static void ZFatalFormat(string format, object arg0, object arg1)
        {
            GetLogger("ZRollingLogFileAppender").FatalFormat(format, arg0, arg1);
        }
        public static void ZFatalFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("ZRollingLogFileAppender").FatalFormat(format, arg0, arg1, arg2);
        }
        public static void ZInfo(object message)
        {
            GetLogger("ZRollingLogFileAppender").Info(message);
        }
        public static void ZInfo(object message, Exception exception)
        {
            GetLogger("ZRollingLogFileAppender").Info(message, exception);
        }
        public static void ZInfoFormat(string format, object arg0)
        {
            GetLogger("ZRollingLogFileAppender").InfoFormat(format, arg0);
        }
        public static void ZInfoFormat(string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").InfoFormat(format, args);
        }
        public static void ZInfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").InfoFormat(provider, format, args);
        }
        public static void ZInfoFormat(string format, object arg0, object arg1)
        {
            GetLogger("ZRollingLogFileAppender").InfoFormat(format, arg0, arg1);
        }
        public static void ZInfoFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("ZRollingLogFileAppender").InfoFormat(format, arg0, arg1, arg2);
        }
        public static void ZWarn(object message)
        {
            GetLogger("ZRollingLogFileAppender").Warn(message);
        }
        public static void ZWarn(object message, Exception exception)
        {
            GetLogger("ZRollingLogFileAppender").Warn(message, exception);
        }
        public static void ZWarnFormat(string format, object arg0)
        {
            GetLogger("ZRollingLogFileAppender").WarnFormat(format, arg0);
        }
        public static void ZWarnFormat(string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").WarnFormat(format, args);
        }
        public static void ZWarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            GetLogger("ZRollingLogFileAppender").WarnFormat(provider, format, args);
        }
        public static void ZWarnFormat(string format, object arg0, object arg1)
        {
            GetLogger("ZRollingLogFileAppender").WarnFormat(format, arg0, arg1);
        }
        public static void ZWarnFormat(string format, object arg0, object arg1, object arg2)
        {
            GetLogger("ZRollingLogFileAppender").WarnFormat(format, arg0, arg1, arg2);
        }
        #endregion
        public static void InitLog4Net()
        {
            FileInfo logConfig = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Log4Net.config");
            XmlConfigurator.ConfigureAndWatch(logConfig);
        }
    }
}
