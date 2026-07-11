using ArquitecturaLimpiaOdont.Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Utilities.Mediator;

public class SimpleMediator : IMediator
{
    private readonly IServiceProvider _serviceProvider;

    public SimpleMediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
    {
        var tipoValidador = typeof(IValidator<>).MakeGenericType(request.GetType());
        var validator = _serviceProvider.GetService(tipoValidador);
        if(validator != null)
        {
            var metodoValidar = tipoValidador.GetMethod("ValidateAsync")!;
            var tareaValidar = (Task<ValidationResult>)metodoValidar.Invoke(validator
                , new object[] { request, CancellationToken.None })!;

            var validationResult = await tareaValidar.ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                throw new ApplicationValidationException(validationResult);
            }
        }


       var useCaseType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));
        var useCase = _serviceProvider.GetService(useCaseType);
        if(useCase == null)
        {
            throw new MediatorException($"No se encontró un handlger para {request.GetType().Name}");
        }
        //Obtener referencia del metodo
        var metodo = useCaseType.GetMethod("Handle")!;
        return await (Task<TResponse>)metodo.Invoke(useCase, new object[] { request })!;
    }
}