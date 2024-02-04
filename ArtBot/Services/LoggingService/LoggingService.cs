namespace ArtBot.Services.LoggingService
{
    internal class LoggingService : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("LoggingService запущен.");
            return Task.CompletedTask;
        }
    }
}
