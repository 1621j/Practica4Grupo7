using PracticaProgramada4Grupo7.UI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services
    .AddHttpClient<
        IEstudianteApiService,
        EstudianteApiService>(
        cliente =>
        {
            var apiUrl =
                builder.Configuration["ApiUrl"]
                ?? "http://localhost:5298/";

            cliente.BaseAddress =
                new Uri(apiUrl);
        });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern:
        "{controller=Estudiantes}/{action=Index}/{id?}");

app.Run();