using BlazorAppVS.Interfaces;
using BlazorAppVS.Models.Commons;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace BlazorAppVS.Services
{
    public class CarreraService : ICarreraService
    {
        private readonly HttpClient client;
        private readonly JsonSerializerOptions options;

        public CarreraService(HttpClient client)
        {
            this.client = client;
            this.options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Carrera>?> Get()
        {
            var response = await client.GetAsync("apicarreras");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Carrera>>(content, options); ;
        }

        public async Task<Carrera?> Get(int idCarrera)
        {
            var response = await client.GetAsync($"apicarreras/{idCarrera}");
            var content= await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return  JsonSerializer.Deserialize<Carrera>(content,options);
        }

        public async Task<Carrera?> Add(Carrera carrera)
        {
            var response=await client.PostAsJsonAsync("apicarreras", carrera);
            var content=await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString()); 
            }
            return JsonSerializer.Deserialize<Carrera>(content, options);
        }  
        
        public async Task Put(Carrera? carrera)
        {
            var response=await client.PutAsJsonAsync($"apicarreras/{carrera?.Id}",carrera);
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response?.ToString());
            }
        }

        public async Task Delete(int idCarrera)
        {
            var response=await client.DeleteAsync($"apicarreras/{idCarrera}");
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.ToString());
            }
        }
    }

    public interface ICarreraService
    {
        public Task<List<Carrera>?> Get();
        public Task<Carrera?> Get(int idCarrera);
        public Task<Carrera?> Add(Carrera? carrera);
        public Task Put(Carrera? carrera);
        public Task Delete(int idCarrera);
    }
}
