using System.Collections.Generic;
using Newtonsoft.Json;

namespace Resipass.Domain.modelos.Domicilio
{
    public class Domicilio
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Numero { get; set; }

        [JsonIgnore]
        public ICollection<Residente.Residente> Residentes { get; set; }
        [JsonIgnore]
        public ICollection<Tarjeta.Tarjeta> Tarjetas { get; set; }
    }
}