using MySqlConnector;
using TGTWebApi.Interfaces;
using TGTWebApi.Models;

namespace TGTWebApi.Services
{
    public class TareaService : ITareaService
    {
        private readonly MySqlConnection _connection;

        public TareaService(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Tarea>> GetAllTareasAsync()
        {
            List<Tarea> tareas = new List<Tarea>();

            await _connection.OpenAsync();

            string query = "SELECT * FROM Tareas";
            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Tarea tarea = new Tarea
                        {
                            IdTarea = reader.GetInt32("id_tarea"),
                            Descripcion = reader.GetString("descripcion"),
                            Fecha = reader.GetDateTime("fecha"),
                            IdUsuario = reader.GetInt32("id_usuario")
                        };
                    
                        tareas.Add(tarea);
                    }
                }
            }

            _connection.Close();

            return tareas;
        }
    }
}
