using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetListConsultorios;

public class ListConsultoriosDTO
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
}
