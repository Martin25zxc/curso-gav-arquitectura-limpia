using ArquitecturaLimpiaOdont.Application.Contracts.Persistance;
using ArquitecturaLimpiaOdont.Application.Contracts.Repositories;
using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using FluentValidation;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;

public class CreateConsultorioUseCaseHandler: IRequestHandler<CreateConsultorioCommand,Guid>
{
    private readonly IRepositoryConsultorios _repositoryConsultorios;
    private readonly IUnitOfWork _unitOfWork;

    public CreateConsultorioUseCaseHandler(IRepositoryConsultorios repositoryConsultorios, IUnitOfWork unitOfWork)
    {
        _repositoryConsultorios = repositoryConsultorios;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateConsultorioCommand command)
    {
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
