using ArquitecturaLimpiaOdont.Api.DTOs.Citas;
using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CreateCita;
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
}
