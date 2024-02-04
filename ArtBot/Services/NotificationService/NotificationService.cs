namespace ArtBot.Services.NotificationService
{
    internal class NotificationService : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("NotificationService запущен.");
            return Task.CompletedTask;
        }
    }
}
