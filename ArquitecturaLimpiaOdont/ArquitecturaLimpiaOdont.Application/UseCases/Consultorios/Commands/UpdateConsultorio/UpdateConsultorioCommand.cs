using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;

public class UpdateConsultorioCommand : IRequest
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
}
