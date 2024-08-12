using BlazorAppVS.Models.Commons;

namespace BlazorAppVS.Interfaces.Commons
{
    public interface IAnioCarreraService : IGenericService<AnioCarrera>
    {
        public Task<List<AnioCarrera>?> GetByCarreraAsync(int? id);
    }
}
