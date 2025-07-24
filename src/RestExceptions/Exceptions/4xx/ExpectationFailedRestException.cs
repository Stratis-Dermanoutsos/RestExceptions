namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/417"/>
/// </summary>
public class ExpectationFailedRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "An expectation given in an 'Expect' header could not be met by the server.";

    public override string Title => "Expectation Failed";
    public override HttpStatusCode StatusCode => HttpStatusCode.ExpectationFailed;
}
