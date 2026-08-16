using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.DeleteConsultorio;

public class DeleteConsultorioCommand : IRequest
{
    public Guid Id { get; set; }
}
