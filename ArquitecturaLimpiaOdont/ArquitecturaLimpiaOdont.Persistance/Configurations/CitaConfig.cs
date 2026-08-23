using ArquitecturaLimpiaOdont.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Configurations;

public class CitaConfig : IEntityTypeConfiguration<Cita>
{
    public void Configure(EntityTypeBuilder<Cita> builder)
    {
        builder.ComplexProperty(prop => prop.IntervalTime, action =>
        {
            action.Property(p => p.Inicio).HasColumnName("FechaInicio");
            action.Property(p => p.Fin).HasColumnName("FechaFin");
        });
    }
}
