using GraphQL.Gateway.Model;
using MeterSystem.Application.Commands.Requests;
using MeterSystem.Application.Commands.Responses;
using MeterSystem.Domain.Entities;

namespace GraphQL.Gateway.Mutation
{
    public class Mutation
    {
        //[RequiresPermission(PermissionConstants.AddProduct)]
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
    }
}
