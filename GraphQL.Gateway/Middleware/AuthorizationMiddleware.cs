using HotChocolate.Resolvers;

namespace GraphQL.Gateway.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly FieldDelegate _next;

        public AuthorizationMiddleware(FieldDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            if (context.ContextData.TryGetValue("RequiresAuthorization", out var requiresAuth) &&
                requiresAuth is bool requiresAuthBool &&
                requiresAuthBool)
            {
                HttpContext? httpContext = context.ContextData["HttpContext"] as HttpContext;
                if (httpContext == null)
                {
                    context.Result = ErrorBuilder.New()
                        .SetMessage("HTTP context is not available")
                        .SetCode("AUTH_ERROR")
                        .Build();
                    return;
                }

                if (!httpContext.Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
                {
                    context.Result = ErrorBuilder.New()
                        .SetMessage("Authorization token is missing")
                        .SetCode("AUTH_ERROR")
                        .Build();
                    return;
                }

                var token = authorizationHeader.ToString().Replace("Bearer ", "");

                context.ContextData["Token"] = token;
            }
            context.ContextData["Token"] = "test";
            await _next(context);
        }
    }
}