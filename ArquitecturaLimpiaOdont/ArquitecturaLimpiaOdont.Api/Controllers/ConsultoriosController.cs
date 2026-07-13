using ArquitecturaLimpiaOdont.Api.DTOs.Consultorios;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
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
        //CreateConsultorioCommand command
        var comando = new GetDetailConsultorioQuery
        {
            Id = id
        };
        var result = await _mediator.Send(comando);
        return Ok(result);
    }
}
