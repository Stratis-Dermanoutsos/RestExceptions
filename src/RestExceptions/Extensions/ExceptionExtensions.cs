namespace RestExceptions;

public static class ExceptionExtensions
{
    /// <summary>
    /// Maps a generic <see cref="Exception"/> to a specific <see cref="RestException"/>.
    /// </summary>
    /// <param name="exception">The exception to map.</param>
    /// <returns>A <see cref="RestException"/> that corresponds to the type of the provided exception.</returns>
    public static RestException MapToRestException(this Exception exception)
    {
        if (exception is RestException restException)
        {
            return restException;
        }

        var extensions = new Dictionary<string, object?>
        {
            { "originalException", exception.GetType().Name }
        };
        return exception switch
        {
            // 404 - Not Found
            ArgumentNullException
                or ArgumentOutOfRangeException
                or DirectoryNotFoundException
                or FileNotFoundException
                or KeyNotFoundException => new NotFoundRestException(exception.Message, extensions),
            // 400 - Bad Request
            ArgumentException => new BadRequestRestException(exception.Message, extensions),
            // 403 - Forbidden
            AccessViolationException
                or UnauthorizedAccessException => new ForbiddenRestException(exception.Message, extensions),
            // 405 - Method Not Allowed
            InvalidOperationException => new MethodNotAllowedRestException(exception.Message, extensions),
            // 501 - Not Implemented
            NotImplementedException
                or TypeLoadException => new NotImplementedRestException(exception.Message, extensions),
            // 500 - Internal Server Error (Default)
            _ => new InternalServerErrorRestException(exception.Message, extensions)
        };
    }
}
