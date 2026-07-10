using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;

public class CreateConsultorioUseCaseHandler
{
    private readonly IRepositoryConsultorios _repositoryConsultorios;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateConsultorioCommand> _validator;

    public CreateConsultorioUseCaseHandler(IRepositoryConsultorios repositoryConsultorios, IUnitOfWork unitOfWork
        , IValidator<CreateConsultorioCommand> validator)
    {
        _repositoryConsultorios = repositoryConsultorios;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateConsultorioCommand command)
    {
        var resultadoValidacion = await _validator.ValidateAsync(command);
        if (!resultadoValidacion.IsValid)
        {
            throw new ApplicationValidationException(resultadoValidacion);
        }
        var consultorio = new Consultorio(command.Nombre);
        try 
        {
            await _repositoryConsultorios.Agregar(consultorio);
            await _unitOfWork.Persistir();
            return consultorio.Id;
        }
        catch(Exception)
        {
            await _unitOfWork.Reversar();
            throw;
        }
   
    }
}
