using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;

public static class MapperExtensions
{
    public static ListPacientesDTO ToDto(this Paciente paciente)
    {
        return new ListPacientesDTO
        {
            Id = paciente.Id,
            Nombre = paciente.Nombre,
            Email = paciente.Email.Value
        };
    }
}
