using Microsoft.AspNetCore.Mvc;
using RestExceptions;

var builder = WebApplication.CreateBuilder(args);

// Uncomment the following line to use a custom implementation of IRestExceptionProblemDetailsBuilder.
// builder.Services.AddSingleton<IRestExceptionProblemDetailsBuilder, CustomExampleRestExceptionProblemDetailsBuilder>();

builder.Services.AddRestExceptions();

var app = builder.Build();

app.MapGet("error/{statusCode:int}", ([FromRoute] int statusCode) =>
{
    throw statusCode switch
    {
        // 4xx
        400 => new BadRequestRestException(),
        401 => new UnauthorizedRestException(),
        403 => new ForbiddenRestException(),
        404 => new NotFoundRestException(),
        409 => new ConflictRestException(),
        422 => new UnprocessableContentRestException(),
        // 5xx
        500 => new InternalServerErrorRestException(),
        501 => new NotImplementedRestException(),
        502 => new BadGatewayRestException(),
        503 => new ServiceUnavailableRestException(),
        504 => new GatewayTimeoutRestException(),
        505 => new HttpVersionNotSupportedRestException(),
        506 => new VariantAlsoNegotiatesRestException(),
        507 => new InsufficientStorageRestException(),
        508 => new LoopDetectedRestException(),
        510 => new NotExtendedRestException(),
        511 => new NetworkAuthenticationRequiredRestException(),
        _ => new Exception()
    };
});

//! Important
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.Run();
