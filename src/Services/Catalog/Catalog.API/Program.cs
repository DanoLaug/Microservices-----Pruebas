using System.Net.Sockets;
using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers;
using Catalog.Services.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
using Serilog.Sinks.Syslog;

var builder = WebApplication.CreateBuilder(args);

//Configuración de SeriLog para usa Syslog y Papertrail
var papertrailHost = builder.Configuration.GetValue<string>("Papertrail:host");
var papertrailPort = builder.Configuration.GetValue<int>("Papertrail:port");
Log.Logger = new LoggerConfiguration()
    .WriteTo.Syslog(papertrailHost, papertrailPort, ProtocolType.Udp)
    .CreateLogger();

//Añadir Serilog como el proveedor de logging
builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Uso de MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(ProductCreateEventHandler).Assembly);
});

//SQL Configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), 
        x => x.MigrationsHistoryTable("_EFMigrationHistory", "Catalog"));
});

//Inyeccion de dependencias
builder.Services.AddTransient<IProductQueryService, ProductQueryService>();
builder.Services.AddTransient<IProductInStockQueryService, ProductInStockQueryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//En caso de exception manda error y nos permite tener un mayor control
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

    app.UseAuthorization();

app.MapControllers();

app.Run();
