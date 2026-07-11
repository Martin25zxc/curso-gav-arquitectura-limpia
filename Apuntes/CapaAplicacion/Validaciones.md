Si van haber validaciones en el dominion con respecto a las reglas de negocio

Logica de validacion, vamos a validar nuestros comandos
Crearemos una clase donde vamos a tener las variaciones del comando
Libreria FluentValidation, permitiendo respetar las responsabilidad unica
En caso de no ser valida lanzaremos una excepcion personalizada

using FluentValidation.Results;

namespace ArquitecturaLimpiaOdont.Application.Exceptions;

public class ApplicationValidationException : Exception
{
    public List<string> ErroresDeValidacion { get; set; } = [];
    public ApplicationValidationException(ValidationResult validationResult)
    {
        ErroresDeValidacion.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
    }
}

Tener cuidado con los usings
ValidationExceptiom es un tipode esxcepcion
ValidationResult es una clase perteneciente a otras librerias comunes integradas