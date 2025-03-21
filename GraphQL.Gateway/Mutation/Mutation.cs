using GraphQL.Gateway.Attributes;
using GraphQL.Gateway.Model;
using MeterSystem.Application.Commands.Requests;
using MeterSystem.Application.Commands.Responses;
using MeterSystem.Domain.Entities;

namespace GraphQL.Gateway.Mutation
{
    public class Mutation
    {
        [UseRequiresPermission]
        [RequiresPermission(PermissionConstants.AddProduct)]
        public async Task<AddProductCommandResponse> AddProductAsync(
            [Service] IHttpClientFactory httpClientFactory,
            [GraphQLDescription("ProductCode")] AddProductCommandRequest req
            )
        {
            var consumptionClient = httpClientFactory.CreateClient("ConsumptionService");

            try
            {
                var productTask = await consumptionClient.PostAsJsonAsync($"api/Product/", req);
                // Better logging can be added here
                if (!productTask.IsSuccessStatusCode)
                    throw new Exception($"Error on Consumption Service: {productTask.StatusCode}");

                var product = await productTask.Content.ReadFromJsonAsync<AddProductCommandResponse>();

                return product ?? throw new Exception("Error on add!");
            }
            catch (Exception ex)
            {
                // Better logging can be added here
                throw new GraphQLException(
                    ErrorBuilder.New()
                        .SetMessage("Error: " + ex.Message)
                        .Build());
            }
        }

        public async Task<AddConsumptionCommandResponse> AddConsumptionAsync(
            [Service] IHttpClientFactory httpClientFactory,
            AddConsumptionCommandRequest req
            )
        {
            var consumptionClient = httpClientFactory.CreateClient("ConsumptionService");

            try
            {
                var consumptionTask = await consumptionClient.PostAsJsonAsync($"api/Consumption/", req);
                // Better logging can be added here
                if (!consumptionTask.IsSuccessStatusCode)
                    throw new Exception($"Error on Consumption Service: {consumptionTask.StatusCode}");

                var consumption = await consumptionTask.Content.ReadFromJsonAsync<AddConsumptionCommandResponse>();

                return consumption ?? throw new Exception("Error on add!");
            }
            catch (Exception ex)
            {
                // Better logging can be added here
                throw new GraphQLException(
                    ErrorBuilder.New()
                        .SetMessage("Error: " + ex.Message)
                        .Build());
            }
        }

        [UseRequiresPermission]
        [RequiresPermission(PermissionConstants.AddUser)]
        public async Task<AddUserCommandResponse> AddUserAsync(
            [Service] IHttpClientFactory httpClientFactory,
            AddUserCommandRequest req
            )
        {
            var serverClient = httpClientFactory.CreateClient("ServerServiceAPI");

            try
            {
                var userTask = await serverClient.PostAsJsonAsync($"api/User/", req);
                // Better logging can be added here
                if (!userTask.IsSuccessStatusCode)
                    throw new Exception($"Error on Server Service: {userTask.StatusCode}");

                var user = await userTask.Content.ReadFromJsonAsync<AddUserCommandResponse>();

                return user ?? throw new Exception("Error on add!");
            }
            catch (Exception ex)
            {
                // Better logging can be added here
                throw new GraphQLException(
                    ErrorBuilder.New()
                        .SetMessage("Error: " + ex.Message)
                        .Build());
            }
        }
    }
}
