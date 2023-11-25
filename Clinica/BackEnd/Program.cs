using System.Text;
using BackEnd.Middleware;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

#region ConnString

string connString = builder
                            .Configuration
                            .GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ClinicaContext>(options =>
                        options.UseSqlServer(
                           connString
                            ));

Util.ConnectionString = connString;

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>

{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

}



    )
    .AddEntityFrameworkStores<ClinicaContext>()
    .AddDefaultTokenProviders();



#endregion

#region JWT


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });




#endregion

#region Depencendy Inyection
builder.Services.AddDbContext<ClinicaContext>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<ICitaDAL, CitaDALImpl>();
builder.Services.AddScoped<IClinicaDAL, ClinicaDALImpl>();
builder.Services.AddScoped<IDiagnosticoDAL, DiagnosticoDALImpl>();
builder.Services.AddScoped<IDoctorDAL, DoctorDALImpl>();
builder.Services.AddScoped<IEspecialidadDAL, EspecialidadDALImpl>();
builder.Services.AddScoped<IFacturaDAL, FacturaDALImpl>();
builder.Services.AddScoped<IHorarioDAL, HorarioDALImpl>();
builder.Services.AddScoped<IPrecioDAL, PrecioDALImpl>();
builder.Services.AddScoped<IReservaDAL, ReservaDALImpl>();
builder.Services.AddScoped<IRoleDAL, RoleDALImpl>();
builder.Services.AddScoped<IStatusReservaDAL, StatusReservaDALImpl>();
builder.Services.AddScoped<IUsuarioDAL, UsuarioDALImpl>();
builder.Services.AddScoped<ICitaService, CitaServiceImpl>();
builder.Services.AddScoped<IClinicaService, ClinicaServiceImpl>();
builder.Services.AddScoped<IDiagnosticoService, DiagnosticoServiceImpl>();
builder.Services.AddScoped<IDoctorService, DoctorServiceImpl>();
builder.Services.AddScoped<IEspecialidadService, EspecialidadServiceImpl>();
builder.Services.AddScoped<IFacturaService, FacturaServiceImpl>();
builder.Services.AddScoped<IHorarioService, HorarioServiceImpl>();
builder.Services.AddScoped<IPrecioService, PrecioServiceImpl>();
builder.Services.AddScoped<IReservaService, ReservaServiceImpl>();
builder.Services.AddScoped<IRoleService, RoleServiceImpl>();
builder.Services.AddScoped<IStatusReservaService, StatusReservaServiceImpl>();
builder.Services.AddScoped<IUsuarioService, UsuarioServiceImpl>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();