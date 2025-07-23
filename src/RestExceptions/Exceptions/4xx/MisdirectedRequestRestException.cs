namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/421"/>
/// </summary>
public class MisdirectedRequestRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The request was directed to a server that is not able to produce a response.";

    public override string Title => "Misdirected Request";
    public override HttpStatusCode StatusCode => HttpStatusCode.MisdirectedRequest;
}
