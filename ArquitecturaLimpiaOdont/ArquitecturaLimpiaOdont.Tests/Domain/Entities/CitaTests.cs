using ArquitecturaLimpiaOdont.Domain;
using ArquitecturaLimpiaOdont.Domain.Entitities;
using ArquitecturaLimpiaOdont.Domain.Enums;
using ArquitecturaLimpiaOdont.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquitecturaLimpiaOdont.Tests.Domain.Entities;

[TestClass]
public class CitaTests
{
    private Guid pacienteId = Guid.NewGuid();
    private Guid dentistaId = Guid.NewGuid();
    private Guid consultorioId = Guid.NewGuid();
    private IntervalTime intervalo = new IntervalTime(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(2));

    [TestMethod]
    public void Constructor_CitaValida_EstadoProgamada()
    {
        var cita = new Cita(pacienteId, dentistaId, consultorioId, intervalo);
        Assert.AreEqual(EstadoCita.Programada, cita.Estado);
        Assert.AreEqual(pacienteId, cita.PacienteId);
        Assert.AreEqual(dentistaId, cita.DentistaId);
        Assert.AreEqual(consultorioId, cita.ConsultorioId);
        Assert.AreEqual(intervalo, cita.IntervalTime);
    }

    [TestMethod]
    public void Constructor_FechaInicioAnteriorALaActual_LanzaExcepcion()
    {
        var intervaloInvalido = new IntervalTime(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow.AddDays(1));
        Assert.ThrowsExactly<BusinessRuleException>(() => new Cita(pacienteId, dentistaId, consultorioId, intervaloInvalido));
    }

    [TestMethod]
    public void Constructor_CancelarCita_EstadoCitaCancelada()
    {

        var cita = new Cita(pacienteId, dentistaId, consultorioId, intervalo);
        cita.Cancelar();
        Assert.AreEqual(EstadoCita.Cancelada, cita.Estado);
    }

    [TestMethod]
    public void Constructor_CancelarCitaYaCancelada_LanzaExcepcion()
    {

        var cita = new Cita(pacienteId, dentistaId, consultorioId, intervalo);
        cita.Cancelar();
        Assert.AreEqual(EstadoCita.Cancelada, cita.Estado);
        Assert.ThrowsExactly<BusinessRuleException>(cita.Cancelar);
    }

    [TestMethod]
    public void Constructor_CompletarCita_EstadoCitaCompletada()
    {

        var cita = new Cita(pacienteId, dentistaId, consultorioId, intervalo);
        cita.Completar();
        Assert.AreEqual(EstadoCita.Completada, cita.Estado);
    }

    [TestMethod]
    public void Constructor_CancelarCitaYaCompletada_LanzaExcepcion()
    {

        var cita = new Cita(pacienteId, dentistaId, consultorioId, intervalo);
        cita.Completar();
        Assert.AreEqual(EstadoCita.Completada, cita.Estado);
        Assert.ThrowsExactly<BusinessRuleException>(cita.Completar);
    }
}
