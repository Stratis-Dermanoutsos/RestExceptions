namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/416"/>
/// </summary>
public class RangeNotSatisfiableRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The range of data requested from the resource cannot be returned.";

    public override string Title => "Range Not Satisfiable";
    public override HttpStatusCode StatusCode => HttpStatusCode.RequestedRangeNotSatisfiable;
}
