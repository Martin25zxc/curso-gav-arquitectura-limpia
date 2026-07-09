using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Domain.Entities;


[TestClass]
public class PacientesTests
{
    [TestMethod]
    public void Constructor_NombreNulo_ThrowsArgumentException()
    {
        // Arrange
        string nombreNulo = string.Empty;
        // Act & Assert
        Assert.ThrowsExactly<BusinessRuleException>(() => new Paciente(nombreNulo, new Email("email@service.com")));
    }

    [TestMethod]
    public void Constructor_EmailNulo_ThrowsArgumentException()
    {
        // Arrange
        string nombre = "nombre del paciente";
        string emailNulo = string.Empty;
        // Act & Assert
        Assert.ThrowsExactly<BusinessRuleException>(() => new Paciente(nombre, null));
    }
}
