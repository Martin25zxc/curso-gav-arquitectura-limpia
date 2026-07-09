using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Domain.Entities;

[TestClass]
public class ConsultorioTests
{
    [TestMethod]
    public void Constuctor_NombreNulo_ThrowsArgumentException()
    {
        // Arrange
        string nombreNulo = string.Empty;
        // Act & Assert
        Assert.ThrowsExactly<BusinessRuleException>(() => new Consultorio(nombreNulo));
    }
}
