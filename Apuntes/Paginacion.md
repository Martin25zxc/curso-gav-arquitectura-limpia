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
