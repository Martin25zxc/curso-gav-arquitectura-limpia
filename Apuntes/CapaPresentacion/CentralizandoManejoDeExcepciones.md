No tiene sentido poner try catch cada rato
Una respuesta especifica segun la excepcion lanzada
Crear carpeta "Middlewares" manejador de excepciones
Ahi colaquemores una clase middleware que maneja los request, y en caso de error los handlea
luego hacemos una clase estatica para extender el builder
(app.UseHandleException();)


using ArquitecturaLimpiaOdont.Application.Exceptions;
using ArquitecturaLimpiaOdont.Domain;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace ArquitecturaLimpiaOdont.Api.Middleware.ExcepctionsHandlers;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke (HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = MediaTypeNames.Application.Json;
        var resultado = string.Empty;
        switch(exception)
        {
            case NotFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case ApplicationValidationException exValidacion:
                httpStatusCode = HttpStatusCode.BadRequest;
                resultado = JsonSerializer.Serialize(exValidacion.ErroresDeValidacion);
                break;

        }
        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(resultado);
    }
}

public static class ExceptionHandlerMiddlewareExtension
{
    public static IApplicationBuilder UseHandleException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}








  private Task HandleException(HttpContext context, Exception exception)
  {
      HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
      context.Response.ContentType = MediaTypeNames.Application.Json;
      var resultado = string.Empty;
      switch(exception)
      {
          case NotFoundException:
              httpStatusCode = HttpStatusCode.NotFound;
              break;
          case ApplicationValidationException exValidacion:
              httpStatusCode = HttpStatusCode.BadRequest;
              resultado = JsonSerializer.Serialize(exValidacion.ErroresDeValidacion);
              break;
          case BusinessRuleException exReglaNegocio:
              httpStatusCode = HttpStatusCode.BadRequest;
              resultado = JsonSerializer.Serialize(new { error = exReglaNegocio.Message });
              break;
          default:
              httpStatusCode = HttpStatusCode.InternalServerError;
              // si es dev devolver el error completo, si es prod solo un mensaje generico
              if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
              {
                  resultado = JsonSerializer.Serialize(new { error = exception.Message, stackTrace = exception.StackTrace });
              }
              else
              {
                  resultado = JsonSerializer.Serialize(new { error = "Ocurrió un error inesperado." });
              }

              break;

      }
      context.Response.StatusCode = (int)httpStatusCode;
      return context.Response.WriteAsync(resultado);
  }