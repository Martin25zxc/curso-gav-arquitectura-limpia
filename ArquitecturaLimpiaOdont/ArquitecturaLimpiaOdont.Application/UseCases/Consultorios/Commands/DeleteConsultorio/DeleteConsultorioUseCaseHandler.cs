using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.DeleteConsultorio;

public class DeleteConsultorioUseCaseHandler : IRequestHandler<DeleteConsultorioCommand>
{
    private readonly IRepositoryConsultorios _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteConsultorioUseCaseHandler  (IRepositoryConsultorios repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteConsultorioCommand request)
    {
        var consultorio = await _repository.ObtenerPorId(request.Id) ?? throw new NotFoundException($"Consultorio {request.Id} no encontrado.");
        try
        {
            await _repository.Borrar(consultorio);
            await _unitOfWork.Persistir();

        }
        catch (Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }
    }
}