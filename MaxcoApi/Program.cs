using MaxcoApi.Data;
using MaxcoApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Crear variable con la cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("ConexionDb");
//Registramos servicio con la conexion
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
builder.Services.AddScoped<IServiceProducto, ServiceProducto>();
builder.Services.AddScoped<IServiceZona, ServiceZona>();
builder.Services.AddScoped<IServiceVendedor, ServiceVendedor>();
builder.Services.AddScoped<IServiceVenta, ServiceVenta>(); 
builder.Services.AddScoped<IServiceDetalle, ServiceDetalleVenta>();
builder.Services.AddScoped<IServiceReport, ServiceReport>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
options.AddPolicy("nuevaPolitica", app =>
{
    app.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
})
);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedDb.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("nuevaPolitica");
app.UseAuthorization();

app.MapControllers();

app.Run();
