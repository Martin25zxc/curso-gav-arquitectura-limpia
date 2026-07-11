Modifican estados
Se crea una clase que representa al comando, indicando los datos que necesito tener a mano para realizar una accion

luego otra que representa al caso de uso
que es la que va realizar la accion (handle) recibiendo el comando (la clase que representa al comando)

en esta curso se ve
ComandoCrearConsultorio
CasoDeUsoCrearConsultorio

Buscando tambien hay ejemplos de 
    CreateUserCommand.cs
    CreateUserCommandHandler.cs

public class CreateUserCommand
{
    public string Name { get; set; }
    public string Email { get; set; }
}
public class CreateUserCommandHandler
{
    public Task Handle(CreateUserCommand command)
    {
        // lógica para crear usuario
    }
}