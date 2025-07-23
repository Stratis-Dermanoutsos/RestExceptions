namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/423"/>
/// </summary>
public class LockedRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "A resource is locked and it can't be accessed.";

    public override string Title => "Locked";
    public override HttpStatusCode StatusCode => HttpStatusCode.Locked;
}
