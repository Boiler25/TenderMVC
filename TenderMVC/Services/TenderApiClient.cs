using System.Net.Http.Headers;
using TenderMVC.Models;

namespace TenderMVC.Services
{
    public class TenderApiClient : ITenderApiClient
    {
        private readonly HttpClient _httpClient;

        public TenderApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("username:password")));
        }

        public async Task<IEnumerable<TenderViewModel>> GetTendersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("tenders");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<TenderViewModel>>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }
    }
}
