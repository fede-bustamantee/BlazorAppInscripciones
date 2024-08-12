using BlazorAppVS.Models.Commons;

namespace BlazorAppVS.Interfaces
{
    public interface IMateriaService : IGenericService<Materia>
    {
        public Task<List<Materia>?> GetByAnioCarreraAsync(int? id);
    }
}
