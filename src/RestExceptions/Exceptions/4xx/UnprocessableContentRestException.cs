using System.Net;

namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/422"/>
/// </summary>
public class UnprocessableContentRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Unable to process the contained instructions.";

    public override string Title => "Unprocessable Content";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableContent;
}
