using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebHotelGranChaco.Models;

namespace WebHotelGranChaco.Dtos
{
    //definir la estructura de los datos que se pueden transferir y manipular dentro de la aplicación,
    //proporcionando reglas de validación y relaciones entre entidades.
    public class DtoRegistro
    {
        public int Id_Registro { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "La fecha de salida es obligatoria.")]
        public DateTime FechaSalida { get; set; }

        [Required(ErrorMessage = "El número de habitación es obligatorio.")]
        public int NumeroHabitacion { get; set; }

        [Required(ErrorMessage = "El número de huéspedes es obligatorio.")]
        public int NumeroHuspedes { get; set; }

        [Required(ErrorMessage = "El número de noches es obligatorio.")]
        public int Noches { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [MaxLength(100)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "El precio total es obligatorio.")]
        public float PrecioTotal { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        [ForeignKey("Habitacion")]
        public int IdHabitacion { get; set; }

        public Habitacion Habitacion { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}
