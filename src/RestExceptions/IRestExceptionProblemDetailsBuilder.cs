using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestExceptions;

public interface IRestExceptionProblemDetailsBuilder
{
    ProblemDetails Build(HttpContext httpContext, RestException restException);
}
