using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/405
/// </summary>
public class MethodNotAllowedRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "Server owners disallow the use of certain methods due to security concerns.";

    public override string Title => "Method Not Allowed";
    public override HttpStatusCode StatusCode => HttpStatusCode.MethodNotAllowed;
}
