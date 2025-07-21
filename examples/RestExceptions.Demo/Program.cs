using Microsoft.AspNetCore.Mvc;
using RestExceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRestExceptions();

var app = builder.Build();

app.MapGet("error/{statusCode:int}", ([FromRoute] int statusCode) =>
{
    throw statusCode switch
    {
        400 => new BadRequestRestException(),
        401 => new UnauthorizedRestException(),
        403 => new ForbiddenRestException(),
        404 => new NotFoundRestException(),
        409 => new ConflictRestException(),
        422 => new UnprocessableContentRestException(),
        500 => new InternalServerErrorRestException(),
        501 => new NotImplementedRestException(),
        502 => new BadGatewayRestException(),
        503 => new ServiceUnavailableRestException(),
        504 => new GatewayTimeoutRestException(),
        _ => new Exception()
    };
});

//! Important
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.Run();
