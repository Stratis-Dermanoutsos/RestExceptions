using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/501
/// </summary>
public class NotImplementedRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "This method is not yet implemented.";

    public override string Title => "Not Implemented";
    public override HttpStatusCode StatusCode => HttpStatusCode.NotImplemented;
}
