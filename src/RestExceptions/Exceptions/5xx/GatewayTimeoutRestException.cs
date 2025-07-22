using System.Net;

namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/504"/>
/// </summary>
public class GatewayTimeoutRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server did not get a response in time in order to complete the request.";

    public override string Title => "Gateway Timeout";
    public override HttpStatusCode StatusCode => HttpStatusCode.GatewayTimeout;
}
