using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;


namespace ArtBot.Services
{
    // Базовый класс для обработки сообщений и команд
    abstract class BotService
    {
        protected TelegramBotClient bot;

        public BotService(TelegramBotClient bot)
        {
            this.bot = bot;
        }

        public abstract Task StartAsync();

        public Task SendMessageAsync(int chatId, string message)
        {
            return bot.SendTextMessageAsync(chatId, message);
        }

        public Task SendPhotoAsync(int chatId, InputFile photoFilePath)
        {
            return bot.SendPhotoAsync(chatId, photoFilePath);
        }

        public Task SendDocumentAsync(int chatId, InputFile documentFilePath)
        {
            return bot.SendDocumentAsync(chatId, documentFilePath);
        }

        public Task SendVoiceAsync(int chatId, InputFile voiceFilePath)
        {
            return bot.SendVoiceAsync(chatId, voiceFilePath);
        }

        public Task SendVideoAsync(int chatId, InputFile videoFilePath)
        {
            return bot.SendVideoAsync(chatId, videoFilePath);
        }

        public Task SendAnimationAsync(int chatId, InputFile animationFilePath)
        {
            return bot.SendAnimationAsync(chatId, animationFilePath);
        }

        public Task SendStickerAsync(int chatId, InputFile stickerFilePath)
        {
            return bot.SendStickerAsync(chatId, stickerFilePath);
        }

        public Task SendAudioAsync(int chatId, InputFile audioFilePath)
        {
            return bot.SendAudioAsync(chatId, audioFilePath);
        }

        public Task SendContactAsync(ChatId chatId, string phoneNumber, string firstName)
        {
            return bot.SendContactAsync(chatId, phoneNumber, firstName);
        }

        public Task SendLocationAsync(int chatId, double latitude, double longitude)
        {
            return bot.SendLocationAsync(chatId, latitude, longitude);
        }

        public Task SendVenueAsync(int chatId, double latitude, double longitude, string title, string address)
        {
            return bot.SendVenueAsync(chatId, latitude, longitude, title, address);
        }

        public Task SendButtonCallbackQueryAsync(int chatId, MenuButton callbackQuery)
        {
            return bot.SetChatMenuButtonAsync(chatId, callbackQuery);
        }

        public Task SendInlineQueryAsync(string chatId, IEnumerable<InlineQueryResult> inlineQuery)
        {
            return bot.AnswerInlineQueryAsync(chatId, inlineQuery);
        }

        public Task SendChatActionAsync(int chatId, ChatAction action)
        {
            return bot.SendChatActionAsync(chatId, action);
        }

    }
}