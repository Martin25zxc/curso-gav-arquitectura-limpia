using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.CreateCita;

public class CreateCitaCommandValidator : AbstractValidator<CreateCitaCommand>
{
    public CreateCitaCommandValidator()
    {
        RuleFor(c => c.FechaInicio)
            .GreaterThan(c => c.FechaFin).WithMessage("La fecha de inicio debe ser menor que la fecha de fin.")
            .GreaterThan(DateTime.UtcNow).WithMessage("La fecha de inicio debe ser una fecha futura.");

        
    }
}
