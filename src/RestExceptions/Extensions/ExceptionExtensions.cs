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
        return exception switch
        {
            RestException restException => restException,
            // 404 - Not Found
            ArgumentNullException
                or ArgumentOutOfRangeException
                or DirectoryNotFoundException
                or FileNotFoundException
                or KeyNotFoundException => new NotFoundRestException(exception.Message),
            // 400 - Bad Request
            ArgumentException => new BadRequestRestException(exception.Message),
            // 403 - Forbidden
            AccessViolationException
                or UnauthorizedAccessException => new ForbiddenRestException(exception.Message),
            // 405 - Method Not Allowed
            InvalidOperationException => new MethodNotAllowedRestException(exception.Message),
            // 501 - Not Implemented
            NotImplementedException
                or TypeLoadException => new NotImplementedRestException(exception.Message),
            // 500 - Internal Server Error (Default)
            _ => new InternalServerErrorRestException(exception.Message),
        };
    }
}
