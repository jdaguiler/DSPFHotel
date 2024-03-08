using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Proveedor
    {
        [Key]
        public int Id_Proveedor { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio.")]
        [MaxLength(255)]
        public string NombreProveedor { get; set; }

        public string DescripcionProveedor { get; set; }
    }
}
