using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/507
/// </summary>
public class InsufficientStorageRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server does not have enough available storage to successfully complete the request.";

    public override string Title => "Insufficient Storage";
    public override HttpStatusCode StatusCode => HttpStatusCode.InsufficientStorage;
}
