using ArtBot.Services.BotServices;

namespace ArtBot.Services
{
    /// <summary>
    /// Класс AppService, реализует интерфейс IService. 
    /// Класс содержит поле List<IService> _listServices, которое используется для хранения списка сервисов. 
    /// Метод StartAsync запускает все сервисы приложения, используя метод Task.WhenAll. 
    /// Поле со списком сервисов инициализируется через входной параметр конструктора класса.
    /// </summary>
    public class AppService(List<IBotService> listServices) : IService
    {
        private readonly List<IBotService> _listServices = listServices;

        public Task StartAsync() => Task.WhenAll(_listServices.Select(s => s.StartAsync()));
    }
}
