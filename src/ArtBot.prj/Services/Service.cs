namespace ArtBot.Services
{
    /// <summary>
    /// Класс AppService, реализует интерфейс IService. 
    /// Класс содержит свойство List<IService> ListServices, которое используется для хранения списка сервисов. 
    /// Метод StartAsync запускает все сервисы приложения, используя метод Task.WhenAll. 
    /// Поле со списком сервисов инициализируется через входной параметр конструктора класса.
    /// </summary>
    public class Service(List<IService> listServices) : IService
    {
        public List<IService> ListServices { get; } = listServices;

        public Task StartAsync() => Task.WhenAll(ListServices.Select(s => s.StartAsync()));
    }
}
