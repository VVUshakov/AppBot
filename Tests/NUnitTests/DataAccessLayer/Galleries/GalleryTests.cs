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
        public void TestAdd()
        {
            // Arrange
            var picture = new Picture();

            // Act
            _gallery.Add(picture);

            // Assert
            Assert.That(_gallery.GetGallery(), Contains.Item(picture));
        }

        [Test]
        public void TestRemove()
        {
            // Arrange
            var picture = new Picture();
            _gallery.Add(picture);

            // Act
            _gallery.Remove(picture);

            // Assert
            Assert.That(_gallery.GetGallery(), Does.Not.Contain(picture));
        }

        [Test]
        public void TestUpdate()
        {
            // Arrange
            var picture = new Picture();
            _gallery.Add(picture);
            var updatedPicture = new Picture();

            // Act
            _gallery.Update(updatedPicture);

            // Assert
            Assert.That(_gallery.GetGallery(), Contains.Item(updatedPicture));
        }

        [Test]
        public void TestClear()
        {
            // Arrange
            var picture = new Picture();
            _gallery.Add(picture);

            // Act
            _gallery.Clear();

            // Assert
            Assert.That(_gallery.GetGallery(), Is.Empty);
        }

        [Test]
        public void TestGetGallery()
        {
            // Arrange & Act
            var gallery = _gallery.GetGallery();

            // Assert
            Assert.That(gallery, Is.Not.Null);
        }
    }

}