using ArquitecturaLimpiaOdont.Domain.Entitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Configurations;

public class PacienteConfig : IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.Property(prop => prop.Nombre)
          .HasMaxLength(250)
          .IsRequired();

        builder.ComplexProperty(prop => prop.Email, action =>
        {
            action.Property(prop => prop.Value)
                .HasColumnName("Email")
                .HasMaxLength(254);
        });
    }
}
