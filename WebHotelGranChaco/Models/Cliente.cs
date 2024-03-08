using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models
{
    public class Cliente
    {
        [Key] 
        public int Id_Cliente { get; set; }
        [Required]
        [RegularExpression(@"^\+?\d+$")] 
        public string Telefono { get; set; }

        public Natural Natural { get; set; }
    }
}
