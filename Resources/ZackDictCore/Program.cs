using Microsoft.Data.Sqlite;
using MySqlConnector;

namespace ZackDictCore
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*
            var connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource= "dict.db",
                Mode = SqliteOpenMode.ReadWrite,
                Password = "ab%A1l010o1"
            }.ToString();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            using var cmd = connection.CreateCommand();
            cmd.CommandText = $"Insert into Words(Word, Chinese)  values(@Word, @Chinese)";

            using var mysqlConnection = new MySqlConnection("Server=localhost;Port=3306;Database=youzack20200703;User=root;Password=root;");
            mysqlConnection.Open();
            using var mysqlCmd = mysqlConnection.CreateCommand();
            mysqlCmd.CommandText = "select Word, Translation from t_words where length(tag)>1";
            using var reader = mysqlCmd.ExecuteReader();
            while (reader.Read())
            {
                var word = reader.GetString(0);
                var translation = reader.GetString(1);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Word", word);
                cmd.Parameters.AddWithValue("@Chinese", translation);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Inserted {word} into dict.db");
            }
            
            connection.Close();
            */
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}