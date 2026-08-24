using ArquitecturaLimpiaOdont.Application.Contracts.Notifications;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories.Modelos;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.EnviarRecordatorioCitas;

public class EnviarRecordatoriosUseCaseHandler : IRequestHandler<ComandoEnviarRecordatoriosCitas>
{
    private readonly IRepositoryCitas _repository;
    private readonly IServiceNotifications _serviceNotifications;
    public EnviarRecordatoriosUseCaseHandler(IRepositoryCitas repository, IServiceNotifications serviceNotifications)
    {
        _repository = repository;
        _serviceNotifications = serviceNotifications;
    }
    public async Task Handle(ComandoEnviarRecordatoriosCitas request)
    {
        var mañana = DateTime.Now.AddDays(1);
        var fechaInicio = mañana;
        var fechaFin = mañana.AddDays(1);

        var filtro = new FilterCitasDTO
        {
            Inicio = fechaInicio,
            Fin = fechaFin,
            EstadoCita = EstadoCita.Programada
        };

        var citas = await _repository.GetFiltered(filtro);
        foreach (var cita in citas)
        {
            var citaDto = cita.ToDto();
            await _serviceNotifications.EnviarRecordatorioCita(citaDto);
        }
    }
}