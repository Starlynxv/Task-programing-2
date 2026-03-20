using Microsoft.EntityFrameworkCore;
using VideojuegoAPI.Infrastructure.Context; 
using VideojuegoAPI.Infrastructure.Interfaces;
using VideojuegoAPI.Infrastructure.Repositories;
using VideojuegoAPI.Application;
using VideojuegoAPI.Application.Contract;
using VideojuegoAPI.Application.Service;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<VideojuegoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddScoped<IProductoService, ProductoService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();