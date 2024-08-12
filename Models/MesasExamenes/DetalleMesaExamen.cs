using BlazorAppVS.Enums;
using BlazorAppVS.Models.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppVS.Models.MesasExamenes
{
    public class DetalleMesaExamen
    {
        public int Id { get; set; }
        public int MesaExamenId { get; set; }
        public MesaExamen? MesaExamen { get; set; }
        public int DocenteId { get; set; }
        public Docente? Docente { get; set; }
        public TipoIntegranteEnum TipoIntegrante { get; set; }
        public override string ToString()
        {
            return $"{Docente?.Nombre} {TipoIntegrante}" ?? string.Empty;
        }

    }
}
