using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebHotelGranChaco.Models.ViewModels
{
    public class ViewModelDatos
    {
        // Propiedades de Natural
        public int Id_Natural { get; set; }

        public string Nombre { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string Genero { get; set; }

        public string DocumentoIdentidad { get; set; }

        public string Nacionalidad { get; set; }

        // Propiedades de Cliente
        public int Id_Cliente { get; set; }

        public string Telefono { get; set; }

        // Propiedades de Registro
        public int Id_Registro { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime FechaSalida { get; set; }

        public int NumeroHabitacion { get; set; }

        public int NumeroHuspedes { get; set; }

        public int Noches { get; set; }

        public string Estado { get; set; }

        public float PrecioTotal { get; set; }

        // Relaciones
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }

        public int IdHabitacion { get; set; }

        public Habitacion Habitacion { get; set; }

        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}
