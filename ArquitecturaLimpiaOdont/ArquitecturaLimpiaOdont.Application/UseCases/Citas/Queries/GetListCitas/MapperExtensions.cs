using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;

public static class MapperExtensions
{
    public static ListCitaDTO ToDto(this Cita cita)
    {
        return new ListCitaDTO
        {
            Id = cita.Id,
            FechaInicio = cita.IntervalTime.Inicio,
            FechaFin = cita.IntervalTime.Fin,
            Consultorio = cita.Consultorio!.Nombre,
            Dentista = cita.Dentista!.Nombre,
            Paciente = cita.Paciente!.Nombre,
            EstadoCita = cita.Estado.ToString()
        };

    }
}
