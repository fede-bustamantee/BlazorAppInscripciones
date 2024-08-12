using BlazorAppVS.Models.Commons;
using BlazorAppVS.Models.Horarios;

namespace BlazorAppVS.Interfaces
{
    public interface IDetalleHorarioService : IGenericService<DetalleHorario>
    {
        public Task<List<DetalleHorario>?> GetByCarreraAsync(int? idCicloLectivo, int? idCarrera);
        public Task<List<DetalleHorario>?> GetByAnioCarreraAsync(int? idCicloLectivo, int? idAnioCarrera);

    }
}
