using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyModel;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace ArquitecturaLimpiaOdont.Tests.Application.UseCases.Consultorios;

[TestClass]
public class CreateConsultorioUseCaseHandlerTests
{
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private IRepositoryConsultorios _repositorio;
    private IValidator<CreateConsultorioCommand> _validador;
    private IUnitOfWork _unidadDeTrabajo;
    private CreateConsultorioUseCaseHandler _casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

    [TestInitialize]
    public void Setup()
    {
        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _validador = Substitute.For< IValidator<CreateConsultorioCommand>>();
        _unidadDeTrabajo = Substitute.For<IUnitOfWork>();
        _casoDeUso = new CreateConsultorioUseCaseHandler(_repositorio, _unidadDeTrabajo, _validador);
    }
    [TestMethod]
    public async Task Handle_Command_Valido_ObttenerIdConsultorio()
    {
        const string nombreConsultorio = "C de consultorio";
        var comando = new CreateConsultorioCommand { Nombre = nombreConsultorio };

        _validador.ValidateAsync(comando).Returns(new ValidationResult());
        var consultorioCreado = new Consultorio(nombreConsultorio);
        _repositorio.Agregar(Arg.Any<Consultorio>()).Returns(consultorioCreado);

        var resultado = await _casoDeUso.Handle(comando);

        await _validador.Received(1).ValidateAsync(comando);
        await _repositorio.Received(1).Agregar(Arg.Any<Consultorio>());
        await _unidadDeTrabajo.Received(1).Persistir();
        Assert.AreNotEqual(Guid.Empty, resultado);
    }

    [TestMethod]
    public async Task Handle_ComandoNoValido_LanzaExcepcion()
    {
        var comando = new CreateConsultorioCommand { Nombre  = ""};
        var resultadoInvalido = new ValidationResult(new[]
        { new ValidationFailure("Nombre", "El nombre es obligatorio")});

        _validador.ValidateAsync(comando).Returns(resultadoInvalido);
        await Assert.ThrowsExactlyAsync<ApplicationValidationException>(async () =>
        {
            await _casoDeUso.Handle(comando);
        });
        await _repositorio.DidNotReceive().Agregar(Arg.Any<Consultorio>());
    }

    [TestMethod]
    public async Task Handle_CuandoHayError_HacerRollBack()
    {

        const string nombreConsultorio = "C de consultorio";
        var comando = new CreateConsultorioCommand { Nombre = nombreConsultorio };
        _repositorio.Agregar(Arg.Any<Consultorio>()).Throws<Exception>();
        _validador.ValidateAsync(comando).Returns(new ValidationResult());

        await Assert.ThrowsExactlyAsync<Exception>(async () => await _casoDeUso.Handle(comando));
        await _unidadDeTrabajo.Received(1).Reversar();

    }
}
