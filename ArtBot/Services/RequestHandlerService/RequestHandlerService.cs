namespace ArtBot.Services.RequestHandlerService
{
    internal class RequestHandlerService : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("RequestHandlerService запущен.");
            return Task.CompletedTask;
        }
    }
}
