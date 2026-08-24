using ArquitecturaLimpiaOdont.Application.Contracts.Notifications;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CreateCita;

public static class MapperExtensions
{
    public static ConfirmacionCitaDTO ToDto(this Cita cita)
    {
        return new ConfirmacionCitaDTO
        {
            Id = cita.Id,
            Fecha = cita.IntervalTime.Inicio,
            Paciente = cita.Paciente!.Nombre,
            Paciente_Email = cita.Paciente.Email.Value,
            Consultorio = cita.Consultorio!.Nombre,
            Dentista = cita.Dentista!.Nombre
        };
    }
}
