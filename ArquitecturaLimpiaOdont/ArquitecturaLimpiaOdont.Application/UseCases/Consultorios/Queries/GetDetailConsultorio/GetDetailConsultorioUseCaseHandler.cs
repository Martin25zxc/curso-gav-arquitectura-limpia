using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;

public class GetDetailConsultorioUseCaseHandler: IRequestHandler<GetDetailConsultorioQuery, ConsultorioDetailDTO>
{
    private readonly IRepositoryConsultorios _repositoryConsultorios;
    public GetDetailConsultorioUseCaseHandler(IRepositoryConsultorios repositoryConsultorios)
    {
        _repositoryConsultorios = repositoryConsultorios;
    }
    public async Task<ConsultorioDetailDTO> Handle(GetDetailConsultorioQuery request)
    {
        var consultorio = await _repositoryConsultorios.ObtenerPorId(request.Id);
        if(consultorio == null)
        {
            throw new NotFoundException("Consultorio no encontrado");
        }

        return consultorio.ToDto();
    }
}
