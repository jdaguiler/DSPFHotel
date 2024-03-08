using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebHotelGranChaco.Migrations
{
    /// <inheritdoc />
    /// esta migración crea la estructura de la base de datos necesaria para almacenar y gestionar los 
    /// datos de la aplicación ASP.NET.
    public partial class Initial01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id_Cargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCargo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id_Cargo);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DescripcionCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id_Proveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProveedor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DescripcionProveedor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id_Proveedor);
                });

            migrationBuilder.CreateTable(
                name: "Tipos",
                columns: table => new
                {
                    Id_Tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CapacidadMaxima = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PrecioBase = table.Column<float>(type: "real", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos", x => x.Id_Tipo);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id_Empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarnetIdentidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id_Empleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargos",
                        principalColumn: "Id_Cargo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Juridicos",
                columns: table => new
                {
                    Id_Juridico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Representacionlegal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juridicos", x => x.Id_Juridico);
                    table.ForeignKey(
                        name: "FK_Juridicos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Naturales",
                columns: table => new
                {
                    Id_Natural = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Naturales", x => x.Id_Natural);
                    table.ForeignKey(
                        name: "FK_Naturales_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id_Producto);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "Id_Categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "Id_Proveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    Id_Habitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    PrecioPorNoche = table.Column<float>(type: "real", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaLimpieza = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTipoHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.Id_Habitacion);
                    table.ForeignKey(
                        name: "FK_Habitaciones_Tipos_IdTipoHabitacion",
                        column: x => x.IdTipoHabitacion,
                        principalTable: "Tipos",
                        principalColumn: "Id_Tipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empleados_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleProductos",
                columns: table => new
                {
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaRenovacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DetalleProductos_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Id_Habitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleProductos_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "Id_Producto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facturaciones",
                columns: table => new
                {
                    Id_Facturacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFacturacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFactura = table.Column<int>(type: "int", nullable: false),
                    SubTotal = table.Column<float>(type: "real", nullable: false),
                    Impuestos = table.Column<float>(type: "real", nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturaciones", x => x.Id_Facturacion);
                    table.ForeignKey(
                        name: "FK_Facturaciones_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Id_Habitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id_Pago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importe = table.Column<float>(type: "real", nullable: false),
                    Metodo_Pago = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id_Pago);
                    table.ForeignKey(
                        name: "FK_Pagos_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Id_Habitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id_Servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DescripcionServicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostoServicio = table.Column<float>(type: "real", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id_Servicio);
                    table.ForeignKey(
                        name: "FK_Servicios_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Id_Habitacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id_Registro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    NumeroHuspedes = table.Column<int>(type: "int", nullable: false),
                    Noches = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrecioTotal = table.Column<float>(type: "real", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id_Registro);
                    table.ForeignKey(
                        name: "FK_Registros_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id_Cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "Id_Habitacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProductos_IdHabitacion",
                table: "DetalleProductos",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleProductos_IdProducto",
                table: "DetalleProductos",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdCargo",
                table: "Empleados",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_Facturaciones_IdHabitacion",
                table: "Facturaciones",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_IdTipoHabitacion",
                table: "Habitaciones",
                column: "IdTipoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Juridicos_IdCliente",
                table: "Juridicos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Naturales_IdCliente",
                table: "Naturales",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_IdHabitacion",
                table: "Pagos",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdProveedor",
                table: "Productos",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_IdCliente",
                table: "Registros",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_IdHabitacion",
                table: "Registros",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_IdUsuario",
                table: "Registros",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdHabitacion",
                table: "Servicios",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEmpleado",
                table: "Usuarios",
                column: "IdEmpleado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleProductos");

            migrationBuilder.DropTable(
                name: "Facturaciones");

            migrationBuilder.DropTable(
                name: "Juridicos");

            migrationBuilder.DropTable(
                name: "Naturales");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Tipos");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
