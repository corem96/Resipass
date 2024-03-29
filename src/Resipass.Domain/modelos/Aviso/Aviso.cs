using System;
using Newtonsoft.Json;

namespace Resipass.Domain.modelos.Aviso
{
    public class Aviso
    {
        public int Id { get; set; }
        public string Comunicado { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario.Usuario Usuario { get; set; }
    }
}