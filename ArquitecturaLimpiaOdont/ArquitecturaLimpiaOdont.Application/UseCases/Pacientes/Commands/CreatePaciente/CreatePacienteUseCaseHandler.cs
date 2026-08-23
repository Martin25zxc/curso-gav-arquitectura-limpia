using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.CreatePaciente;

public class CreatePacienteUseCaseHandler : IRequestHandler<CreatePacienteCommand, Guid>
{
    private readonly IRepositoryPacientes _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePacienteUseCaseHandler(IRepositoryPacientes repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreatePacienteCommand request)
    {
        var email = new Email(request.Email);
        var paciente = new Paciente(request.Nombre, email);
        
        try
        {
            await _repository.Agregar(paciente);
            await _unitOfWork.Persistir();
            return paciente.Id;

        }
        catch (Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }
    }
}
