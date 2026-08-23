using ArquitecturaLimpiaOdont.Application.Utilities.Commons;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetListDentistas;

public class ListDentistasQuery : FilterDentistasDTO, IRequest<PagingDTO<ListDentistasDTO>>
{

}
