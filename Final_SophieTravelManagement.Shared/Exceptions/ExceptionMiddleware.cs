﻿using Final_SophieTravelManagement.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Shared.Exceptions
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (TravelerCheckListException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.Headers.Add("content-type", "application/json");

                var errorCode =
                    ToUnderscoreCase(ex.GetType().Name
                    .Replace("Exception", string.Empty));

                var json = JsonSerializer.Serialize(new { ErrorCode = errorCode, ex.Message });
                await context.Response.WriteAsync(json);
            }
        }

        private object ToUnderscoreCase(string value)
            => string.Concat((value ?? string.Empty)
                .Select((x, i) => i > 0 && char.IsUpper(x)));
    }
}
