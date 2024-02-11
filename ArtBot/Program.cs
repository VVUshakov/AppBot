using ArtBot.Services.Bot.TG;
using ArtBot.Services.Logging;
using ArtBot.Services.RequestHandlerService;


class Program
{
    static async Task Main(string[] args)
    {
        var telegramBot = new TelegramBot();
        var requestHandlerService = new RequestHandlerService();



        await telegramBot.StartAsync();
        await requestHandlerService.StartAsync();
        await LoggingService.StartAsync();

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