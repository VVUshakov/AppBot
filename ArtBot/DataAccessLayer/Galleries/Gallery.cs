using static System.Net.Mime.MediaTypeNames;

namespace ArtBot.DataAccessLayer.Galleries
{
    public class Gallery
    {
        private List<Image> _images = new List<Image>();


        public void Add(Image image)
        {
            _images.Add(image);
        }

        public void Remove(Image image)
        {
            _images.Remove(image);
        }

        public void Update(Image image)
        {
            _images.Remove(image);
            _images.Add(image);
        }

        public void Clear()
        {
            _images.Clear();
        }

        public List<Image> GetGallery()
        {
            return _images;
        }
    }
}
