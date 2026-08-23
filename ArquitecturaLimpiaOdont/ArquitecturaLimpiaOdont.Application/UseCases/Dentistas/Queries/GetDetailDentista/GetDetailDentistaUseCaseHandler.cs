using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetDetailDentista;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetDetailPaciente;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetDetailDentista;

public class GetDetailDentistaUseCaseHandler : IRequestHandler<GetDetailDentistaQuery, DetailDentistaDTO>
{
    private readonly IRepositoryDentistas _repositoryDentistas;
    public GetDetailDentistaUseCaseHandler(IRepositoryDentistas repositoryDentistas)
    {
        _repositoryDentistas = repositoryDentistas;
    }
    public async Task<DetailDentistaDTO> Handle(GetDetailDentistaQuery request)
    {
        var dentista = await _repositoryDentistas.ObtenerPorId(request.Id) ?? throw new NotFoundException("Dentista no encontrado");
        return dentista.ToDto();
    }
}
