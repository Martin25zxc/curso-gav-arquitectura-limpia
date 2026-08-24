using ArquitecturaLimpiaOdont.Identity.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ArquitecturaLimpiaOdont.Application.Contracts.Identity;
using ArquitecturaLimpiaOdont.Identity.Services;

namespace ArquitecturaLimpiaOdont.Identity;

public static class IdentityRegisterServices
{
    public static void AgregarServiciosDeIdentidad(this IServiceCollection services)
    {
        services.AddAuthentication(IdentityConstants.BearerScheme).AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorization(opciones =>
        {
            opciones.AddPolicy("esadmin", politica => politica.RequireClaim("esadmin"));
        });

        services.AddDbContext<OdontIdentityDbContext>(options =>
        options.UseSqlServer("name=OdontConnectionString"));

        services.AddIdentityCore<Usuario>()
            .AddEntityFrameworkStores<OdontIdentityDbContext>()
            .AddApiEndpoints();

        services.AddTransient<IUsersService, UsersService>();
        services.AddHttpContextAccessor();
    }
}
