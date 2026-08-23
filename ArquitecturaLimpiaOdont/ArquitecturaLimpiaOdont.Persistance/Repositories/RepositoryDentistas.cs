using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetListDentistas;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Persistance.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Repositories;

public class RepositoryDentistas:Repository<Dentista>, IRepositoryDentistas
{
    private readonly OdontDbContext _context;
    public RepositoryDentistas(OdontDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Dentista>> GetFilteredDentistas(FilterDentistasDTO filter)
    {
        var query = _context.Dentistas.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Nombre))
        {
            query = query.Where(p => p.Nombre.Contains(filter.Nombre));
        }

        if (!string.IsNullOrWhiteSpace(filter.Email))
        {
            query = query.Where(p => p.Email.Value.Contains(filter.Email));
        }

        return await query.OrderBy(p => p.Nombre)
            .Paginate(filter.Page, filter.RecordsPerPage)
            .ToListAsync();
    }
}
