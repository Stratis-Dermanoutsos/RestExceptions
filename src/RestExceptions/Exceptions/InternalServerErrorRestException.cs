using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/500
/// </summary>
public class InternalServerErrorRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "The server was unable to complete your request.";

    public override string Title => "Internal Server Error";
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
}
