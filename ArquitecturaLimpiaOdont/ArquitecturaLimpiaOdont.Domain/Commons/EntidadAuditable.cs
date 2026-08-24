using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Commons;

public abstract class EntidadAuditable
{
    public string? CreadoPor { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string? UltimaModificacionPor { get; set; }
    public DateTime? UltimaFechaModificacion { get; set; }
}