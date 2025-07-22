using System.Net;

namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/510"/>
/// </summary>
public class NotExtendedRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The client request declares an HTTP Extension that should be used to process the request, but the extension is not supported.";

    public override string Title => "Not Extended";
    public override HttpStatusCode StatusCode => HttpStatusCode.NotExtended;
}
