using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CreateCita;

public class CreateCitaCommand : IRequest<Guid>
{
    public Guid PacienteId { get; set; }
    public Guid DentistaId { get; set; }
    public Guid ConsultorioId { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
}
