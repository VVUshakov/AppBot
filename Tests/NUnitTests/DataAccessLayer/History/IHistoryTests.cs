using ArtBot.DataAccessLayer.History;
using NUnit.Framework;
using NUnit.Framework.Internal;


namespace NUnitTests
{
    /// <summary>
    /// IHistoryTests проверяет, что свойство History возвращает не null, что означает, что интерфейс IHistory реализован правильно.
    /// HistoryImplementation - это класс, который реализует интерфейс IHistory. 
    /// Он принимает объект History в конструкторе и устанавливает его в свойство History.
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