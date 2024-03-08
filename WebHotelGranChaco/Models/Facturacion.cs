using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Facturacion
    {
        [Key]
        public int Id_Facturacion { get; set; }

        [Required(ErrorMessage = "La fecha de facturación es obligatoria.")]
        public DateTime FechaFacturacion { get; set; }

        [Required(ErrorMessage = "El número de factura es obligatorio.")]
        public int NumeroFactura { get; set; }

        [Required(ErrorMessage = "El subtotal es obligatorio.")]
        public float SubTotal { get; set; }

        [Required(ErrorMessage = "Los impuestos son obligatorios.")]
        public float Impuestos { get; set; }

        [Required(ErrorMessage = "La forma de pago es obligatoria.")]
        [MaxLength(255)]
        public string FormaPago { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(255)]
        public string Estado { get; set; }

        [ForeignKey("Habitacion")]
        public int IdHabitacion { get; set; }

        public Habitacion Habitacion { get; set; }
    }
}
