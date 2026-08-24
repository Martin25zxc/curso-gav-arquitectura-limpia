En la capa de infra aislaremos todo lo de seguridad
crearemos un nuevo proyecto especifico

Paquetes a instalar
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.AspNetCore.Identity.UI

Con proteger las rutas no basta
tambien se puede proteger usando claims 
No basta que el usuario este autenticado, sino que tambien tenga el claim que le permita usarlo

se le puede agregar el claim desde la bd
con una query
insert into AspNetUserClaims (UserId, ClaimType, ClaimValue)

select '', 'esadmin', 'true'

header
Authorization : Bearer ...


{
  "email": "odonto@ejemplo.com",
  "password": "Odonto.1"
}

---------

Creamos el contrato en aplication pero la implementacion en una carpeta services del proyecto identity

UsersService

para obtener el id del usuario


public class UsersService : IUsersService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public UsersService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public string ObtenerUsuarioId()
    {
        return httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
    }
}