using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ClinicaContext>();
builder.Services.AddScoped<IPrecioDAL, PrecioDALImpl>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IPrecioService, PrecioService>();
builder.Services.AddScoped<IClinicaDAL, ClinicaDALImpl>();
builder.Services.AddScoped<IClinicaService, ClinicaService>();
builder.Services.AddScoped<IDoctorDAL, DoctorDALImpl>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IHorarioDAL, HorarioDALImpl>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<IEspecialidadDAL, EspecialidadDALImpl>();
builder.Services.AddScoped<IEspecialidadService, EspecialidadService>();
builder.Services.AddScoped<ICitaDAL, CitaDALImpl>();
builder.Services.AddScoped<ICitaService, CitaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
