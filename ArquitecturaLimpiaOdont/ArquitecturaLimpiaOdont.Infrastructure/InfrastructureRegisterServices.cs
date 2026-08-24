using ArquitecturaLimpiaOdont.Application.Contracts.Notifications;
using ArquitecturaLimpiaOdont.Infrastructure.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Infrastructure;

public static class InfrastructureRegisterServices
{
    public static IServiceCollection AgregarServiciosDeInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IServiceNotifications, ServicioCorreos>();
        return services;
    }
}
