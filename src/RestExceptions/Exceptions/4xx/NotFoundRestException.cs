using System.Net;

namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/404"/>
/// </summary>
public class NotFoundRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Content not found.";

    public override string Title => "Not Found";
    public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
}
