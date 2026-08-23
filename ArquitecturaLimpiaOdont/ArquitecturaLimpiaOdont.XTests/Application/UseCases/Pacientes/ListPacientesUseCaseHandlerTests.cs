using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.XTests.Application.UseCases.Pacientes;

public class ListPacientesUseCaseHandlerTests
{
    private readonly IRepositoryPacientes _repositorio;
    private readonly ListPacientesUseCaseHandler _casoDeUso;

    public ListPacientesUseCaseHandlerTests()
    {
        _repositorio = Substitute.For<IRepositoryPacientes>();
        _casoDeUso = new ListPacientesUseCaseHandler(_repositorio);
    }

    [Fact]
    public async Task Handle_Query_Valido_ObtenerPacientesPaginados()
    {
        var page = 1;
        var recordsPerPage = 2;

        var filtroPacientoDto= new FilterPacientesDTO { Page = page, RecordsPerPage = recordsPerPage };
        var paciente1 = new Paciente ("Felipe", new Email("felipe@example.com"));
        var paciente2 = new Paciente ("María", new Email("maria@example.com"));

        IEnumerable<Paciente> pacientes = new List<Paciente> { paciente1, paciente2 };
        _repositorio.GetFilteredPacientes(Arg.Any<FilterPacientesDTO>()).Returns(Task.FromResult(pacientes));

        _repositorio.ObtenerCantidadTotalRegistros().Returns(Task.FromResult(10));

        var request = new ListPacientesQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        };

        var result = await _casoDeUso.Handle(request);

        Assert.NotNull(result);
        Assert.Equal(2, result.Items.Count);
        Assert.Equal("Felipe", result.Items[0].Nombre);
        Assert.Equal("María", result.Items[1].Nombre);
    }

    [Fact]
    public async Task Handle_Query_SinPacientes_ObtenerListaVacia()
    {
        var page = 1;
        var recordsPerPage = 2;
        var filtroPacientoDto = new FilterPacientesDTO { Page = page, RecordsPerPage = recordsPerPage };
        IEnumerable<Paciente> pacientes = new List<Paciente>();
        _repositorio.GetFilteredPacientes(Arg.Any<FilterPacientesDTO>()).Returns(Task.FromResult(pacientes));
        _repositorio.ObtenerCantidadTotalRegistros().Returns(Task.FromResult(0));
        var request = new ListPacientesQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        };
        var result = await _casoDeUso.Handle(request);
        Assert.NotNull(result);
        Assert.Empty(result.Items);
        Assert.Equal(0, result.Total);
    }

    [Fact]
    public async Task Handle_Query_ErrorEnRepositorio_LanzaExcepcion()
    {
        var page = 1;
        var recordsPerPage = 2;
        var filtroPacientoDto = new FilterPacientesDTO { Page = page, RecordsPerPage = recordsPerPage };
        _repositorio.GetFilteredPacientes(Arg.Any<FilterPacientesDTO>()).ThrowsAsync(new Exception("Error en el repositorio"));
        var request = new ListPacientesQuery
        {
            Page = page,
            RecordsPerPage = recordsPerPage
        };
        await Assert.ThrowsAsync<Exception>(() => _casoDeUso.Handle(request));
    }
}
