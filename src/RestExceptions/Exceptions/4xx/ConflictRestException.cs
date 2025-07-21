using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/409
/// </summary>
public class ConflictRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "Concurrent tasks disallowed.";

    public override string Title => "Conflict";
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
