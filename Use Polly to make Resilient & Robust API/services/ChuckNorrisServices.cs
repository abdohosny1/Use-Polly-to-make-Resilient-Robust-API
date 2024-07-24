using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace Use_Polly_to_make_Resilient___Robust_API.services
{
    public class NorrisServices
    {
        //public async Task<RestResponse> NorrisServicesAsync(CancellationToken cancellationToken = default)
        //{
        //    var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";

        //    var client = new RestClient();
        //    var request = new RestRequest(url, Method.Get);
        //    request.AddHeader("x-rapidapi-key", "ac83b0fefcmsh4b87e02f273ac48p1052d9jsn57ec4c976b31");
        //    request.AddHeader("x-rapidapi-host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
        //    request.AddHeader("accept", "application/json");

        //    var response = await client.ExecuteAsync(request);

        //        return response;
        
        //}

        public async Task<string> NorrisServicesAsync(CancellationToken cancellationToken = default)
        {
            var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";

            var client = new RestClient();
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("x-rapidapi-key", "ac83b0fefcmsh4b87e02f273ac48p1052d9jsn57ec4c976b31");
            request.AddHeader("x-rapidapi-host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");
            request.AddHeader("accept", "application/json");

            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return response.Content;

            }
            else
            {
                throw new Exception($"{response.Content}");
            }

        }
    }
}
