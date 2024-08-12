using BlazorAppVS.Models.Commons;
using System.Text.Json;

namespace BlazorAppVS.Services.Commons
{
    public class AlumnoService : IAlumnoService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;

        public AlumnoService(HttpClient client)
        {
            this.client = client;
            options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<Alumno>?> Get()
        {
            var response = await client.GetAsync("apialumnos");
            return await JsonSerializer.DeserializeAsync<List<Alumno>>(await response.Content.ReadAsStreamAsync(), options);
        }
    }

    public interface IAlumnoService
    {
        public Task<List<Alumno>?> Get();
    }
}
