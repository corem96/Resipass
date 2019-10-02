using System.Collections.Generic;
using Newtonsoft.Json;

namespace Resipass.Domain.modelos.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<Aviso.Aviso> Avisos { get; set; }
    }
}