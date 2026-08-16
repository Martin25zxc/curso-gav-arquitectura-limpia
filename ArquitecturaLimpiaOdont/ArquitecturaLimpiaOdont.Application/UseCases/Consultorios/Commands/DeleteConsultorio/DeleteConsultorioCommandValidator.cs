using ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.UpdateConsultorio;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.DeleteConsultorio;

public class DeleteConsultorioCommandValidator : AbstractValidator<DeleteConsultorioCommand>
{
    public DeleteConsultorioCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El Id del consultorio es obligatorio.")
            .NotEqual(Guid.Empty).WithMessage("El Id del consultorio no puede ser un Guid vacío.");
    }
}
