using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.UseCases.Consultorios.Commands.CreateConsultorio;

public class CreateConsultorioCommand
{
    public required string Nombre { get; set; }
}
