using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Citas.Queries.GetListCitas;

public class FilterCitasDTO
{
    public Guid? PacienteId { get; set; }
    public Guid? DentistaId { get; set; }
    public Guid? ConsultorioId { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fin { get; set; }
}
