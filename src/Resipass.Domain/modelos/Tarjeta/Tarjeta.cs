using System;

namespace Resipass.Domain.modelos.Tarjeta
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime Vigencia { get; set; }
        public bool Activa { get; set; }
    }
}