using Customer.Persistence.DataBase;
using Customer.Sevice.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Paso1. Agregar DbContext(ref Customer.Persistence.DataBase)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Referenciar a Microsoft.EntityFrameworkCore
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql_connection"),
        x => x.MigrationsHistoryTable("_EFMigrationHistory", "Customer"));
});

// Paso2. Configuracion de MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

//Paso3. Inyeccion de dependencias (Referenciar a Customer.Sevice.Queries)
builder.Services.AddTransient<IClientQueryService, ClientQueryService>();

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