using BlazorAppVS.Models.Inscripciones;

namespace BlazorAppVS.Interfaces
{
    public interface IDetalleInscripcionService : IGenericService<DetalleInscripcion>
    {
        public Task<List<DetalleInscripcion>?> GetByInscripcionAsync(int? id);
        public Task<bool> CheckDuplicadoDetalleInscripcionAsync(int?idDetalle, int? idInscripcion, int? idMateria);
    }
}
