using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;

public class ListConsultoriosUseCaseHandler : IRequestHandler<ListConsultoriosQuery, List<ListConsultoriosDTO>>
{
    private readonly IRepositoryConsultorios _repository;

    public ListConsultoriosUseCaseHandler(IRepositoryConsultorios repository)
    {
        _repository = repository;
    }

    public async Task<List<ListConsultoriosDTO>> Handle(ListConsultoriosQuery request)
    {
        var consultorios = await _repository.ObtenerTodos();
        return consultorios.Select(c => c.ToDto()).ToList();
    }
}
