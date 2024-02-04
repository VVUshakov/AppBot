namespace ArtBot.Services.BotServices
{
    /// <summary>
    /// Класс BotService, реализует интерфейс IService. 
    /// Класс содержит поле List<IBotService> _listBots, которое используется для хранения списка ботов сервиса (Telegram, VK, Viber, WhatsApp). 
    /// Метод StartAsync запускает все боты, используя метод Task.WhenAll. 
    /// Поле со списком ботов инициализируется через входной параметр конструктора класса
    /// </summary>
    public class BotService(List<IBotService> listBots) : IService
    {
        private readonly List<IBotService> _listBots = listBots;

        public Task StartAsync() => Task.WhenAll(_listBots.Select(s => s.StartAsync()));
    }
}