using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Enums;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using Xunit;

namespace ArquitecturaLimpiaOdont.XTests.Domain.Entities;

public class CitaTests
{
    private readonly Guid _pacienteId = Guid.NewGuid();
    private readonly Guid _dentistaId = Guid.NewGuid();
    private readonly Guid _consultorioId = Guid.NewGuid();
    private readonly IntervalTime _intervalo = new(
        DateTime.UtcNow.AddDays(1),
        DateTime.UtcNow.AddDays(2));

    [Fact]
    public void Constructor_CitaValida_EstadoProgamada()
    {
        // Act
        var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);

        // Assert
        Assert.Equal(EstadoCita.Programada, cita.Estado);
        Assert.Equal(_pacienteId, cita.PacienteId);
        Assert.Equal(_dentistaId, cita.DentistaId);
        Assert.Equal(_consultorioId, cita.ConsultorioId);
        Assert.Equal(_intervalo, cita.IntervalTime);
    }

    [Fact]
    public void Constructor_FechaInicioAnteriorALaActual_LanzaExcepcion()
    {
        // Arrange
        var intervaloInvalido = new IntervalTime(
            DateTime.UtcNow.AddDays(-1),
            DateTime.UtcNow.AddDays(1));

        // Act / Assert
        Assert.Throws<BusinessRuleException>(() =>
            new Cita(_pacienteId, _dentistaId, _consultorioId, intervaloInvalido));
    }

    [Fact]
    public void Constructor_CancelarCita_EstadoCitaCancelada()
    {
        // Arrange
        var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);

        // Act
        cita.Cancelar();

        // Assert
        Assert.Equal(EstadoCita.Cancelada, cita.Estado);
    }

    [Fact]
    public void Constructor_CancelarCitaYaCancelada_LanzaExcepcion()
    {
        // Arrange
        var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
        cita.Cancelar();

        // Assert estado previo
        Assert.Equal(EstadoCita.Cancelada, cita.Estado);

        // Act / Assert
        Assert.Throws<BusinessRuleException>(cita.Cancelar);
    }

    [Fact]
    public void Constructor_CompletarCita_EstadoCitaCompletada()
    {
        // Arrange
        var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);

        // Act
        cita.Completar();

        // Assert
        Assert.Equal(EstadoCita.Completada, cita.Estado);
    }

    [Fact]
    public void Constructor_CompletarCitaYaCompletada_LanzaExcepcion()
    {
        // Arrange
        var cita = new Cita(_pacienteId, _dentistaId, _consultorioId, _intervalo);
        cita.Completar();

        // Assert estado previo
        Assert.Equal(EstadoCita.Completada, cita.Estado);

        // Act / Assert
        Assert.Throws<BusinessRuleException>(cita.Completar);
    }
}