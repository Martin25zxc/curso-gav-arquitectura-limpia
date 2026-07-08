using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Domain.ValueObjects;

[TestClass]
public class IntervalTimeTests
{
    [TestMethod]
    public void Constructor_FechaInicioMayorQueFechaFin_LanzaExcepcion()
    {
        Assert.ThrowsExactly<BusinessRuleException>(() => new IntervalTime(DateTime.Now.AddHours(1), DateTime.Now));
    }

    [TestMethod]
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
