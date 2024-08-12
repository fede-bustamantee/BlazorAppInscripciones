using BlazorAppVS.Class;
using BlazorAppVS.Interfaces.Commons;
using BlazorAppVS.Models.Commons;
using System.Text.Json;

namespace BlazorAppVS.Services
{
    public class AnioCarreraService : GenericService<AnioCarrera>, IAnioCarreraService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public AnioCarreraService(HttpClient client): base(client) 
        {
            this.client = client;
            this.options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            this._endpoint = ApiEndpoints.GetEndpoint(nameof(AnioCarrera));
        }
        
        public async Task<List<AnioCarrera>?> GetByCarreraAsync(int? idCarrera)
        {
            var response = await client.GetAsync($"{_endpoint}?idCarrera={idCarrera}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<AnioCarrera>>(content, options); ;
        }
    }
}
