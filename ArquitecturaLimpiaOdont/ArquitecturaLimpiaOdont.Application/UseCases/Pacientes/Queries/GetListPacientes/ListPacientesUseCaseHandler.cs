using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Utilities.Commons;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;

public class ListPacientesUseCaseHandler : IRequestHandler<ListPacientesQuery, PagingDTO<ListPacientesDTO>>
{
    private readonly IRepositoryPacientes _repositoryPacientes;
    public ListPacientesUseCaseHandler(IRepositoryPacientes repositoryPacientes)
    {
        _repositoryPacientes = repositoryPacientes;
    }
    public async Task<PagingDTO<ListPacientesDTO>> Handle(ListPacientesQuery request)
    {
       var pacientes = await _repositoryPacientes.GetFilteredPacientes(request);
       var pacientesDto = pacientes.Select(p => p.ToDto()).ToList();
       var total = await _repositoryPacientes.ObtenerCantidadTotalRegistros();
        return new PagingDTO<ListPacientesDTO>
       {
           Items = pacientesDto,
           Total = total
       };
    }
}
