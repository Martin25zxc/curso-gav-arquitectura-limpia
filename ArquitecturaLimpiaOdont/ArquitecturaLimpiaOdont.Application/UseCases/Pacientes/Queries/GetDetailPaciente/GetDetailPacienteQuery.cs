using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetDetailPaciente;

public class GetDetailPacienteQuery: IRequest<DetailPacienteDTO>
{
    public required Guid Id { get; set; }
}
