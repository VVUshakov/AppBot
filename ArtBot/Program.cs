using ArtBot;
using ArtBot.Services;
using ArtBot.Services.BotServices.TG;
using ArtBot.Services.RequestHandlerService;


/// <summary>
/// В этом примере класс Program реализует точку входа приложения, в которой создаются экземпляры всех сервисов и запускаются их методы StartAsync. 
/// Затем приложение получает входящий запрос от клиента с помощью метода GetRequestFromClientAsync и передает его в сервис RequestHandlerService для обработки.
/// Метод GetRequestFromClientAsync представляет собой точку взаимодействия с клиентом и может быть реализован с использованием соответствующих средств коммуникации, 
/// таких как HTTP-сервер, TCP-сокеты или другие методы обмена данными.
/// </summary>
/// <param name="args"></param>
class Program
{
    static async Task Main(string[] args)
    {
        var telegramBot = new TelegramBot();
        var requestHandlerService = new RequestHandlerService();



        await telegramBot.StartAsync();
        await requestHandlerService.StartAsync();


        /*
        // Сконфигурировать параметры загрузки приложения
        var configuration = new Configuration();

        // Запустить все сервисы и боты
        IService services = new Service(configuration.ListServices);
        await services.StartAsync();
        */





        // Получение входящего запроса от клиента
        string request = await GetRequestFromClientAsync();

        
        // Обработка запроса
        await requestHandlerService.HandleRequestAsync(request);
        
    }

    static async Task<string> GetRequestFromClientAsync()
    {
        // Взаимодействие с клиентом для получения входящего запроса
        // ...
        return "REQUEST";
    }
}