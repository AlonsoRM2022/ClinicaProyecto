using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
<<<<<<< Updated upstream
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUsuarioService, UsuarioServiceImpl>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Inicio/IniciarSesion";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IPrecioHelper, PrecioHelper>();
builder.Services.AddScoped<IClinicaHelper, ClinicaHelper>();
builder.Services.AddScoped<IDoctorHelper, DoctorHelper>();
builder.Services.AddScoped<IHorarioHelper, HorarioHelper>();
builder.Services.AddScoped<IEspecialidadHelper, EspecialidadHelper>();
builder.Services.AddScoped<ICitaHelper, CitaHelper>();
builder.Services.AddScoped<IUsuarioHelper, UsuarioHelper>();

builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Home/IniciarSesion";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

<<<<<<< Updated upstream
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=IniciarSesion}/{id?}");

=======
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

>>>>>>> Stashed changes
app.Run();
