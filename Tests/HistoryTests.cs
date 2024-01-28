using ArtBot.DataAccessLayer.History;

namespace Tests
{
    [TestClass]
    public class HistoryTests
    {
        public History History;

        //public List<string> History { get; set; }

        public HistoryTests()
        {
            History = new List<string>();
        }

        [TestMethod]
        public void TestGetHistory()
        {
            // Арrange
            History.Add("Элемент 1");
            History.Add("Элемент 2");

            // Act
            var result = History;

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }

}