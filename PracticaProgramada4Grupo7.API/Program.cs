using Microsoft.EntityFrameworkCore;
using PracticaProgramada4Grupo7.BLL.Services;
using PracticaProgramada4Grupo7.DAL.Data;
using PracticaProgramada4Grupo7.DAL.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        var conexion =
            builder.Configuration
                .GetConnectionString("DefaultConnection");

        options.UseSqlServer(conexion);
    });

builder.Services.AddScoped<
    IEstudianteRepositorio,
    EstudianteRepositorio>();

builder.Services.AddScoped<
    IEstudianteService,
    EstudianteService>();

var app = builder.Build();

/*
 * Crea la base de datos y sus tablas
 * si todavía no existen.
 */
using (var scope = app.Services.CreateScope())
{
    var contexto =
        scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

    contexto.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();