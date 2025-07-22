using System.Net;

namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/506"/>
/// </summary>
public class VariantAlsoNegotiatesRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "There is recursive loop in the process of selecting a resource.";

    public override string Title => "Variant Also Negotiates";
    public override HttpStatusCode StatusCode => HttpStatusCode.VariantAlsoNegotiates;
}
