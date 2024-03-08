using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHotelGranChaco.Controllers;
using WebHotelGranChaco.Data;
using WebHotelGranChaco.Servicio.Contrato;
using WebHotelGranChaco.Servicio.Implementacion;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Agrega servicios para controladores MVC y vistas.
builder.Services.AddControllersWithViews();

// Configurar AutoMapper para mapeo de objetos.
builder.Services.AddAutoMapper(typeof(Program));

// Agrega el servicio de usuario y su contrato al contenedor de dependencias.
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Configuraci�n de la conexi�n a la base de datos usando Entity Framework Core.
builder.Services.AddDbContext<WebDbContext>(option =>
{
    option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

// Configuraci�n de la autenticaci�n de cookies.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Ruta de inicio de sesi�n.
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Tiempo de expiraci�n de la cookie.
    });

// Configuraci�n de filtros de respuesta para deshabilitar la cach�.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
            new ResponseCacheAttribute
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});

var app = builder.Build();

// Middleware para manejar excepciones y redirigir a la p�gina de error en caso de errores.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Middleware para redirigir HTTP a HTTPS.
app.UseHttpsRedirection();
app.UseStaticFiles();

// Middleware para enrutamiento.
app.UseRouting();

// Middleware para autenticaci�n y autorizaci�n.
app.UseAuthentication();
app.UseAuthorization();

// Configuraci�n de rutas de controlador.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Configuraci�n de Rotativa para generar archivos PDF en la aplicaci�n.
IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa/Windows");

// Ejecuci�n de la aplicaci�n.
app.Run();
