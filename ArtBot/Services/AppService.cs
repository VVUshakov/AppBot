using ArtBot.Services.BotServices;

namespace ArtBot.Services
{
    /// <summary>
    /// Класс AppService, реализует интерфейс IService. 
    /// Класс содержит поле List<IService> _listServices, которое используется для хранения списка сервисов. 
    /// Метод StartAsync запускает все сервисы приложения, используя метод Task.WhenAll. 
    /// Метод AddService позволяет добавлять новые сервисы в список.
    /// </summary>
    public class AppService : IService
    {
        private readonly List<IBotService> _listServices = [];

        public Task StartAsync() => Task.WhenAll(_listServices.Select(s => s.StartAsync()));
        public void AddService(IBotService service) => _listServices.Add(service);
    }
}
