namespace RestExceptions;

/// <summary>
/// <see href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Reference/Status/402"/>
/// </summary>
public class PaymentRequiredRestException(
    string? message = null,
    Dictionary<string, object?>? extensions = null)
    : RestException(message ?? DefaultMessage, extensions), IRestException
{
    public static string DefaultMessage => "Requested content is not available until the client makes a payment.";

    public override string Title => "Payment Required";
    public override HttpStatusCode StatusCode => HttpStatusCode.PaymentRequired;
}
