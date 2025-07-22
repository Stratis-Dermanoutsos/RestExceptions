namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/500"/>
/// </summary>
public class InternalServerErrorRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The server was unable to complete your request.";

    public override string Title => "Internal Server Error";
    public override HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;
}
