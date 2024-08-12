using BlazorAppVS.Class;
using BlazorAppVS.Interfaces.MesasExamenes;
using BlazorAppVS.Models.MesasExamenes;
using System.Text.Json;

namespace BlazorAppVS.Services
{
    public class MesaExamenService : GenericService<MesaExamen>, IMesaExamenService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public MesaExamenService(HttpClient client): base(client) 
        {
            this.client = client;
            this.options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            this._endpoint = ApiEndpoints.GetEndpoint(nameof(MesaExamen));
        }
        
        public async Task<List<MesaExamen>?> GetByTurnoAndCarreraAsync(int? idTurno, int? idCarrera)
        {
            var response = await client.GetAsync($"{_endpoint}?idTurno={idTurno}&idCarrera={idCarrera}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<MesaExamen>>(content, options); ;
        }
    }
}
