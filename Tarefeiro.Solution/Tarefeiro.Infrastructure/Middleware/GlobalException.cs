using System;
using System.Data.SqlTypes;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tarefeiro.Infrastructure.Middleware;

public class GlobalException(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var (title, msg, status) = ex switch
            {
                TaskCanceledException or OperationCanceledException =>
                ("Task canceled error", "Operation was canceled", StatusCodes.Status499ClientClosedRequest),
                TimeoutException =>
                ("Time out error", "Request timed out", StatusCodes.Status408RequestTimeout),
                SqlTypeException =>
                 ("DB Error", "A database error ocurred", StatusCodes.Status400BadRequest),
                _ =>
                 ("Error", "Internal server error", StatusCodes.Status500InternalServerError)
            };

            await WriteJSON(context, title, msg, status);
        }
    }

    private async Task WriteJSON(HttpContext context, string title, string details, int status)
    {
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails()
        {
            Title = title,
            Detail = details,
            Status = status
        }));
    }
}
