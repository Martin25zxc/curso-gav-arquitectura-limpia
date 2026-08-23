using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.DeleteConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetDetailPaciente;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application;

public static class ApplicationRegisterServices
{
    public static IServiceCollection AgregarServiciosDeApplication(this IServiceCollection services)
    {
        services.AddTransient<IMediator, SimpleMediator>();


    
        services.Scan(scan =>
        scan.FromAssembliesOf(typeof(IMediator))
        //sin response
        .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime()
        //con response
        .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
        .AsImplementedInterfaces()
        .WithScopedLifetime());
       // services.AddScoped<IRequestHandler<GetDetailPacienteQuery, DetailPacienteDTO>, GetDetailPacienteUseCaseHandler>();

        //services.AddScoped<IRequestHandler<CreateConsultorioCommand, Guid>, CreateConsultorioUseCaseHandler>();
        //services.AddScoped<IRequestHandler<UpdateConsultorioCommand>, UpdateConsultorioUseCaseHandler>();
        //services.AddScoped<IRequestHandler<DeleteConsultorioCommand>, DeleteConsultorioUseCaseHandler>();
        //services.AddScoped<IRequestHandler<GetDetailConsultorioQuery, ConsultorioDetailDTO>, GetDetailConsultorioUseCaseHandler>();
        //services.AddScoped<IRequestHandler<ListConsultoriosQuery, List<ListConsultoriosDTO>>, ListConsultoriosUseCaseHandler>();

        return services;
    }
}
