using Newtonsoft.Json.Linq;
using Ocelot.Configuration;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Net;
using System.Text;

namespace MeterSystem.APIGateway.Aggregators
{
    public class ConsumptionTestAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            // Doğru servisi key ile bulma
            var consumptionContext = responses.FirstOrDefault(r =>
            {
                var route = r.Items.DownstreamRoute();
                return route != null && route.Key == "Consumption";
            });

            var testContext = responses.FirstOrDefault(r =>
            {
                var route = r.Items.DownstreamRoute();
                return route != null && route.Key == "Test";
            });

            if (consumptionContext == null || testContext == null)
            {
                return new DownstreamResponse(new StringContent("Bir veya daha fazla servis yanıt vermedi"),
                    HttpStatusCode.InternalServerError,
                    new List<KeyValuePair<string, IEnumerable<string>>>(),
                    "Error");
            }

            // Response'ları alma
            var consumptionResponse = consumptionContext.Items.DownstreamResponse();
            var testResponse = testContext.Items.DownstreamResponse();

            // Hata kontrolü
            if (consumptionResponse.StatusCode != HttpStatusCode.OK)
            {
                return consumptionResponse;
            }

            if (testResponse.StatusCode != HttpStatusCode.OK)
            {
                return testResponse;
            }

            // Yanıt içeriklerini okuma
            var consumptionContent = await consumptionResponse.Content.ReadAsStringAsync();
            var testContent = await testResponse.Content.ReadAsStringAsync();

            try
            {
                var consumptionJson = JToken.Parse(consumptionContent);
                var testJson = JToken.Parse(testContent);

                // Birleşik JSON oluşturma
                var aggregatedResult = new JObject
                {
                    ["consumption"] = consumptionJson,
                    ["test"] = testJson
                };

                var stringContent = new StringContent(
                    aggregatedResult.ToString(),
                    Encoding.UTF8,
                    "application/json"
                );

                return new DownstreamResponse(
                    stringContent,
                    HttpStatusCode.OK,
                    consumptionResponse.Headers,
                    "OK"
                );
            }
            catch (Exception ex)
            {
                return new DownstreamResponse(
                    new StringContent($"JSON işleme hatası: {ex.Message}"),
                    HttpStatusCode.InternalServerError,
                    new List<KeyValuePair<string, IEnumerable<string>>>(),
                    "Error"
                );
            }
        }
    }
}
