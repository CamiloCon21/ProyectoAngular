using Microsoft.EntityFrameworkCore;  // Importar Entity Framework Core
using InterApi.Models;
using InterApi.Data;
using InterApi.Services;  // Aseg�rate de reemplazar 'TuNamespace' con el nombre de tu proyecto

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<EstudianteMateriasService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "http://localhost:4200") // Agrega m�s URLs si es necesario
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Agregar la configuraci�n de la cadena de conexi�n
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el DbContext con la cadena de conexi�n
builder.Services.AddDbContext<InterContext>(options =>
    options.UseSqlServer(connectionString));  // Configura el uso de SQL Server

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger para la documentaci�n de la API
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
