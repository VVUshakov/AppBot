using ArtBot;
using ArtBot.Services;
using ArtBot.Services.BotServices;
using ArtBot.Services.BotServices.TG;


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
        //Сконфигурировать параметры загрузки приложения
        var appConfiguration = new Configuration();

        





        //var botService = new BotService();

        // Запуск сервисов
        //await botService.StartAsync();
        /*
        //await responseService.StartAsync();
        //await messageHandlingService.StartAsync();
        //await loggingService.StartAsync();
        //await databaseProcessor.StartAsync();
        //await webhookService.StartAsync();
        //await authService.StartAsync();
        //await notificationService.StartAsync();
        //await requestHandlerService.StartAsync();
        */

        // Получение входящего запроса от клиента
        string request = await GetRequestFromClientAsync();

        /*
        // Обработка запроса
        //await requestHandlerService.HandleRequestAsync(request);
        */
    }

    

    static async Task<string> GetRequestFromClientAsync()
    {
        // Взаимодействие с клиентом для получения входящего запроса
        // ...
        return "REQUEST";
    }
}