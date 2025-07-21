using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/505
/// </summary>
public class HttpVersionNotSupportedRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "The HTTP version used in the request is not supported by the server.";

    public override string Title => "HTTP Version Not Supported";
    public override HttpStatusCode StatusCode => HttpStatusCode.HttpVersionNotSupported;
}
