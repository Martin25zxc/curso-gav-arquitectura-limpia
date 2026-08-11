using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using NSubstitute;
using Xunit;

namespace ArquitecturaLimpiaOdont.XTests.Application.UseCases.Consultorios;

public class ListConsultoriosUseCaseHandlerTests
{
    private readonly IRepositoryConsultorios _repositorio;
    private readonly ListConsultoriosUseCaseHandler _casoDeUso;

    public ListConsultoriosUseCaseHandlerTests()
    {
        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _casoDeUso = new ListConsultoriosUseCaseHandler(_repositorio);
    }

    [Fact]
    public async Task Handle_Query_Valido_ObtenerConsultorios()
    {
        // Arrange
        List<Consultorio> consultorios =
        [
            new("Consultorio 1"),
            new("Consultorio 2"),
            new("Consultorio 3")
        ];

        _repositorio
            .ObtenerTodos()
            .Returns(consultorios);

        List<ListConsultoriosDTO> esperado = consultorios
            .Select(c => new ListConsultoriosDTO
            {
                Id = c.Id,
                Nombre = c.Nombre
            })
            .ToList();

        // Act
        var resultado = await _casoDeUso.Handle(new ListConsultoriosQuery());

        // Assert
        Assert.NotEmpty(resultado);
        Assert.Equal(consultorios.Count, resultado.Count);

        for (int i = 0; i < consultorios.Count; i++)
        {
            Assert.Equal(esperado[i].Nombre, resultado[i].Nombre);
            Assert.Equal(esperado[i].Id, resultado[i].Id);
        }
    }

    [Fact]
    public async Task Handle_Query_Valido_ListaVacia()
    {
        // Arrange
        List<Consultorio> consultorios = [];

        _repositorio
            .ObtenerTodos()
            .Returns(consultorios);

        // Act
        var resultado = await _casoDeUso.Handle(new ListConsultoriosQuery());

        // Assert
        Assert.Empty(resultado);
    }
}