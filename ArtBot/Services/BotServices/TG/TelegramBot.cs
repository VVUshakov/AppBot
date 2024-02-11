using Telegram.Bot;
using ArtBot.Services.Logging;

namespace ArtBot.Services.Bot.TG
{
    public class TelegramBot : IBotService
    {
        private string Token { get; }

        public TelegramBot()
        {            
            DotNetEnv.Env.Load();
            Token = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN")
                ?? throw new InvalidOperationException("Нет валидного токена для Telegram.");
        }

        public async Task StartAsync()
        {
            // Создать экземпляр Бота
            var botClient = new TelegramBotClient(Token);

            await Log(botClient);
        }

        private async Task Log(TelegramBotClient botClient)
        {            
            // Получить сведения о боте и вывести в консоль
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"TelegramBot {me.Id} запущен с именем {me.FirstName}.");

            LoggingService.LogMessage();

            //TODO: переделать на отправку сообщения в сервис Логгирования
        }
    }
}
