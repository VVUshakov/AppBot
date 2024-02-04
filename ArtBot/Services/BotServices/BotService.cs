namespace ArtBot.Services.BotServices
{
    /// <summary>
    /// Класс BotService, реализует интерфейс IService. 
    /// Класс содержит поле List<IBotService> _listBots, которое используется для хранения списка ботов сервиса (Telegram, VK, Viber, WhatsApp). 
    /// Метод StartAsync запускает все боты, используя метод Task.WhenAll. 
    /// Метод AddService позволяет добавлять нового бота в список.
    /// </summary>
    public class BotService : IService
    {
        private readonly List<IBotService> _listBots = [];

        public Task StartAsync() => Task.WhenAll(_listBots.Select(s => s.StartAsync()));
        public void AddService(IBotService botService) => _listBots.Add(botService);
    }
}