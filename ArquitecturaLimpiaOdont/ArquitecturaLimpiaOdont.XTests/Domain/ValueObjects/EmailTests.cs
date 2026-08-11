using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Domain.ValueObjects;

public class EmailTests
{
    [Fact]
    public void Constructor_EmailNulo_LanzaExcepcion()
    {
        Assert.Throws<BusinessRuleException>(() => new Email(null!));
    }

    [Fact]
    public void Constructor_EmailSinArroba_LanzaExcepcion()
    {
        Assert.Throws<BusinessRuleException>(() => new Email("emailSinArroba.com"));
    }

    [Fact]
    public void Constructor_EmailValido_CreaInstancia()
    {
        var email = new Email("email@valido.com");
        Assert.Equal("email@valido.com", email.Value.ToString());
    }
}