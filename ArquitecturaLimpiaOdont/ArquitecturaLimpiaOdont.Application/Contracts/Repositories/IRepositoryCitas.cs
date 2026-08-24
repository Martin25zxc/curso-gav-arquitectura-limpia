using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Contracts.Repositories;

public interface IRepositoryCitas : IRepository<Cita>
{
    Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin);
    new Task<Cita?> ObtenerPorId(Guid id);
    Task<IEnumerable<Cita>> GetFilteredCitas(FilterCitasDTO filter);
}
