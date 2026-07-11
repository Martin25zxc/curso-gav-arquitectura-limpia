using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;

public static class MapperExtensions
{
    public static ConsultorioDetailDTO ToDto(this Consultorio consultorio)
    {
        return new ConsultorioDetailDTO
        {
            Id = consultorio.Id,
            Nombre = consultorio.Nombre
        };
    }
}
