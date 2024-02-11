namespace ArtBot.Services.Logging
{
    public static class LoggingService
    {
        private static bool _disposed = false;
        private static List<ILogger>? _loggers;

        private static List<ILogger> GetLoggers()
        {
            return [new ConsoleLogger(),];

            //TODO: изменить на получение списка из внешенго источника
        }

        public static Task LogMessageAsync(string message)
        {
            if (_disposed && _loggers != null)
            {
                lock (_loggers)
                    foreach (var logger in _loggers)
                        logger.Log(message);
            }
            return Task.CompletedTask;
        }

        public static async Task StartAsync()
        {
            _loggers = GetLoggers();
            _disposed = true;
            await LogMessageAsync("LoggingService запущен.");
        }

        public static async Task StopAsync()
        {
            await LogMessageAsync("LoggingService остановлен.");
            _disposed = false;            
        }
    }
}
