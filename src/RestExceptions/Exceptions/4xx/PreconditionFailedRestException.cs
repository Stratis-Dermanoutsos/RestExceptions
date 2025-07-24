namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/412"/>
/// </summary>
public class PreconditionFailedRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Access to the target resource was denied.";

    public override string Title => "Precondition Failed";
    public override HttpStatusCode StatusCode => HttpStatusCode.PreconditionFailed;
}
