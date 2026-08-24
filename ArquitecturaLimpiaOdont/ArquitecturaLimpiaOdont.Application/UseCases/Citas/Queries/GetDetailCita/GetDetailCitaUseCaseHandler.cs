using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetDetailCita;

public class GetDetailCitaUseCaseHandler : IRequestHandler<GetDetailCitaQuery, GetDetailCitaDTO>
{
    private readonly IRepositoryCitas _repositoryCitas;
    public GetDetailCitaUseCaseHandler(IRepositoryCitas repositoryCitas)
    {
        _repositoryCitas = repositoryCitas;
    }

    public async Task<GetDetailCitaDTO> Handle(GetDetailCitaQuery request)
    {
        var cita = await _repositoryCitas.ObtenerPorId(request.Id) ?? throw new NotFoundException("Cita no encontrada");
        return cita.ToDto();
    }
}
