using ArquitecturaLimpiaOdont.Api.DTOs.Dentistas;
using ArquitecturaLimpiaOdont.Api.Utilities;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.CreateDentista;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.DeleteDentista;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.UpdateDentista;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetDetailDentista;
using ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetListDentistas;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaLimpiaOdont.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DentistasController : ControllerBase
{
    private readonly IMediator _mediator;
    public DentistasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDentista([FromBody] CreateDentistaDTO createDentista)
    {
        var DentistaId = await _mediator.Send(new CreateDentistaCommand
        {
            Nombre = createDentista.Nombre,
            Email = createDentista.Email
        });
        return Ok(DentistaId);
    }

    [HttpGet]
    public async Task<IActionResult> GetDentistas([FromQuery] ListDentistasQuery query)
    {
        var Dentistas = await _mediator.Send(query);
        HttpContext.InsertarPaginacionEnCabecera(Dentistas.Total);
        return Ok(Dentistas.Items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetDetailDentistaQuery
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateDentistaDTO updateDentistaDTO)
    {
        var comando = new UpdateDentistaCommand
        {
            Id = id,
            Nombre = updateDentistaDTO.Nombre,
            Email = updateDentistaDTO.Email
        };
        await _mediator.Send(comando);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var comando = new DeleteDentistaCommand
        {
            Id = id,
        };
        await _mediator.Send(comando);
        return Ok();
    }
}
