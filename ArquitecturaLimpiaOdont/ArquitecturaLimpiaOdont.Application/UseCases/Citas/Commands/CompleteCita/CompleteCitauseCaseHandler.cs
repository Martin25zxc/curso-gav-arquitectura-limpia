using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CompleteCita;

public class CompleteCitauseCaseHandler : IRequestHandler<CompleteCitaCommand>
{
    private readonly IRepositoryCitas _repositoryCitas;
    private readonly IUnitOfWork _unitOfWork;
    public CompleteCitauseCaseHandler(IRepositoryCitas repositoryCitas, IUnitOfWork unitOfWork)
    {
        _repositoryCitas = repositoryCitas;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CompleteCitaCommand request)
    {
        var cita = await _repositoryCitas.ObtenerPorId(request.Id) ?? throw new NotFoundException("Cita no encontrada");
        cita.Completar();

        try
        {
            await _repositoryCitas.Actualizar(cita);
            await _unitOfWork.Persistir();
        }
        catch (Exception) 
        {
            await _unitOfWork.Reversar();
            throw;
        }
    }
}
