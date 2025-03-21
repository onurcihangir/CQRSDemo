using GraphQL.Gateway.Middleware;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Gateway.Extensions
{
    public static class GraphQLMiddlewareExtensions
    {
        public static IRequestExecutorBuilder UseAuthorization(this IRequestExecutorBuilder builder)
        {
            return builder.UseField<AuthorizationMiddleware>();
        }
        public static IRequestExecutorBuilder CheckPermissions(this IRequestExecutorBuilder builder)
        {
            return builder.UseField<PermissionMiddleware>();
        }
    }
}