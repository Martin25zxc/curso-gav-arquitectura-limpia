using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;

public class GetDetailConsultorioQuery:IRequest<ConsultorioDetailDTO>
{
    public Guid Id { get; set;  }
}
