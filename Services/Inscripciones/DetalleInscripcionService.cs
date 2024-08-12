using BlazorAppVS.Class;
using BlazorAppVS.Interfaces;
using BlazorAppVS.Models.Inscripciones;
using BlazorAppVS.Pages.Materias;
using System.Net.Http;
using System.Net;
using System.Text.Json;

namespace BlazorAppVS.Services
{
    public class DetalleInscripcionService : GenericService<DetalleInscripcion>, IDetalleInscripcionService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;
        private readonly string _endpoint;

        public DetalleInscripcionService(HttpClient client): base(client) 
        {
            this.client = client;
            this.options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            this._endpoint = ApiEndpoints.GetEndpoint(nameof(DetalleInscripcion));
        }
        
        public async Task<List<DetalleInscripcion>?> GetByInscripcionAsync(int? idInscripcion)
        {
            var response = await client.GetAsync($"{_endpoint}?idInscripcion={idInscripcion}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<DetalleInscripcion>>(content, options); ;
        }

        public async Task<bool> CheckDuplicadoDetalleInscripcionAsync(int? idDetalle, int? idInscripcion, int? idMateria)
        {
            var response = await client.GetAsync($"{_endpoint}/checkduplicado?idDetalle={idDetalle}&idInscripcion={idInscripcion}&idMateria={idMateria}");
            return response.StatusCode == HttpStatusCode.Conflict;
            
        }
    }
}
