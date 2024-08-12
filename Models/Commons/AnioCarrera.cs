using BlazorAppVS.Interfaces.Commons;
using BlazorAppVS.Models.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppVS.Models.Commons
{
    public class AnioCarrera : IEntityIdNombre
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int? CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
        [NotMapped]
        public string AñoYCarrera {
            get { return $"{Nombre} {Carrera?.Nombre}" ?? string.Empty; } 
        }
        public override string ToString()
        {
            return AñoYCarrera;
        }
    }
}
