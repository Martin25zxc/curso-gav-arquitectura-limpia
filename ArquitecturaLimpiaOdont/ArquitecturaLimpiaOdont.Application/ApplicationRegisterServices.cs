using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application;

public static class ApplicationRegisterServices
{
    public static IServiceCollection AgregarServiciosDeApplication(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();
        services.AddScoped<IRequestHandler<CreateConsultorioCommand, Guid>, CreateConsultorioUseCaseHandler>();
        services.AddScoped<IRequestHandler<GetDetailConsultorioQuery, ConsultorioDetailDTO>, GetDetailConsultorioUseCaseHandler>();
        services.AddScoped<IRequestHandler<ListConsultoriosQuery, List<ListConsultoriosDTO>>, ListConsultoriosUseCaseHandler>();

        return services;
    }
}
