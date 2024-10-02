using Microsoft.EntityFrameworkCore;  // Importar Entity Framework Core
using InterApi.Models;
using InterApi.Data;
using InterApi.Services;  // Asegúrate de reemplazar 'TuNamespace' con el nombre de tu proyecto

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<EstudianteMateriasService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "http://localhost:4200") // Agrega más URLs si es necesario
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Agregar la configuración de la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el DbContext con la cadena de conexión
builder.Services.AddDbContext<InterContext>(options =>
    options.UseSqlServer(connectionString));  // Configura el uso de SQL Server

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de la solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





// Configurar el middleware de CORS
app.UseCors("AllowLocalhost3000");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
