using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [MaxLength(100)]
        public string CorreoElectronico { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [MaxLength(255)]
        public string Password { get; set; }

        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }

        public Empleado Empleado { get; set; }

    }
}
