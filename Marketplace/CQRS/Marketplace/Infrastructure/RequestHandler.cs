﻿using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Infrastructure
{
    public static class RequestHandler
    {
        public static async Task<IActionResult> HandleRequest<T>(
            T request, Func<T, Task> handler, ILogger log)
        {
            try
            {
                log.Debug("Handling HTTP request of type {type}",
                typeof(T).Name);
                await handler(request);
                return new OkResult();
            }
            catch (Exception e)
            {
                log.Error(e, "Error handling the request");
                return new BadRequestObjectResult(new
                {
                    error =
                e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }

        public static async Task<IActionResult> HandleQuery<TModel>(
            Func<Task<TModel>> query, ILogger log)
        {
            try
            {
                return new OkObjectResult(await query());
            }
            catch (Exception e)
            {
                log.Error(e, "Error handling the query");
                return new BadRequestObjectResult(new
                {
                    error = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
    }
}
