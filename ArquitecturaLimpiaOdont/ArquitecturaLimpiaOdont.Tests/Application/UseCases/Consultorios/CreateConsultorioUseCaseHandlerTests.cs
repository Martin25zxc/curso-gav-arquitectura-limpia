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
    private IUnitOfWork _unidadDeTrabajo;
    private CreateConsultorioUseCaseHandler _casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

    [TestInitialize]
    public void Setup()
    {
        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _unidadDeTrabajo = Substitute.For<IUnitOfWork>();
        _casoDeUso = new CreateConsultorioUseCaseHandler(_repositorio, _unidadDeTrabajo);
    }
    [TestMethod]
    public async Task Handle_Command_Valido_ObtenerIdConsultorio()
    {
        const string nombreConsultorio = "C de consultorio";
        var comando = new CreateConsultorioCommand { Nombre = nombreConsultorio };

        var consultorioCreado = new Consultorio(nombreConsultorio);
        _repositorio.Agregar(Arg.Any<Consultorio>()).Returns(consultorioCreado);

        var resultado = await _casoDeUso.Handle(comando);

        await _repositorio.Received(1).Agregar(Arg.Any<Consultorio>());
        await _unidadDeTrabajo.Received(1).Persistir();
        Assert.AreNotEqual(Guid.Empty, resultado);
    }

    [TestMethod]
    public async Task Handle_CuandoHayError_HacerRollBack()
    {

        const string nombreConsultorio = "C de consultorio";
        var comando = new CreateConsultorioCommand { Nombre = nombreConsultorio };
        _repositorio.Agregar(Arg.Any<Consultorio>()).Throws<Exception>();

        await Assert.ThrowsExactlyAsync<Exception>(async () => await _casoDeUso.Handle(comando));
        await _unidadDeTrabajo.Received(1).Reversar();

    }
}
