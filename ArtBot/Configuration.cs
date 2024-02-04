using ArtBot.Services;
using ArtBot.Services.BotServices;
using ArtBot.Services.BotServices.TG;


namespace ArtBot
{
    /// <summary>
    /// Класс конфигурирующий параметры начальной загрузки приложения
    /// </summary>
    internal class Configuration
    {
        public required List<IBotService> ListBot;
        public required List<IService> ListServices;
        public required string TokenTG;


        public Configuration()
        {
            SetListBots();
            SetListServices();
            SetTelegramToken();
            //добавить другие элементы конфигурации, предварительно добавив свойсво в класс
        }
        private void SetListBots()
        {
            // Создание списка экземпляров ботов
            var listBots = new List<IBotService>();
            listBots.AddRange(Enum.GetValues(typeof(BotType))
                    .Cast<BotType>()
                    .Select(GetBotService));
            if (listBots.Count > 0) ListBot = listBots;
            else throw new InvalidOperationException("Нет подписанных ботов для загрузки.");
        }
        private void SetListServices()
        {
            // Создание списка экземпляров сервисов
            var listServices = new List<IService>();
            listServices.AddRange(Enum.GetValues(typeof(ServiceType))
                .Cast<ServiceType>()
                .Select(serviceType => GetService(serviceType, ListBot)));
            if (listServices.Count > 0) ListServices = listServices;
            else throw new InvalidOperationException("Нет подписанных сервисов для загрузки.");
        }        
        private void SetTelegramToken()
        {
            DotNetEnv.Env.Load();
            var telegramToken = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN");
            if (telegramToken != null) TokenTG = telegramToken;
            else throw new InvalidOperationException("Нет валидного токена для Telegram.");
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
    }
}
