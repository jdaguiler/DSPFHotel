using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Cargo
    {
        [Key]
        public int Id_Cargo { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreCargo { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; }

    }
}
