using ArtBot.Services.BotServices;
using ArtBot.Services;
using ArtBot.Services.BotServices.TG;
using System.Collections.Generic;

namespace ArtBot
{
    /// <summary>
    /// Класс конфигурирующий параметры начальной загрузки приложения
    /// </summary>
    internal class Configuration
    {
        public static List<IService> listServices;

        public static void Build()
        {
            listServices = GetListStartedServices();
        }

        private static List<IService> GetListStartedServices()
        {   
            // Создание списка экземпляров ботов
            var listBots = new List<IBotService>();

            listBots.AddRange(Enum.GetValues(typeof(BotType))
                    .Cast<BotType>()
                    .Select(GetBotService));

            // Создание списка экземпляров сервисов
            var listServices = new List<IService>();

            listServices.AddRange(Enum.GetValues(typeof(ServiceType))
                .Cast<ServiceType>()
                .Select(serviceType => GetService(serviceType, listBots)));

            return listServices;
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
