using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Pago
    {
        [Key]
        public int Id_Pago { get; set; }

        [Required(ErrorMessage = "La fecha de pago es obligatoria.")]
        public DateTime FechaPago { get; set; }

        [Required(ErrorMessage = "El importe es obligatorio.")]
        public float Importe { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        [MaxLength(255)]
        public string Metodo_Pago { get; set; }

        [ForeignKey("Habitacion")]
        public int IdHabitacion { get; set; }

        public Habitacion Habitacion { get; set; }
    }
}
