using Imobiliaria.Api.Data;
using Imobiliaria.Api.Repositories;
using Imobiliaria.Api.Repositories.Interfaces;
using Imobiliaria.Api.Services;
using Imobiliaria.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//O código está configurado de forma modular, com serviços configurados separadamente, o que torna mais fácil entender e modificar cada parte separadamente.
builder.Services.AddScoped<ICorretorService, CorretorService>();

builder.Services.AddScoped<ICorretorRepository, CorretorRepository>();


builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
builder.Services.AddScoped<IImovelService, ImovelService>();

builder.Services.AddScoped<IInquilinoRepository, InquilinoRepository>();
builder.Services.AddScoped<IInquilinoService, InquilinoService>();

builder.Services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
builder.Services.AddScoped<IProprietarioService, ProprietarioService>();

builder.Services.AddScoped<IAluguelService, AluguelService>();
var configuration = builder.Configuration;
builder.Services.AddDbContext<ImobiliariaContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

try
{
    Log.Information("Starting up");

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
