using ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetDetailPaciente;

public static class MapperExtensions
{
    public static DetailPacienteDTO ToDto(this Paciente paciente)
    {
        return new DetailPacienteDTO
        {
            Id = paciente.Id,
            Nombre = paciente.Nombre,
            Email = paciente.Email.Value
        };
    }
}
