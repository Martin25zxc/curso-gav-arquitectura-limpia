using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace ArquitecturaLimpiaOdont.XTests.Application.UseCases.Consultorios;

public class CreateConsultorioUseCaseHandlerTests
{
    private readonly IRepositoryConsultorios _repositorio;
    private readonly IUnitOfWork _unidadDeTrabajo;
    private readonly CreateConsultorioUseCaseHandler _casoDeUso;

    public CreateConsultorioUseCaseHandlerTests()
    {
        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _unidadDeTrabajo = Substitute.For<IUnitOfWork>();
        _casoDeUso = new CreateConsultorioUseCaseHandler(_repositorio, _unidadDeTrabajo);
    }

    [Fact]
    public async Task Handle_Command_Valido_ObtenerIdConsultorio()
    {
        // Arrange
        const string nombreConsultorio = "C de consultorio";
        var comando = new CreateConsultorioCommand { Nombre = nombreConsultorio };

        var consultorioCreado = new Consultorio(nombreConsultorio);

        _repositorio
            .Agregar(Arg.Any<Consultorio>())
            .Returns(consultorioCreado);

        // Act
        var resultado = await _casoDeUso.Handle(comando);

        // Assert
        await _repositorio.Received(1).Agregar(Arg.Any<Consultorio>());
        await _unidadDeTrabajo.Received(1).Persistir();

        Assert.NotEqual(Guid.Empty, resultado);
    }

    [Fact]
    public async Task Handle_CuandoHayError_HacerRollBack()
    {
        // Arrange
        const string nombreConsultorio = "C de consultorio";
        var comando = new CreateConsultorioCommand { Nombre = nombreConsultorio };

        _repositorio.Agregar(Arg.Any<Consultorio>()).ThrowsAsync(new Exception());

        // Act
        var excepcion = await Assert.ThrowsAsync<Exception>(() => _casoDeUso.Handle(comando));

        // Assert
        await _unidadDeTrabajo.Received(1).Reversar();
        await _unidadDeTrabajo.DidNotReceive().Persistir();
    }
}