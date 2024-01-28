using ArtBot.DataAccessLayer.History;

namespace NUnitTests
{
    [TestFixture]
    public class HistoryTest
    {
        [Test]
        public void TestGetHistory()
        {
            // Arrange
            var history = new History();
            var propertyName1 = "Property1";
            var propertyName2 = "Property2";
            var newValue1 = "NewValue1";
            var newValue2 = "NewValue2";
            var time1 = DateTime.Now;
            var time2 = DateTime.Now.AddDays(1);

            // Act
            history.Add(propertyName1, newValue1, time1);
            history.Add(propertyName2, newValue2, time2);

            // Assert
            var expectedHistory1 = new Dictionary<DateTime, string>
            {
                { time1, newValue1 }
            };
            var expectedHistory2 = new Dictionary<DateTime, string>
            {
                { time2, newValue2 }
            };
            Assert.That(history.GetHistory(propertyName1), Is.EqualTo(expectedHistory1));
            Assert.That(history.GetHistory(propertyName2), Is.EqualTo(expectedHistory2));
        }



        [Test]
        public void TestAdd()
        {
            // Arrange
            var history = new History();
            var propertyName = "Property1";
            var newValue = "NewValue";
            var time = DateTime.Now;

            // Act
            history.Add(propertyName, newValue, time);

            // Assert
            var expectedHistory = new Dictionary<DateTime, string>
            {
                { time, newValue }
            };
            Assert.That(history.GetHistory(propertyName), Is.EqualTo(expectedHistory));
        }

        [Test]
        public void TestGetAllHistory()
        {
            // Arrange
            var history = new History();
            var propertyName1 = "Property1";
            var propertyName2 = "Property2";
            var newValue1 = "NewValue1";
            var newValue2 = "NewValue2";
            var time1 = DateTime.Now;
            var time2 = DateTime.Now.AddDays(1);

            // Act
            history.Add(propertyName1, newValue1, time1);
            history.Add(propertyName2, newValue2, time2);

            // Assert
            var expectedHistory = new Dictionary<string, Dictionary<DateTime, string>>
            {
                { propertyName1, new Dictionary<DateTime, string> { { time1, newValue1 } } },
                { propertyName2, new Dictionary<DateTime, string> { { time2, newValue2 } } }
            };
            Assert.That(history.GetAllHistory(), Is.EqualTo(expectedHistory));
        }

        [Test]
        public void TestGetValueOnDate()
        {
            // Arrange
            var history = new History();
            var propertyName = "Property1";
            var newValue1 = "NewValue1";
            var newValue2 = "NewValue2";
            var time1 = DateTime.Now;
            var time2 = DateTime.Now.AddDays(1);

            // Act
            history.Add(propertyName, newValue1, time1);
            history.Add(propertyName, newValue2, time2);

            // Assert
            var expectedValue1 = newValue1;
            var expectedValue2 = newValue2;
            Assert.That(history.GetValueOnDate(propertyName, time1), Is.EqualTo(expectedValue1));
            Assert.That(history.GetValueOnDate(propertyName, time2), Is.EqualTo(expectedValue2));
        }
    }
}