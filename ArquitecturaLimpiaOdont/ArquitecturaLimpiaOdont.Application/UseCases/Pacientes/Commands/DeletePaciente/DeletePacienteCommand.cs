using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.DeletePaciente;

public class DeletePacienteCommand : IRequest
{
    public required Guid Id { get; set; }
}
