using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApplication3.Services
{

    public class DogClient : IDogClient
    {
        private readonly HttpClient _client;

        public DogClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<DogBreedImagesResponse> GetBreedImages(string breed = "hound")
        {
            var result = await _client.GetAsync($"/api/breed/{breed}/images");

            if (result.IsSuccessStatusCode)
            {
                var stringContent = await result.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var obj = JsonSerializer.Deserialize<DogBreedImagesResponse>(stringContent, options);

                return obj;
            }   
            else
            {
                throw new HttpRequestException("Bad dog :(");
            }
        }
    }
}
