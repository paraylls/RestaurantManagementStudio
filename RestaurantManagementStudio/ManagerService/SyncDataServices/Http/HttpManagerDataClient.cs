using ManagerService.Dtos;
using System.Text;
using System.Text.Json;

namespace ManagerService.SyncDataServices.Http
{
    public class HttpManagerDataClient : IManagerDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpManagerDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public HttpClient HttpClient { get; }

        public async Task SendManagerToBartender(ManagerReadDto managerReadDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(managerReadDto),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient
                .PostAsync($"{_configuration["BarService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to BarService was ok!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to BarService was NOT ok!");
            }
        }
    }
}
