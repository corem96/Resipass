using System;

namespace Resipass.Api.Api.ViewModels
{
    public class TarjetaVm
    {
        public int Id { get; set; }
        public int ResidenteId { get; set; }
        public string Codigo { get; set; }
        public string ResidenteNombreCompleto { get; set; }
        public DateTime Vigencia { get; set; }
        public bool Activa { get; set; }
    }
}