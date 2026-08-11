using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Domain.ValueObjects;

public class IntervalTimeTests
{
    [Fact]
    public void Constructor_FechaInicioMayorQueFechaFin_LanzaExcepcion()
    {
        Assert.Throws<BusinessRuleException>(() => new IntervalTime(DateTime.Now.AddHours(1), DateTime.Now));
    }

    [Fact]
    public void Constructor_ParametrosCorrectos_NoLanzaExcepcion()
    {
        try
        {
            var intervalTime = new IntervalTime(DateTime.Now, DateTime.Now.AddHours(1));

        }
        catch (BusinessRuleException)
        {
            Assert.Fail("No se esperaba una excepción de regla de negocio.");
        }
    }
}
