using System.ComponentModel.DataAnnotations;

namespace ArquitecturaLimpiaOdont.Api.DTOs.Consultorios;

public class UpdateConsultorioDTO
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [MaxLength(150, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;
}
