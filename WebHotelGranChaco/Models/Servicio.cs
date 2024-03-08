using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Servicio
    {
        [Key]
        public int Id_Servicio { get; set; }

        [Required(ErrorMessage = "El nombre del servicio es obligatorio.")]
        [MaxLength(255)]
        public string NombreServicio { get; set; }

        public string DescripcionServicio { get; set; }

        [Required(ErrorMessage = "El costo del servicio es obligatorio.")]
        public float CostoServicio { get; set; }

        [ForeignKey("Habitacion")]
        public int IdHabitacion { get; set; }

        public Habitacion Habitacion { get; set; }
    }
}
