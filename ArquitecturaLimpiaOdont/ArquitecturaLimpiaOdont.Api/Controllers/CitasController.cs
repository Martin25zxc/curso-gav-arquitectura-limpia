using ArquitecturaLimpiaOdont.Api.DTOs.Citas;
using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CancelCita;
using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CompleteCita;
using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CreateCita;
using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetDetailCita;
using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetDetailDentista;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaLimpiaOdont.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CitasController : Controller
{
    private readonly IMediator _mediator;
    public CitasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCita([FromBody] CreateCitaDTO createCita)
    {
        var command = new CreateCitaCommand
        {
            ConsultorioId = createCita.ConsultorioId,
            DentistaId = createCita.DentistaId,
            PacienteId = createCita.PacienteId,
            FechaFin = createCita.FechaFin,
            FechaInicio = createCita.FechaInicio
        };
        var result = await _mediator.Send(command);

        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetDetailCitaQuery
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetListCitasQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("{id}/completar")]
    public async Task<IActionResult> CompleteCita(Guid id)
    {
        var command = new CompleteCitaCommand
        {
            Id = id
        };
        await _mediator.Send(command);
        return Ok();
    }

    [HttpPost("{id}/cancelar")]
    public async Task<IActionResult> CancelCita(Guid id)
    {
        var command = new CancelCitaCommand
        {
            Id = id
        };
        await _mediator.Send(command);
        return Ok();
    }
}