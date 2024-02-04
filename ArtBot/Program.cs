using ArtBot.Services.BotServices;


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
        // Создание экземпляров сервисов
        var botService = new BotService(); // Базовый класс для обработки сообщений и команд из Telegram        
        /*
        //var responseService = new ResponseService(); // Сервис отправки ответов и выполнения сценариев: этот сервис отвечает за отправку ответов на сообщения пользователей и выполнение сценариев, определенных в приложении
        //var messageHandlingService = new MessageHandlingService(); // Сервис обработки сообщений и команд: этот сервис отвечает за обработку входящих сообщений и команд от пользователей.
        //var loggingService = new LoggingService(); // Сервис логирования действий пользователей: этот сервис отвечает за запись действий пользователей в журнал или базу данных
        //var databaseProcessor = new DatabaseProcessor(); // Сервис обработки баз данных: этот сервис отвечает за взаимодействие с базой данных. Может включать в себя функциональность для создания, чтения, обновления и удаления данных в базе данных
        //var webhookService = new WebhookService(); // Сервис обработки вебхуков: этот сервис отвечает за обработку вебхуков, которые могут быть использованы для взаимодействия с другими системами или платформами
        //var authService = new AuthService(); // Сервис обработки платежей: этот сервис отвечает за обработку платежей, связанных с использованием бота.
        //var notificationService = new NotificationService(); // Служба уведомлений: этот сервис отвечает за инфоррование пользователей
        //var requestHandlerService = new RequestHandlerService(); //Сервис обработки аутентификации и авторизации: этот сервис отвечает за аутентификацию пользователей и управление их правами доступа к функциональности бота
        */

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

    static async Task<string> GetRequestFromClientAsync()
    {
        // Взаимодействие с клиентом для получения входящего запроса
        // ...
        return "REQUEST";
    }
}