using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace ArquitecturaLimpiaOdont.XTests.Application.Utilities.Mediador;

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

    [Fact]
    public async Task Send_RequestHandler()
    {
        // Arrange
        var request = new RequestFalse { Nombre = "Test" };

        var casoDeUsoMock = Substitute.For<IRequestHandler<RequestFalse, string>>();

        casoDeUsoMock
            .Handle(request)
            .Returns(Task.FromResult("Handled"));

        var serviceProviderMock = Substitute.For<IServiceProvider>();

        serviceProviderMock
            .GetService(typeof(IRequestHandler<RequestFalse, string>))
            .Returns(casoDeUsoMock);

        var mediator = new SimpleMediator(serviceProviderMock);

        // Act
        var resultado = await mediator.Send(request);

        // Assert
        Assert.Equal("Handled", resultado);
        await casoDeUsoMock.Received(1).Handle(request);
    }

    [Fact]
    public async Task Send_SinHandlerRegistrado_LanzaExcepcion()
    {
        // Arrange
        var request = new RequestFalse { Nombre = "Test" };

        var serviceProviderMock = Substitute.For<IServiceProvider>();

        var mediator = new SimpleMediator(serviceProviderMock);

        // Act / Assert
        await Assert.ThrowsAsync<MediatorException>(() => mediator.Send(request));
    }

    [Fact]
    public async Task Send_ComandoNoValido_LanzarExcepcion()
    {
        // Arrange
        var request = new RequestFalse { Nombre = "" };

        var serviceProviderMock = Substitute.For<IServiceProvider>();

        var validador = new ValidadorRequestFalse();

        serviceProviderMock
            .GetService(typeof(IValidator<RequestFalse>))
            .Returns(validador);

        var mediator = new SimpleMediator(serviceProviderMock);

        // Act / Assert
        await Assert.ThrowsAsync<ApplicationValidationException>(() => mediator.Send(request));
    }
}