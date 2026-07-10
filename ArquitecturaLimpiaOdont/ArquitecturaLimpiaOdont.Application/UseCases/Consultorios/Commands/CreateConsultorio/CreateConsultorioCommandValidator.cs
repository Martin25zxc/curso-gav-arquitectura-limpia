using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;

public class CreateConsultorioCommandValidator:AbstractValidator<CreateConsultorioCommand>
{
    public CreateConsultorioCommandValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre del consultorio es obligatorio.");
            //.MaximumLength(100).WithMessage("El nombre del consultorio no puede exceder los 100 caracteres.");
    }
}