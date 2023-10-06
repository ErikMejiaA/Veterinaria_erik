using System.Reflection;
using API.Extensions;
using AspNetCoreRateLimit;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options =>
{
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true; //envia error si no es soportado el formato que se quiere usar

}).AddXmlSerializerFormatters();

builder.Services.ConfigureCors(); //configuracion de la cors
builder.Services.AddApplicationServices(); //habilitar unidad de trabajo Scoped
builder.Services.ConfigureRateLimiting(); //limite de peticiones que se pueden hacer
builder.Services.ConfigureApiVersioning(); // versionado para los EndPoint o project Apis
builder.Services.AddJwt(builder.Configuration); // Configuracion del JWT (autenticacion y validacion) del token
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly()); //habilitar el AutoMapper


//realizamos la conexion a la abase de datos 
builder.Services.AddDbContext<WebDbAppiContext>(OptionsBuilder => 
{
    string ? ConfigurationStrings = builder.Configuration.GetConnectionString("ConexMysql");
    OptionsBuilder.UseMySql(ConfigurationStrings, ServerVersion.AutoDetect(ConfigurationStrings));

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cargar las peticiones persistentes 
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   var loggerFactory = services.GetRequiredService<ILoggerFactory>();
   try
    {
        var context = services.GetRequiredService<WebDbAppiContext>();
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Ocurrió un error durante la migración");
    }
}

app.UseIpRateLimiting();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
