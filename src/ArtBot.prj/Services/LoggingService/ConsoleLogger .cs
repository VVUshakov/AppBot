namespace ArtBot.Services.Logging
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine(message);
    }
}
