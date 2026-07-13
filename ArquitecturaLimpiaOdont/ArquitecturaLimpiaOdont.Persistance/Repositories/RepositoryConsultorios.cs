using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Repositories;

public class RepositoryConsultorios : Repository<Consultorio> , IRepositoryConsultorios
{
    public RepositoryConsultorios(OdontDbContext context) : base(context)
    {
            
    }
}
