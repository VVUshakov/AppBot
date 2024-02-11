namespace ArtBot.Services.Logging
{
    public static class LoggingService
    {
        private static List<ILogger>? loggers;

        static LoggingService() 
        {
            loggers = GetLoggers();
        }
        private static List<ILogger> GetLoggers()
        {
            return [new ConsoleLogger(),];

            //TODO: изменить на получение списка из внешенго источника
        }

        public static void LogMessage(string message)
        {
            if (loggers != null)
                lock (loggers)
                    foreach (var logger in loggers)
                        logger.Log(message);
        }

        public static Task StartAsync()
        {
            loggers = GetLoggers();
            LogMessage("LoggingService запущен.");
            return Task.CompletedTask;
        }
    }
}
