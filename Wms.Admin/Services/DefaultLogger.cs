
using NLog;

namespace Wms.Admin.Services
{
    public class DefaultLogger : Wms.Admin.IServices.ILogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }
    }

    public static class LoggerNew
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly Logger processLogger = LogManager.GetLogger("Process");
        private static readonly Logger otherLogger = LogManager.GetLogger("Other");

        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        public static void Info(string message)
        {
            logger.Info(message);
        }

        public static void Warn(string message)
        {
            logger.Warn(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public static void Process(string message)
        {
            processLogger.Info(message);
        }

        public static void Other(string message)
        {
            otherLogger.Info(message);
        }
    }

}


