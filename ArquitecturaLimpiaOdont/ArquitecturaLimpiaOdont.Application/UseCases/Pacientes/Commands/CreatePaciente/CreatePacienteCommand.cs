using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.CreatePaciente;

public class CreatePacienteCommand : IRequest<Guid>
{
    public required string Nombre { get; set; }
    public required string Email { get; set; }

}
