using ArquitecturaLimpiaOdont.Api.Middleware.ExcepctionsHandlers;
using ArquitecturaLimpiaOdont.Application;
using ArquitecturaLimpiaOdont.Persistance;
using ArquitecturaLimpiaOdont.Infrastructure;
using ArquitecturaLimpiaOdont.Identity;
using Scalar.AspNetCore;
using ArquitecturaLimpiaOdont.Application.Contracts.Notifications;
using ArquitecturaLimpiaOdont.Api.Jobs;
using ArquitecturaLimpiaOdont.Identity.Model;
using System.Net;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opciones =>
{
    opciones.Filters.Add(new AuthorizeFilter("esadmin"));
});

builder.Services.AgregarServiciosDeApplication();
builder.Services.AgregarServiciosDeArchitecture();
builder.Services.AgregarServiciosDeInfrastructure();
builder.Services.AgregarServiciosDeIdentidad();

builder.Services.AddHostedService<RecordatorioCitasJob>();

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
    app.MapScalarApiReference(options =>
    {
        options
            .DisableAgent();
    });
}
app.MapIdentityApi<Usuario>();
app.UseHandleException();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
