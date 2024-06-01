using MySqlConnector;
using TGTWebApi.Interfaces;
using TGTWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar la conexión a la base de datos MySQL
var connectionString = builder.Configuration.GetConnectionString("MySQLConnection");

builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(connectionString));


// Registrar servicio de tareas
builder.Services.AddScoped<ITareaService, TareaService>();

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
