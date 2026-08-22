using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Value_Objects;

public record Email
{
    public string Value { get;} = string.Empty;
    public Email(string email)
    {

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new BusinessRuleException($"El {nameof(email)} es obligatorio");
        }
        if (!email.Contains('@'))
        {
            throw new BusinessRuleException($"El {nameof(email)} no es válido");
        }
        Value = email;
    }

    private Email()
    {
        
    }
}
