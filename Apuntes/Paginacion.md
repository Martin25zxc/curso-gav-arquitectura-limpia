Dado que paginar es algo basico para cualquier entidad se empieza desde el repositorio generico

IRepository
Repository
  public async Task<int> ObtenerCantidadTotalRegistros()
  {
      return await _context.Set<TEntity>().CountAsync();
  }

  Sobre la query donde queremos aplicar
  creamos la clase 
  public class FilterPacientesDTO
{
    public int Page { get; set; } = 1;
    public int RecordsPerPage { get; set; } = 10;
}

  En el IRepository de donde queremos aplicar
  public interface IRepositoryPacientes : IRepository<Paciente>

public class RepositoryPacientes:Repository<Paciente>, IRepositoryPacientes
{
    private readonly OdontDbContext _context;
    public RepositoryPacientes(OdontDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Paciente>> GetFilteredPacientes(FilterPacientesDTO filter)
    {
        
        return await _context.Pacientes.OrderBy(p => p.Nombre)
            .Paginate(filter.Page, filter.RecordsPerPage)
            .ToListAsync();
    }
}



En el proyecto de persistance creamos una utilidad que extienda IQueryable
namespace ArquitecturaLimpiaOdont.Persistance.Utilities;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }
}

Creamos una clase para que se pueda paginar en aplicacion
namespace ArquitecturaLimpiaOdont.Application.Utilities.Commons;

public class PagingDTO<T>
{
    public List<T> Items { get; set; } = [];
    public int Total { get; set; }
}


Ahora la query seria
public class ListPacientesQuery : FilterPacientesDTO, IRequest<PagingDTO<ListPacientesDTO>>
{

}

    EL REPOSITORIO NO DEBE DEPENDENDER DE CASOS DE USO PARTICULARES, sino que debe manejar datos distintos, por eso se creo FilterPacientesDto

UseCase actualizado

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


Controller

 [HttpGet]
 public async Task<IActionResult> GetPacientes([FromQuery] ListPacientesQuery query)
 {
     var pacientes = await _mediator.Send(query);
     HttpContext.InsertarPaginacionEnCabecera(pacientes.Total);
     return Ok(pacientes.Items);
 }


public static class HttpContextExtensions
{
    public static void InsertarPaginacionEnCabecera<T>(this HttpContext context, int cantidadRegistros)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.Response.Headers.Append("X-Pagination-TotalCount", cantidadRegistros.ToString());
    }
}


Ejemplo de cuando se necesitan hacer cosas especificas
public interface IRepositoryCitas : IRepository<Cita>
{
    Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin);
    new Task<Cita> ObtenerPorId(Guid id);
}


en el caso del new es cuando queremos pisar el metodo