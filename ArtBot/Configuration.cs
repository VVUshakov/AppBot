using ArtBot.Services;
using ArtBot.Services.BotServices;
using ArtBot.Services.BotServices.TG;
using ArtBot.Services.BotServices.Viber;
using ArtBot.Services.BotServices.VK;
using ArtBot.Services.BotServices.WhatsApp;


namespace ArtBot
{
    /// <summary>
    /// Класс конфигурирующий параметры начальной загрузки приложения
    /// </summary>
    internal class Configuration
    {
        public readonly List<IBotService> ListBots;
        public readonly List<IService> ListServices;
        public readonly string TokenTG;

        public Configuration()
        {
            ListBots = GetListBots();
            ListServices = GetListServices(ListBots);
            TokenTG = GetTelegramToken();
            //добавить другие элементы конфигурации, предварительно добавив свойство в класс
        }
        private static List<IBotService> GetListBots()
        {
            return 
                [ 
                    new TelegramBot(), 
                    /*
                     * new VKBot(), 
                     * new ViberBot(), 
                     * new WhatsAppBot()
                     */ 
                ];

            /*
            // Создание списка экземпляров ботов
            var listBots = new List<IBotService>();
            listBots.AddRange(Enum.GetValues(typeof(BotType))
                    .Cast<BotType>()
                    .Select(GetBotService));
            if (listBots.Count !> 0) 
                throw new InvalidOperationException("Нет подписанных ботов для загрузки.");
            return listBots;
            */
        }
        private static List<IService> GetListServices(List<IBotService> listBots)
        {
            return 
                [
                    new BotService(listBots),
                    /*
                     * new ResponseService(), 
                     * new MessageHandlingService(), 
                     * new LoggingService()
                     * new DatabaseProcessor()
                     * new WebhookService()
                     * new AuthService()
                     * new NotificationService()
                     * new RequestHandlerService()
                     */
                ];

            /*
            // Создание списка экземпляров сервисов
            var listServices = new List<IService>();
            listServices.AddRange(Enum.GetValues(typeof(ServiceType))
                .Cast<ServiceType>()
                .Select(serviceType => GetService(serviceType, listBots)));
            if (listServices.Count !> 0) 
                throw new InvalidOperationException("Нет подписанных сервисов для загрузки.");
            return listServices;
            */
        }        
        private static string GetTelegramToken()
        {
            DotNetEnv.Env.Load();
            var telegramToken = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN") 
                ?? throw new InvalidOperationException("Нет валидного токена для Telegram.");
            return telegramToken;
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
