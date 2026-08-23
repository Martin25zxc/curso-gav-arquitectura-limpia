using System.ComponentModel.DataAnnotations;

namespace ArquitecturaLimpiaOdont.Api.DTOs.Pacientes;

public class UpdatePacienteDTO
{
    [Required]
    [StringLength(250)]
    public required string Nombre { get; set; }

    [Required]
    [StringLength(254)]
    [EmailAddress]
    public required string Email { get; set; }
}
