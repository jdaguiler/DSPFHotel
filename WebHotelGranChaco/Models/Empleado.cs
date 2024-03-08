using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Empleado
    {
        [Key]
        public int Id_Empleado { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreEmpleado { get; set; }

        [Required]
        [MaxLength(100)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(100)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [MaxLength(100)]
        public string CarnetIdentidad { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genero { get; set; }

        [ForeignKey("Cargo")]
        public int IdCargo { get; set; }

        public Cargo Cargo { get; set; }
    }
}
