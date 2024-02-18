namespace ArtBot.Services.AuthService
{
    internal class AuthService : IService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("AuthService запущен.");
            return Task.CompletedTask;
        }
    }
}
