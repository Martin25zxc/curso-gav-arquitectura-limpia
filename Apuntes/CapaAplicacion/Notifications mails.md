Agregamos en Contracts de Applications

la carpeta Notifications

agregamos:

ConfirmacionCitaDTO

public interface IServiceNotifications
{
    Task EnviarConfirmacionesCita(ConfirmacionCitaDTO cita);
}


En el create preparamos un mapper para ConfirmacionCitaDTO

y actualizamos el usecasehandler
 public async Task<Guid> Handle(CreateCitaCommand request)
 {
     var citaSolapa = await _repositoryCitas.ExisteCitaSolapada(request.DentistaId, request.FechaInicio, request.FechaFin);
     if (citaSolapa)
     {
         throw new ApplicationValidationException("Ya existe una cita en el mismo horario para el Dentista.");
     }

     var intervaloDeTiempo = new IntervalTime(request.FechaInicio, request.FechaFin);
     var cita = new Cita(request.PacienteId, request.DentistaId, request.ConsultorioId, intervaloDeTiempo);

     Guid? id = null;
     try
     {
         await _repositoryCitas.Agregar(cita);
         await _unitOfWork.Persistir();
         id = cita.Id;

     }
     catch (Exception)
     {
         await _unitOfWork.Reversar();
         throw;
     }

     var citaDb = await _repositoryCitas.ObtenerPorId(id.Value);
     var notificacionDto = citaDb!.ToDto();
     await _serviceNotifications.EnviarConfirmacionesCita(notificacionDto);

     return id.Value;
 }


 En infraestructura creamos un nuevo proyecto para el envio de correos

 .Infrastructure

 public class ServicioCorreo : IServiceNotifications
{
    public Task EnviarConfirmacionesCita(ConfirmacionCitaDTO cita)
    {
        throw new NotImplementedException();
    }
}

hacemos un registro de servicios y lo llamamos en la api


Configurar Gmail, servicio limitado pero gratuito

Paquete nugget en el proyecto de Infrastructure para bindear el iconfiguration


puerto 587,
"CONFIGURACIONES_EMAIL": {
  "HOST": "smtp.gmail.com",
  "PUERTO": 587,
  "EMAIL": "xxx",
  "PASSWORD": "xxx"
}

Tambien podemos enviar notificaciones de recordatorios aprovechando los datos y reutilizando codigo

