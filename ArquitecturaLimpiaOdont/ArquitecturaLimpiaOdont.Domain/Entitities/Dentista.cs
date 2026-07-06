using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Entitities;

public class Dentista
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;

    public string Email { get; private set; }= string.Empty;
    public Dentista(string nombre, string email)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new BusinessRuleException($"El {nameof(nombre)} es obligatorio");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"El {nameof(email)} es obligatorio");
        }
        if(!email.Contains('@'))
        {
            throw new BusinessRuleException($"El {nameof(email)} no es válido");
        }
        Nombre = nombre;
        Id = Guid.CreateVersion7();
        Email = email;
    }
}
