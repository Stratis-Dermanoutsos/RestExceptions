using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/401
/// </summary>
public class UnauthorizedRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "Unauthorized request to a protected API.";

    public override string Title => "Unauthorized";
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}
