using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(255)]
        public string NombreCategoria { get; set; }

        public string DescripcionCategoria { get; set; }
    }
}
