
namespace ArtBot.Services.RequestHandlerService
{
    internal class RequestHandlerService : IService
    {
        internal static Task HandleRequestAsync(string request)
        {
            throw new NotImplementedException();
        }

        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("RequestHandlerService запущен.");
            return Task.CompletedTask;
        }
    }
}
