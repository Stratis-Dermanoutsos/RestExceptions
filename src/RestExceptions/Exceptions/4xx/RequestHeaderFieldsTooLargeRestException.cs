namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/431"/>
/// </summary>
public class RequestHeaderFieldsTooLargeRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The request may be resubmitted after reducing the size of the request headers.";

    public override string Title => "Request Header Fields Too Large";
    public override HttpStatusCode StatusCode => HttpStatusCode.RequestHeaderFieldsTooLarge;
}
