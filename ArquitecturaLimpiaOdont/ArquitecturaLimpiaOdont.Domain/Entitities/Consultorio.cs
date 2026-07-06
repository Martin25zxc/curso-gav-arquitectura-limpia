namespace ArquitecturaLimpiaOdont.Domain.Entitities;

public class Consultorio
{
    public Guid Id { get; private set; }
    public string Nombre { get; private set; } = string.Empty;

    public Consultorio(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new BusinessRuleException($"El {nameof(nombre)} es obligatorio");
        }
        Nombre = nombre;
        Id = Guid.CreateVersion7();
    }
}
