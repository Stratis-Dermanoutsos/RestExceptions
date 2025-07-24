namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/451"/>
/// </summary>
public class UnavailableForLegalReasonsRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The resource is not available due to legal reasons.";

    public override string Title => "Unavailable For Legal Reasons";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnavailableForLegalReasons;
}
