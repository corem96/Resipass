using AutoMapper;
using Resipass.Api.Api.ViewModels;
using Resipass.Domain.modelos.Tarjeta;

namespace Resipass.Api.Perfiles
{
    public class TarjetaProfile : Profile
    {
        public TarjetaProfile()
        {
            CreateMap<Tarjeta, TarjetaVm>();
        }
    }
}