using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.CreateDentista;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.CreateDentista;

public class CreateDentistaUseCaseHandler : IRequestHandler<CreateDentistaCommand, Guid>
{
    private readonly IRepositoryDentistas _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateDentistaUseCaseHandler(IRepositoryDentistas repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateDentistaCommand request)
    {
        var email = new Email(request.Email);
        var dentista = new Dentista(request.Nombre, email);
        
        try
        {
            await _repository.Agregar(dentista);
            await _unitOfWork.Persistir();
            return dentista.Id;

        }
        catch (Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }
    }
}
