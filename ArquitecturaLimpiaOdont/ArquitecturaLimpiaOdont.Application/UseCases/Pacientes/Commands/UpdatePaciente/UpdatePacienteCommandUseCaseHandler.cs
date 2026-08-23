using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.UpdatePaciente;

public class UpdatePacienteCommandUseCaseHandler: IRequestHandler<UpdatePacienteCommand>
{
    private readonly IRepositoryPacientes _repositoryPacientes;
    private readonly IUnitOfWork _unitOfWork;
    public UpdatePacienteCommandUseCaseHandler(IRepositoryPacientes repositoryPacientes, IUnitOfWork unitOfWork)
    {
        _repositoryPacientes = repositoryPacientes;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdatePacienteCommand request)
    {
        var paciente = await _repositoryPacientes.ObtenerPorId(request.Id) ?? throw new NotFoundException($"Paciente with Id {request.Id} not found.");

        paciente.ActualizarNombre(request.Nombre);
        paciente.ActualizarEmail(new Email(request.Email));

        try
        {
            await _repositoryPacientes.Actualizar(paciente);
            await _unitOfWork.Persistir();

        }
        catch (Exception)
        {
           await _unitOfWork.Reversar();
           throw;
        }
    }
}
