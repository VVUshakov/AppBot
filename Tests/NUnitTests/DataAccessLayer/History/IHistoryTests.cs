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
            var historyInterface1 = new HistoryImplementation1();
            var historyInterface2 = new HistoryImplementation2(history);

            // Act
            var historyProperty1 = historyInterface1.History;
            var historyProperty2 = historyInterface2.History;

            // Assert
            Assert.That(historyProperty1, Is.Not.Null);
            Assert.That(historyProperty2, Is.Not.Null);
        }
    }

    public class HistoryImplementation1 : IHistory
    {
        private readonly History _history = new();

        public History History => _history;
    }

    public class HistoryImplementation2(History history) : IHistory
    {
        private readonly History _history = history;

        public History History => _history;
    }
}