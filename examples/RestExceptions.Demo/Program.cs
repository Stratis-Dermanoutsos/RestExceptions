using Microsoft.AspNetCore.Mvc;
using RestExceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRestExceptions();

var app = builder.Build();

app.MapGet("error/{statusCode:int}", ([FromRoute] int statusCode) =>
{
    return statusCode switch
    {
        400 => throw new BadRequestRestException(),
        401 => throw new UnauthorizedRestException(),
        403 => throw new ForbiddenRestException(),
        404 => throw new NotFoundRestException(),
        409 => throw new ConflictRestException(),
        500 => throw new InternalServerErrorRestException(),
        501 => throw new NotImplementedRestException(),
        _ => throw new Exception()
    };

    return Results.Ok(statusCode);
});

//! Important
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.Run();
