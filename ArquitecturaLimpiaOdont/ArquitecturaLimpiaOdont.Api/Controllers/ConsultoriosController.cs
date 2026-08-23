using ArquitecturaLimpiaOdont.Api.DTOs.Consultorios;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.DeleteConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaLimpiaOdont.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConsultoriosController : Controller
{
    private readonly IMediator _mediator;

    public ConsultoriosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateConsultorio([FromBody] CretateConsultorioDTO cretateConsultorioDTO)
    {
        //CreateConsultorioCommand command
        var comando = new CreateConsultorioCommand
        {
            Nombre = cretateConsultorioDTO.Nombre
        };
        var result = await _mediator.Send(comando);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetDetailConsultorioQuery
        {
            Id = id
        };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new ListConsultoriosQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateConsultorioDTO updateConsultoriosDTO)
    {
        var comando = new UpdateConsultorioCommand
        {
            Id = id,
            Nombre = updateConsultoriosDTO.Nombre
        };
        await _mediator.Send(comando);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var comando = new DeleteConsultorioCommand
        {
            Id = id
        };

        await _mediator.Send(comando);
        return NoContent();
    }
}
