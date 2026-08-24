using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetDetailCita;

public class GetDetailCitaQuery:IRequest<GetDetailCitaDTO>
{
    public required Guid Id { get; set; }
}
