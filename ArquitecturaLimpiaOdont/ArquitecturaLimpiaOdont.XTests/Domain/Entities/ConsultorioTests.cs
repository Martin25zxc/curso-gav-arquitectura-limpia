using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using Xunit;

namespace ArquitecturaLimpiaOdont.XTests.Domain.Entities;

public class ConsultorioTests
{
    [Fact]
    public void Constructor_NombreVacio_LanzaBusinessRuleException()
    {
        // Arrange
        string nombreVacio = string.Empty;

        // Act / Assert
        Assert.Throws<BusinessRuleException>(() => new Consultorio(nombreVacio));
    }
}