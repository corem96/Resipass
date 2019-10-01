using System;

namespace Resipass.Domain.modelos.Tarjeta
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime Vigencia { get; set; }
        public bool Activa { get; set; }

        public int ResidenteId { get; set; }
        public Residente.Residente Residente { get; set; }
    }
}