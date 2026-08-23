using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Utilities.Commons;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetListDentistas;

public class ListDentistasUseCaseHandler : IRequestHandler<ListDentistasQuery, PagingDTO<ListDentistasDTO>>
{
    private readonly IRepositoryDentistas _repositoryDentistas;
    public ListDentistasUseCaseHandler(IRepositoryDentistas repositoryDentistas)
    {
        _repositoryDentistas = repositoryDentistas;
    }

    public async Task<PagingDTO<ListDentistasDTO>> Handle(ListDentistasQuery request)
    {
       var dentistas = await _repositoryDentistas.GetFilteredDentistas(request);
       var dentistasDto = dentistas.Select(d => d.ToDto()).ToList();
       var total = await _repositoryDentistas.ObtenerCantidadTotalRegistros();
        return new PagingDTO<ListDentistasDTO>
       {
           Items = dentistasDto,
           Total = total
       };
    }
}
