using ArquitecturaLimpiaOdont.Domain.Entitities;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Dentistas.Queries.GetListDentistas;

public static class MapperExtensions
{
    public static ListDentistasDTO ToDto(this Dentista dentista)
    {
        return new ListDentistasDTO
        {
            Id = dentista.Id,
            Nombre = dentista.Nombre,
            Email = dentista.Email.Value
        };
    }
}
