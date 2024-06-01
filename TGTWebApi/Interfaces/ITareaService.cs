using TGTWebApi.Models;

namespace TGTWebApi.Interfaces
{
    public interface ITareaService
    {
        Task<IEnumerable<Tarea>> GetAllTareasAsync();
    }
}
