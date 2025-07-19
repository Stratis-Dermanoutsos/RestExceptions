using System.Net;

namespace RestExceptions;

[Serializable]
public abstract class RestException(string message) : Exception(message)
{
    public abstract string Title { get; }
    public abstract HttpStatusCode StatusCode { get; }
}
