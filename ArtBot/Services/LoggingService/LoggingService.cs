using System.Collections.Generic;
using Telegram.Bot.Types;

namespace ArtBot.Services.LoggingService
{
    public class LoggingService : IService
    {
        private static List<ILogger>? loggers;

        public List<ILogger> GetLoggers()
        {
            return [ new ConsoleLogger(), ];

            //TODO: изменить на получение списка из внешенго источника
        }

        public static void LogMessage(string message)
        {
            if (loggers != null)
                foreach (var logger in loggers)
                    logger.Log(message);
        }

        public Task StartAsync()
        {
            loggers = GetLoggers();
            LogMessage("LoggingService запущен.");
            return Task.CompletedTask;
        }
    }
}
