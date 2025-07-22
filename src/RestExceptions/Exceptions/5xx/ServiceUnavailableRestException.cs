namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/503"/>
/// </summary>
public class ServiceUnavailableRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server is not ready to handle the request.";

    public override string Title => "Service Unavailable";
    public override HttpStatusCode StatusCode => HttpStatusCode.ServiceUnavailable;
}
