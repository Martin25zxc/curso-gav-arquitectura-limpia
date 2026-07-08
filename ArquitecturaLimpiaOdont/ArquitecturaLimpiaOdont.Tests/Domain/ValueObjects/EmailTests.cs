using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Domain.ValueObjects;

[TestClass]
public class EmailTests
{
    [TestMethod]
    public void Constructor_EmailNulo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<BusinessRuleException>(() => new Email(null!));
    }

    [TestMethod]
    public void Constructor_EmailSinArroba_LanzaExcepcion()
    {
        Assert.ThrowsExactly<BusinessRuleException>(() => new Email("emailSinArroba.com"));
    }

    [TestMethod]
    public void Constructor_EmailValido_CreaInstancia()
    {
        var email = new Email("email@valido.com");
        Assert.AreEqual("email@valido.com", email.Value.ToString());
    }
}