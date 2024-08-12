using System.ComponentModel.DataAnnotations;

namespace BlazorAppVS.Models.Commons
{
    public class Alumno
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El apellido y nombre deben cargarse obligatoriamente")]
        public string ApellidoNombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
