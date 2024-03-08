using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using WebHotelGranChaco.Data;
using WebHotelGranChaco.Models;
using WebHotelGranChaco.Models.ViewModels;
using ClosedXML.Excel;

namespace WebHotelGranChaco.Controllers
{
    public class ReporteRotativaController : Controller
    {
        private readonly WebDbContext _context;

        public ReporteRotativaController(WebDbContext context)
        {
            _context = context;
        }

        public IActionResult ImprimirRegistroPDF()
        {
            var modelos = ObtenerDatos(); // Obtener los datos

            if (modelos == null || modelos.Count == 0)
            {
                return NotFound(); // Manejo de error si no se encuentran registros
            }

            // Devuelve la vista PDF utilizando Rotativa con una lista de modelos
            return new ViewAsPdf("ImprimirRegistro", modelos)
            {
                FileName = $"Registros.pdf", // Nombre del archivo PDF generado
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait, // Orientación de la página
                PageSize = Rotativa.AspNetCore.Options.Size.A4 // Tamaño de la página
            };
        }

        public IActionResult ImprimirRegistroExcel()
        {
            var modelos = ObtenerDatos(); // Obtener los datos

            if (modelos == null || modelos.Count == 0)
            {
                return NotFound(); // Manejo de error si no se encuentran registros
            }

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Registros");

                // Añadir encabezados
                worksheet.Cell(1, 1).Value = "Número de Registro";
                worksheet.Cell(1, 2).Value = "Fecha de Registro";
                worksheet.Cell(1, 3).Value = "Fecha de Salida";
                worksheet.Cell(1, 4).Value = "Número de Habitación";
                worksheet.Cell(1, 5).Value = "Número de Huéspedes";
                worksheet.Cell(1, 6).Value = "Número de Noches";
                worksheet.Cell(1, 7).Value = "Estado";
                worksheet.Cell(1, 8).Value = "Precio Total";
                worksheet.Cell(1, 9).Value = "Nombre Cliente";
                worksheet.Cell(1, 10).Value = "Apellido Paterno";
                worksheet.Cell(1, 11).Value = "Apellido Materno";
                worksheet.Cell(1, 12).Value = "Género";
                worksheet.Cell(1, 13).Value = "Documento de Identidad";
                worksheet.Cell(1, 14).Value = "Nacionalidad";
                // Añadir más encabezados según sea necesario

                // Llenar datos
                int row = 2;
                foreach (var registro in modelos)
                {
                    worksheet.Cell(row, 1).Value = registro.Id_Registro;
                    worksheet.Cell(row, 2).Value = registro.FechaRegistro.ToShortDateString();
                    worksheet.Cell(row, 3).Value = registro.FechaSalida.ToShortDateString();
                    worksheet.Cell(row, 4).Value = registro.NumeroHabitacion;
                    worksheet.Cell(row, 5).Value = registro.NumeroHuspedes;
                    worksheet.Cell(row, 6).Value = registro.Noches;
                    worksheet.Cell(row, 7).Value = registro.Estado;
                    worksheet.Cell(row, 8).Value = registro.PrecioTotal;
                    worksheet.Cell(row, 9).Value = registro.Nombre;
                    worksheet.Cell(row, 10).Value = registro.ApellidoPaterno;
                    worksheet.Cell(row, 11).Value = registro.ApellidoMaterno;
                    worksheet.Cell(row, 12).Value = registro.Genero;
                    worksheet.Cell(row, 13).Value = registro.DocumentoIdentidad;
                    worksheet.Cell(row, 14).Value = registro.Nacionalidad;
                    // Llenar más datos según sea necesario
                    row++;
                }

                // Guardar el libro de trabajo en un flujo de memoria
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Registros.xlsx");
                }
            }
        }


        private List<ViewModelDatos> ObtenerDatos()
        {
            return _context.Registros
                .Include(r => r.Cliente)
                    .ThenInclude(c => c.Natural)
                .Include(r => r.Habitacion)
                .Include(r => r.Usuario)
                .Select(registro => new ViewModelDatos
                {
                    Id_Registro = registro.Id_Registro,
                    FechaRegistro = registro.FechaRegistro,
                    FechaSalida = registro.FechaSalida,
                    NumeroHabitacion = registro.NumeroHabitacion,
                    NumeroHuspedes = registro.NumeroHuspedes,
                    Noches = registro.Noches,
                    Estado = registro.Estado,
                    PrecioTotal = registro.PrecioTotal,
                    IdCliente = registro.IdCliente,
                    Cliente = registro.Cliente,
                    IdHabitacion = registro.IdHabitacion,
                    Habitacion = registro.Habitacion,
                    IdUsuario = registro.IdUsuario,
                    Usuario = registro.Usuario,
                    // Propiedades de Natural
                    Id_Natural = registro.Cliente.Natural.Id_Natural,
                    Nombre = registro.Cliente.Natural.Nombre,
                    ApellidoPaterno = registro.Cliente.Natural.ApellidoPaterno,
                    ApellidoMaterno = registro.Cliente.Natural.ApellidoMaterno,
                    Genero = registro.Cliente.Natural.Genero,
                    DocumentoIdentidad = registro.Cliente.Natural.DocumentoIdentidad,
                    Nacionalidad = registro.Cliente.Natural.Nacionalidad
                })
                .ToList();
        }
        public IActionResult PreviaVisualizacion()
        {
            // Recupera todos los registros de la base de datos incluyendo los datos de la entidad Natural
            var modelos = _context.Registros
                .Include(r => r.Cliente)
                    .ThenInclude(c => c.Natural)
                .Include(r => r.Habitacion)
                .Include(r => r.Usuario)
                .Select(registro => new ViewModelDatos
                {
                    Id_Registro = registro.Id_Registro,
                    FechaRegistro = registro.FechaRegistro,
                    FechaSalida = registro.FechaSalida,
                    NumeroHabitacion = registro.NumeroHabitacion,
                    NumeroHuspedes = registro.NumeroHuspedes,
                    Noches = registro.Noches,
                    Estado = registro.Estado,
                    PrecioTotal = registro.PrecioTotal,
                    IdCliente = registro.IdCliente,
                    Cliente = registro.Cliente,
                    IdHabitacion = registro.IdHabitacion,
                    Habitacion = registro.Habitacion,
                    IdUsuario = registro.IdUsuario,
                    Usuario = registro.Usuario,
                    // Propiedades de Natural
                    Id_Natural = registro.Cliente.Natural.Id_Natural,
                    Nombre = registro.Cliente.Natural.Nombre,
                    ApellidoPaterno = registro.Cliente.Natural.ApellidoPaterno,
                    ApellidoMaterno = registro.Cliente.Natural.ApellidoMaterno,
                    Genero = registro.Cliente.Natural.Genero,
                    DocumentoIdentidad = registro.Cliente.Natural.DocumentoIdentidad,
                    Nacionalidad = registro.Cliente.Natural.Nacionalidad
                })
                .ToList();

            if (modelos == null || modelos.Count == 0)
            {
                return NotFound(); // Manejo de error si no se encuentran registros
            }

            // Pasa los modelos a la vista para previsualización
            return View(modelos);
        }

    }
}
