using System.ComponentModel.DataAnnotations;

namespace TGTWebApi.Models
{
    public class Tarea
    {
        public int IdTarea { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int IdUsuario { get; set; }
    }
}
