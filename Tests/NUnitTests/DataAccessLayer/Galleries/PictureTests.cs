using ArtBot.DataAccessLayer.Galleries;

namespace NUnitTests.DataAccessLayer.Galleries
{
    [TestFixture]
    public class PictureTests
    {
        private Picture _picture;

        [SetUp]
        public void SetUp() 
            => _picture = new Picture();

        [Test]
        public void TestIdProperty()
            => Assert.That(_picture.Id, Is.Not.EqualTo(Guid.Empty)); // Assert

        [Test]
        public void TestNameProperty() 
            => Assert.That(_picture.Name, Is.EqualTo(string.Empty)); // Assert

        [Test]
        public void TestDescriptionProperty()
            => Assert.That(_picture.Description, Is.EqualTo(string.Empty)); // Assert

        [Test]
        public void TestImagePathProperty() 
            => Assert.That(_picture.ImagePath, Is.EqualTo(string.Empty)); // Assert

        [Test]
        public void TestPriceProperty()         
            => Assert.That(_picture.Price, Is.EqualTo(decimal.Zero)); // Assert

        [Test]
        public void TestUpdateNameProperty()
        {
            // Arrange
            var newName1 = "New Name1";
            var newName2 = "New Name2";

            // Act
            _picture.Name = newName1;
            _picture.Name = newName2;

            // Assert
            Assert.That(_picture.Name, Is.Not.EqualTo(newName1));
            Assert.That(_picture.Name, Is.EqualTo(newName2));
        }

        [Test]
        public void TestUpdateDescriptionProperty()
        {
            // Arrange
            var newDescription1 = "New Description1";
            var newDescription2 = "New Description2";

            // Act
            _picture.Description = newDescription1;
            _picture.Description = newDescription2;

            // Assert
            Assert.That(_picture.Description, Is.Not.EqualTo(newDescription1));
            Assert.That(_picture.Description, Is.EqualTo(newDescription2));
        }

        [Test]
        public void TestUpdateImagePathProperty()
        {
            // Arrange
            var newImagePath1 = "New Image Path1";
            var newImagePath2 = "New Image Path2";

            // Act
            _picture.ImagePath = newImagePath1;
            _picture.ImagePath = newImagePath2;

            // Assert
            Assert.That(_picture.ImagePath, Is.Not.EqualTo(newImagePath1));
            Assert.That(_picture.ImagePath, Is.EqualTo(newImagePath2));
        }

        [Test]
        public void TestUpdatePriceProperty()
        {
            // Arrange
            var newPrice1 = 100m;
            var newPrice2 = 200m;

            // Act
            _picture.Price = newPrice1;
            _picture.Price = newPrice2;

            // Assert
            Assert.That(_picture.Price, Is.Not.EqualTo(newPrice1));
            Assert.That(_picture.Price, Is.EqualTo(newPrice2));
        }
    }
}
