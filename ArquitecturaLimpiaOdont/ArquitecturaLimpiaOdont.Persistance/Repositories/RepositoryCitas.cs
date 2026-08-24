using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Repositories;

public class RepositoryCitas: Repository<Cita>, IRepositoryCitas
{
    private readonly OdontDbContext _context;
    public RepositoryCitas(OdontDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin)
    {

        return await _context.Citas.Where(
            c => c.DentistaId == dentistaId
        && c.Estado == EstadoCita.Programada
        && inicio < c.IntervalTime.Fin
        && fin > c.IntervalTime.Inicio).AnyAsync();
    }

    public async Task<IEnumerable<Cita>> GetFilteredCitas(FilterCitasDTO filter)
    {
        var query = _context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Dentista)
            .Include(c => c.Consultorio)
            .AsQueryable();

        if(filter.ConsultorioId.HasValue)
        {
            query = query.Where(c => c.ConsultorioId == filter.ConsultorioId);
        }

        if(filter.DentistaId.HasValue)
        {
            query = query.Where(c => c.DentistaId == filter.DentistaId);
        }

        if (filter.PacienteId.HasValue)
        {
            query = query.Where(c => c.PacienteId == filter.PacienteId);
        }

        return await query.Where(c=> c.IntervalTime.Inicio >= filter.Inicio && c.IntervalTime.Fin < filter.Fin)
            .OrderBy(c => c.IntervalTime.Fin)
            .ToListAsync();
    }

    new public async Task<Cita?> ObtenerPorId(Guid id)
    {
        var cita = await _context.Citas
            .Include(c => c.Paciente)
            .Include(c => c.Dentista)
            .Include(c => c.Consultorio)
            .FirstOrDefaultAsync(c=> c.Id == id);
        return cita;
    }
}
