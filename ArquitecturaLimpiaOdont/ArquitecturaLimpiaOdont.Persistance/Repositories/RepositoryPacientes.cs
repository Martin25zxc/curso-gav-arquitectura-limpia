using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Repositories;

public class RepositoryPacientes:Repository<Paciente>, IRepositoryPacientes
{
    public RepositoryPacientes(OdontDbContext context) : base(context)
    {
            
    }
}
