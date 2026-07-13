using ArquitecturaLimpiaOdont.Api.Middleware.ExcepctionsHandlers;
using ArquitecturaLimpiaOdont.Application;
using ArquitecturaLimpiaOdont.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AgregarServiciosDeApplication();
builder.Services.AgregarServiciosDeArchitecture();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHandleException();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
