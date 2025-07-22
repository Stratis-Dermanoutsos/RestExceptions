using System.Net;

namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/511"/>
/// </summary>
public class NetworkAuthenticationRequiredRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The client needs to authenticate to gain network access.";

    public override string Title => "Network Authentication Required";
    public override HttpStatusCode StatusCode => HttpStatusCode.NetworkAuthenticationRequired;
}
