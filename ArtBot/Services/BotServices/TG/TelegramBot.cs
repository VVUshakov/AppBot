using Telegram.Bot;

namespace ArtBot.Services.BotServices.TG
{
    public class TelegramBot : IBotService
    {
        public string Token { get; }

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
            // Получить сведения о боте и вывести в консоль
            var me = await botClient.GetMeAsync();
            Console.WriteLine($"TelegramBot {me.Id} запущен с именем {me.FirstName}.");
        }
    }
}
