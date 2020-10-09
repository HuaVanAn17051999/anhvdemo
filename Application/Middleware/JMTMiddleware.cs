using Application.Contract.Exceptions;
using Application.Logging;
using Application.Services.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Middleware
{
    public class JwTMiddleware
    {
        private readonly RequestDelegate _next;

        public JwTMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IUserAppService userAppService)
        {
            if (!context.Request.Path.Equals("/token", StringComparison.Ordinal))
            {
                await ExecuteNonLoginRequestAsync(context);
            }
            else
            {
                await ExecuteLoginRequestAsync(context, userAppService);
            }
        }
        private async Task ExecuteNonLoginRequestAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task ExecuteLoginRequestAsync(HttpContext context, IUserAppService userAppService)
        {
            try
            {
                if (!context.Request.Method.Equals("POST"))
                {
                    throw new NotSupportedException();
                }
                var authModel = await userAppService.LoginAsync(context);
                var response = JsonConvert.SerializeObject(authModel);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Logger.LogDebug(LoggingMessage.CannotProcessWithoutAction, exception);

            var statusCode = HttpStatusCode.InternalServerError;

            if (exception is ArgumentNullException
                || exception is InconsistentException
                || exception is LoginInvalidException
                || exception is SelfDeleteException)
            {
                statusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is NotSupportedException)
            {
                statusCode = HttpStatusCode.UnsupportedMediaType;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}
