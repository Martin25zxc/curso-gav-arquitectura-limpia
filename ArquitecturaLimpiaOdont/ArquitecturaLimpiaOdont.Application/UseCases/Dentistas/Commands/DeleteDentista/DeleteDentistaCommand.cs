using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.DeleteDentista;

public class DeleteDentistaCommand : IRequest
{
    public required Guid Id { get; set; }
}
