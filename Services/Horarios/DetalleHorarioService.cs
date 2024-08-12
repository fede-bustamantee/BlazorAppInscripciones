using BlazorAppVS.Class;
using BlazorAppVS.Interfaces;
using BlazorAppVS.Models.Commons;
using BlazorAppVS.Models.Horarios;
using System.Text.Json;

namespace BlazorAppVS.Services
{
    public class DetalleHorarioService : GenericService<DetalleHorario>, IDetalleHorarioService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public DetalleHorarioService(HttpClient client): base(client) 
        {
            this.client = client;
            this.options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            this._endpoint = ApiEndpoints.GetEndpoint(nameof(DetalleHorario));
        }
        
        public async Task<List<DetalleHorario>?> GetByCarreraAsync(int? idCicloLectivo, int? idCarrera)
        {
            var response = await client.GetAsync($"{_endpoint}?idCicloLectivo={idCicloLectivo}&idCarrera={idCarrera}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<DetalleHorario>>(content, options); ;
        }
        public async Task<List<DetalleHorario>?> GetByAnioCarreraAsync(int? idCicloLectivo, int? idAnioCarrera)
        {
            var response = await client.GetAsync($"{_endpoint}?idCicloLectivo={idCicloLectivo}&idAnioCarrera={idAnioCarrera}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<DetalleHorario>>(content, options); ;
        }
    }
}
