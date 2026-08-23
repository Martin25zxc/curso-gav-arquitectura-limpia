using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetListDentistas;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Contracts.Repositories;

public interface IRepositoryDentistas : IRepository<Dentista>
{
    Task<IEnumerable<Dentista> > GetFilteredDentistas(FilterDentistasDTO filter);
}
