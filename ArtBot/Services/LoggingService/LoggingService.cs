namespace ArtBot.Services.LoggingService
{
    /*
    public class LoggingService : IService
    {
        public LoggingService(string message)
        {
            Log(message);
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("LoggingService запущен.");
            return Task.CompletedTask;
        }
    }
    */

    public class LoggingService
    {
        private readonly List<ILogger> loggers;

        public LoggingService()
        {
            loggers = [];
        }

        public void AddLogger(ILogger logger)
        {
            loggers.Add(logger);
        }

        public void LogMessage(string message)
        {
            foreach (var logger in loggers)
            {
                logger.Log(message);
            }
        }

        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("LoggingService запущен.");
            return Task.CompletedTask;
        }
    }
}
