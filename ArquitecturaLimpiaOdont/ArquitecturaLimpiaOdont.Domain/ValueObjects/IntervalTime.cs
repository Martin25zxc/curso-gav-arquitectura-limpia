using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Value_Objects;

public record IntervalTime
{
    public DateTime Inicio { get; }
    public DateTime Fin { get; }

    public IntervalTime(DateTime inicio, DateTime fin)
    {
        if (inicio >= fin)
        {
            throw new BusinessRuleException("El inicio del intervalo debe ser anterior al fin.");
        }

        Inicio = inicio;
        Fin = fin;
    }
    private IntervalTime()
    {
            
    }
}
