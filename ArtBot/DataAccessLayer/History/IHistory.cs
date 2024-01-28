namespace ArtBot.DataAccessLayer.History
{
    internal interface IHistory
    {
        /// <summary>
        /// Интерфейс IUpdate определяет свойство класса History.
        /// Свойство History хранит в себе историю изменений объекта.        
        public History<string> History { get; }
    }
}