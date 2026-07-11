using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Application.UseCases.Consultorios;

[TestClass]
public class GetDetailConsultorioUseCaseHandlerHandlerTests
{
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private IRepositoryConsultorios _repositorio;
    private GetDetailConsultorioUseCaseHandler _casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

    [TestInitialize]
    public void Setup()
    {
        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _casoDeUso = new GetDetailConsultorioUseCaseHandler(_repositorio);
    }

    [TestMethod]
    public async Task Handle_ConsultorioExiste_RetornaDTO()
    {
        // Arrange
        var consultorio = new Consultorio("Consultorio Test");
        var id = consultorio.Id;
        var consulta = new GetDetailConsultorioQuery { Id = id };
        _repositorio.ObtenerPorId(id).Returns(consultorio);

        // Act
        var resultado = await _casoDeUso.Handle(consulta);

        // Assert
        Assert.IsNotNull(resultado);
        Assert.AreEqual(id, resultado.Id);
        Assert.AreEqual(consultorio.Nombre, resultado.Nombre);
    }

    [TestMethod]
    public async Task Handle_ConsultorioNoExiste_LanzarNoEncontrado()
    {
        var id = Guid.CreateVersion7();
        var consulta = new GetDetailConsultorioQuery { Id = id };

        _repositorio.ObtenerPorId(id).ReturnsNull();

        await Assert.ThrowsExactlyAsync<NotFoundException>(async () => await _casoDeUso.Handle(consulta));

    }
}
