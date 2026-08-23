using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Persistance.Repositories;
using ArquitecturaLimpiaOdont.Persistance.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArquitecturaLimpiaOdont.Persistance;

public static class ArchitectureRegisterServices
{
    public static IServiceCollection AgregarServiciosDeArchitecture(this IServiceCollection services)
    {
        services.AddDbContext<OdontDbContext>(options => options.UseSqlServer("name=OdontConnectionString"));

        services.AddScoped<IRepositoryConsultorios, RepositoryConsultorios>();
        services.AddScoped<IRepositoryPacientes, RepositoryPacientes>();
        services.AddScoped<IRepositoryDentistas, RepositoryDentistas>();
        services.AddScoped<IRepositoryCitas, RepositoryCitas>();
        services.AddScoped<IUnitOfWork, UnitOfWorkEF>();
        return services;
    }
}
