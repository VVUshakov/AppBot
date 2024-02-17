namespace ArtBot.Services.MessageHandlingService
{
    internal class MessageHandlingService : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("MessageHandlingService запущен.");
            return Task.CompletedTask;
        }
    }
}
