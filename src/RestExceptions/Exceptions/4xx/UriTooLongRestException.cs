namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/414"/>
/// </summary>
public class UriTooLongRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The URI is too long.";

    public override string Title => "URI Too Long";
    public override HttpStatusCode StatusCode => HttpStatusCode.RequestUriTooLong;
}
