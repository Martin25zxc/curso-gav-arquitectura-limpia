using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly OdontDbContext _context;
    
    public Repository(OdontDbContext context)
    {
        _context = context;
    }

    public Task Actualizar(TEntity entidad)
    {
        _context.Update(entidad);
        return Task.CompletedTask;
    }

    public Task<TEntity> Agregar(TEntity entidad)
    {
        _context.Add(entidad);
        return Task.FromResult(entidad);
    }

    public Task Borrar(TEntity entidad)
    {
        _context.Remove(entidad);
        return Task.CompletedTask;
    }

    public async Task<int> ObtenerCantidadTotalRegistros()
    {
        return await _context.Set<TEntity>().CountAsync();
    }

    public async Task<TEntity?> ObtenerPorId(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> ObtenerTodos()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
}
