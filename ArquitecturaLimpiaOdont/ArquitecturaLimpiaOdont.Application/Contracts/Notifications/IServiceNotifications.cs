using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Application.Contracts.Notifications;

public interface IServiceNotifications
{
    Task EnviarConfirmacionesCita(ConfirmacionCitaDTO cita);
    Task EnviarRecordatorioCita(RecordatorioCitasDTO cita);
}
