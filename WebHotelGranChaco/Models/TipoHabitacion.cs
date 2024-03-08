using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class TipoHabitacion
    {
        [Key]
        public int Id_Tipo { get; set; }

        [Required(ErrorMessage = "El nombre del tipo es obligatorio.")]
        [MaxLength(255)]
        public string NombreTipo { get; set; }

        [Required(ErrorMessage = "La capacidad máxima es obligatoria.")]
        [MaxLength(255)]
        public string CapacidadMaxima { get; set; }

        [Required(ErrorMessage = "El precio base es obligatorio.")]
        public float PrecioBase { get; set; }

        public string Descripcion { get; set; }

    }
}
