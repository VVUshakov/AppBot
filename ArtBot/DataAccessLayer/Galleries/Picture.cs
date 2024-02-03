using ArtBot.DataAccessLayer.Stories;
using System.Xml.Linq;

namespace ArtBot.DataAccessLayer.Galleries
{
    public class Picture : IHistory
    {
        /// <summary>
        /// Данный класс данных представляет собой объект Картина.
        /// </summary>

        public Guid Id { get; }
        private string? _name;
        private string? _description;
        private string? _imagePath;
        private decimal _price;
        public History<string>? History { get; }

        public Picture()
        {
            /// <summary>
            /// Конструктор класса Picture инициализирует свойство Id новым уникальным Guid при создании нового объекта. 
            /// Это гарантирует, что у каждого объекта будет уникальное значение свойства Id.
            /// </summary>

            Id = Guid.NewGuid();
        }

        public string Name
        {
            /// <summary>
            /// Свойство Name предоставляет доступ к имени объекта. 
            /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
            /// Перед вызовом метода Update проверяется, не равно ли новое значение null и не равно ли оно текущему значению свойства. 
            /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
            /// </summary>

            get { return _name; }
            set { if (value != null && _name != value) Update(nameof(Name), value); }
        }
        public string Description
        {
            /// <summary>
            /// Свойство Description предоставляет доступ к описанию объекта. 
            /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
            /// Перед вызовом метода Update проверяется, не равно ли новое значение null и не равно ли оно текущему значению свойства. 
            /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
            /// </summary>

            get { return _description; }
            set { if (value != null && _description != value) Update(nameof(Description), value); }
        }
        public string ImagePath
        {
            /// <summary>
            /// Свойство ImagePath предоставляет доступ к Url объекта. 
            /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
            /// Перед вызовом метода Update проверяется, не равно ли новое значение null и не равно ли оно текущему значению свойства. 
            /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
            /// </summary>

            get { return _imagePath; }
            set { if (value != null && _imagePath != value) Update(nameof(ImagePath), value); }
        }
        public decimal Price
        {
            /// <summary>
            /// Свойство Price предоставляет доступ к цене объекта. 
            /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
            /// Перед вызовом метода Update проверяется, может ли новое значение быть успешно преобразовано в decimal, 
            /// не равно ли оно текущему значению свойства и больше ли оно или равно 0. 
            /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
            /// </summary>

            get { return _price; }
            set { if (decimal.TryParse(value.ToString(), out _) && value >= 0 && _price != value) Update(nameof(Price), value); }
        }

        public void Update<T>(string propertyName, T newValue)
        {
            /// <summary>
            /// Метод Update используется для изменения свойств объекта и фиксации факта изменения в истории. 
            /// В качестве параметров он принимает имя изменяемого свойства и новое значение свойства. 
            /// Перед изменением свойства, новое значение преобразуется в строку. 
            /// Если новое значение равно null или пустой строке, метод возвращает управление, не изменяя свойство. 
            /// В зависимости от имени изменяемого свойства, новое значение присваивается соответствующему свойству объекта. 
            /// После изменения свойства, новое значение вместе с текущим временем добавляется в историю. 
            /// Если имя свойства не найдено в истории, выбрасывается исключение ArgumentException.
            /// </summary>
            /// <param name="propertyName">Имя изменяемого свойства</param>
            /// <param name="newValue">Новое значение свойства</param>

            string value = newValue.ToString();
            if (string.IsNullOrEmpty(value)) return;

            switch (propertyName)
            {
                case "Name": _name = value; break;
                case "Description": _description = value; break;
                case "ImagePath": _imagePath = value; break;
                case "Price": _price = decimal.Parse(value); break;
                default: throw new ArgumentException($"Property {propertyName} not found in history");
            }

            History.Add(propertyName, value, DateTime.Now);
        }
    }
}