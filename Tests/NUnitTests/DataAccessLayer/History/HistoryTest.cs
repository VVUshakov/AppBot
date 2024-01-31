using ArtBot.DataAccessLayer.History;


namespace NUnitTests
{
    [TestFixture]
    public class HistoryTest
    {        
        [Test]
        public void TestAdd()
        {
            // Arrange
            var history = new History();
            var propertyName = "PropertyName";
            var dateAndTime = DateTime.Now;
            var newValue = "NewValue";

            // Act
            history.Add(propertyName, dateAndTime, newValue);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(history.HistoryChanges.ContainsKey(propertyName), Is.True);
                Assert.That(history.HistoryChanges[propertyName].ContainsKey(dateAndTime), Is.True);
                Assert.That(history.HistoryChanges[propertyName][dateAndTime], Is.EqualTo(newValue));
            });
        }

        [Test]
        public void TestGetAllHistory()
        {
            // Arrange
            var history = new History();
            var propertyName1 = "PropertyName1";
            var propertyName2 = "PropertyName2";
            var dateAndTime1 = DateTime.Now;
            var dateAndTime2 = DateTime.Now.AddDays(1);
            var newValue1 = "NewValue1";
            var newValue2 = "NewValue2";

            // Act
            history.Add(propertyName1, dateAndTime1, newValue1);
            history.Add(propertyName2, dateAndTime2, newValue2);

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
            // Arrange
            var history = new History();
            var propertyName1 = "PropertyName1";
            var propertyName2 = "PropertyName2";
            var dateAndTime1 = DateTime.Now;
            var dateAndTime2 = DateTime.Now.AddDays(1);
            var newValue1 = "NewValue1";
            var newValue2 = "NewValue2";

            // Act
            history.Add(propertyName1, dateAndTime1, newValue1);
            history.Add(propertyName2, dateAndTime2, newValue2);

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
            // Arrange
            var history = new History();
            var propertyName = "PropertyName";
            var dateAndTime1 = DateTime.Now;
            var dateAndTime2 = DateTime.Now.AddDays(1);
            var newValue1 = "NewValue1";
            var newValue2 = "NewValue2";

            // Act
            history.Add(propertyName, dateAndTime1, newValue1);
            history.Add(propertyName, dateAndTime2, newValue2);

            // Assert
            var expectedValue1 = newValue1;
            var expectedValue2 = newValue2;
            Assert.Multiple(() =>
            {
                Assert.That(history.GetValuePropertyOnDate(propertyName, dateAndTime1), Is.EqualTo(expectedValue1));
                Assert.That(history.GetValuePropertyOnDate(propertyName, dateAndTime2), Is.EqualTo(expectedValue2));
            });
        }
    }
}