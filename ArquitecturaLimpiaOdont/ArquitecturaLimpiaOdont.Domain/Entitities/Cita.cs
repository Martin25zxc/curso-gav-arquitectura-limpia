using ArquitecturaLimpiaOdont.Domain.Enums;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Entitities;

public class Cita
{   
    public Guid Id { get; private set; }
    public Guid PacienteId { get; private set; }
    public Guid DentistaId { get; private set; }
    public Guid ConsultorioId { get; private set; }
    public EstadoCita Estado { get; private set; }
    public IntervalTime IntervalTime { get; private set; }
    public Paciente? Paciente { get; private set; }
    public Dentista? Dentista { get; private set; }
    public Consultorio? Consultorio { get; private set; }
    public Cita(Guid pacienteId, Guid dentistaId, Guid consultorioId, IntervalTime intervalTime)
    {
        if (intervalTime.Inicio < DateTime.UtcNow)
        {
            throw new BusinessRuleException($"La fecha de inicio no puede ser anterior a la fecha actual");
        }
        //asignacion de Id
        PacienteId = pacienteId;
        DentistaId = dentistaId;
        ConsultorioId = consultorioId;
        IntervalTime = intervalTime;
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

    private Cita()
    {
        IntervalTime = default!;
    }
}
