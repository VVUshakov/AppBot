namespace ArtBot.DataAccessLayer.Galleries
{
    /// <summary>
    /// Класс Gallery представляет собой коллекцию изображений, которые можно добавлять, удалять и обновлять. 
    /// Метод Add добавляет новое изображение в галерею. 
    /// Метод Remove удаляет изображение из галереи. 
    /// Метод Update обновляет существующее изображение в галерее. 
    /// Метод Clear очищает галерею, удаляя все изображения. 
    /// Метод GetGallery возвращает список всех изображений в галерее.
    /// </summary>
    public class Gallery
    {
        private readonly List<Picture> _gallery = [];

        /// <summary>
        /// Метод Update обновляет существующее изображение в галерее. 
        /// Он принимает изображение типа Picture в качестве параметра и обновляет его свойства (Name, Description, ImagePath и Price) в галерее, если изображение с таким же идентификатором существует. 
        /// Если изображение с таким же идентификатором не найдено, выбрасывается исключение ArgumentException.
        /// </summary>
        public void Update(Picture item)
        {   
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
                //TODO: реализовать отправку сообщения пользователю об отсутсвии такой картины
            }
        }

        /// <summary>
        /// Метод Add добавляет новое изображение в галерею. 
        /// Он принимает изображение типа Picture в качестве параметра и добавляет его в список изображений галереи.
        /// </summary>
        public void Remove(Picture item) => _gallery.Remove(item);

        /// <summary>
        /// Метод Clear очищает галерею, удаляя все изображения. 
        /// Он не принимает параметров и просто вызывает метод Clear класса List<T>, который удаляет все элементы из списка изображений галереи.
        /// </summary>
        public void Clear() => _gallery.Clear();

        /// <summary>
        /// Метод GetGallery возвращает список всех изображений в галерее. 
        /// Он не принимает параметров и просто возвращает список изображений галереи
        /// </summary>
        public List<Picture> GetGallery() => _gallery;
    }
}