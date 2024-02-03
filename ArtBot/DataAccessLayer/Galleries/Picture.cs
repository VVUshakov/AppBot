using ArtBot.DataAccessLayer.Stories;

namespace ArtBot.DataAccessLayer.Galleries
{
    public class Picture //: IHistory
    {
        public Guid Id { get; }

        
        public Picture()
        {
            /// <summary>
            /// Конструктор класса Picture инициализирует свойство Id новым уникальным Guid при создании нового объекта. 
            /// Это гарантирует, что у каждого объекта будет уникальное значение свойства Id.
            /// </summary>

            Id = Guid.NewGuid();

        }
    }
}
