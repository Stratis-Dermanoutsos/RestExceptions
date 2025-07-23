namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/411"/>
/// </summary>
public class LengthRequiredRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server refused to accept the request without a defined 'Content-Length' header.";

    public override string Title => "Length Required";
    public override HttpStatusCode StatusCode => HttpStatusCode.LengthRequired;
}
