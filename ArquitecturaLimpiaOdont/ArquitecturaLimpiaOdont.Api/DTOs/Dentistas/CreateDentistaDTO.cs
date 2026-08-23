using System.ComponentModel.DataAnnotations;

namespace ArquitecturaLimpiaOdont.Api.DTOs.Dentistas;

public class CreateDentistaDTO
{
    [Required]
    [StringLength(250)]
    public required  string Nombre { get; set; }

    [Required]
    [StringLength(254)]
    [EmailAddress]
    public required  string Email { get; set; }
}
