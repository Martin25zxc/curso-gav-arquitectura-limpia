using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CompleteCita;

public class CompleteCitaCommand : IRequest
{
    public Guid Id { get; set; }
}
