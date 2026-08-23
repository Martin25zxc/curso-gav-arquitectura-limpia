using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.DeleteDentista;

public class DeleteDentistaUseCaseHandler : IRequestHandler<DeleteDentistaCommand>
{
    private readonly IRepositoryDentistas _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteDentistaUseCaseHandler(IRepositoryDentistas repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(DeleteDentistaCommand request)
    {
        var dentista = await _repository.ObtenerPorId(request.Id) ?? throw new NotFoundException($"Dentista with Id {request.Id} not found.");
        try
        {
            await _repository.Borrar(dentista);
            await _unitOfWork.Persistir();
        }
        catch (Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }
    }
}
