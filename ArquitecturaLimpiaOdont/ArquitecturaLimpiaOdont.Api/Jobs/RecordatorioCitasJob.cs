using ArquitecturaLimpiaOdont.Application.UseCases.Citas.Commands.EnviarRecordatorioCitas;
using ArquitecturaLimpiaOdont.Application.Utilities.Mediator;

namespace ArquitecturaLimpiaOdont.Api.Jobs;

public class RecordatorioCitasJob : BackgroundService
{
    private readonly IServiceScopeFactory scopeFactory;
    private readonly TimeZoneInfo zonaHoraria = = TimeZoneInfo.FindSystemTimeZoneById("Montevideo Standard Time");

    public RecordatorioCitasJob(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var ahora = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zonaHoraria);

            if (ahora.Hour == 8)
            {
                using var scope = scopeFactory.CreateScope();
                var mediador = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediador.Send(new ComandoEnviarRecordatoriosCitas());
            }

            // para que no se vuelva a pisar cuando la hora es 8
            await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
        }
    }
}
