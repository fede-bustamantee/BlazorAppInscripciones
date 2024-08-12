using BlazorAppVS.Interfaces.Commons;

namespace BlazorAppVS.Models.Horarios
{
    public class Hora : IEntityIdNombre
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool EsRecreo { get; set; } = false;

        public override string ToString()
        {
            return Nombre;
        }
    }
}
