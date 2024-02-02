namespace ArtBot.Services
{
    internal interface ILogger
    {
    }

    class LoggingService
    {
        /// <summary>
        /// Сервис логирования действий пользователей: 
        /// Этот сервис отвечает за запись действий пользователей в журнал или базу данных. 
        /// Он может быть полезен для отслеживания активности пользователей, 
        /// обнаружения проблем и анализа поведения пользователей.
        /// </summary>

        /*
         * В этом примере класс LoggingService реализует метод StartAsync, который будет вызван при запуске сервиса. 
         * Внутри метода StartAsync выполняется логирование действия пользователя в различные системы хранения.
         * Класс LoggingService использует словарь _loggers, чтобы хранить логировщики для различных категорий действий. 
         * 
         * Метод RegisterLogger позволяет зарегистрировать логировщик для определенной категории.
         * 
         * Метод StartAsync собирает все зарегистрированные логировщики и логирует сообщение для каждого из них. 
         * Сообщение включает информацию о времени, категории действия и названии текущего метода.
         * 
         * Вы можете использовать различные реализации интерфейса ILogger, чтобы логировать информацию в разные системы хранения, 
         * такие как базы данных, файловые системы или облачные сервисы. 
         * Каждый логировщик может иметь свои собственные настройки и параметры, 
         * чтобы адаптировать логирование под конкретные требования и потребности.
        */


        private readonly IDictionary<string, ILogger> _loggers;

        public LoggingService()
        {
            _loggers = new Dictionary<string, ILogger>();
        }

        public void RegisterLogger(string category, ILogger logger)
        {
            _loggers.Add(category, logger);
        }

        public Task StartAsync()
        {
            // Логирование действий пользователей
            var loggers = _loggers.ToList();
            foreach (var logger in loggers)
            {
                var message = $"{DateTime.Now}: {logger.Key} - {GetCurrentMethodName()}";
                //logger.Log(message);
            }
            return Task.FromResult(0);
        }

        private object GetCurrentMethodName()
        {
            throw new NotImplementedException();
        }
    }
}