namespace ArtBot.DataAccessLayer.Galleries
{
    public class Gallery
    {
        /// <summary>
        /// Класс Gallery представляет собой коллекцию изображений, которые можно добавлять, удалять и обновлять. 
        /// Метод Add добавляет новое изображение в галерею. 
        /// Метод Remove удаляет изображение из галереи. 
        /// Метод Update обновляет существующее изображение в галерее. 
        /// Метод Clear очищает галерею, удаляя все изображения. 
        /// Метод GetGallery возвращает список всех изображений в галерее.
        /// </summary>

        private List<Picture> _gallery = [];

        public void Update(Picture item)
        {
            /// <summary>
            /// Метод Update обновляет существующее изображение в галерее. 
            /// Он принимает изображение типа Picture в качестве параметра и обновляет его свойства (Name, Description, ImagePath и Price) в галерее, если изображение с таким же идентификатором существует. 
            /// Если изображение с таким же идентификатором не найдено, выбрасывается исключение ArgumentException.
            /// </summary>

            Picture? picture = _gallery.FirstOrDefault(i => i.Id == item.Id);
            if (picture != null)
            {
                picture.Name = item.Name;
                picture.Description = item.Description;
                picture.ImagePath = item.ImagePath;
                picture.Price = item.Price;
            }
            else
            {
                throw new ArgumentException($"Item with id {item.Id} not found in gallery");
            }
        }

        public void Remove(Picture item)
        {
            /// <summary>
            /// Метод Add добавляет новое изображение в галерею. 
            /// Он принимает изображение типа Picture в качестве параметра и добавляет его в список изображений галереи.
            /// </summary>

            _gallery.Remove(item);
        }

        public void Clear()
        {
            /// <summary>
            /// Метод Clear очищает галерею, удаляя все изображения. 
            /// Он не принимает параметров и просто вызывает метод Clear класса List<T>, который удаляет все элементы из списка изображений галереи.
            /// </summary>

            _gallery.Clear();
        }

        public List<Picture> GetGallery()
        {
            /// <summary>
            /// Метод GetGallery возвращает список всех изображений в галерее. 
            /// Он не принимает параметров и просто возвращает список изображений галереи
            /// </summary>

            return _gallery;
        }
    }
}