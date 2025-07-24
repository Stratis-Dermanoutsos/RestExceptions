namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/407"/>
/// </summary>
public class ProxyAuthenticationRequiredRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The request lacks valid authentication credentials for the proxy server.";

    public override string Title => "Proxy Authentication Required";
    public override HttpStatusCode StatusCode => HttpStatusCode.ProxyAuthenticationRequired;
}
