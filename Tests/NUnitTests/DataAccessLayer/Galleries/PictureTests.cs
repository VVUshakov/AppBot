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

        [Test]
        public void TestUpdateNameProperty()
        {
            // Arrange
            var newName = "New Name";

            // Act
            _picture.Name = newName;

            // Assert
            Assert.That(_picture.Name, Is.EqualTo(newName));
        }

        [Test]
        public void TestUpdateDescriptionProperty()
        {
            // Arrange
            var newDescription = "New Description";

            // Act
            _picture.Description = newDescription;

            // Assert
            Assert.That(_picture.Description, Is.EqualTo(newDescription));
        }

        [Test]
        public void TestUpdateImagePathProperty()
        {
            // Arrange
            var newImagePath = "New Image Path";

            // Act
            _picture.ImagePath = newImagePath;

            // Assert
            Assert.That(_picture.ImagePath, Is.EqualTo(newImagePath));
        }

        [Test]
        public void TestUpdatePriceProperty()
        {
            // Arrange
            var newPrice = 100m;

            // Act
            _picture.Price = newPrice;

            // Assert
            Assert.That(_picture.Price, Is.EqualTo(newPrice));
        }
    }
}
