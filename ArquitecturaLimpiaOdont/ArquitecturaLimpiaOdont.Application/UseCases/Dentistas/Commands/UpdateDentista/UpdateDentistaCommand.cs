using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.UpdateDentista;

public class UpdateDentistaCommand: IRequest
{
    public required Guid Id { get; set; }
    public required string Nombre { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
}
