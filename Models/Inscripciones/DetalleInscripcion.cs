using BlazorAppVS.Enums;
using BlazorAppVS.Models.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppVS.Models.Inscripciones
{
    public class DetalleInscripcion
    {
        public int Id { get; set; }
        public ModalidadCursadoEnum ModalidadCursado { get; set; }
        public int InscripcionId { get; set; }
        public Inscripcion? Inscripcion { get; set; }
        public int MateriaId { get; set; }
        public Materia? Materia { get; set; }
        public override string ToString()
        {
            //return $"{Materia?.Nombre} {ModalidadCursado}" ?? string.Empty;
            return $"Id ={Id} {Environment.NewLine}" +
                $"ModalidadCursado= {ModalidadCursado} {Environment.NewLine}" +
                $"InscripcionId= {InscripcionId}{Environment.NewLine}" +
                $"MateriaId= {MateriaId}";
        }

    }
}
