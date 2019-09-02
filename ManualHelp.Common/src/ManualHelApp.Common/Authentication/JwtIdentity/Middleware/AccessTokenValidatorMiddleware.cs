using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManualHelp.Common.Authentication.JwtIdentity.Middleware
{
    public class AccessTokenValidatorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Query["access_token"];
            if (!string.IsNullOrEmpty(token))
            {
                await next(context);
                return;
            }

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
