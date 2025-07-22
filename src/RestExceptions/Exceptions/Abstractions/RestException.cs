using System.Net;

namespace RestExceptions;

[Serializable]
public abstract class RestException(string message, Dictionary<string, object?>? extensions) : Exception(message)
{
    public abstract string Title { get; }
    public abstract HttpStatusCode StatusCode { get; }

    public Dictionary<string, object?> Extensions { get; } = extensions ?? [];

    public string TypeSuffix => $"{(int)StatusCode}-{Title.ToKebabCase()}";
}
