using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/403
/// </summary>
public class ForbiddenRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Request failed due to insufficient permissions.";

    public override string Title => "Forbidden";
    public override HttpStatusCode StatusCode => HttpStatusCode.Forbidden;
}
