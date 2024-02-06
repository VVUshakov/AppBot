using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBot.DataAccessLayer.Entities
{
    /// <summary>
    /// LoggingMode - это класс, который содержит информацию о способе логирования.
    /// Вы можете использовать эти объекты для инициализации свойства LoggingModes в конструкторе класса LoggingService.
    /// </summary>
    public class LoggingMode
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // Добавьте другие свойства, если необходимо
        public string ConnectionString { get; set; }
    }

}
