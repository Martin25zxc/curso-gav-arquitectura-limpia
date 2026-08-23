namespace ArquitecturaLimpiaOdont.Api.Utilities;

public static class HttpContextExtensions
{
    public static void InsertarPaginacionEnCabecera(this HttpContext context, int cantidadRegistros)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.Response.Headers.Append("X-Pagination-TotalCount", cantidadRegistros.ToString());
    }
}