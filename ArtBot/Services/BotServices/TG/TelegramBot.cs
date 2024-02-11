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

            // Получить сведения о боте и отправить на логирование
            var me = await botClient.GetMeAsync();
            await LoggingService.LogMessageAsync($"TelegramBot {me.Id} запущен с именем {me.FirstName}.");
        }
    }
}
