using System;
using Newtonsoft.Json;

namespace Resipass.Domain.modelos.RegistroPago
{
    public class RegistroPago
    {
        public int Id { get; set; }
        public int TarjetaId { get; set; }
        
        [JsonIgnore]
        public Tarjeta.Tarjeta Tarjeta { get; set; }

        public DateTime FechaPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public string NumeroFolio { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string Sucursal { get; set; }
        public string Cajero { get; set; }
    }
}