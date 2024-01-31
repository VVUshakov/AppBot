using ArtBot.DataAccessLayer.History;
using NUnit.Framework;
using NUnit.Framework.Internal;


namespace NUnitTests
{
    /// <summary>
    /// IHistoryTests ���������, ��� �������� History ���������� �� null, ��� ��������, ��� ��������� IHistory ���������� ���������.
    /// HistoryImplementation - ��� �����, ������� ��������� ��������� IHistory. 
    /// �� ��������� ������ History � ������������ � ������������� ��� � �������� History.
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