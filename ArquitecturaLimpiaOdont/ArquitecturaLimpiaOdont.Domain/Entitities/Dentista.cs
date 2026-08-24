using ArquitecturaLimpiaOdont.Domain.Commons;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Domain.Entitities;

public class Dentista : EntidadAuditable
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;

    public Email Email { get; private set; }
    public Dentista(string nombre, Email email)
    {
        AplicarReglaNegocioNombre(nombre);
        AplicarReglaNegocioEmail(email);
        Nombre = nombre;
        Id = Guid.CreateVersion7();
        Email = email;
    }

    private Dentista()
    {
        Email = default!;
    }

    public void ActualizarNombre(string nombre)
    {
        AplicarReglaNegocioNombre(nombre);
        Nombre = nombre;
    }

    public void ActualizarEmail(Email email)
    {
        AplicarReglaNegocioEmail(email);
        Email = email;
    }

    private void AplicarReglaNegocioNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new BusinessRuleException($"El {nameof(nombre)} es obligatorio");
        }
    }
    private void AplicarReglaNegocioEmail(Email email)
    {
        if (email == null)
        {
            throw new BusinessRuleException($"El {nameof(email)} es obligatorio");
        }
    }
}