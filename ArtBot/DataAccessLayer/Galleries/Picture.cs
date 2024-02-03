using ArtBot.DataAccessLayer.Stories;


namespace ArtBot.DataAccessLayer.Galleries
{
    /// <summary>
    /// Данный класс данных представляет собой объект Картина.
    /// </summary>
    public class Picture : IHistory
    {
        public Guid Id { get; }
        private string _name = string.Empty;
        private string _description = string.Empty;
        private string _imagePath = string.Empty;
        private decimal _price = decimal.Zero;
        public History History { get; } = new();

        /// <summary>
        /// Конструктор класса Picture инициализирует свойство Id новым уникальным Guid при создании нового объекта. 
        /// Это гарантирует, что у каждого объекта будет уникальное значение свойства Id.
        /// </summary>
        public Picture() => Id = Guid.NewGuid();

        /// <summary>
        /// Свойство Name предоставляет доступ к имени объекта. 
        /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
        /// Перед вызовом метода Update проверяется, не равно ли новое значение null и не равно ли оно текущему значению свойства. 
        /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { if (value != null && _name != value) Update(nameof(Name), value.ToString()); }
        }

        /// <summary>
        /// Свойство Description предоставляет доступ к описанию объекта. 
        /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
        /// Перед вызовом метода Update проверяется, не равно ли новое значение null и не равно ли оно текущему значению свойства. 
        /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { if (value != null && _description != value) Update(nameof(Description), value.ToString()); }
        }

        /// <summary>
        /// Свойство ImagePath предоставляет доступ к Url объекта. 
        /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
        /// Перед вызовом метода Update проверяется, не равно ли новое значение null и не равно ли оно текущему значению свойства. 
        /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
        /// </summary>
        public string ImagePath
        {
            get { return _imagePath; }
            set { if (value != null && _imagePath != value) Update(nameof(ImagePath), value.ToString()); }
        }

        /// <summary>
        /// Свойство Price предоставляет доступ к цене объекта. 
        /// При изменении значения свойства вызывается метод Update, который фиксирует изменение в истории. 
        /// Перед вызовом метода Update проверяется, может ли новое значение быть успешно преобразовано в decimal, 
        /// не равно ли оно текущему значению свойства и больше ли оно или равно 0. 
        /// Если хотя бы одно из условий не выполняется, метод Update не вызывается.
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set { if (decimal.TryParse(value.ToString(), out _) && value >= 0 && _price != value) Update(nameof(Price), value.ToString()); }
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
                case "Name": _name = newValue; break;
                case "Description": _description = newValue; break;
                case "ImagePath": _imagePath = newValue; break;
                case "Price": _price = decimal.Parse(newValue); break;
                default: throw new ArgumentException($"Property {propertyName} not found in history");
            }

            History.Add(propertyName, DateTime.Now, newValue);
            Gallery.Update(this);
        }
    }
}
