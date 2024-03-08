using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Dtos
{
    //proporcionan reglas de validación que se aplican cuando se intenta crear o actualizar un objeto
    //DtoCliente, asegurando que los datos ingresados cumplan con ciertos criterios antes de ser procesados.
    public class DtoCliente
    {
        public int Id_Cliente { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [RegularExpression(@"^\+?\d+$", ErrorMessage = "El formato del teléfono no es válido.")]
        public string Telefono { get; set; }

        public int Id_Natural { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido Paterno es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El apellido paterno no puede tener más de 100 caracteres.")]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "El campo Apellido Materno es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El apellido materno no puede tener más de 100 caracteres.")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "El campo Género es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El género no puede tener más de 100 caracteres.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El campo Documento de Identidad es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El documento de identidad no puede tener más de 100 caracteres.")]
        public string DocumentoIdentidad { get; set; }

        [Required(ErrorMessage = "El campo Nacionalidad es obligatorio.")]
        [MaxLength(100, ErrorMessage = "La nacionalidad no puede tener más de 100 caracteres.")]
        public string Nacionalidad { get; set; }
    }
}
