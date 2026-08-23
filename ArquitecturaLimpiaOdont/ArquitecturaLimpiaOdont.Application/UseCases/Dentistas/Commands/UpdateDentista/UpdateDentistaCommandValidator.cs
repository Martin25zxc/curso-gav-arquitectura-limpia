using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Commands.UpdateDentista;

public class UpdateDentistaCommandValidator: AbstractValidator<UpdateDentistaCommand>
{
    public UpdateDentistaCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("El Id del dentista es obligatorio.");

        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
            .MaximumLength(250).WithMessage("El campo {PropertyName} no puede exceder los {MaxLength} caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
            .MaximumLength(254).WithMessage("El campo {PropertyName} no puede exceder los {MaxLength} caracteres.")
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible).WithMessage("El email no es válido.");
    }
}
