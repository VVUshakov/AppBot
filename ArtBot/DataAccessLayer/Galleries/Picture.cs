using ArtBot.DataAccessLayer.Stories;

namespace ArtBot.DataAccessLayer.Galleries
{
    /// <summary>
    /// Данный класс данных представляет собой объект Картина.
    /// </summary>
    public class Picture : IHistory
    {
        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string ImagePath { get; } = string.Empty;
        public decimal Price { get; } = decimal.Zero;
        public History History { get; } = new();
                
        /// <summary>
        /// Конструктор класса Picture инициализирует свойство Id новым уникальным Guid при создании нового объекта. 
        /// Это гарантирует, что у каждого объекта будет уникальное значение свойства Id.
        /// </summary>
        public Picture() => Id = Guid.NewGuid();
    }
}
