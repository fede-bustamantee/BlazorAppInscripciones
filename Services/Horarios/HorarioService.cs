using BlazorAppVS.Class;
using BlazorAppVS.Interfaces;
using BlazorAppVS.Models.Commons;
using BlazorAppVS.Models.Horarios;
using System.Text.Json;

namespace BlazorAppVS.Services.Horarios
{
    public class HorarioService : GenericService<Horario>, IHorarioService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public HorarioService(HttpClient client) : base(client)
        {
            this.client = client;
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _endpoint = ApiEndpoints.GetEndpoint(nameof(Horario));
        }

        public async Task<List<Horario>?> GetByCarreraAsync(int? idCicloLectivo, int? idCarrera)
        {
            var response = await client.GetAsync($"{_endpoint}?idCicloLectivo={idCicloLectivo},idCarrera={idCarrera}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Horario>>(content, options); ;
        }
    }
}
