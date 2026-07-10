using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Exceptions;

public class ApplicationValidationException : Exception
{
    public List<string> ErroresDeValidacion { get; set; } = [];
    public ApplicationValidationException(ValidationResult validationResult)
    {
        ErroresDeValidacion.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
    }
}
