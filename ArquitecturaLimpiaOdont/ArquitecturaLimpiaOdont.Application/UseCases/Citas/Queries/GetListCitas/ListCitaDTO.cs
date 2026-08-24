using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;

public class ListCitaDTO
{
    public required Guid Id { get; set; }
    public required string Paciente { get; set; }
    public required string Dentista { get; set; }
    public required string Consultorio { get; set; }
    public required DateTime FechaInicio { get; set; }
    public required DateTime FechaFin { get; set; }
    public required string EstadoCita { get; set; }
}
