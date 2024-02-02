using ArtBot.DataAccessLayer.History;
using NUnit.Framework.Internal;


namespace NUnitTests
{
    [TestFixture]
    public class HistoryTest
    {
        private History history;

        string propertyName1;
        string propertyName2;
        DateTime dateAndTime1;
        DateTime dateAndTime2;
        string newValue1;
        string newValue2;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            history = new History();
            propertyName1 = "PropertyName1";
            propertyName2 = "PropertyName2";
            dateAndTime1 = DateTime.Now;
            dateAndTime2 = DateTime.Now.AddDays(1);
            newValue1 = "NewValue1";
            newValue2 = "NewValue2";

            // Act
            history.Add(propertyName1, dateAndTime1, newValue1);
            history.Add(propertyName2, dateAndTime2, newValue2);
        }

        [Test]
        public void TestAdd()
        {
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(history.HistoryChanges.ContainsKey(propertyName1), Is.True);
                Assert.That(history.HistoryChanges[propertyName1].ContainsKey(dateAndTime1), Is.True);
                Assert.That(history.HistoryChanges[propertyName1][dateAndTime1], Is.EqualTo(newValue1));
            });
        }

        [Test]
        public void TestGetAllHistory()
        {
            // Assert
            var expectedHistory = new Dictionary<string, Dictionary<DateTime, string>>
            {
                { propertyName1, new Dictionary<DateTime, string> { { dateAndTime1, newValue1 } } },
                { propertyName2, new Dictionary<DateTime, string> { { dateAndTime2, newValue2 } } }
            };
            Assert.That(history.GetAllHistory(), Is.EqualTo(expectedHistory));
        }

        [Test]
        public void TestGetHistoryProperty()
        {
            // Assert
            var expectedHistory1 = new Dictionary<DateTime, string> { { dateAndTime1, newValue1 } };
            var expectedHistory2 = new Dictionary<DateTime, string> { { dateAndTime2, newValue2 } };
            Assert.Multiple(() =>
            {
                Assert.That(history.GetHistoryProperty(propertyName1), Is.EqualTo(expectedHistory1));
                Assert.That(history.GetHistoryProperty(propertyName2), Is.EqualTo(expectedHistory2));
            });
        }

        [Test]
        public void TestGetValuePropertyOnDate()
        {
            // Assert
            var expectedValue1 = newValue1;
            var expectedValue2 = newValue2;
            Assert.Multiple(() =>
            {
                Assert.That(history.GetValuePropertyOnDate(propertyName1, dateAndTime1), Is.EqualTo(expectedValue1));
                Assert.That(history.GetValuePropertyOnDate(propertyName2, dateAndTime2), Is.EqualTo(expectedValue2));
            });
        }
    }
}