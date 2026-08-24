using ArquitecturaLimpiaOdont.Application.Contracts.Notifications;
using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CreateCita;

public class CreateCitaUseCaseHandler: IRequestHandler<CreateCitaCommand, Guid>
{
    private readonly IRepositoryCitas _repositoryCitas;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceNotifications _serviceNotifications;

    public CreateCitaUseCaseHandler(IRepositoryCitas repositoryCitas, IUnitOfWork unitOfWork, IServiceNotifications serviceNotifications)
    {
        _repositoryCitas = repositoryCitas;
        _unitOfWork = unitOfWork;
        _serviceNotifications = serviceNotifications;
    }

    public async Task<Guid> Handle(CreateCitaCommand request)
    {
        var citaSolapa = await _repositoryCitas.ExisteCitaSolapada(request.DentistaId, request.FechaInicio, request.FechaFin);
        if (citaSolapa)
        {
            throw new ApplicationValidationException("Ya existe una cita en el mismo horario para el Dentista.");
        }

        var intervaloDeTiempo = new IntervalTime(request.FechaInicio, request.FechaFin);
        var cita = new Cita(request.PacienteId, request.DentistaId, request.ConsultorioId, intervaloDeTiempo);

        Guid? id = null;
        try
        {
            await _repositoryCitas.Agregar(cita);
            await _unitOfWork.Persistir();
            id = cita.Id;

        }
        catch (Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }

        var citaDb = await _repositoryCitas.ObtenerPorId(id.Value);
        var notificacionDto = citaDb!.ToDto();
        await _serviceNotifications.EnviarConfirmacionesCita(notificacionDto);

        return id.Value;
    }
}
