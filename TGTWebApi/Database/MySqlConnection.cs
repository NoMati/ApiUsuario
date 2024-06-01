using MySqlConnector;

namespace TGTWebApi.Database
{
    public class MySQLConnection
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public MySQLConnection()
        {
            Initialize();
        }

        // Inicializar valores de conexión
        private void Initialize()
        {
            server = "localhost";
            database = "tgt_prueba";
            uid = "root";
            password = "1234";
            string connectionString;
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            connection = new MySqlConnection(connectionString);
        }

        // Abrir conexión a la base de datos
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Cerrar conexión a la base de datos
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
