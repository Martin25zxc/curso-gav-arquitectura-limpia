using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetDetailPaciente;

public class GetDetailPacienteUseCaseHandler : IRequestHandler<GetDetailPacienteQuery, DetailPacienteDTO>
{
    private readonly IRepositoryPacientes _repositoryPacientes;
    public GetDetailPacienteUseCaseHandler(IRepositoryPacientes repositoryPacientes)
    {
        _repositoryPacientes = repositoryPacientes;
    }
    public async Task<DetailPacienteDTO> Handle(GetDetailPacienteQuery request)
    {
        var paciente = await _repositoryPacientes.ObtenerPorId(request.Id) ?? throw new NotFoundException("Paciente no encontrado");
        return paciente.ToDto();
    }
}
