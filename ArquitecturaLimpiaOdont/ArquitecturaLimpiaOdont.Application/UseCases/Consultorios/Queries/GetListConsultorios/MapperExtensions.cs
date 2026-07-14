using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;

public static class MapperExtensions
{
    public static ListConsultoriosDTO ToDto(this Consultorio consultorio)
    {
        var dto = new ListConsultoriosDTO { Id = consultorio.Id, Nombre = consultorio.Nombre };
        return dto;
    }
}
