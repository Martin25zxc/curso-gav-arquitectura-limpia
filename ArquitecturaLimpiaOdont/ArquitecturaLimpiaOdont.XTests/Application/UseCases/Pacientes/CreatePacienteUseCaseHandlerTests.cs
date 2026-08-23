using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Commands.CreatePaciente;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.XTests.Application.UseCases.Pacientes;

public class CreatePacienteUseCaseHandlerTests
{
    private readonly IRepositoryPacientes _repositorio;
    private readonly IUnitOfWork _unidadDeTrabajo;
    private readonly CreatePacienteUseCaseHandler _casoDeUso;

    public CreatePacienteUseCaseHandlerTests()
    {
        _repositorio = Substitute.For<IRepositoryPacientes>();
        _unidadDeTrabajo = Substitute.For<IUnitOfWork>();
        _casoDeUso = new CreatePacienteUseCaseHandler(_repositorio, _unidadDeTrabajo);
    }

    [Fact]
    public async Task Handle_Command_Valido_ObtenerIdPaciente()
    {
        // Arrange
        const string nombrePaciente = "John Doe";
        var comando = new CreatePacienteCommand { Nombre = nombrePaciente, Email = "john.doe@example.com" };

        var pacienteCreado = new Paciente(nombrePaciente, new Email("john.doe@example.com"));

        _repositorio
            .Agregar(Arg.Any<Paciente>())
            .Returns(pacienteCreado);

        // Act
        var resultado = await _casoDeUso.Handle(comando);

        // Assert
        await _repositorio.Received(1).Agregar(Arg.Any<Paciente>());
        await _unidadDeTrabajo.Received(1).Persistir();

        Assert.NotEqual(Guid.Empty, resultado);
    }

    [Fact]
    public async Task Handle_CuandoHayError_HacerRollBack()
    {
        // Arrange
        const string nombrePaciente = "John Doe";
        var comando = new CreatePacienteCommand { Nombre = nombrePaciente, Email = "john.doe@example.com" };

        _repositorio.Agregar(Arg.Any<Paciente>()).ThrowsAsync(new Exception());

        // Act
        var excepcion = await Assert.ThrowsAsync<Exception>(() => _casoDeUso.Handle(comando));

        // Assert
        await _unidadDeTrabajo.Received(1).Reversar();
        await _unidadDeTrabajo.DidNotReceive().Persistir();
    }
}