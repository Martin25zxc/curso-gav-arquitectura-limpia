using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using FluentValidation;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Application.Utilities.Mediador;

[TestClass]
public class SimpleMediatorTests
{
    public class RequestFalse : IRequest<string>
    {
        public required string Nombre { get; set; }
    }

    public class HandlerFalse : IRequestHandler<RequestFalse, string>
    {
        public Task<string> Handle(RequestFalse request)
        {
            return Task.FromResult("Handled");
        }
    }

    public class ValidadorRequestFalse : AbstractValidator<RequestFalse>
    {
        public ValidadorRequestFalse()
        {
            RuleFor(x => x.Nombre).NotEmpty();
        }
    }

    [TestMethod]
    public async Task Send_RequestHandler()
    {
        // Arrange
        var request = new RequestFalse { Nombre = "Test" };
        var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalse, string>>();
        var serviceProviderMock = Substitute.For<IServiceProvider>();
        serviceProviderMock
            .GetService(typeof(IRequestHandler<RequestFalse, string>))
            .Returns(casoDeUsoMock);
        // Act & Assert

        var mediator = new SimpleMediator(serviceProviderMock);
        var resultado = await mediator.Send(request);
        await casoDeUsoMock.Received(1).Handle(request);

    }

    [TestMethod]
    public async Task Send_SinHandlerRegistrado_LanzaExcepcion()
    {
        // Arrange
        var request = new RequestFalse { Nombre = "Test" };
        var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalse, string>>();
        var serviceProviderMock = Substitute.For<IServiceProvider>();
        // Act & Assert

        var mediator = new SimpleMediator(serviceProviderMock);
        await Assert.ThrowsExactlyAsync<MediatorException>(async () => await mediator.Send(request));
    }

    [TestMethod]
    public async Task Send_ComandoNoValido_LanzarExcepcion()
    {
        // Arrange
        var request = new RequestFalse { Nombre = "" };
        var serviceProviderMock = Substitute.For<IServiceProvider>();
        var validador = new ValidadorRequestFalse();
        serviceProviderMock.GetService(typeof(IValidator<RequestFalse>))
            .Returns(validador);
        // Act & Assert

        var mediator = new SimpleMediator(serviceProviderMock);
        await Assert.ThrowsExactlyAsync<ApplicationValidationException>(async () => await mediator.Send(request));
    }
}
