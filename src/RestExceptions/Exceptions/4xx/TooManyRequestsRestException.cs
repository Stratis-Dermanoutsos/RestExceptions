namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/429"/>
/// </summary>
public class TooManyRequestsRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The client has sent too many requests in a short amount of time.";

    public override string Title => "Too Many Requests";
    public override HttpStatusCode StatusCode => HttpStatusCode.TooManyRequests;
}
