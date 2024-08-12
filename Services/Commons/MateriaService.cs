using BlazorAppVS.Class;
using BlazorAppVS.Interfaces;
using BlazorAppVS.Models.Commons;
using System.Text.Json;

namespace BlazorAppVS.Services.Commons
{
    public class MateriaService : GenericService<Materia>, IMateriaService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public MateriaService(HttpClient client) : base(client)
        {
            this.client = client;
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _endpoint = ApiEndpoints.GetEndpoint(nameof(Materia));
        }

        public async Task<List<Materia>?> GetByAnioCarreraAsync(int? idAnioCarrera)
        {
            var response = await client.GetAsync($"{_endpoint}?idAnioCarrera={idAnioCarrera}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Materia>>(content, options); ;
        }
    }
}
