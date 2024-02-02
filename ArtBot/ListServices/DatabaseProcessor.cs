using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArtBot.ListServices
{

    public class DatabaseProcessor
    {
        /// <summary>
        /// Сервис обработки баз данных: 
        /// Этот сервис отвечает за взаимодействие с базой данных, которая может использоваться для хранения информации о пользователях, настройках бота и других данных. 
        /// Он может включать в себя функциональность для создания, чтения, обновления и удаления данных в базе данных.
        /// </summary>


        private readonly string connectionString;

        public DatabaseProcessor(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Process()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Выполняем SQL-запросы
                SqlCommand command = new SqlCommand("SELECT * FROM Users", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // Обрабатываем данные
                    string username = reader["Username"].ToString();
                    string email = reader["Email"].ToString();

                    // Выполняем дополнительные действия с данными
                    // Например, сохраняем данные в другую базу данных или файл
                    // Или выполняем бизнес-логику на основе данных
                }

                reader.Close();
            }
        }
    }
}
