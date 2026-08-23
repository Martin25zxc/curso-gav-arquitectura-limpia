using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetDetailDentista;

public class GetDetailDentistaQuery: IRequest<DetailDentistaDTO>
{
    public required Guid Id { get; set; }
}
