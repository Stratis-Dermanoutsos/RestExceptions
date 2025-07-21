using System.Net;

namespace RestExceptions;

/// <summary>
/// https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/422
/// </summary>
public class UnprocessableContentRestException(string? message = null) : RestException(message ?? DefaultMessage), IRestException
{
    public static string DefaultMessage => "Unable to process the contained instructions.";

    public override string Title => "Unprocessable Content";
    public override HttpStatusCode StatusCode => HttpStatusCode.UnprocessableContent;
}
