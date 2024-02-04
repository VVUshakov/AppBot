namespace ArtBot.Services.WebhookService
{
    internal class WebhookService : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("WebhookService запущен.");
            return Task.CompletedTask;
        }
    }
}
