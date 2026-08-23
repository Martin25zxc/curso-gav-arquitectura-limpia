using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Contracts.Repositories;

public interface IRepositoryPacientes : IRepository<Paciente>
{
    Task<IEnumerable<Paciente> > GetFilteredPacientes(FilterPacientesDTO filter);
}
