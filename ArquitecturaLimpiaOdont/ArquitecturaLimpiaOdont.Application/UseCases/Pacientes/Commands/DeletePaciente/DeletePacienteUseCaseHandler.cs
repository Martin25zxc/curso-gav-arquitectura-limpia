using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.DeletePaciente;

public class DeletePacienteUseCaseHandler : IRequestHandler<DeletePacienteCommand>
{
    private readonly IRepositoryPacientes _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePacienteUseCaseHandler(IRepositoryPacientes repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeletePacienteCommand request)
    {
        var paciente = await _repository.ObtenerPorId(request.Id) ?? throw new NotFoundException($"Paciente with Id {request.Id} not found.");
        try
        {
            await _repository.Borrar(paciente);
            await _unitOfWork.Persistir();
        }
        catch (Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }
    }
}
