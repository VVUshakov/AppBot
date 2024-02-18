using ArtBot.Services.Logging;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;

namespace ArtBot.Services.RequestHandlerService
{
    public class RequestHandlerService : IService
    {
        private static bool _disposed = false;

        public async Task StartAsync()
        {
            _disposed = true;
            await LoggingService.LogMessageAsync("RequestHandlerService запущен.");
        }

        public static async Task StopAsync()
        {
            await LoggingService.LogMessageAsync("RequestHandlerService остановлен.");
            _disposed = false;
        }

        public static Task HandleRequestAsync(string request)
        {
            if (_disposed)
            {
                ProcessRequest(request);
                // Обработка запроса
                // ...
            }
            return Task.FromResult(0);
        }

        public static Task ProcessRequest(string request)
        {
            return Task.FromResult(0); //убрать
            /*
            if (!_disposed)
            {
                // Получение сообщения из запроса
                var message = JsonConvert.DeserializeObject<TelegramMessage>(request);

                // Обработка сообщения                
                switch (message.Type)
                {
                    case MessageType.Text:
                        // Обработка текстового сообщения
                        break;
                    case MessageType.Photo:
                        // Обработка фото
                        break;
                    case MessageType.Audio:
                        // Обработка аудио
                        break;
                    case MessageType.Document:
                        // Обработка документа
                        break;
                    case MessageType.Sticker:
                        // Обработка стикера
                        break;
                    case MessageType.Video:
                        // Обработка видео
                        break;
                    case MessageType.Voice:
                        // Обработка голосового сообщения
                        break;
                    case MessageType.Contact:
                        // Обработка контакта
                        break;
                    case MessageType.Location:
                        // Обработка местоположения
                        break;                    
                    case MessageType.Invoice:
                        // Обработка запроса на оплату
                        break;
                    case MessageType.SuccessfulPayment:
                        // Обработка успешной оплаты
                        break;
                    case MessageType.VideoNote:
                        // Обработка видеопримечания
                        break;
                    case MessageType.Animation:
                        // Обработка анимации
                        break;
                    case MessageType.ChatMembersAdded:
                        // Обработка добавления участников чата
                        break;
                    case MessageType.ChatTitleChanged:
                        // Обработка изменения названия чата
                        break;
                    case MessageType.ChatPhotoChanged:
                        // Обработка изменения фотографии чата
                        break;
                    case MessageType.MessagePinned:
                        // Обработка закрепления сообщения
                        break;
                    case MessageType.ChatPhotoDeleted:
                        // Обработка удаления фотографии чата
                        break;
                    case MessageType.Poll:
                        // Обработка голосования
                        break;
                    case MessageType.ProximityAlertTriggered:
                        // Обработка оповещения о близости
                        break;
                    case MessageType.VideoChatScheduled:
                        // Обработка запланированного видеочата
                        break;
                    case MessageType.VideoChatStarted:
                        // Обработка начала сеанса видеочата
                        break;
                    case MessageType.VideoChatEnded:
                        // Обработка завершения сеанса видеочата
                        break;
                    case MessageType.VideoChatParticipantsInvited:
                        // Обработка приглашения участников видеочата
                        break;
                    case MessageType.ForumTopicCreated:
                        // Обработка создания темы форума
                        break;
                    case MessageType.ForumTopicClosed:
                        // Обработка закрытия темы форума
                        break;
                    case MessageType.ForumTopicReopened:
                        // Обработка вновь открытой темы форума
                        break;
                    case MessageType.ForumTopicEdited:
                        // Обработка изменения темы форума
                        break;
                    case MessageType.WriteAccessAllowed:
                        // Обработка разрешения доступа для записи
                        break;
                    case MessageType.UserShared:
                        // Обработка сообщения о том, что пользователь поделился
                        break;
                }
            }
            */
        }
    }
}