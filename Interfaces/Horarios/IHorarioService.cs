using BlazorAppVS.Models.Commons;
using BlazorAppVS.Models.Horarios;

namespace BlazorAppVS.Interfaces
{
    public interface IHorarioService : IGenericService<Horario>
    {
        public Task<List<Horario>?> GetByCarreraAsync(int? idCicloLectivo, int? idCarrera);
    }
}
