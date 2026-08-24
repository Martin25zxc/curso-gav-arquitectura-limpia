using ArquitecturaLimpiaOdont.Application.Utilities.Commons;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;

public class GetListCitasQuery : FilterCitasDTO, IRequest<List<ListCitaDTO>>
{
}
