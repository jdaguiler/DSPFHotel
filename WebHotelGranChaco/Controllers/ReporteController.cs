using AspNetCore.Reporting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebHotelGranChaco.Controllers
{
    public class ReporteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor que recibe el entorno de hospedaje de la aplicación
        public ReporteController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            // Registra el proveedor de codificaciones para permitir el uso de codificaciones específicas
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        // Método de acción para mostrar la vista de inicio del controlador de reportes
        public IActionResult Index()
        {
            return View();
        }

        // Método de acción para generar e imprimir un informe
        public IActionResult Imprimir()
        {
            try
            {
                int extension = 1; // Tipo de extensión del archivo (PDF en este caso)
                // Obtiene la ruta del archivo de informe RDL/RDLC
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Reportes", "ReportNew.rdlc");
                // Parámetros opcionales para el informe (en este caso, solo se proporciona un parámetro)
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("ReportParameter1", "Reporte de clientes");

                // Crea una instancia de LocalReport con la ruta del archivo de informe
                LocalReport localreport = new LocalReport(path);
                // Ejecuta el informe y lo renderiza en formato PDF
                var resultado = localreport.Execute(RenderType.Pdf, extension, parameters);
                // Devuelve el archivo PDF como resultado de la acción
                return File(resultado.MainStream, "application/pdf", "ReporteClientes.pdf");
            }
            catch (Exception ex)
            {
                // Si se produce un error durante la generación del informe, devuelve un mensaje de error
                return Content($"Error al generar el informe: {ex.Message}");
            }
        }
    }
}
