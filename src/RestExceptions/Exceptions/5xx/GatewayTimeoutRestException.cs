using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/504
/// </summary>
public class GatewayTimeoutRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "The server did not get a response in time in order to complete the request.";

    public override string Title => "Gateway Timeout";
    public override HttpStatusCode StatusCode => HttpStatusCode.GatewayTimeout;
}
