using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class DetalleProducto
    {
        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "La fecha de renovación es obligatoria.")]
        public DateTime FechaRenovacion { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        [ForeignKey("Habitacion")]
        public int IdHabitacion { get; set; }
        public Habitacion Habitacion { get; set; }
    }
}
