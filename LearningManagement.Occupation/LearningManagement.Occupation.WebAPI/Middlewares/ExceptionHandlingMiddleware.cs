using Azure.Identity;
using Framework.Exceptions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LearningManagement.Occupation.WebAPI.Middlewares;

public sealed class ExceptionHandlingMiddleware(
    RequestDelegate next,
    IWebHostEnvironment env,
    ILogger<ExceptionHandlingMiddleware> logger) {
    public async Task InvokeAsync(HttpContext context) {
        try {
            await next(context);
            await HandleModelBindingErrors(context);
        }
        catch (DbUpdateException exception) when (exception.InnerException is SqlException sqlException) {
            ErrorResponse errorResponse = new() {
                Status = StatusCodes.Status400BadRequest,
                Type = "DbUpdateFailure",
                Title = "Database update error",
                TechnicalDetails = !env.IsProduction() ? exception.InnerException.Message : default
            };

            switch (sqlException.Number) {
                case 547: // Foreign key constraint violation
                    errorResponse.Detail = "Invalid foreign key reference in provided IDs.";
                    break;

                case 2601: // Unique constraint violation
                    errorResponse.Detail = "A unique constraint violation occurred. Please check for uniqueness.";
                    break;

                case 8152: // String or binary data would be truncated
                    errorResponse.Detail = "One or more fields exceed maximum allowed length.";
                    break;

                case 53: // SQL Server connection issue
                    errorResponse.Detail = "Service is temporarily unavailable. Please try again later.";
                    break;
            }

            logger.LogError(exception, "DbUpdate exception occurred: {Details}", errorResponse.Detail);
            await SetResponse(context, errorResponse);
        }
        // catch (IdentityResultException exception)
        // {
        //     logger.LogError(exception, "Identity result exception occurred: {Message}", exception.Message);
        //
        //     ErrorResponse errorResponse = new()
        //     {
        //         Status = StatusCodes.Status400BadRequest,
        //         Type = "IdentityOperationFailure",
        //         Title = "Identity operation error",
        //         Detail = $"One or more errors has occurred on {exception.OperationName}.",
        //         TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
        //     };
        //
        //     if (exception.IdentityResult.Errors is not null)
        //         errorResponse.Extensions["errors"] = exception.IdentityResult.Errors;
        //
        //     await SetResponse(context, errorResponse);
        // }
        catch (AuthenticationFailedException exception) {
            logger.LogError(exception, "Authentication failed because of {Message}", exception.Message);

            ErrorResponse errorResponse = new() {
                Status = StatusCodes.Status400BadRequest,
                Type = "AuthenticationFailure",
                Title = "Authentication Failed",
                Detail = $"Authentication failed because of {exception.Message}",
                TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
            };

            await SetResponse(context, errorResponse);
        }
        // catch (Exceptions.ValidationException exception)
        // {
        //     logger.LogError(exception, "Validation exception occurred: {Message}", exception.Message);
        //
        //     ErrorResponse errorResponse = new()
        //     {
        //         Status = StatusCodes.Status400BadRequest,
        //         Type = "ValidationFailure",
        //         Title = "Validation error",
        //         Detail = "One or more validation errors has occurred.",
        //         TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
        //     };
        //
        //     if (exception.Errors is not null)
        //         errorResponse.Extensions["errors"] = exception.Errors;
        //
        //     await SetResponse(context, errorResponse);
        // }
        catch (InvariantException exception) {
            logger.LogError(exception, "Invariant exception occurred: {Message}", exception.Message);

            ErrorResponse errorResponse = new() {
                Status = StatusCodes.Status400BadRequest,
                Type = "InvariantFailure",
                Title = "Invariant error",
                Detail = "One or more invariant rules has broken.",
                TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
            };

            if (exception.Errors is not null)
                errorResponse.Extensions["errors"] = exception.Errors;

            await SetResponse(context, errorResponse);
        }
        catch (BadDataException exception) {
            logger.LogError(exception, "BadData exception occurred: {Message}", exception.Message);

            ErrorResponse errorResponse = new() {
                Status = StatusCodes.Status400BadRequest,
                Type = "BadData",
                Title = "BadData error",
                Detail = "One or more properties have invalid value.",
                TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
            };

            if (exception.Errors is not null)
                errorResponse.Extensions["errors"] = exception.Errors;

            await SetResponse(context, errorResponse);
        }
        catch (NotFoundException exception) {
            logger.LogError(exception, "NotFound exception occurred: {Message}", exception.Message);

            ErrorResponse errorResponse = new() {
                Status = StatusCodes.Status404NotFound,
                Type = "NotFound",
                Title = "NotFound error",
                Detail = exception.Error.ErrorMessage,
                TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
            };

            await SetResponse(context, errorResponse);
        }
        catch (Exception exception) {
            logger.LogError(exception, "Unknown exception occurred: {Message}", exception.Message);

            ErrorResponse errorResponse = new() {
                Status = StatusCodes.Status500InternalServerError,
                Type = "InternalServerError",
                Title = "Internal Server Error",
                Detail = exception.Message,
                TechnicalDetails = !env.IsProduction() ? exception.StackTrace : default
            };

            await SetResponse(context, errorResponse);
        }
    }

    private static async Task HandleModelBindingErrors(HttpContext context) {
        if (context.Response.StatusCode == StatusCodes.Status400BadRequest) {
            var modelStateErrors = context.Features.Get<IHttpRequestFeature>()?.Headers;

            if (modelStateErrors != null && modelStateErrors.Count > 0) {
                ErrorResponse errorResponse = new() {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "ModelBindingError",
                    Title = "Invalid request parameters",
                    Detail = "One or more query parameters have invalid values."
                };

                //errorResponse.Extensions["errors"] = modelStateErrors;

                await SetResponse(context, errorResponse);
            }
        }
    }

    private static Task SetResponse(HttpContext context, ErrorResponse errorResponse) {
        context.Response.StatusCode = errorResponse.Status!.Value;
        return context.Response.WriteAsJsonAsync(errorResponse);
    }
}

public sealed class ErrorResponse : ProblemDetails {
    public string? TechnicalDetails { get; set; }
}