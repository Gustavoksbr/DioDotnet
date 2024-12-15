namespace TrilhaApiDesafio.Controllers.exception;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NaoEncontradoException ex)
        {
            await HandleExceptionAsync(context, ex, StatusCodes.Status404NotFound, "Entidade não encontrada");
        }
        catch (JaExisteException ex)
        {
            await HandleExceptionAsync(context, ex, StatusCodes.Status400BadRequest,"Já existe essa entidade");
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, StatusCodes.Status500InternalServerError, "Ocorreu um erro inesperado.");
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode, string customMessage = null)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var result = new
        {
            error = customMessage ?? "erro: " + statusCode
        };

        return context.Response.WriteAsJsonAsync(result);
    }
}

public class JaExisteException : Exception
{
}

public class NaoEncontradoException : Exception
{
}
