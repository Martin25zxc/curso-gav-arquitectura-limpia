using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;

public class CreateConsultorioCommand : IRequest<Guid>
{
    public required string Nombre { get; set; }
}
