using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/502
/// </summary>
public class BadGatewayRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server received an invalid response from the upstream server.";

    public override string Title => "Bad Gateway";
    public override HttpStatusCode StatusCode => HttpStatusCode.BadGateway;
}
