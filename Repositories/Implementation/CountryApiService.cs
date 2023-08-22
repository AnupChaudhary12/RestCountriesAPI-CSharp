using RestCountriesApi.Models;
using RestCountriesApi.Repositories.Abstraction;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration; // Make sure to import IConfiguration

namespace RestCountriesApi.Repositories.Implementation
{
    public class CountryApiService : ICountryApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public CountryApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<List<Class1>> GetCountries()
        {
            string url = _configuration.GetSection("ApiUrls")["Url"];
            var result = new List<Class1>();

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                // Log the response content for debugging
                Console.WriteLine("Response Content: " + stringResponse);

                try
                {
                    result = JsonSerializer.Deserialize<List<Class1>>(stringResponse);
                }
                catch (JsonException ex)
                {
                    // Handle JSON deserialization error
                    throw new JsonException("Error deserializing response content.", ex);
                }
            }
            else
            {
                // Log the HTTP status code for debugging
                Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
