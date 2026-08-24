using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetDetailCita;

public static class MapperExtensions
{
    public static GetDetailCitaDTO ToDto(this Cita cita)
    {
        var dto = new GetDetailCitaDTO
        {
            Id = cita.Id,
            FechaInicio = cita.IntervalTime.Inicio,
            FechaFin = cita.IntervalTime.Fin,
            Consultorio = cita.Consultorio!.Nombre,
            Dentista = cita.Dentista!.Nombre,
            Paciente = cita.Paciente!.Nombre,
            EstadoCita = cita.Estado.ToString()
        };
        return dto;
    }
}
