using ArquitecturaLimpiaOdont.Api.DTOs.Pacientes;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.CreatePaciente;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaLimpiaOdont.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacientesController:ControllerBase
{
   private readonly IMediator _mediator;
    public PacientesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaciente([FromBody] CreatePacienteDTO createPaciente)
    {
        var pacienteId = await _mediator.Send(new CreatePacienteCommand
        {
            Nombre = createPaciente.Nombre,
            Email = createPaciente.Email
        });
        return Ok(pacienteId);
    }
}
