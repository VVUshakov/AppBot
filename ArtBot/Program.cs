using ArtBot.Services;
using ArtBot.Services.BotServices;
using ArtBot.Services.BotServices.TG;
using System.Collections.Generic;


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
        // Создание списка экземпляров ботов
        var listBots = new List<IBotService>();

        listBots.AddRange(Enum.GetValues(typeof(BotType))
                .Cast<BotType>()
                .Select(botType => GetBotService(botType)));

        // Создание списка экземпляров сервисов
        var listServices = new List<IService>();

        listServices.AddRange(Enum.GetValues(typeof(ServiceType))
            .Cast<ServiceType>()
            .Select(serviceType => GetService(serviceType, listBots)));





        var botService = new BotService();

        // Запуск сервисов
        await botService.StartAsync();
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

    private static IBotService GetBotService(BotType botType)
    {
        return botType switch
        {
            BotType.Telegram => new TelegramBot(),
          /*//BotType.VK => new VKBot(),
            //BotType.Viber => new ViberBot(),
            //BotType.WhatsApp => new WhatsAppBot(),*/
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    private static IService GetService(ServiceType serviceType, List<IBotService> listBots)
    {
        return serviceType switch
        {
            ServiceType.BotService => new BotService(listBots),
          /*//case ServiceType.ResponseService: return new ResponseService();
            //case ServiceType.MessageHandlingService: return new MessageHandlingService();
            //case ServiceType.LoggingService: return new LoggingService();
            //case ServiceType.DatabaseProcessor: return new DatabaseProcessor();
            //case ServiceType.WebhookService: return new WebhookService();
            //case ServiceType.AuthService: return new AuthService();
            //case ServiceType.NotificationService: return new NotificationService();
            //case ServiceType.RequestHandlerService: return new RequestHandlerService();*/
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    static async Task<string> GetRequestFromClientAsync()
    {
        // Взаимодействие с клиентом для получения входящего запроса
        // ...
        return "REQUEST";
    }
}