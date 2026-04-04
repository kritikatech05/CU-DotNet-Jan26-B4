using System.Net.Http.Json;
using Vegabond.MVC.Models;

namespace Vegabond.MVC.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly HttpClient _httpClient;

        public DestinationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Destination>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("api/destinations");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch data from API");

            return await response.Content.ReadFromJsonAsync<IEnumerable<Destination>>();
        }
        public async Task AddAsync(Destination destination)
        {
            var response = await _httpClient.PostAsJsonAsync("api/destinations", destination);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to add destination");
        }
        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/destinations/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Delete failed");
        }

        public async Task<Destination> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/destinations/{id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch destination");

            return await response.Content.ReadFromJsonAsync<Destination>();
        }

        public async Task UpdateAsync(Destination destination)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/destinations/{destination.Id}", destination);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Update failed");
        }
    }
}
