using ArtBot.DataAccessLayer.Galleries;

namespace NUnitTests.DataAccessLayer.Galleries
{
    [TestFixture]
    public class GalleryTests
    {
        private Gallery _gallery;

        [SetUp]
        public void SetUp()
        {
            _gallery = new Gallery();
        }
        
        [Test]
        public void TestRemove()
        {
            // Arrange
            var picture = new Picture();
            Gallery.Add(picture);

            // Act
            Gallery.Remove(picture);

            // Assert
            Assert.That(Gallery.GetGallery(), Does.Not.Contain(picture));
        }
        
        [Test]
        public void TestClear()
        {
            // Arrange
            var picture = new Picture();
            Gallery.Add(picture);

            // Act
            Gallery.Clear();

            // Assert
            Assert.That(Gallery.GetGallery(), Is.Empty);
        }

        [Test]
        public void TestGetGallery()
        {
            // Arrange & Act
            var gallery = Gallery.GetGallery();

            // Assert
            Assert.That(gallery, Is.Not.Null);
        }

        [Test]
        public void TestAdd()
        {
            // Arrange
            var picture = new Picture();

            // Act
            Gallery.Add(picture);

            // Assert
            Assert.That(Gallery.GetGallery(), Contains.Item(picture));
        }

        [Test]
        public void TestUpdate()
        {
            // Arrange
            var picture = new Picture();
            Gallery.Add(picture);
            
            picture.Name = "TestName";
            picture.Description = "TestDescription";
            picture.ImagePath = "TestImagePath";
            picture.Price = 100m;
            
            var updatedPicture = picture;

            // Act
            Gallery.Update(updatedPicture);

            // Assert
            Assert.That(Gallery.GetGallery(), Contains.Item(updatedPicture));
            Assert.Multiple(() =>
            {
                Assert.That(Gallery.GetGallery().First(p => p.Id == updatedPicture.Id).Name, Is.EqualTo("TestName"));
                Assert.That(Gallery.GetGallery().First(p => p.Id == updatedPicture.Id).Description, Is.EqualTo("TestDescription"));
                Assert.That(Gallery.GetGallery().First(p => p.Id == updatedPicture.Id).ImagePath, Is.EqualTo("TestImagePath"));
                Assert.That(Gallery.GetGallery().First(p => p.Id == updatedPicture.Id).Price, Is.EqualTo(100));
            });
        }
    }
}