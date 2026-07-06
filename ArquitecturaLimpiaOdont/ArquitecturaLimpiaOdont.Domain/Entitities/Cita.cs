using ArquitecturaLimpiaOdont.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Entitities;

public class Cita
{   
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid Dentistald { get; private set; }
    public Guid Consultoriold { get; private set; }
    public EstadoCita Estado { get; private set; }
    public DateTime FechaInicio { get; private set; }
    public DateTime FechaFin { get; private set; }
    public Paciente? Paciente { get; private set; }
    public Dentista? Dentista { get; private set; }
    public Consultorio? Consultorio { get; private set; }
    public Cita(Guid pacienteId, Guid dentistaId, Guid consultorioId, DateTime fechaInicio, DateTime fechaFin)
    {
        if(fechaInicio > fechaFin)
        {
            throw new BusinessRuleException($"La fecha de inicio no peude ser posterior a la fecha de fin");
        }
        if(fechaInicio < DateTime.UtcNow)
        {
            throw new BusinessRuleException($"La fecha de inicio no puede ser anterior a la fecha actual");
        }
        //asignacion de Id
        PacienteId = pacienteId;
        Dentistald = dentistaId;
        Consultoriold = consultorioId;
        FechaInicio = fechaInicio;
        FechaFin = fechaFin;
        Estado = EstadoCita.Programada;
        Id = Guid.CreateVersion7();
    }

    public void Cancelar()
    {
        if(Estado != EstadoCita.Programada)
        {
            throw new BusinessRuleException($"Solo se pueden cancelar citas programadas");
        }
        Estado = EstadoCita.Cancelada;
    }

    public void Completar()
    {
        if (Estado != EstadoCita.Programada)
        {
            throw new BusinessRuleException($"Solo se pueden cancelar citas programadas");
        }
        Estado = EstadoCita.Completada;
    }
}
