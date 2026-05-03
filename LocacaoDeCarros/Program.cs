using LocacaoDeCarros.Data;
using LocacaoDeCarros.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<CarroService>();
builder.Services.AddScoped<LocacaoService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
