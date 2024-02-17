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
        private static readonly List<Picture> _gallery = [];

        /// <summary>
        /// Метод Update обновляет существующее изображение в галерее. 
        /// Он принимает изображение типа Picture в качестве параметра и обновляет его свойства (Name, Description, ImagePath и Price) в галерее, если изображение с таким же идентификатором существует. 
        /// Если изображение с таким же идентификатором не найдено, выбрасывается исключение ArgumentException.
        /// </summary>
        public static void Update(Picture item)
        {   
            Picture? picture = _gallery.FirstOrDefault(i => i.Id == item.Id);
            if (picture != null)
            {
                picture.Name = item.Name;
                picture.Description = item.Description;
                picture.ImagePath = item.ImagePath;
                picture.Price = item.Price;
            }
            else Add(item);
        }

        /// <summary>
        /// Метод Add добавляет изображение в галерее. 
        /// Он принимает изображение типа Picture в качестве параметра,
        /// проверяет есть ли изображение с таким идентификатором в галерее.
        /// Если изображение с таким идентификатором найдено, выбрасывается исключение ArgumentException.
        /// Если в галереи изображения с таким индентификатором не найдено, то новое изображение добавляется в галерею.
        /// </summary>
        public static void Add(Picture item)
        {
            Picture? picture = _gallery.FirstOrDefault(i => i.Id == item.Id);
            if (picture != null) Update(item);
            _gallery.Add(item);
        }

        /// <summary>
        /// Метод Add добавляет новое изображение в галерею. 
        /// Он принимает изображение типа Picture в качестве параметра и добавляет его в список изображений галереи.
        /// </summary>
        public static void Remove(Picture item) => _gallery.Remove(item);

        /// <summary>
        /// Метод Clear очищает галерею, удаляя все изображения. 
        /// Он не принимает параметров и просто вызывает метод Clear класса List<T>, который удаляет все элементы из списка изображений галереи.
        /// </summary>
        public static void Clear() => _gallery.Clear();

        /// <summary>
        /// Метод GetGallery возвращает список всех изображений в галерее. 
        /// Он не принимает параметров и просто возвращает список изображений галереи
        /// </summary>
        public static List<Picture> GetGallery() => _gallery;                
    }
}