
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
}
