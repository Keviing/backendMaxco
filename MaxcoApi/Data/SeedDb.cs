using MaxcoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MaxcoApi.Data
{
    public static class SeedDb
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Datos semilla
                if (context.Clientes.Any() || context.Vendedores.Any() || context.Zonas.Any() || context.Productos.Any())
                {
                    return;   
                }

                context.Clientes.AddRange(
                    new Cliente
                    {
                        Nombre = "Juan Pérez",
                        Email = "juan.perez@example.com",
                        Telefono = "123456789",
                        Direccion = "Calle Falsa 123"
                    },
                    new Cliente
                    {
                        Nombre = "María López",
                        Email = "maria.lopez@example.com",
                        Telefono = "987654321",
                        Direccion = "Avenida Siempre Viva 456"
                    },
                    new Cliente
                    {
                        Nombre = "Carlos García",
                        Email = "carlos.garcia@example.com",
                        Telefono = "555666777",
                        Direccion = "Calle Luna 789"
                    },
                    new Cliente
                    {
                        Nombre = "Ana Fernández",
                        Email = "ana.fernandez@example.com",
                        Telefono = "888999000",
                        Direccion = "Avenida Sol 321"
                    },
                    new Cliente
                    {
                        Nombre = "Luis Martínez",
                        Email = "luis.martinez@example.com",
                        Telefono = "333444555",
                        Direccion = "Calle Estrella 654"
                    }
                );
                // Seed Vendedores
                context.Vendedores.AddRange(
                    new Vendedor
                    {
                        Nombre = "Vendedor Ejemplo 1",
                        Email = "vendedor1@example.com",
                        Telefono = "111222333",
                        Direccion = "Calle Comercio 1"
                    },
                    new Vendedor
                    {
                        Nombre = "Vendedor Ejemplo 2",
                        Email = "vendedor2@example.com",
                        Telefono = "444555666",
                        Direccion = "Avenida Industria 2"
                    },
                    new Vendedor
                    {
                        Nombre = "Vendedor Ejemplo 3",
                        Email = "vendedor3@example.com",
                        Telefono = "777888999",
                        Direccion = "Calle Mercurio 3"
                    },
                    new Vendedor
                    {
                        Nombre = "Vendedor Ejemplo 4",
                        Email = "vendedor4@example.com",
                        Telefono = "000111222",
                        Direccion = "Avenida Venus 4"
                    },
                    new Vendedor
                    {
                        Nombre = "Vendedor Ejemplo 5",
                        Email = "vendedor5@example.com",
                        Telefono = "333444555",
                        Direccion = "Calle Marte 5"
                    }
                );
                // Seed Zonas
                context.Zonas.AddRange(
                    new Zona
                    {
                        NombreZona = "Zona Norte",
                        Descripcion = "Zona comercial norte"
                    },
                    new Zona
                    {
                        NombreZona = "Zona Sur",
                        Descripcion = "Zona residencial sur"
                    },
                    new Zona
                    {
                        NombreZona = "Zona Este",
                        Descripcion = "Zona industrial este"
                    },
                    new Zona
                    {
                        NombreZona = "Zona Oeste",
                        Descripcion = "Zona rural oeste"
                    },
                    new Zona
                    {
                        NombreZona = "Zona Centro",
                        Descripcion = "Zona administrativa centro"
                    }
                );

                // Seed Productos
                context.Productos.AddRange(
                    new Producto
                    {
                        Nombre = "Producto A",
                        Descripcion = "Descripción de Producto A",
                        Precio = 100.00m,
                        Stock = 50,
                        Categoria = "Categoría 1"
                    },
                    new Producto
                    {
                        Nombre = "Producto B",
                        Descripcion = "Descripción de Producto B",
                        Precio = 200.00m,
                        Stock = 30,
                        Categoria = "Categoría 2"
                    },
                    new Producto
                    {
                        Nombre = "Producto C",
                        Descripcion = "Descripción de Producto C",
                        Precio = 150.00m,
                        Stock = 40,
                        Categoria = "Categoría 3"
                    },
                    new Producto
                    {
                        Nombre = "Producto D",
                        Descripcion = "Descripción de Producto D",
                        Precio = 300.00m,
                        Stock = 20,
                        Categoria = "Categoría 4"
                    },
                    new Producto
                    {
                        Nombre = "Producto E",
                        Descripcion = "Descripción de Producto E",
                        Precio = 250.00m,
                        Stock = 10,
                        Categoria = "Categoría 5"
                    }
                );

                // Save all changes before seeding ventas and detalles de venta
                context.SaveChanges();

                // Seed Ventas
                context.Ventas.AddRange(
                    new Venta
                    {
                        Id_Cliente = 1,
                        Id_Vendedor = 1,
                        Id_Zona = 1,
                        Fecha = DateTime.Now,
                        Monto_Total = 650 
                    },
                    new Venta
                    {
                        Id_Cliente = 2,
                        Id_Vendedor = 2,
                        Id_Zona = 2,
                        Fecha = DateTime.Now,
                        Monto_Total = 600
                    },
                    new Venta
                    {
                        Id_Cliente = 3,
                        Id_Vendedor = 3,
                        Id_Zona = 3,
                        Fecha = DateTime.Now,
                        Monto_Total = 600
                    },
                    new Venta
                    {
                        Id_Cliente = 4,
                        Id_Vendedor = 4,
                        Id_Zona = 4,
                        Fecha = DateTime.Now,
                        Monto_Total = 500
                    },
                    new Venta
                    {
                        Id_Cliente = 5,
                        Id_Vendedor = 5,
                        Id_Zona = 5,
                        Fecha = DateTime.Now,
                        Monto_Total = 250
                    }
                );

                context.SaveChanges();

                // Seed Detalles de Venta
                context.DetallesVentas.AddRange(
                    new DetalleVenta
                    {
                        IdVenta = 1,
                        IdProducto = 1,
                        Cantidad = 2,
                        PrecioUnitario = 100.00m,
                        Subtotal = 200.00m
                    },
                    new DetalleVenta
                    {
                        IdVenta = 1,
                        IdProducto = 2,
                        Cantidad = 1,
                        PrecioUnitario = 200.00m,
                        Subtotal = 200.00m
                    },
                    new DetalleVenta
                    {
                        IdVenta = 2,
                        IdProducto = 3,
                        Cantidad = 3,
                        PrecioUnitario = 150.00m,
                        Subtotal = 450.00m
                    },
                    new DetalleVenta
                    {
                        IdVenta = 2,
                        IdProducto = 4,
                        Cantidad = 1,
                        PrecioUnitario = 300.00m,
                        Subtotal = 300.00m
                    },
                    new DetalleVenta
                    {
                        IdVenta = 3,
                        IdProducto = 5,
                        Cantidad = 2,
                        PrecioUnitario = 250.00m,
                        
                    },
                    new DetalleVenta
                    {
                        IdVenta = 4,
                        IdProducto = 1,
                        Cantidad = 1,
                        PrecioUnitario = 100.00m,
                        Subtotal = 100.00m
                    },
                    new DetalleVenta
                    {
                        IdVenta = 4,
                        IdProducto = 2,
                        Cantidad = 2,
                        PrecioUnitario = 200.00m,
                        Subtotal = 400.00m
                        
                    },
                    new DetalleVenta
                    {
                        IdVenta = 5,
                        IdProducto = 3,
                        Cantidad = 4,
                        PrecioUnitario = 150.00m,
                        Subtotal = 3200.00m
                    }
                );

               

                context.SaveChanges();
            }
        }
    }
}
