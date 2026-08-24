using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CancelCita;

public class CancelCitaCommand : IRequest
{
    public Guid Id { get; set; }
}
