using BlazorAppVS.Models.MesasExamenes;

namespace BlazorAppVS.Interfaces.MesasExamenes
{
    public interface IMesaExamenService : IGenericService<MesaExamen>
    {
        public Task<List<MesaExamen>?> GetByTurnoAndCarreraAsync(int? idTurno, int? idCarrera);
    }
}
