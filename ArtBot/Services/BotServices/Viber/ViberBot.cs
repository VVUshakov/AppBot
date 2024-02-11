namespace ArtBot.Services.Bot.Viber
{
    public class ViberBot : IBotService
    {
        public Task StartAsync()
        {
            //TODO: заглушка

            Console.WriteLine("ViberBot запущен.");
            return Task.CompletedTask;
        }
    }
}