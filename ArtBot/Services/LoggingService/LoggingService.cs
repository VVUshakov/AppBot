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

        public static Task LogMessageAsync(string message)
        {
            if (loggers != null)
            {
                lock (loggers)
                    foreach (var logger in loggers)
                        logger.Log(message);
            }
            return Task.CompletedTask;
        }

        public static async Task StartAsync()
        {
            loggers = GetLoggers();
            await LogMessageAsync("LoggingService запущен.");
        }
    }
}
