using System;

namespace Resipass.Domain.modelos.RegistroPago
{
    public class RegistroPago
    {
        public int ResidenteId { get; set; }
        public Residente.Residente Residente { get; set; }

        public int TarjetaId { get; set; }
        public Tarjeta.Tarjeta Tarjeta { get; set; }

        public DateTime FechaPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
    }
}