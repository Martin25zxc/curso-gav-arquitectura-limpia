using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using NSubstitute;
using Xunit;

namespace ArquitecturaLimpiaOdont.XTests.Application.UseCases.Consultorios;

public class GetDetailConsultorioUseCaseHandlerTests
{
    private readonly IRepositoryConsultorios _repositorio;
    private readonly GetDetailConsultorioUseCaseHandler _casoDeUso;

    public GetDetailConsultorioUseCaseHandlerTests()
    {
        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _casoDeUso = new GetDetailConsultorioUseCaseHandler(_repositorio);
    }

    [Fact]
    public async Task Handle_ConsultorioExiste_RetornaDTO()
    {
        // Arrange
        var consultorio = new Consultorio("Consultorio Test");
        var id = consultorio.Id;

        var consulta = new GetDetailConsultorioQuery { Id = id };

        _repositorio
            .ObtenerPorId(id)
            .Returns(consultorio);

        // Act
        var resultado = await _casoDeUso.Handle(consulta);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(id, resultado.Id);
        Assert.Equal(consultorio.Nombre, resultado.Nombre);
    }

    [Fact]
    public async Task Handle_ConsultorioNoExiste_LanzarNoEncontrado()
    {
        // Arrange
        var id = Guid.CreateVersion7();

        var consulta = new GetDetailConsultorioQuery { Id = id };

        _repositorio
            .ObtenerPorId(id)
            .Returns((Consultorio?)null);

        // Act / Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _casoDeUso.Handle(consulta));
    }
}