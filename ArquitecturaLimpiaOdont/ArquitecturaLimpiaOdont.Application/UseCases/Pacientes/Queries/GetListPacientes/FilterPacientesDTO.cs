using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Pacientes.Queries.GetListPacientes;

public class FilterPacientesDTO
{
    public int Page { get; set; } = 1;
    public int RecordsPerPage { get; set; } = 10;
}
