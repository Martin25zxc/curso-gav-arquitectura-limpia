using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Queries.GetDetailConsultorio;

public class ConsultorioDetailDTO
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
}
