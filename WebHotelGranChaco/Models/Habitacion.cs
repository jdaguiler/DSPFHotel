using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebHotelGranChaco.Models
{
    public class Habitacion
    {
        [Key]
        public int Id_Habitacion { get; set; }

        [Required(ErrorMessage = "El número de habitación es obligatorio.")]
        public int NumeroHabitacion { get; set; }

        [Required(ErrorMessage = "El precio por noche es obligatorio.")]
        public float PrecioPorNoche { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        [Required(ErrorMessage = "El estado de la habitación es obligatorio.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "La fecha de limpieza es obligatoria.")]
        public DateTime FechaLimpieza { get; set; }
        [ForeignKey("TipoHabitacion")]
        public int IdTipoHabitacion { get; set; }

        public TipoHabitacion TipoHabitacion { get; set; }

    }
}
