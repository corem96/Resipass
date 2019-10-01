using System.Collections.Generic;

namespace Resipass.Domain.modelos.Domicilio
{
    public class Domicilio
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Numero { get; set; }

        public ICollection<Residente.Residente> Residentes { get; set; }
        public ICollection<Tarjeta.Tarjeta> Tarjetas { get; set; }
    }
}