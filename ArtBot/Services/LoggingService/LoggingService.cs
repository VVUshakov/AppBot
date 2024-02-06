using ArtBot.DataAccessLayer.Entities;

namespace ArtBot.Services.LoggingService
{
    public class LoggingService : IService
    {
        private List<LoggingMode> _loggingModes;

        public LoggingService(List<LoggingMode> loggingModes) => _loggingModes = loggingModes;

        public Task StartAsync()
        {




            //TODO: заглушка
            Console.WriteLine("LoggingService запущен.");
            return Task.CompletedTask;
        }
    }
}
