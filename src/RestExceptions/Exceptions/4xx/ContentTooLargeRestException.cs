namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/413"/>
/// </summary>
public class ContentTooLargeRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The request is too large for the server to process.";

    public override string Title => "Content Too Large";
    public override HttpStatusCode StatusCode => HttpStatusCode.RequestEntityTooLarge;
}
