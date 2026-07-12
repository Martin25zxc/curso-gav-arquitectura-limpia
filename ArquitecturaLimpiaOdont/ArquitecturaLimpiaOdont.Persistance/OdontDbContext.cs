using ArquitecturaLimpiaOdont.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance;

public class OdontDbContext : DbContext
{
    public OdontDbContext(DbContextOptions<OdontDbContext> options)
        : base(options)
    {

    }

    protected OdontDbContext()
    {
            
    }

    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Consultorio> Consultorios { get; set; }
}
