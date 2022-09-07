using System.Text.Json;
using CoNettion.Core.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException e)
        {
            context.Response.StatusCode = 404;

            await context.Response.WriteAsync(e.Message);
        }
        catch (BadRequestException e)
        {
            context.Response.StatusCode = 400;

            await context.Response.WriteAsync(e.Message);
        }
        catch (ForbiddenException e)
        {
            context.Response.StatusCode = 403;

            await context.Response.WriteAsync(e.Message);
        }
        catch (ValidationException e)
        {
            var problemDetails = GetValidationProblemDetails(e);

            context.Response.StatusCode = 422;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }

    private ValidationProblemDetails GetValidationProblemDetails(ValidationException ex)
    {
        string traceId = Guid.NewGuid().ToString();

        var errors = new Dictionary<string, string[]>();
        foreach (var error in ex.Errors)
        {
            errors.Add(error.PropertyName, new string[] { error.ErrorMessage });
        }

        var validationProblemDetails = new ValidationProblemDetails(errors);

        validationProblemDetails.Status = 422;
        validationProblemDetails.Type = "https://httpstatuses.com/422";
        validationProblemDetails.Title = "Validation failed";
        validationProblemDetails.Detail = "One or more inputs need to be corrected. Check errors for details";
        validationProblemDetails.Instance = traceId;

        return validationProblemDetails;
    }
}