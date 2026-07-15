using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;
using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Application.UseCases.Consultorios;

[TestClass]
public class ListConsultoriosUseCaseHandlerTests
{

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
    private IRepositoryConsultorios _repositorio;
    private ListConsultoriosUseCaseHandler _casoDeUso;
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

    [TestInitialize]
    public void Setup()
    {
        _repositorio = Substitute.For<IRepositoryConsultorios>();
        _casoDeUso = new ListConsultoriosUseCaseHandler(_repositorio);
    }

    [TestMethod]
    public async Task Handle_Query_Valido_ObtenerConsultorios()
    {
        List<Consultorio> consultorios =
        [
            new("Consultorio 1"),
            new("Consultorio 2"),
            new("Consultorio 3")
        ];
        _repositorio.ObtenerTodos().Returns(consultorios);
        List<ListConsultoriosDTO> esperado = consultorios.Select(c => new ListConsultoriosDTO
        {
             Id = c.Id,
             Nombre = c.Nombre
        }).ToList();
        var resultado = await _casoDeUso.Handle(new ListConsultoriosQuery());

        Assert.IsNotEmpty(resultado);
        Assert.HasCount(consultorios.Count, resultado);
        for (int i = 0; i < consultorios.Count; i++)
        {
            Assert.AreEqual(esperado[i].Nombre, resultado[i].Nombre);
            Assert.AreEqual(esperado[i].Id, resultado[i].Id);
        }
    }

    [TestMethod]
    public async Task Handle_Query_Valido_ListaVacia()
    {
        List<Consultorio> consultorios =[];
        _repositorio.ObtenerTodos().Returns(consultorios);
        var resultado = await _casoDeUso.Handle(new ListConsultoriosQuery());

        Assert.IsEmpty(resultado);
    }
}
