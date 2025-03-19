using GraphQL.Gateway.Model;
using MeterSystem.Application.Queries.Responses;
using MeterSystem.Domain.Entities;
using MeterSystem.SecondApi.Controllers;

namespace GraphQL.Gateway.Query
{
    public class Query
    {
        [GraphQLName("aggregatedData")]
        public async Task<AggregatedData> GetAggregatedDataAsync(
            [Service] IHttpClientFactory httpClientFactory,
            [GraphQLDescription("consumptionId")] int consumptionId,
            [GraphQLDescription("testId")] int testId)
        {
            var consumptionClient = httpClientFactory.CreateClient("ConsumptionService");
            var testClient = httpClientFactory.CreateClient("TestService");

            try
            {
                var consumptionTask = consumptionClient.GetAsync($"api/Consumption/{consumptionId}");
                var testTask = testClient.GetAsync($"api/Test/{testId}");

                await Task.WhenAll(consumptionTask, testTask);

                // Better logging can be added here
                if (!consumptionTask.Result.IsSuccessStatusCode)
                    throw new Exception($"Error on Consumption Service: {consumptionTask.Result.StatusCode}");
                if (!testTask.Result.IsSuccessStatusCode)
                    throw new Exception($"Error on Test Service: {testTask.Result.StatusCode}");

                var consumption = await consumptionTask.Result.Content.ReadFromJsonAsync<Consumption>();
                var test = await testTask.Result.Content.ReadFromJsonAsync<TestModel>();

                if (consumption == null)
                    throw new Exception("No Consumption Data!");
                if (test == null)
                    throw new Exception("No Test Data!");

                return new AggregatedData
                {
                    Consumption = consumption,
                    Test = test
                };
            }
            catch (Exception ex)
            {
                // Better logging can be added here
                throw new GraphQLException(
                    ErrorBuilder.New()
                        .SetMessage("Error when fetching data: " + ex.Message)
                        .Build());
            }
        }

        [GraphQLName("product")]
        public async Task<GetProductByIdQueryResponse> GetProductAsync(
            [Service] IHttpClientFactory httpClientFactory,
            [GraphQLDescription("consumptionId")] int productId)
        {
            var consumptionClient = httpClientFactory.CreateClient("ConsumptionService");

            try
            {
                var consumptionTask = await consumptionClient.GetAsync($"api/Product/{productId}");

                // Better logging can be added here
                if (!consumptionTask.IsSuccessStatusCode)
                    throw new Exception($"Error on Consumption Service: {consumptionTask.StatusCode}");

                var product = await consumptionTask.Content.ReadFromJsonAsync<GetProductByIdQueryResponse>();

                return product ?? throw new Exception("No Product Data!");
            }
            catch (Exception ex)
            {
                // Better logging can be added here
                throw new GraphQLException(
                    ErrorBuilder.New()
                        .SetMessage("Error when fetching data: " + ex.Message)
                        .Build());
            }
        }
    }
}
