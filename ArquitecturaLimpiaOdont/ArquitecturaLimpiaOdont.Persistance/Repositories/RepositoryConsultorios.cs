using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Persistance.Repositories;

public class ConsultoriosRepository : Repository<Consultorio> , IRepositoryConsultorios
{
    public ConsultoriosRepository(OdontDbContext context) : base(context)
    {
            
    }
}
