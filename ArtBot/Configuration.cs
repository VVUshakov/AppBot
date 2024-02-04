using ArtBot.Services;
using ArtBot.Services.AuthService;
using ArtBot.Services.BotServices;
using ArtBot.Services.BotServices.TG;
using ArtBot.Services.BotServices.Viber;
using ArtBot.Services.BotServices.VK;
using ArtBot.Services.BotServices.WhatsApp;
using ArtBot.Services.DatabaseProcessor;
using ArtBot.Services.LoggingService;
using ArtBot.Services.MessageHandlingService;
using ArtBot.Services.NotificationService;
using ArtBot.Services.RequestHandlerService;
using ArtBot.Services.ResponseService;
using ArtBot.Services.WebhookService;


namespace ArtBot
{
    /// <summary>
    /// Класс конфигурирующий параметры начальной загрузки приложения
    /// </summary>
    internal class Configuration
    {
        public readonly List<IBotService> ListBots;
        public readonly List<IService> ListServices;
        //public readonly string TokenTG;

        public Configuration()
        {
            ListBots = GetListBots();
            ListServices = GetListServices(ListBots);

            //добавить другие элементы конфигурации, предварительно добавив свойство в класс
        }

        /// <summary>
        /// Создание списка экземпляров ботов
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private static List<IBotService> GetListBots()
        {
            var listBots = new List<IBotService>();
            listBots.AddRange(Enum.GetValues(typeof(BotType))
                    .Cast<BotType>()
                    .Select(GetBotService));
            if (listBots.Count <= 0) 
                throw new InvalidOperationException("Нет подписанных ботов для загрузки.");
            return listBots;
            
        }

        /// <summary>
        /// Создание списка экземпляров сервисов
        /// </summary>
        /// <param name="listBots"></param>
        /// <returns></returns>
        private static List<IService> GetListServices(List<IBotService> listBots)
        {   
            var listServices = new List<IService>();
            listServices.AddRange(Enum.GetValues(typeof(ServiceType))
                .Cast<ServiceType>()
                .Select(serviceType => GetService(serviceType, listBots)));
            if (listServices.Count <= 0) 
                throw new InvalidOperationException("Нет подписанных сервисов для загрузки.");
            return listServices;            
        }
                
        private static IBotService GetBotService(BotType botType)
        {
            return botType switch
            {
                BotType.Telegram => new TelegramBot(),
                BotType.VK => new VKBot(),
                BotType.Viber => new ViberBot(),
                BotType.WhatsApp => new WhatsAppBot(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
        private static IService GetService(ServiceType serviceType, List<IBotService> listBots)
        {
            return serviceType switch
            {
                ServiceType.BotService => new BotService(listBots),
                ServiceType.ResponseService => new ResponseService(),
                ServiceType.MessageHandlingService => new MessageHandlingService(),
                ServiceType.LoggingService => new LoggingService(),
                ServiceType.DatabaseProcessor => new DatabaseProcessor(),
                ServiceType.WebhookService => new WebhookService(),
                ServiceType.AuthService => new AuthService(),
                ServiceType.NotificationService => new NotificationService(),
                ServiceType.RequestHandlerService => new RequestHandlerService(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
