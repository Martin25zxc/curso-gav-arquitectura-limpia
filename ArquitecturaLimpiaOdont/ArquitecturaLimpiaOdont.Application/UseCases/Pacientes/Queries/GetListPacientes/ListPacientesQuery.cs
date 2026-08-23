using ArquitecturaLimpiaOdont.Application.Utilities.Commons;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;

public class ListPacientesQuery : FilterPacientesDTO, IRequest<PagingDTO<ListPacientesDTO>>
{

}
