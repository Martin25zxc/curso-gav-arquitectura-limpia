using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Entitities;

public class Dentista
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;

    public Email Email { get; private set; }
    public Dentista(string nombre, Email email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new BusinessRuleException($"El {nameof(nombre)} es obligatorio");
        }

        if (email == null)
        {
            throw new BusinessRuleException($"El {nameof(email)} es obligatorio");
        }

        Nombre = nombre;
        Id = Guid.CreateVersion7();
        Email = email;
    }
}
