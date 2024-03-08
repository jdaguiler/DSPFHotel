using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Natural
    {
        [Key]
        public int Id_Natural { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(100)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genero { get; set; }

        [Required]
        [MaxLength(100)]
        public string DocumentoIdentidad { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nacionalidad { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}
