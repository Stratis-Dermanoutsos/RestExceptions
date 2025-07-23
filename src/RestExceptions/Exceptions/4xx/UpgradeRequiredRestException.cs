namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/426"/>
/// </summary>
public class UpgradeRequiredRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The client needs to upgrade to a different protocol.";

    public override string Title => "Upgrade Required";
    public override HttpStatusCode StatusCode => HttpStatusCode.UpgradeRequired;
}
