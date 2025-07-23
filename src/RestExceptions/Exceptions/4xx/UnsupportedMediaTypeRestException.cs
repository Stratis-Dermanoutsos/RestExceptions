namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/415"/>
/// </summary>
public class UnsupportedMediaTypeRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The message content format is not supported.";

    public override string Title => "Unsupported Media Type";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnsupportedMediaType;
}
