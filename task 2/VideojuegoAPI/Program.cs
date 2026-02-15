using Microsoft.EntityFrameworkCore;
using VideojuegoAPI.Data; // Asegúrate que este nombre coincida con tu carpeta

var builder = WebApplication.CreateBuilder(args);

// ESTO ES LO QUE TE FALTA: Conectar el Contexto con el JSON
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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