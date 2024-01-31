namespace ArtBot.DataAccessLayer.History
{
    /// <summary>
    /// В этом интерфейсе определено свойство History, которое возвращает объект класса History. 
    /// Классы, реализующие этот интерфейс, должны предоставить реализацию этого свойства, которая хранит объект истории.
    /// </summary>
    public interface IHistory
    {
        History History { get; }
    }
}