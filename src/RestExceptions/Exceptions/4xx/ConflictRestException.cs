namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/409"/>
/// </summary>
public class ConflictRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Concurrent tasks disallowed.";

    public override string Title => "Conflict";
    public override HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
