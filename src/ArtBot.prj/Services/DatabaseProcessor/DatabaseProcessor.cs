namespace ArtBot.Services.DatabaseProcessor
{
    internal class DatabaseProcessor : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("DatabaseProcessor запущен.");
            return Task.CompletedTask;
        }
    }
}
