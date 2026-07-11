Una consulta
es similar al comando, es lo que le pasamos al mediador para identificar el caso de uso ejecutar, solo que es para obtener data y no hacer cambios

No debemos devolver entidades, lo ideal es devolver dtos (datatransferobjects)

Los casos de usos no tienen que atender detalles de implementacion por lo tanto podemos abstraer la logica de mapeo,

public static class MapperExtensions
{
    public static ConsultorioDetailDTO ToDto(this Consultorio consultorio)
    {
        return new ConsultorioDetailDTO
        {
            Id = consultorio.Id,
            Nombre = consultorio.Nombre
        };
    }
}
