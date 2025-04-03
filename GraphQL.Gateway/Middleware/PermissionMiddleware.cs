using GraphQL.Gateway.Attributes;
using HotChocolate.Resolvers;
using MeterSystem.Application.Queries.Responses;
using System.Reflection;

namespace GraphQL.Gateway.Middleware
{
    public class PermissionMiddleware
    {
        private readonly FieldDelegate _next;
        private readonly IHttpClientFactory _httpClientFactory;

        public PermissionMiddleware(
            FieldDelegate next,
            IHttpClientFactory httpClientFactory)
        {
            _next = next;
            _httpClientFactory = httpClientFactory;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            var permissionAttribute = context.Selection.Field.ResolverMember?.GetCustomAttribute<RequiresPermissionAttribute>();
            if (permissionAttribute != null)
            {
                if (!context.ContextData.TryGetValue("Token", out var tokenObj) || tokenObj is not string token)
                {
                    context.Result = ErrorBuilder.New()
                        .SetMessage("Authorization is required!!")
                        .SetCode("AUTH_ERROR")
                        .Build();
                    return;
                }

                try
                {
                    var userClient = _httpClientFactory.CreateClient("ServerServiceAPI");
                    userClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                    var response = await userClient.GetAsync("api/User/1");

                    if (!response.IsSuccessStatusCode)
                    {
                        context.Result = ErrorBuilder.New()
                            .SetMessage("Failed to get user data!!")
                            .SetCode("AUTH_ERROR")
                            .Build();
                        return;
                    }

                    var user = await response.Content.ReadFromJsonAsync<GetUserByIdQueryResponse>();

                    if (user == null || !user.Permissions.Contains(permissionAttribute.Permission))
                    {
                        context.Result = ErrorBuilder.New()
                            .SetMessage($"No permission to perform this operation")
                            .SetCode("FORBIDDEN")
                            .Build();
                        return;
                    }

                    context.ContextData["UserInfo"] = user;
                }
                catch (Exception ex)
                {
                    context.Result = ErrorBuilder.New()
                        .SetMessage("Error validating permissions: ", ex)
                        .SetCode("SERVER_ERROR")
                        .Build();
                    return;
                }
            }

            await _next(context);
        }
    }
}