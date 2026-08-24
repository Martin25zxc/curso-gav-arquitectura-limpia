using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;

public class GetListCitasUseCaseHandler : IRequestHandler<GetListCitasQuery, List<ListCitaDTO>>
{
    private readonly IRepositoryCitas _repositoryCitas;
    public GetListCitasUseCaseHandler(IRepositoryCitas repositoryCitas)
    {
        _repositoryCitas = repositoryCitas;
    }

    public async  Task<List<ListCitaDTO>> Handle(GetListCitasQuery request)
    {
        var citas = await _repositoryCitas.GetFilteredCitas(request);
        var citasDto = citas.Select(cita=> cita.ToDto()).ToList();
        return citasDto;
    }
}
