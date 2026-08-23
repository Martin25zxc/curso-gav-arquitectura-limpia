using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Contracts.Repositories;

public interface IRepositoryCitas : IRepository<Cita>
{
    Task<bool> ExisteCitaSolapada(Guid dentistaId, DateTime inicio, DateTime fin);
}
