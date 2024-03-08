using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Producto
    {
        [Key]
        public int Id_Producto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [MaxLength(255)]
        public string NombreProducto { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        public float Precio { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria.")]
        [MaxLength(255)]
        public string DescripcionProducto { get; set; }

        [ForeignKey("Proveedor")]
        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
