using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.DeleteConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.XTests.Application.UseCases.Consultorios;

public class DeleteConsultorioUseCaseHandlerTests
{
    private readonly IRepositoryConsultorios _repositorio;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DeleteConsultorioUseCaseHandler _casoDeUso;
    public DeleteConsultorioUseCaseHandlerTests()
    {

        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _casoDeUso = new DeleteConsultorioUseCaseHandler(_repositorio, _unitOfWork);
    }

    [Fact]
    public async Task Handle_Should_DeleteConsultorio_When_ConsultorioExists()
    {
        // Arrange
        var consultorio = new Consultorio("Consultorio a eliminar");
        var command = new DeleteConsultorioCommand
        {
            Id = consultorio.Id
        };
        _repositorio.ObtenerPorId(command.Id).Returns(consultorio);
        // Act
        await _casoDeUso.Handle(command);
        // Assert
        await _repositorio.Received(1).Borrar(Arg.Any<Consultorio>());
        await _unitOfWork.Received(1).Persistir();
    }
    //not found ex
    [Fact]
    public async Task Handle_Should_ThrowNotFoundException_When_ConsultorioDoesNotExist()
    {
        // Arrange
        var command = new DeleteConsultorioCommand
        {
            Id = Guid.NewGuid()
        };
        _repositorio.ObtenerPorId(command.Id).ReturnsNull();
        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => _casoDeUso.Handle(command));
    }
    [Fact]
    public async Task Handle_Should_Rollback_When_ExceptionOccurs()
    {
        // Arrange
        var consultorio = new Consultorio("Consultorio Original");
        var command = new DeleteConsultorioCommand
        {
            Id = consultorio.Id
        };
        _repositorio.ObtenerPorId(command.Id).Returns(consultorio);
        _repositorio.Actualizar(Arg.Any<Consultorio>()).ThrowsAsync(new Exception());
        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _casoDeUso.Handle(command));
        await _unitOfWork.Received(1).Reversar();
    }
}
