using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
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
}
