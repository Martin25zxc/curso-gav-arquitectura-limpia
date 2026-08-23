using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Persistance.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Repositories;

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
