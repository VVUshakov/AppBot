using System.Windows.Input;
using Telegram.Bot;


namespace ArtBot.Services
{
    class MessageHandlingService //: BotService
    {
        /// <summary>
        /// Сервис обработки сообщений и команд: 
        /// Этот сервис отвечает за обработку входящих сообщений и команд от пользователей. 
        /// Он может включать в себя функциональность для распознавания и классификации сообщений, 
        /// сопоставления команд с действиями и выполнения соответствующих операций.
        /// </summary>

        /*
         * В этом примере класс MessageHandlingService наследуется от класса BotService 
         * и реализует метод StartAsync, который будет вызван при запуске сервиса.         * 
         * Внутри метода StartAsync выполняется обработка сообщений и команд, зарегистрированных в сервисе.
         * 
         * Класс MessageHandlingService использует словарь _commands, чтобы хранить команды для различных категорий действий. 
         * 
         * Метод RegisterCommand позволяет зарегистрировать команду для определенной категории.
         * 
         * Метод StartAsync собирает все зарегистрированные команды и выполняет их, передавая в качестве аргумента сообщение, 
         * содержащее информацию о времени, названии текущего метода и самом сообщении. 
         * Вы можете использовать различные реализации интерфейса ICommand, 
         * чтобы определить различные команды для обработки сообщений и выполнения соответствующих операций. 
         * Каждая команда может иметь свои собственные параметры и настройки, 
         * чтобы адаптировать обработку сообщений под конкретные требования и потребности вашего приложения.
         */
        
        /*
        private readonly IDictionary<string, ICommand> _commands;

        public MessageHandlingService()
        {
            _commands = new Dictionary<string, ICommand>();
        }

        public void RegisterCommand(string name, ICommand command)
        {
            _commands.Add(name, command);
        }

        public override Task StartAsync()
        {
            // Обработка сообщений и команд
            var commands = _commands.ToList();
            foreach (var command in commands)
            {
                var message = $"{DateTime.Now}: {GetCurrentMethodName()} - {command.Name}";
                command.Execute(message);
            }
            return base.StartAsync();
        }
        */
    }

}