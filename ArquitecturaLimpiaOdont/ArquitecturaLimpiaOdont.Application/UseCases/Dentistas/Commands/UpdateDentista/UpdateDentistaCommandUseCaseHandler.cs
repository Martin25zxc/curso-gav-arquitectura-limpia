using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.UpdateDentista;

public class UpdateDentistaCommandUseCaseHandler: IRequestHandler<UpdateDentistaCommand>
{
    private readonly IRepositoryDentistas _repositoryDentistas;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateDentistaCommandUseCaseHandler(IRepositoryDentistas repositoryDentistas, IUnitOfWork unitOfWork)
    {
        _repositoryDentistas = repositoryDentistas;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateDentistaCommand request)
    {
        var dentista = await _repositoryDentistas.ObtenerPorId(request.Id) ?? throw new NotFoundException($"Dentista with Id {request.Id} not found.");

        dentista.ActualizarNombre(request.Nombre);
        dentista.ActualizarEmail(new Email(request.Email));

        try
        {
            await _repositoryDentistas.Actualizar(dentista);
            await _unitOfWork.Persistir();

        }
        catch (Exception)
        {
           await _unitOfWork.Reversar();
           throw;
        }
    }
}
