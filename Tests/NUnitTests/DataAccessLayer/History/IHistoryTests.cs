using ArtBot.DataAccessLayer.Stories;
using NUnit.Framework.Internal;


namespace NUnitTests
{
    /// <summary>
    /// IHistoryTests проверяет, что свойство History возвращает не null, что означает, что интерфейс IHistory реализован правильно.
    /// HistoryImplementation - это класс, который реализует интерфейс IHistory. 
    /// Он принимает объект History в конструкторе и устанавливает его в свойство History.
    /// 
    /// IHistoryTests checks that the History property returns non-null, which means that the IHistory interface is implemented correctly.
    /// HistoryImplementation is a class that implements the IHistory interface.
    /// It takes a History object in the constructor and sets it to the History property.
    /// </summary>
    [TestFixture]
    public class IHistoryTests
    {
        [Test]
        public void HistoryPropertyReturnsNotNull()
        {
            // Arrange
            var history = new History();
            var historyInterface = new HistoryImplementation(history);

            // Act
            var historyProperty = historyInterface.History;

            // Assert
            Assert.That(historyProperty, Is.Not.Null);
        }
    }

    public class HistoryImplementation(History history) : IHistory
    {
        private readonly History _history = history;

        public History History => _history;
    }
}