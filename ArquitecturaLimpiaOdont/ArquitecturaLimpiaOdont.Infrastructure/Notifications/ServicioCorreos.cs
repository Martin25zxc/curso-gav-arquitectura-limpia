using ArquitecturaLimpiaOdont.Application.Contracts.Notifications;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ArquitecturaLimpiaOdont.Infrastructure.Notifications;

public class ServicioCorreos : IServiceNotifications
{
    private readonly IConfiguration _configuration;
    public ServicioCorreos(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task EnviarConfirmacionesCita(ConfirmacionCitaDTO cita)
    {
        var asunto = $"Confirmación de cita con {cita.Dentista}";

        var cuerpo = $"""
        Estimado (a) {cita.Paciente}, 
            
        Su cita con el Dr (Dra.) {cita.Dentista} ha sido programada para el {cita.Fecha.ToString("f", new CultureInfo("es-DO"))} en el consultorio {cita.Consultorio}.

        ¡Lo esperamos!

        Equipo Odontológico
        """;

        await EnviarMensaje(cita.Paciente_Email, asunto, cuerpo);
    }

    public async Task EnviarRecordatorioCita(RecordatorioCitasDTO cita)
    {
        var asunto = "RECORDATORIO: Confirmación de cita";

        var cuerpo = $"""
            Estimado (a) {cita.Paciente}, 
            
            Le recordamos que tiene cita con el Dr (Dra.) {cita.Dentista} para el {cita.Fecha.ToString("f", new CultureInfo("es-DO"))} en el consultorio {cita.Consultorio}.

            ¡Lo esperamos!

            Equipo Odontológico
            """;

        await EnviarMensaje(cita.Paciente_Email, asunto, cuerpo);

    }

    private async Task EnviarMensaje(string emailDestinatario, string asunto, string cuerpo)
    {
        var nuestroEmail = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
        var password = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
        var host = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
        var puerto = _configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

        var smtpCliente = new SmtpClient(host, puerto);
        smtpCliente.EnableSsl = true;
        smtpCliente.UseDefaultCredentials = false;
        smtpCliente.Credentials = new NetworkCredential(nuestroEmail, password);

        var mensaje = new MailMessage(nuestroEmail!, emailDestinatario, asunto, cuerpo);
        await smtpCliente.SendMailAsync(mensaje);
    }

}
