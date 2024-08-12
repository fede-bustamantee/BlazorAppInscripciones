using BlazorAppVS.Interfaces.Commons;
using System.ComponentModel.DataAnnotations;

namespace BlazorAppVS.Models.Commons
{
    public class Docente: IEntityIdNombre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre debe cargarse obligatoriamente")]
        public string Nombre { get; set; }=string.Empty;

        public override string ToString()
        {
            return $"Id ={Id} {Environment.NewLine}" +
                   $"Nombre= {Nombre} {Environment.NewLine}";
        }
    }
}
