using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/500
/// </summary>
public class InternalServerErrorRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "This method is not yet implemented.";

    public override string Title => "Internal Server Error";
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
}
