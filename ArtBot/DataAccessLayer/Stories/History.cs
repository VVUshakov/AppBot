namespace ArtBot.DataAccessLayer.Stories
{
    /// <summary>
    /// Этот класс может быть использован для отслеживания изменений в объекте другого класса. 
    /// Для этого вы должны создать экземпляр класса ChangeHistory в отслеживаемом классе
    /// и вызвать метод Add каждый раз, когда значение свойства объекта изменяется.
    /// </summary>
    public class History
    {
        private Dictionary<string, Dictionary<DateTime, string>> HistoryChanges { get; } = [];

        /// <summary>
        /// Метод Add используется для добавления новой пары ключ-значение в историю изменений объекта.
        /// Он добавляет новую пару ключ-значение по запрашиваемому свойству и времени изменения.
        /// Если свойство не найдено, будет создан новый словарь.
        /// </summary>
        /// <param name="propertyName">Имя изменяемого свойства</param>
        /// <param name="newValue">Новое значение свойства</param>
        /// <param name="dateAndTime">Время изменения</param>
        public void Add(string propertyName, DateTime dateAndTime, string newValue)
        {
            if (!HistoryChanges.TryGetValue(propertyName, out Dictionary<DateTime, string>? value))
            {
                value = [];
                HistoryChanges[propertyName] = value;
            }

            value.Add(dateAndTime, newValue);
        }

        /// <summary>
        /// Метод GetAllHistory возвращает всю историю изменений объекта класса.
        /// </summary>
        /// <returns>История изменений объекта</returns>
        public Dictionary<string, Dictionary<DateTime, string>> GetAllHistory() => HistoryChanges;

        /// <summary>
        /// Метод GetHistory возвращает список всех изменений для указанного свойства.
        /// </summary>
        /// <param name="propertyName">Имя изменяемого свойства</param>
        /// <returns>История изменений для указанного свойства</returns>
        public Dictionary<DateTime, string> GetHistoryProperty(string propertyName) => HistoryChanges[propertyName];

        /// <summary>
        /// Метод GetValueOnDate возвращает актуальное значение запрашиваемого свойства на запрашиваемую дату или на ближайшую более раннюю найденную дату.
        /// </summary>
        /// <param name="propertyName">Имя изменяемого свойства</param>
        /// <param name="date">Запрашиваемая дата</param>
        /// <returns>Значение свойства на запрашиваемую дату</returns>
        public string GetValuePropertyOnDate(string propertyName, DateTime date)
        {
            if (!HistoryChanges.TryGetValue(propertyName, out Dictionary<DateTime, string>? value))
            {
                // Проверяем, есть ли в истории изменений запрашиваемое свойство.
                // Если нет, то выбрасывается исключение.

                throw new KeyNotFoundException($"Property {propertyName} not found in history");
                //TODO: реализовать вызов функции отправки сообщения пользователю 
            }
            {
                // Получаем историю изменений для запрашиваемого свойства.
                // Ищем значение запрашиваемого свойства на запрашиваемую дату в истории.
                // Если запрашиваемая дата отсутствует в истории, ищем значение запрашиваемого свойства на ближайшую более раннюю дату.

                var history = value;
                var valueOnDate = history.FirstOrDefault(x => x.Key == date);
                if (valueOnDate.Equals(default(KeyValuePair<DateTime, string>)))
                {
                    // Если запрашиваемая дата отсутствует в истории, ищем значение запрашиваемого свойтсва на ближайшую более раннюю дату
                    var closestDate = history.OrderBy(x => Math.Abs(x.Key.Subtract(date).TotalDays)).First();
                    return closestDate.Value;
                }

                return valueOnDate.Value;
            }
        }
    }
}