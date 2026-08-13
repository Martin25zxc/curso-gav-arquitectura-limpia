namespace ArquitecturaLimpiaOdont.Domain.Entitities;

public class Consultorio
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;

    public Consultorio(string nombre)
    {
        AplicarReglaDeNegocioNombre(nombre);
        Nombre = nombre;
        Id = Guid.CreateVersion7();
    }

    public void UpdateNombre(string nombre)
    {
        AplicarReglaDeNegocioNombre(nombre);
        Nombre = nombre;
    }

    private void AplicarReglaDeNegocioNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new BusinessRuleException($"El {nameof(nombre)} es obligatorio");
        }
    }
}
