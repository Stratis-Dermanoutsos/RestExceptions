namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/406"/>
/// </summary>
public class NotAcceptableRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server could not produce a response matching the list of acceptable values defined in the request's proactive content negotiation headers.";

    public override string Title => "Not Acceptable";
    public override HttpStatusCode StatusCode => HttpStatusCode.NotAcceptable;
}
