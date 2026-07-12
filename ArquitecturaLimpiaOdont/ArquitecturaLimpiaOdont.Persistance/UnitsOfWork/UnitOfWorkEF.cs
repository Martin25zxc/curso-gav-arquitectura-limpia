using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.UnitsOfWork;

public class UnitOfWorkEF : IUnitOfWork
{
    private readonly OdontDbContext _context;
    public UnitOfWorkEF(OdontDbContext odontDbContext)
    {
        _context = odontDbContext;
    }
    public async Task Persistir()
    {
        await _context.SaveChangesAsync();
    }

    public Task Reversar()
    {
        return Task.CompletedTask;
    }
}
