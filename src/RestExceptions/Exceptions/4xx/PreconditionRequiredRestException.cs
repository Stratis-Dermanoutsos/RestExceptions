namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/428"/>
/// </summary>
public class PreconditionRequiredRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server requires the request to be conditional.";

    public override string Title => "Precondition Required";
    public override HttpStatusCode StatusCode => HttpStatusCode.PreconditionRequired;
}
