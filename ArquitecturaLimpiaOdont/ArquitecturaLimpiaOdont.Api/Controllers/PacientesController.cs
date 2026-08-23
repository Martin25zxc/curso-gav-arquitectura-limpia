using ArquitecturaLimpiaOdont.Api.DTOs.Consultorios;
using ArquitecturaLimpiaOdont.Api.DTOs.Pacientes;
using ArquitecturaLimpiaOdont.Api.Utilities;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.CreatePaciente;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.DeletePaciente;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.UpdatePaciente;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetDetailPaciente;
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetDetailPacienteQuery
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdatePacienteDTO updatePacienteDTO)
    {
        var comando = new UpdatePacienteCommand
        {
            Id = id,
            Nombre = updatePacienteDTO.Nombre,
            Email = updatePacienteDTO.Email
        };
        await _mediator.Send(comando);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var comando = new DeletePacienteCommand
        {
            Id = id,
        };
        await _mediator.Send(comando);
        return Ok();
    }
}
