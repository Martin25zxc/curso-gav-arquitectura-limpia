using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;

public class UpdateConsultorioUseCaseHandler : IRequestHandler<UpdateConsultorioCommand>
{
    private readonly IRepositoryConsultorios _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateConsultorioUseCaseHandler(IRepositoryConsultorios repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task Handle(UpdateConsultorioCommand request)
    {
        var consultorio = await _repository.ObtenerPorId(request.Id);
        if (consultorio == null)
        {
            throw new NotFoundException($"Consultorio {request.Id} no encontrado.");
        }

        consultorio.UpdateNombre(request.Nombre);

        try
        {
            await _repository.Actualizar(consultorio);
            await _unitOfWork.Persistir();

        }
        catch (Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }
    }
}
