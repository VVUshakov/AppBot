namespace ArtBot.DataAccessLayer.History
{
    /// <summary>
    /// Интерфейс IHistory определяет свойство класса History.
    /// Свойство History хранит в себе историю изменений объекта.
    public interface IHistory
    {
        private History<string> _history;
    }

    internal interface IHistory
    {
        /// <summary>
        /// Интерфейс IUpdate определяет свойство класса History.
        /// Свойство History хранит в себе историю изменений объекта.        
        public History<string> History { get; }
    }
}