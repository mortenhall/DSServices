using System;
using System.Threading.Tasks;
using FunService.Configuration;
using FunService.Model;
using RestSharp;

namespace FunService.Services
{
    public class ChuckNorrisService : IChuckNorrisService
    {
        private readonly ISettingsManager _settingsManager;

        public ChuckNorrisService(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public async Task<string> GetRandomJokeAsync()
        {
            var restClient = CreateRestClient();

            var request = new RestRequest("/jokes/random", Method.GET);
            request.Parameters.Add(new Parameter("category", "dev", ParameterType.QueryString));
            var response = await restClient.ExecuteTaskAsync<ChuckNorrisRandomJokeResponse>(request);

            return response.Data.value;
        }

        private RestClient CreateRestClient()
        {
            return new RestClient(_settingsManager.ChuckNorrisServiceUri);
        }
    }
}