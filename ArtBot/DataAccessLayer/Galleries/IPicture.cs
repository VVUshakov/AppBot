using ArtBot.DataAccessLayer.Stories;

namespace ArtBot.DataAccessLayer.Galleries
{
    public class IPicture : IHistory
    {
        public Guid Id { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
        public abstract string ImagePath { get; }
        public abstract decimal Price { get; }
        public abstract History History { get; }

        IPicture()
        {
            Id = Guid.NewGuid();

        }

        /// <summary>
        /// Метод Update используется для изменения свойств объекта и фиксации факта изменения в истории. 
        /// В качестве параметров он принимает имя изменяемого свойства и новое значение свойства.
        /// Если новое значение равно null или пустой строке, метод возвращает управление, не изменяя свойство. 
        /// В зависимости от имени изменяемого свойства, новое значение присваивается соответствующему свойству объекта. 
        /// Если имя свойства не найдено в истории, выбрасывается исключение ArgumentException.
        /// После изменения свойства, новое значение вместе с текущим временем добавляется в историю.
        /// После изменения свойств, текущий объект Picture обновляется в галерее.
        /// </summary>
        /// <param name="propertyName">Имя изменяемого свойства</param>
        /// <param name="newValue">Новое значение свойства</param>
        private void Update(string propertyName, string newValue)
        {
            if (string.IsNullOrEmpty(newValue)) return;

            switch (propertyName)
            {
                case "Name": Name = newValue; break;
                case "Description": Description = newValue; break;
                case "ImagePath": _imagePath = newValue; break;
                case "Price": _price = decimal.Parse(newValue); break;
                default: throw new ArgumentException($"Property {propertyName} not found in history");
            }

            History.Add(propertyName, DateTime.Now, newValue);
            Gallery.Update(this);
        }
    }
}
