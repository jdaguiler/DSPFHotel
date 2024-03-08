using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Juridico
    {
        [Key]
        public int Id_Juridico { get; set; }

        [Required]
        [MaxLength(100)]
        public string RazonSocial { get; set; }

        [Required]
        [MaxLength(100)]
        public string Representacionlegal { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}
