using ArtBot.DataAccessLayer.Galleries;

namespace NUnitTests.DataAccessLayer.Galleries
{
    [TestFixture]
    public class PictureTests
    {
        private Picture _picture;

        [SetUp]
        public void SetUp()
        {
            _picture = new Picture();
        }

        [Test]
        public void TestIdProperty()
        {
            // Arrange & Act
            var id = _picture.Id;

            // Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void TestNameProperty()
        {
            // Arrange & Act
            var name = _picture.Name;

            // Assert
            Assert.That(name, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestDescriptionProperty()
        {
            // Arrange & Act
            var description = _picture.Description;

            // Assert
            Assert.That(description, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestImagePathProperty()
        {
            // Arrange & Act
            var imagePath = _picture.ImagePath;

            // Assert
            Assert.That(imagePath, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestPriceProperty()
        {
            // Arrange & Act
            var price = _picture.Price;

            // Assert
            Assert.That(price, Is.EqualTo(decimal.Zero));
        }

    }

}
