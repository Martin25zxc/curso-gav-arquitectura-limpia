using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Persistance.Repositories;
using ArquitecturaLimpiaOdont.Persistance.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance;

public static class ArchitectureRegisterServices
{
    public static IServiceCollection AgregarServiciosDeArchitecture(this IServiceCollection services)
    {
        services.AddDbContext<OdontDbContext>(options => options.UseSqlServer("name=OdontConnectionString"));

        services.AddScoped<IRepositoryConsultorios, RepositoryConsultorios>();
        services.AddScoped<IUnitOfWork, UnitOfWorkEF>();
        return services;
    }
}
