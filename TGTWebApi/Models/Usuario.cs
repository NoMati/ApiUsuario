using System.ComponentModel.DataAnnotations;

namespace TGTWebApi.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(300)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
