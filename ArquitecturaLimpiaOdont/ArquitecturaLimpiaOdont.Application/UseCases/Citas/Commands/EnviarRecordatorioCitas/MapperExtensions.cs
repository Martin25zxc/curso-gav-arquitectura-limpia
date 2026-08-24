using ArquitecturaLimpiaOdont.Application.Contracts.Notifications;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.EnviarRecordatorioCitas;

public static class MapperExtensions
{
    public static RecordatorioCitasDTO ToDto(this Cita cita)
    {
        return new RecordatorioCitasDTO

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
