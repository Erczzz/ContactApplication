﻿namespace ContactAPI.CustomMiddleware
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKey = "ApiKey";

        // request object
        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // context contains request response pipeline objects
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(ApiKey, out var extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key not given in the request");
                return;
            }
            // validate the API Key
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var key = appSettings.GetValue<string>(ApiKey);
            if (!key.Equals(extractedKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key is not a valid/unauthorized");
                return;
            }

            await _next(context);
        }
    }
}
