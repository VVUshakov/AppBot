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
            // ��range
            History.Add("������� 1");
            History.Add("������� 2");

            // Act
            var result = History;

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }

}