using System.Collections.Generic;
using Newtonsoft.Json;

namespace Resipass.Domain.modelos.Residente
{
    public class Residente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

        public string NombreCompleto => string.Concat(Nombre + ' ', Apellido);

        public int DomicilioId { get; set; }
        [JsonIgnore]
        public Domicilio.Domicilio Domicilio { get; set; }

        [JsonIgnore]
        public ICollection<Tarjeta.Tarjeta> Tarjetas { get; set; }
        [JsonIgnore]
        public ICollection<RegistroPago.RegistroPago> RegistroPagos { get; set; }
    }
}