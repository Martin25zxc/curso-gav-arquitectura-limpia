namespace ArquitecturaLimpiaOdont.Api.DTOs.Citas;

public class CreateCitaDTO
{
    public required Guid PacienteId { get; set; }
    public required Guid DentistaId { get; set; }
    public required Guid ConsultorioId { get; set; }
    public required DateTime FechaInicio { get; set; }
    public required DateTime FechaFin { get; set; }
}
