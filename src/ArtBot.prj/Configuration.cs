using ArtBot.Services;
using ArtBot.Services.AuthService;
using ArtBot.Services.Bot;
using ArtBot.Services.Bot.TG;
using ArtBot.Services.Bot.Viber;
using ArtBot.Services.Bot.VK;
using ArtBot.Services.Bot.WhatsApp;
using ArtBot.Services.DatabaseProcessor;
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

        public Configuration()
        {
            ListBots = GetListBots();
            ListServices = GetListServices();

            //добавить другие элементы конфигурации, предварительно добавив свойство в класс
        }

        /// <summary>
        /// Создание списка экземпляров ботов
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private List<IBotService> GetListBots()
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
        private List<IService> GetListServices()
        {
            var listServices = new List<IService>();
            listServices.AddRange(Enum.GetValues(typeof(ServiceType))
                .Cast<ServiceType>()
                .Select(GetService));
            if (listServices.Count <= 0)
                throw new InvalidOperationException("Нет подписанных сервисов для загрузки.");
            return listServices;
        }

        private IBotService GetBotService(BotType botType)
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
        private IService GetService(ServiceType serviceType)
        {
            return serviceType switch
            {
                ServiceType.BotService => new BotService(ListBots),
                ServiceType.ResponseService => new ResponseService(),
                ServiceType.MessageHandlingService => new MessageHandlingService(),
                //ServiceType.LoggingService => new LoggingService(),
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
