using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebHotelGranChaco.Models;

namespace WebHotelGranChaco.Data
{
    //define una clase llamada WebDbContext que hereda de DbContext, que es una clase
    //proporcionada por Entity Framework Core para interactuar con la base de datos.
    public class WebDbContext: DbContext
    {
        public WebDbContext()
        {

        }
        public WebDbContext(DbContextOptions<WebDbContext> options):base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Natural> Naturales { get; set; }
        public DbSet<Juridico> Juridicos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<TipoHabitacion> Tipos { get; set; }
        public DbSet<Registro> Registros { get; set; }
      //  public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Facturacion> Facturaciones { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetalleProducto> DetalleProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleProducto>().HasNoKey();
        }
    }

}
