using ArquitecturaLimpiaOdont.Api.DTOs.Pacientes;
using ArquitecturaLimpiaOdont.Api.Utilities;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.CreatePaciente;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;
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

    [HttpGet]
    public async Task<IActionResult> GetPacientes([FromQuery] ListPacientesQuery query)
    {
        var pacientes = await _mediator.Send(query);
        HttpContext.InsertarPaginacionEnCabecera(pacientes.Total);
        return Ok(pacientes.Items);
    }
}
