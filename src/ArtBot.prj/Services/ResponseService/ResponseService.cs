namespace ArtBot.Services.ResponseService
{
    internal class ResponseService : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("ResponseService запущен.");
            return Task.CompletedTask;
        }
    }
}
