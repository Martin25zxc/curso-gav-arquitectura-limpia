using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetDetailDentista;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetDetailDentista;

public static class MapperExtensions
{
    public static DetailDentistaDTO ToDto(this Dentista dentista)
    {
        return new DetailDentistaDTO
        {
            Id = dentista.Id,
            Nombre = dentista.Nombre,
            Email = dentista.Email.Value
        };
    }
}
