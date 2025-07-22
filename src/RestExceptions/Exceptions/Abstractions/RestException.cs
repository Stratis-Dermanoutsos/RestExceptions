using System.Net;
using System.Text.RegularExpressions;

namespace RestExceptions;

[Serializable]
public abstract partial class RestException(string message, Dictionary<string, object?>? extensions) : Exception(message)
{
    public abstract string Title { get; }
    public abstract HttpStatusCode StatusCode { get; }

    public Dictionary<string, object?> Extensions { get; } = extensions ?? [];

    // Add this property
    public string TypeSuffix
    {
        get
        {
            // Lowercase, replace non-alphanumerics with -, and collapse dashes.
            var kebab = NotWordRegex().Replace(Title.ToLowerInvariant(), "-").Trim('-');
            return $"{(int)StatusCode}-{kebab}";
        }
    }

    [GeneratedRegex(@"[^\w]+")]
    private static partial Regex NotWordRegex();
}
