using System.ComponentModel.DataAnnotations;
using BlazorAppVS.Models.Commons;
using BlazorAppVS.Models.MesasExamenes;

namespace BlazorAppVS.Models.MesasExamenes
{
    public class MesaExamen
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El primer llamado debe cargarse obligatoriamente")]
        public DateTime Llamado1 { get; set; }

        [Required(ErrorMessage = "El segundo llamado debe cargarse obligatoriamente")]
        public DateTime Llamado2 { get; set; }

        [Required(ErrorMessage = "La materia debe cargarse obligatoriamente")]
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }

        [Required(ErrorMessage = "El horario debe cargarse obligatoriamente")]
        public string Horario { get; set; }= string.Empty;

        public int TurnoExamenId { get; set; }
        public TurnoExamen? TurnoExamen { get; set; }

        public ICollection<DetalleMesaExamen> DetallesMesaExamen { get; set; }

        public override string ToString()
        {
            return $"{Materia?.Nombre} {Llamado1.Date} / {Llamado2.Date}" ?? string.Empty;
        }
    }
}
