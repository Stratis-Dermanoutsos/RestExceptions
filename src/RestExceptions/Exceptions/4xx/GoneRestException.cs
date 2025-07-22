namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/410"/>
/// </summary>
public class GoneRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The target resource is no longer available at the server and that this condition is likely to be permanent.";

    public override string Title => "Gone";
    public override HttpStatusCode StatusCode => HttpStatusCode.Gone;
}
