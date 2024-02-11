namespace ArtBot.Services.LoggingService
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
    }
}
