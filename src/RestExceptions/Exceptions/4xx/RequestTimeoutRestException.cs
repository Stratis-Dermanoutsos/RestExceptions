namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/408"/>
/// </summary>
public class RequestTimeoutRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server would like to shut down this unused connection.";

    public override string Title => "Request Timeout";
    public override HttpStatusCode StatusCode => HttpStatusCode.RequestTimeout;
}
