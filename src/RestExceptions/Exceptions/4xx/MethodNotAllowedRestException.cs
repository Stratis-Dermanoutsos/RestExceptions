namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/405"/>
/// </summary>
public class MethodNotAllowedRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Server owners disallow the use of certain methods due to security concerns.";

    public override string Title => "Method Not Allowed";
    public override HttpStatusCode StatusCode => HttpStatusCode.MethodNotAllowed;
}
