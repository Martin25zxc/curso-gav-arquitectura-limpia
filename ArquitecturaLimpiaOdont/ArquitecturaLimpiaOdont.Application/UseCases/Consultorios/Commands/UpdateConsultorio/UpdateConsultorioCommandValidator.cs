using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;

public class UpdateConsultorioCommandValidator : AbstractValidator<UpdateConsultorioCommand>
{
    public UpdateConsultorioCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El Id del consultorio es obligatorio.")
            .NotEqual(Guid.Empty).WithMessage("El Id del consultorio no puede ser un Guid vacío.");
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del consultorio es obligatorio.")
            .MaximumLength(150).WithMessage("El nombre del consultorio no puede exceder los 150 caracteres.");
    }
}
