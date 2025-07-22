namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/508"/>
/// </summary>
public class LoopDetectedRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "The entire operation failed because it encountered an infinite loop while processing a request with `Depth: infinity.`";

    public override string Title => "Loop Detected";
    public override HttpStatusCode StatusCode => HttpStatusCode.LoopDetected;
}
