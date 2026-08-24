using ArquitecturaLimpiaOdont.Application.Contracts.Identity;
using ArquitecturaLimpiaOdont.Domain.Commons;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance;

public class OdontDbContext : DbContext
{
    private readonly IUsersService? _usersService;
    public OdontDbContext(DbContextOptions<OdontDbContext> options, IUsersService usersService)
        : base(options)
    {
        _usersService = usersService;
    }

    protected OdontDbContext()
    {
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
       if(_usersService is not null)
        {
            foreach(var entry in ChangeTracker.Entries<EntidadAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.UtcNow;
                        entry.Entity.CreadoPor = _usersService.ObtenerUsuarioId();
                        break;
                    case EntityState.Modified:
                        entry.Entity.UltimaModificacionPor = _usersService.ObtenerUsuarioId();
                        entry.Entity.UltimaFechaModificacion = DateTime.UtcNow;
                        break;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OdontDbContext).Assembly);
    }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Consultorio> Consultorios { get; set; }
    public DbSet<Dentista> Dentistas { get; set; }
    public DbSet<Cita> Citas { get; set; }
}
