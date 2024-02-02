using Telegram.Bot.Types.Enums;


namespace ArtBot.Services
{
    class ResponseService //: BotService
    {
        /// <summary>
        /// Сервис отправки ответов и выполнения сценариев: 
        /// Этот сервис отвечает за отправку ответов на сообщения пользователей и выполнение сценариев, определенных в приложении. 
        /// Он может включать в себя функциональность для отправки текстовых сообщений, изображений, видео, аудио 
        /// и других типов сообщений, а также выполнение различных действий в соответствии с определенными сценариями.
        /// </summary>

        /*
         * В этом примере класс ResponseService наследуется от класса BotService и 
         * реализует метод StartAsync, который будет вызван при запуске сервиса. 
         * Внутри метода StartAsync выполняется отправка ответов и выполнение сценариев, определенных в приложении.
         * Класс ResponseService использует класс Telegram.Bot.BotClient для взаимодействия с Telegram API и отправки сообщений и запросов. 
         * Методы SendMessageAsync, SendPhotoAsync, SendDocumentAsync, SendVoiceAsync, SendVideoAsync, SendAnimationAsync, 
         * SendStickerAsync, SendAudioAsync, SendContactAsync, SendLocationAsync, SendVenueAsync, SendButtonCallbackQueryAsync и SendInlineQueryAsync 
         * предоставляют возможность отправлять различные типы сообщений и выполнять различные действия в соответствии с определенными сценариями.
         */

        /*
        public override Task StartAsync()
        {
            // Отправка ответов и выполнение сценариев
            Console.WriteLine("Bot started");
            return base.StartAsync();
        }

        public Task SendMessageAsync(int chatId, string message)
        {
            return bot.SendMessageAsync(chatId, message);
        }

        public Task SendPhotoAsync(int chatId, string photoFilePath)
        {
            return bot.SendPhotoAsync(chatId, photoFilePath);
        }

        public Task SendDocumentAsync(int chatId, string documentFilePath)
        {
            return bot.SendDocumentAsync(chatId, documentFilePath);
        }

        public Task SendVoiceAsync(int chatId, string voiceFilePath)
        {
            return bot.SendVoiceAsync(chatId, voiceFilePath);
        }

        public Task SendVideoAsync(int chatId, string videoFilePath)
        {
            return bot.SendVideoAsync(chatId, videoFilePath);
        }

        public Task SendAnimationAsync(int chatId, string animationFilePath)
        {
            return bot.SendAnimationAsync(chatId, animationFilePath);
        }

        public Task SendStickerAsync(int chatId, string stickerFilePath)
        {
            return bot.SendStickerAsync(chatId, stickerFilePath);
        }

        public Task SendAudioAsync(int chatId, string audioFilePath)
        {
            return bot.SendAudioAsync(chatId, audioFilePath);
        }

        public Task SendContactAsync(int chatId, string contact)
        {
            return bot.SendContactAsync(chatId, contact);
        }

        public Task SendLocationAsync(int chatId, string latitude, string longitude)
        {
            return bot.SendLocationAsync(chatId, latitude, longitude);
        }

        public Task SendVenueAsync(int chatId, string latitude, string longitude, string title, string address)
        {
            return bot.SendVenueAsync(chatId, latitude, longitude, title, address);
        }

        public Task SendButtonCallbackQueryAsync(int chatId, string callbackQuery)
        {
            return bot.SendButtonCallbackQueryAsync(chatId, callbackQuery);
        }

        public Task SendInlineQueryAsync(int chatId, string inlineQuery)
        {
            return bot.SendInlineQueryAsync(chatId, inlineQuery);
        }

        public Task SendChatActionAsync(int chatId, ChatAction action)
        {
            return bot.SendChatActionAsync(chatId, action);
        }
        */
    }

}